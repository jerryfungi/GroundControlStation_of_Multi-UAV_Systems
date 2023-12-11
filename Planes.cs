using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace GCS_5895
{
    class Planes
    {
        /*飛機資料*/
        public DataTable dt = new DataTable();

        public static int TA = 30;
        public static int RA = 20;
        /* 不變常數宣告 */
        static readonly double d2r = 0.01745329251994329576923690768489; //預設是 Private

        public static GMapMarker AddDrone(double lat, double lng, double heading, FrameType frameType, string name, SolidBrush color)
        {
            Image srcPlane = null;
            Bitmap picPlane = null;
            switch (frameType)
            {
                case FrameType.Quad:
                    srcPlane = Image.FromFile("../../image/quad.png");
                    picPlane = GraphicRotateAtAny((Bitmap)srcPlane, srcPlane.Height / 2, srcPlane.Width / 2, heading);
                    break;
                case FrameType.Fixed_wing:
                    srcPlane = Image.FromFile("../../image/plane.tif");
                    picPlane = RotateImg((Bitmap)srcPlane, (float)-heading + 90);
                    break;
            }
            picPlane.MakeTransparent(Color.Yellow);
            GMapMarker drone = new GMarkerGoogle(new PointLatLng(lat, lng), picPlane);
            drone.Offset = new Point(-picPlane.Width / 2, -picPlane.Height / 2);

            drone.ToolTip = new GMapToolTip(drone);
            drone.ToolTip.Fill = color;
            drone.ToolTip.Foreground = new SolidBrush(Color.Black);
            drone.ToolTip.Font = new Font("Times New Roman", 7, FontStyle.Bold);
            drone.ToolTip.Offset = new Point(23, -20);
            drone.ToolTip.TextPadding = new Size(12, 6);

            drone.Tag = name;
            drone.ToolTipText = name;
            drone.ToolTipMode = MarkerTooltipMode.Always;

            return drone;
        }

        public static GMapMarker AddRunway(double lat, double lng, string name, double heading, SolidBrush color)
        {
            //跑道的圖層
            Image srcPic = Image.FromFile("../../image/runway.png");
            Bitmap runway = RotateImg((Bitmap)srcPic, (float)heading);
            runway.MakeTransparent(Color.Yellow);

            GMapMarker Runway = new GMarkerGoogle(new PointLatLng(lat, lng), runway);
            Runway.Offset = new Point(-runway.Width / 2, -runway.Height / 2);
            GMapToolTip tooltip = new GMapToolTip(Runway);

            tooltip.Fill = color;
            tooltip.Foreground = new SolidBrush(Color.Black);
            tooltip.Offset = new Point(23, -20);
            tooltip.TextPadding = new Size(6, 6);

            Runway.Tag = name;
            Runway.ToolTipText = name;
            Runway.ToolTip = tooltip;
            Runway.ToolTipMode = MarkerTooltipMode.Always;
            Runway.ToolTip.Font = new Font("Times New Roman", 7, FontStyle.Bold);

            return Runway;
        }

        public static GMapMarker AddHelipad(double lat, double lng, string name, double heading, SolidBrush color)
        {
            Image srcPic = Image.FromFile("../../image/helipad.tif");
            Bitmap helipad = RotateImg((Bitmap)srcPic, (float)-heading+90);
            helipad.MakeTransparent(Color.Yellow);

            GMapMarker Helipad = new GMarkerGoogle(new PointLatLng(lat, lng), helipad);
            Helipad.Offset = new Point(-helipad.Width / 2, -helipad.Height / 2);
            return Helipad;
        }

        public static GMapMarker AddWaypoint(double Lat, double Lng, int num, GMarkerGoogleType color)
        {
            GMapMarker wp = new GMarkerGoogle(new PointLatLng(Lat, Lng), color);
            wp.ToolTipText = num.ToString();
            wp.ToolTip.Fill = Brushes.Transparent;
            if (num < 10)
            {
                wp.ToolTip.Offset = new Point(-16, -12);
            }
            else
            {
                wp.ToolTip.Offset = new Point(-21, -12);
            }
            wp.ToolTip.Stroke.Color = Color.Transparent;
            wp.ToolTip.Foreground = Brushes.Black;
            wp.ToolTip.Font = new Font("Times New Roman", 8, FontStyle.Bold);
            wp.ToolTipMode = MarkerTooltipMode.Always;
            
            return wp;
        }

        private static Bitmap GraphicRotateAtAny(Bitmap SrcBmp, int m, int n, double angle)
        {
            double radians = d2r * angle;

            float cosine = (float)Math.Sin(radians);
            float sine = (float)Math.Cos(radians);

            Bitmap DestBmp = new Bitmap(SrcBmp.Width, SrcBmp.Height);
            Graphics tmpBox = Graphics.FromImage(DestBmp);
            for (int x = 0; x < DestBmp.Width; x++)
            {
                for (int y = 0; y < DestBmp.Height; y++)
                {
                    int SrcBitmapy = (int)Math.Ceiling((x - m) * cosine - (y - n) * sine + m);
                    int SrcBitmapx = (int)Math.Ceiling((y - n) * cosine + (x - m) * sine + n);

                    if (SrcBitmapx >= 0 && SrcBitmapx < SrcBmp.Width && SrcBitmapy >= 0 && SrcBitmapy < SrcBmp.Height)
                    {
                        DestBmp.SetPixel(y, x, SrcBmp.GetPixel(SrcBitmapx, SrcBitmapy));
                    }
                    else
                    {
                        DestBmp.SetPixel(x, y, Color.Yellow);
                    }
                }
            }
            // DestBmp.Save("DestBmp");
            return DestBmp;
        }

        private static Bitmap RotateImg(Bitmap bmpimage, float angle)
        {
            int w = bmpimage.Width;
            int h = bmpimage.Height;
            PixelFormat pf;
            pf = bmpimage.PixelFormat;
            Bitmap tempImg = new Bitmap(w, h, pf);
            Graphics g = Graphics.FromImage(tempImg);
            g.DrawImageUnscaled(bmpimage, 1, 1);
            g.Dispose();
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new RectangleF(0.0F, 0.0F, w, h));
            Matrix mtrx = new Matrix();

            mtrx.Rotate(angle);
            RectangleF rct = path.GetBounds(mtrx);
            Bitmap newImg = new Bitmap(Convert.ToInt32(rct.Width), Convert.ToInt32(rct.Height), pf);
            g = Graphics.FromImage(newImg);
            g.TranslateTransform(-rct.X, -rct.Y);
            g.RotateTransform(angle);
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawImageUnscaled(tempImg, 0, 0);
            g.Dispose();
            tempImg.Dispose();
            return newImg;
        }


        public static Bitmap Resize(Bitmap originImage, Double times)
        {
            int width = Convert.ToInt32(originImage.Width * times);
            int height = Convert.ToInt32(originImage.Height * times);

            return Process(originImage, originImage.Width, originImage.Height, width, height);
        }

        private static Bitmap Process(Bitmap originImage, int oriwidth, int oriheight, int width, int height)
        {
            Bitmap resizedbitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(resizedbitmap);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.Clear(Color.Transparent);
            g.DrawImage(originImage, new Rectangle(0, 0, width, height), new Rectangle(0, 0, oriwidth, oriheight), GraphicsUnit.Pixel);
            return resizedbitmap;
        }

        public static void NewWaypoint(bool isReached, double lat, double lng, GMapOverlay markerOverlay, GMapOverlay planeOverlay, List<PointLatLng> points, DataTable dt)
        {
            if (isReached == true)
            {
                PointLatLng latlng = new PointLatLng(lat, lng);
                GMapMarker waypoint = new GMarkerGoogle(latlng, GMarkerGoogleType.blue);
                waypoint.ToolTipText = Convert.ToString(planeOverlay.Id + "\n" + (markerOverlay.Markers.Count + 1));
                waypoint.ToolTip.Fill = Brushes.Transparent;
                waypoint.ToolTip.Offset = new Point(-30, -15);
                waypoint.ToolTip.Stroke.Color = Color.Transparent;
                waypoint.ToolTip.Foreground = Brushes.Black;
                waypoint.ToolTip.Font = new Font("Arial", 10);
                waypoint.ToolTipMode = MarkerTooltipMode.Always;
                waypoint.IsVisible = waypoint.IsMouseOver;

                markerOverlay.Markers.Add(waypoint);
                points.Add(latlng);

                dt.Rows.Add(new Object[] { markerOverlay.Markers.Count, (int)(latlng.Lat * 10000000), (int)(latlng.Lng * 10000000), 30, 0 });
            }
        }
    }
}