using System;
using System.Windows.Media.Media3D;
using System.Numerics;
using System.Windows.Media;
using GMap.NET;

namespace GCS_5895
{
    public class CoordinateTransform
    {
        //不變常數
        private const double a = 6378137.0000;
        private const double b = 6356752.3142;
        private double e = Math.Sqrt(1.0 - Math.Pow((b / a), 2));
        private static double f = 1 / 298.2572236;
        private static double e_sq = f * (2 - f);
        public  double[] orgxyz = new double[3];
        public  double[] orgllh = new double[3];
        public double phi, lam, s , N;
        public PointLatLng mapCenter { get; private set; }

        public CoordinateTransform(double lat, double lng, double alt, PointLatLng mapCenter)
        {
            // 初始化原點
            var origin = llh2xyz(lat, lng, alt);
            orgllh[0] = lng;
            orgllh[1] = lat;
            orgllh[2] = alt;
            orgxyz[0] = origin.X;
            orgxyz[1] = origin.Y;
            orgxyz[2] = origin.Z;
            phi = lng * Math.PI / 180;
            lam = lat * Math.PI / 180;
            s = Math.Sin(lam);
            N = a / Math.Sqrt(1 - e_sq * s * s);
            this.mapCenter = mapCenter;
        }

        //llh座標轉ecef座標
        public Point3D llh2xyz(double lat, double lon, double h)
        {
            double phi = lon * Math.PI / 180;//lng
            double lam = lat * Math.PI / 180;//lat
            var s = Math.Sin(lam);
            var N = a / Math.Sqrt(1 - e_sq * s * s);
            double sinphi = Math.Sin(phi);
            double cosphi = Math.Cos(phi);
            double sinlam = Math.Sin(lam);
            double coslam = Math.Cos(lam);

            var x = (h + N) * coslam * cosphi;
            var y = (h + N) * coslam * sinphi;
            var z = (h + (1 - e_sq) * N) * sinlam;

            Point3D xyz = new Point3D();

            xyz.X = x;
            xyz.Y = y;
            xyz.Z = z;

            return xyz;
        }

        public double[] llh2enu(double lat, double lng, double h)
        {
            lng = lng * Math.PI / 180;//lng
            lat = lat * Math.PI / 180;//lat

            var x = (h + N) * Math.Cos(lat) * Math.Cos(lng);
            var y = (h + N) * Math.Cos(lat) * Math.Sin(lng);
            var z = (h + (1 - e_sq) * N) * Math.Sin(lat);

            double sinphi = Math.Sin(phi);
            double cosphi = Math.Cos(phi);
            double sinlam = Math.Sin(lam);
            double coslam = Math.Cos(lam);

            //目標點到原點距離
            double[] difxyz = new double[3];
            difxyz[0] = x - orgxyz[0];
            difxyz[1] = y - orgxyz[1];
            difxyz[2] = z - orgxyz[2];

            double[,] R = new double[3, 3] { { -sinphi         , cosphi          , 0      },
                                             { sinlam * -cosphi, -sinphi * sinlam, coslam },
                                             { coslam * cosphi , coslam * sinphi , sinlam } };

            double[] enu = new double[3];
            enu[0] = R[0, 0] * difxyz[0] + R[0, 1] * difxyz[1] + R[0, 2] * difxyz[2];
            enu[1] = R[1, 0] * difxyz[0] + R[1, 1] * difxyz[1] + R[1, 2] * difxyz[2];
            enu[2] = R[2, 0] * difxyz[0] + R[2, 1] * difxyz[1] + R[2, 2] * difxyz[2];
            return (enu);
        }
        public double[] enu2llh(double e, double n, double u)
        {
            double sinphi = Math.Sin(phi);
            double cosphi = Math.Cos(phi);
            double sinlam = Math.Sin(lam);
            double coslam = Math.Cos(lam);

            var t = coslam * u - sinlam * n;
            var zd = sinlam * u + coslam * n;
            var xd = cosphi * t - sinphi * e;
            var yd = sinphi * t + cosphi * e;
            
            var x = orgxyz[0] + xd;
            var y = orgxyz[1] + yd;
            var z = orgxyz[2] + zd;
            
            double x2 = x * x;
            double y2 = y * y;
            double z2 = z * z;
            double b2 = b * b;
            double e2 = this.e * this.e;
            double ep = this.e * (a / b);
            double r = Math.Sqrt(x2 + y2);
            double r2 = r * r;
            double E2 = a * a - b * b;
            double F = 54 * b2 * z * z;
            double G = r2 + (1 - e2) * z2 - e2 * E2;
            double c = (e2 * e2 * F * r2) / (G * G * G);
            double s = Math.Pow((1 + c + Math.Sqrt(c * c + 2 * c)), (1 / 3));
            double P = F / (3 * Math.Pow((s + 1 / s + 1), 2) * G * G);
            double Q = Math.Sqrt(1 + 2 * e2 * e2 * P);
            double ro = -(P * e2 * r) / (1 + Q) + Math.Sqrt((a * a / 2) * (1 + 1 / Q) - (P * (1 - e2) * z2) / (Q * (1 + Q)) - P * r2 / 2);

            double tmp = Math.Pow((r - e2 * ro), 2);
            double U = Math.Sqrt(tmp + z2);
            double V = Math.Sqrt(tmp + (1 - e2) * z2);
            double zo = (b2 * z) / (a * V);

            double height = U * (1 - b2 / (a * V));
            double lat = Math.Atan((z + ep * ep * zo) / r) / Math.PI * 180;

            double temp = Math.Atan(y / x);

            double lon;
            if (x >= 0)
                lon = temp / Math.PI * 180;
            else if (x < 0 && y >= 0)
                lon = (Math.PI + temp) / Math.PI * 180;
            else
                lon = (temp - Math.PI) / Math.PI * 180;

            double[] llh = new double[3];
            llh[0] = lat;
            llh[1] = lon;
            llh[2] = height;

            return (llh);
        }

        //ecef座標轉enu座標
        public double[] xyz2enu(double x, double y, double z)
        {
            var s = Math.Sin(lam);
            var N = a / Math.Sqrt(1 - e_sq * s * s);
            double sinphi = Math.Sin(phi);
            double cosphi = Math.Cos(phi);
            double sinlam = Math.Sin(lam);
            double coslam = Math.Cos(lam);

            //var x0 = (30 + N) * coslam * cosphi;
            //var y0 = (30 + N) * coslam * sinphi;
            //var z0 = (30 + (1 - e_sq) * N) * sinlam;
            //目標點到原點距離
            double[] difxyz = new double[3];
            difxyz[0] = x - orgxyz[0]; //ecef互減
            difxyz[1] = y - orgxyz[1];
            difxyz[2] = z - orgxyz[2];

            double[,] R = new double[3, 3] { { -sinphi         , cosphi          , 0 },
                                             { sinlam * -cosphi, -sinphi * sinlam, coslam },
                                             { coslam * cosphi, coslam * sinphi , sinlam } };
            double[] enu = new double[3];

            enu[0] = R[0, 0] * difxyz[0] + R[0, 1] * difxyz[1] + R[0, 2] * difxyz[2];//X E
            enu[1] = R[1, 0] * difxyz[0] + R[1, 1] * difxyz[1] + R[1, 2] * difxyz[2];//Y N
            enu[2] = R[2, 0] * difxyz[0] + R[2, 1] * difxyz[1] + R[2, 2] * difxyz[2];//Z U

            return (enu);
        }
        //enu座標轉ecef座標
        public double[] enu2xyz(double xEast, double yNorth, double zUp)
        {
            double s = Math.Sin(lam);
            double N = a / Math.Sqrt(1 - e_sq * s * s);

            double sinphi = Math.Sin(phi);
            double cosphi = Math.Cos(phi);
            double sinlam = Math.Sin(lam);
            double coslam = Math.Cos(lam);


            //var x0 = (30 + N) * coslam * cosphi;
            //var y0 = (30 + N) * coslam * sinphi;
            //var z0 = (30 + (1 - e_sq) * N) * sinlam;

            var t = coslam * zUp - sinlam * yNorth;
            var zd = sinlam * zUp + coslam * yNorth;
            var xd = cosphi * t - sinphi * xEast;
            var yd = sinphi * t + cosphi * xEast;
            double[] enutoxyz = new double[3];
            enutoxyz[0] = orgxyz[0] + xd;
            enutoxyz[1] = orgxyz[1] + yd;
            enutoxyz[2] = orgxyz[2] + zd;
            return (enutoxyz);
        }

        //ecef座標轉ned座標
        public double[] xyz2ned(double x, double y, double z)
        {
            double sinphi = Math.Sin(lam);
            double cosphi = Math.Cos(lam);
            double sinlam = Math.Sin(phi);
            double coslam = Math.Cos(phi);

            double[,] invR = new double[3, 3] { { -sinphi * coslam, -sinphi * sinlam, cosphi * cosphi },
                                                { -sinlam         , coslam          , 0               },
                                                { -cosphi * coslam, -cosphi * sinlam, -sinphi         } };
            double[] difxyz = new double[3];
            difxyz[0] = x - orgxyz[0];
            difxyz[1] = y - orgxyz[1];
            difxyz[2] = z - orgxyz[2];

            double[] ned = new double[3];

            ned[0] = invR[0, 0] * difxyz[0] + invR[0, 1] * difxyz[1] + invR[0, 2] * difxyz[2];
            ned[1] = invR[1, 0] * difxyz[0] + invR[1, 1] * difxyz[1] + invR[1, 2] * difxyz[2];
            ned[2] = invR[2, 0] * difxyz[0] + invR[2, 1] * difxyz[1] + invR[2, 2] * difxyz[2];

            return (ned);
        }

        //ned座標轉ecef座標
        public double[] ned2xyz(double n, double e, double d)
        {
            double sinphi = Math.Sin(lam);
            double cosphi = Math.Cos(lam);
            double sinlam = Math.Sin(phi);
            double coslam = Math.Cos(phi);

            double[,] invR = new double[3, 3] { { -sinphi * coslam, -sinlam, -cosphi * coslam },
                                                { -sinphi * sinlam,  coslam, -cosphi * sinlam },
                                                { cosphi          ,       0, -sinphi          } };

            double[] xyz = new double[3];

            xyz[0] = invR[0, 0] * n + invR[0, 1] * e + invR[0, 2] * d + orgxyz[0];
            xyz[1] = invR[1, 0] * n + invR[1, 1] * e + invR[1, 2] * d + orgxyz[1];
            xyz[2] = invR[2, 0] * n + invR[2, 1] * e + invR[2, 2] * d + orgxyz[2];

            return (xyz);
        }

        //ecef座標轉llh座標
        public double[] xyz2llh(double x, double y, double z)
        {
            double x2 = x * x;
            double y2 = y * y;
            double z2 = z * z;
            double b2 = b * b;
            double e2 = e * e;
            double ep = e * (a / b);
            double r = Math.Sqrt(x2 + y2);
            double r2 = r * r;
            double E2 = a * a - b * b;
            double F = 54 * b2 * z * z;
            double G = r2 + (1 - e2) * z2 - e2 * E2;
            double c = (e2 * e2 * F * r2) / (G * G * G);
            double s = Math.Pow((1 + c + Math.Sqrt(c * c + 2 * c)), (1 / 3));
            double P = F / (3 * Math.Pow((s + 1 / s + 1), 2) * G * G);
            double Q = Math.Sqrt(1 + 2 * e2 * e2 * P);
            double ro = -(P * e2 * r) / (1 + Q) + Math.Sqrt((a * a / 2) * (1 + 1 / Q) - (P * (1 - e2) * z2) / (Q * (1 + Q)) - P * r2 / 2);

            double tmp = Math.Pow((r - e2 * ro), 2);
            double U = Math.Sqrt(tmp + z2);
            double V = Math.Sqrt(tmp + (1 - e2) * z2);
            double zo = (b2 * z) / (a * V);

            double height = U * (1 - b2 / (a * V));
            double lat = Math.Atan((z + ep * ep * zo) / r) / Math.PI * 180;

            double temp = Math.Atan(y / x);

            double lon;
            if (x >= 0)
                lon = temp / Math.PI * 180;
            else if (x < 0 && y >= 0)
                lon = (Math.PI + temp) / Math.PI * 180;
            else
                lon = (temp - Math.PI) / Math.PI * 180;

            double[] llh = new double[3];
            llh[0] = lat;
            llh[1] = lon;
            llh[2] = height;

            return (llh);
        }

        //計算碰撞點
        public double[] CalculateIntersection(double x1, double y1, double m1, double x2, double y2, double m2)
        {
            double[] inter = new double[2];
            inter[0] = ((y2 - y1 + m1 * x1 - m2 * x2) / (m1 - m2));
            inter[1] = ((m1 * m2 * (x2 - x1) + m2 * y1 - m1 * y2) / (m2 - m1));
            return (inter);
        }
        private static double deg(double x)
        {
            return x * 180 / Math.PI;
        }
        private static double rad(double d)
        {
            return d * Math.PI / 180.0;
        }
        public static double[] computerThatLonLat(double lon, double lat, double brng, double dist) //已知一個經緯度及距離和角度求另一點,dist(m)
        {

            double alpha1 = rad(-brng);
            double sinAlpha1 = Math.Sin(alpha1);
            double cosAlpha1 = Math.Cos(alpha1);

            double tanU1 = (1 - f) * Math.Tan(rad(lat));
            double cosU1 = 1 / Math.Sqrt((1 + tanU1 * tanU1));
            double sinU1 = tanU1 * cosU1;
            double sigma1 = Math.Atan2(tanU1, cosAlpha1);
            double sinAlpha = cosU1 * sinAlpha1;
            double cosSqAlpha = 1 - sinAlpha * sinAlpha;
            double uSq = cosSqAlpha * (a * a - b * b) / (b * b);
            double A = 1 + uSq / 16384 * (4096 + uSq * (-768 + uSq * (320 - 175 * uSq)));
            double B = uSq / 1024 * (256 + uSq * (-128 + uSq * (74 - 47 * uSq)));

            double cos2SigmaM = 0;
            double sinSigma = 0;
            double cosSigma = 0;
            double sigma = dist / (b * A), sigmaP = 2 * Math.PI;
            while (Math.Abs(sigma - sigmaP) > 1e-12)
            {
                cos2SigmaM = Math.Cos(2 * sigma1 + sigma);
                sinSigma = Math.Sin(sigma);
                cosSigma = Math.Cos(sigma);
                double deltaSigma = B * sinSigma * (cos2SigmaM + B / 4 * (cosSigma * (-1 + 2 * cos2SigmaM * cos2SigmaM)
                        - B / 6 * cos2SigmaM * (-3 + 4 * sinSigma * sinSigma) * (-3 + 4 * cos2SigmaM * cos2SigmaM)));
                sigmaP = sigma;
                sigma = dist / (b * A) + deltaSigma;
            }

            double tmp = sinU1 * sinSigma - cosU1 * cosSigma * cosAlpha1;
            double lat2 = Math.Atan2(sinU1 * cosSigma + cosU1 * sinSigma * cosAlpha1,
                    (1 - f) * Math.Sqrt(sinAlpha * sinAlpha + tmp * tmp));
            double lambda = Math.Atan2(sinSigma * sinAlpha1, cosU1 * cosSigma - sinU1 * sinSigma * cosAlpha1);
            double C = f / 16 * cosSqAlpha * (4 + f * (4 - 3 * cosSqAlpha));
            double L = lambda - (1 - C) * f * sinAlpha
                    * (sigma + C * sinSigma * (cos2SigmaM + C * cosSigma * (-1 + 2 * cos2SigmaM * cos2SigmaM)));

            double revAz = Math.Atan2(sinAlpha, -tmp); // final bearing
            double[] endPoint = new double[2];
            endPoint[0] = lon + deg(L);
            endPoint[1] = deg(lat2);
            return endPoint;

            //  System.out.println(revAz);
            //  System.out.println(lon + deg(L) + "," + deg(lat2));
        }
        public static double angleFromCoordinate(double lat1, double long1, double lat2, double long2)
        {

            double dLon = (long2 - long1);

            double y = Math.Sin(dLon) * Math.Cos(lat2);
            double x = Math.Cos(lat1) * Math.Sin(lat2) - Math.Sin(lat1)
                    * Math.Cos(lat2) * Math.Cos(dLon);

            double brng = Math.Atan2(y, x);

            brng = deg(brng);
            brng = (brng + 360) % 360;
            brng = 360 - brng; // count degrees counter-clockwise - remove to make clockwise

            return brng;
        }
        //计算点到线段的距离
        /*
        public double pointToLine(Vector2 point, LineBase line)
        {
            //距离
            double distance = 0;
            //线段的起点与终点
            Vector2 start = new Vector2(line.startpoint.x, line.startpoint.z);
            Vector2 end = new Vector2(line.endpoint.x, line.endpoint.z);
            //点到起点的距离
            double startlength = Vector2.Distance(point, start);
            //点到终点的距离
            double endlength = Vector2.Distance(point, enf);
            //线段的长度
            double length = Vector2.Distance(start, end);
            //点到线端两端的距离很小
            if (startlength <= 0.00001 || endlength < 0.00001)
            {
                distance = 0;
                return distance;
            }
            //如果线段很短
            if (length < 0.00001)
            {
                distance = startlength;
                return distance;
            }
            //如果在线段延长线的两边
            if (startlength * startlength >= length * length + endlength * endlength)
            {
                distance = endlength;
                return distance;
            }
            if (length * length + startlength * startlength <= endlength * endlength)
            {
                distance = startlength;
                return distance;
            }
            //最后利用三角形的面积求高（点到垂足的距离）
            double p = (length + startlength + endlength) / 2;
            //求三角形面积
            double area = Math.Sqrt(p * (p - endlength) * (p - startlength) * (p - length));

            distance = 2 * area / length;
            return distance;
        }
        */
        public static float DistanceForPointToABLine(float x, float y, float x1, float y1, float x2, float y2)//所在点到AB线段的垂线长度
        {
            float reVal = 0f;
            bool retData = false;

            float cross = (x2 - x1) * (x - x1) + (y2 - y1) * (y - y1);
            if (cross <= 0)
            {
                reVal = (float)Math.Sqrt((x - x1) * (x - x1) + (y - y1) * (y - y1));
                retData = true;
            }

            float d2 = (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);
            if (cross >= d2)
            {
                reVal = (float)Math.Sqrt((x - x2) * (x - x2) + (y - y2) * (y - y2));
                retData = true;
            }

            if (!retData)
            {
                float r = cross / d2;
                float px = x1 + (x2 - x1) * r;
                float py = y1 + (y2 - y1) * r;
                reVal = (float)Math.Sqrt((x - px) * (x - px) + (py - y) * (py - y));
            }

            return reVal;
        }
    }
}
