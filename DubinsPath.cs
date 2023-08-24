using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GCS_5895
{
	/// <summary>
	/// reference:
	///		https://github.com/ilariamarte/dubins-curve/blob/main/Dubins_Curve.cs
	/// </summary>
	class DubinsPath
    {
		const double pi = Math.PI;

		public double curveRadius = 4;

		public float lineWidth = 0.2f;
		public int numberOfPoints = 20;

		// Alias to check for curveRadius changes
		double rad = 4;

		public List<Vector3> Dubins_shortestPath(double[] startPos, double[] endPos, double rad)
		{
			if (startPos[2] == endPos[2])
            {
				endPos[2] += 1e-5;
            }
			// Initial conditions
			double xPosI, yPosI, thetaI;
			// Desired target
			double xPosD, yPosD, thetaD;

			// For drawing the scene
			Vector3 position, center1, center2, center3, endArc1, endArc3;
			double arc1, arc2, arc3, angleStart1, angleStart2, angleStart3;
			bool straightSegment;

			double[] px, py, pyaw, len, cost;
			double xCenterI1, yCenterI1, xCenterI2, yCenterI2, xCenterD1, yCenterD1, xCenterD2, yCenterD2;
			double offset, angleEnd1, angleEnd3, dstD1, dstD2;
			float xCenter1, yCenter1, xCenter2, yCenter2, xCenter3, yCenter3;
			float xEndArc1, yEndArc1, xEndArc3, yEndArc3;


			char[] mode = { 'N', 'N', 'N' }; // Default N = None
			double curvature = 1 / rad;
			(xPosI, yPosI, thetaI) = (startPos[0], startPos[1], startPos[2] * Math.PI / 180);
			(xPosD, yPosD, thetaD) = (endPos[0], endPos[1], endPos[2] * Math.PI / 180);
			(xCenterI1, yCenterI1) = (xPosI + rad * Math.Cos(thetaI + pi / 2), yPosI + rad * Math.Sin(thetaI + pi / 2));
			(xCenterI2, yCenterI2) = (xPosI + rad * Math.Cos(thetaI - pi / 2), yPosI + rad * Math.Sin(thetaI - pi / 2));
			(xCenterD1, yCenterD1) = (xPosD + rad * Math.Cos(thetaD + pi / 2), yPosD + rad * Math.Sin(thetaD + pi / 2));
			(xCenterD2, yCenterD2) = (xPosD + rad * Math.Cos(thetaD - pi / 2), yPosD + rad * Math.Sin(thetaD - pi / 2));

			double[] startCoord = new double[] { xPosI, yPosI, thetaI };
			double[] endCoord = new double[] { xPosD, yPosD, thetaD };
			(px, py, pyaw, len, cost, mode) = DubinsPathPlanning(startCoord, endCoord, curvature);

			straightSegment = (mode[1] == 'S') ? true : false;
			arc1 = len[0];
			arc3 = -len[2]; // Goes backwards from end point (-)
			offset = (mode[0] == 'L') ? pi / 2 : -pi / 2;
			angleStart1 = thetaI - offset;
			xCenter1 = (float)(xPosI + rad * Math.Cos(thetaI + offset));
			yCenter1 = (float)(yPosI + rad * Math.Sin(thetaI + offset));
			center1 = new Vector3(xCenter1, yCenter1, 0);

			dstD1 = GetDistancePoints(px[2], py[2], xCenterD1, yCenterD1) + GetDistancePoints(px[3], py[3], xCenterD1, yCenterD1);
			dstD2 = GetDistancePoints(px[2], py[2], xCenterD2, yCenterD2) + GetDistancePoints(px[3], py[3], xCenterD2, yCenterD2);
			offset = (dstD1 > dstD2) ? -pi / 2 : pi / 2;
			angleStart3 = thetaD - offset;
			xCenter3 = (float)(xPosD + rad * Math.Cos(thetaD + offset));
			yCenter3 = (float)(yPosD + rad * Math.Sin(thetaD + offset));
			center3 = new Vector3(xCenter3, yCenter3, 0);

			angleEnd1 = angleStart1 + arc1;
			angleEnd3 = angleStart3 + arc3;
			(xEndArc1, yEndArc1) = GetEndArc(angleEnd1, xCenter1, yCenter1, rad);
			(xEndArc3, yEndArc3) = GetEndArc(angleEnd3, xCenter3, yCenter3, rad);
			endArc1 = new Vector3(xEndArc1, yEndArc1, 0);
			endArc3 = new Vector3(xEndArc3, yEndArc3, 0);

			arc2 = len[1];
			xCenter2 = xCenter1 + (float)(2 * rad * Math.Cos(angleEnd1));
			yCenter2 = yCenter1 + (float)(2 * rad * Math.Sin(angleEnd1));
			angleStart2 = GetAngleFromPoint(xEndArc1, yEndArc1, xCenter2, yCenter2);
			center2 = new Vector3(xCenter2, yCenter2, 0);

			Vector3[] center = new Vector3[] { center1, center2, center3 };
			double[] arc = new double[] { arc1, arc2, -arc3 };
			double[] angleStart = new double[] { angleStart1, angleStart2, angleStart3 + arc3 };
			int[] jStart = new int[] { 0, numberOfPoints, numberOfPoints * 2 };
			var dubins_path = new List<Vector3>();

			for (int i = 0; i < 3; i++)
			{
				for (int j = jStart[i]; j < numberOfPoints * (i + 1); j++)
				{
					if (i == 1 && straightSegment)
					{
						// Straight segment
						position = endArc1 + (endArc3 - endArc1) * (j - jStart[i]) / (numberOfPoints - 1);
					}
					else
					{
						// Curve segments
						double angle = angleStart[i] + arc[i] * (j - jStart[i]) / (numberOfPoints - 1);
						float xDir = (float)(rad * Math.Cos(angle));
						float yDir = (float)(rad * Math.Sin(angle));
						Vector3 dir = new Vector3(xDir, yDir, 0);
						position = center[i] + dir;
					}
					dubins_path.Add(position);
				}
			}
			return dubins_path;
		}
		//----------------------------------------------------------------------//
		//----------------------------------------------------------------------//
		//                  Methods for Dubins Curve computing                  //
		//----------------------------------------------------------------------//
		//----------------------------------------------------------------------//

		// alpha: The opposite of the angle of the end position
		// beta: The difference between desired end yaw and the angle of the end position
		// d: The straight-line-distance/turning-radius
		double[] LSL(double alpha, double beta, double d)
		{
			double sa, sb, ca, cb, c_ab, tmp0, tmp1, p_squared, t, p, q;
			char[] mode = { 'L', 'S', 'L' };
			double[] tpqReturn;
			(sa, sb) = (Math.Sin(alpha), Math.Sin(beta));
			(ca, cb) = (Math.Cos(alpha), Math.Cos(beta));
			c_ab = Math.Cos(alpha - beta);
			tmp0 = d + sa - sb;
			p_squared = 2 + (d * d) - (2 * c_ab) + (2 * d * (sa - sb));
			if (p_squared < 0)
				return tpqReturn = new double[] { -1, -1, -1 };
			tmp1 = Math.Atan2((cb - ca), tmp0);
			t = Mod2Pi(-alpha + tmp1);
			p = Math.Sqrt(p_squared);
			q = Mod2Pi(beta - tmp1);
			tpqReturn = new double[] { t, p, q };
			return tpqReturn;
		}

		double[] RSR(double alpha, double beta, double d)
		{
			double sa, sb, ca, cb, c_ab, tmp0, tmp1, p_squared, t, p, q;
			char[] mode = { 'R', 'S', 'R' };
			double[] tpqReturn;
			(sa, sb) = (Math.Sin(alpha), Math.Sin(beta));
			(ca, cb) = (Math.Cos(alpha), Math.Cos(beta));
			c_ab = Math.Cos(alpha - beta);
			tmp0 = d - sa + sb;
			p_squared = 2 + (d * d) - (2 * c_ab) + (2 * d * (sb - sa));
			if (p_squared < 0)
				return tpqReturn = new double[] { -1, -1, -1 };
			tmp1 = Math.Atan2((ca - cb), tmp0);
			t = Mod2Pi(alpha - tmp1);
			p = Math.Sqrt(p_squared);
			q = Mod2Pi(-beta + tmp1);
			tpqReturn = new double[] { t, p, q };
			return tpqReturn;
		}

		double[] LSR(double alpha, double beta, double d)
		{
			double sa, sb, ca, cb, c_ab, tmp2, p_squared, t, p, q;
			char[] mode = { 'L', 'S', 'R' };
			double[] tpqReturn;
			(sa, sb) = (Math.Sin(alpha), Math.Sin(beta));
			(ca, cb) = (Math.Cos(alpha), Math.Cos(beta));
			c_ab = Math.Cos(alpha - beta);
			p_squared = -2 + (d * d) + (2 * c_ab) + (2 * d * (sa + sb));
			if (p_squared < 0)
				return tpqReturn = new double[] { -1, -1, -1 };
			p = Math.Sqrt(p_squared);
			tmp2 = Math.Atan2((-ca - cb), (d + sa + sb)) - Math.Atan2(-2.0, p);
			t = Mod2Pi(-alpha + tmp2);
			q = Mod2Pi(-Mod2Pi(beta) + tmp2);
			tpqReturn = new double[] { t, p, q };
			return tpqReturn;
		}

		double[] RSL(double alpha, double beta, double d)
		{
			double sa, sb, ca, cb, c_ab, tmp2, p_squared, t, p, q;
			char[] mode = { 'R', 'S', 'L' };
			double[] tpqReturn;
			(sa, sb) = (Math.Sin(alpha), Math.Sin(beta));
			(ca, cb) = (Math.Cos(alpha), Math.Cos(beta));
			c_ab = Math.Cos(alpha - beta);
			p_squared = (d * d) - 2 + (2 * c_ab) - (2 * d * (sa + sb));
			if (p_squared < 0)
				return tpqReturn = new double[] { -1, -1, -1 };
			p = Math.Sqrt(p_squared);
			tmp2 = Math.Atan2((ca + cb), (d - sa - sb)) - Math.Atan2(2.0, p);
			t = Mod2Pi(alpha - tmp2);
			q = Mod2Pi(beta - tmp2);
			tpqReturn = new double[] { t, p, q };
			return tpqReturn;
		}

		double[] RLR(double alpha, double beta, double d)
		{
			double sa, sb, ca, cb, c_ab, tmp_rlr, t, p, q;
			char[] mode = { 'R', 'L', 'R' };
			double[] tpqReturn;
			(sa, sb) = (Math.Sin(alpha), Math.Sin(beta));
			(ca, cb) = (Math.Cos(alpha), Math.Cos(beta));
			c_ab = Math.Cos(alpha - beta);
			tmp_rlr = (6.0 - d * d + 2.0 * c_ab + 2.0 * d * (sa - sb)) / 8.0;
			if (Math.Abs(tmp_rlr) > 1)
				return tpqReturn = new double[] { -1, -1, -1 };
			p = Mod2Pi(2 * pi - Math.Acos(tmp_rlr));
			t = Mod2Pi(alpha - Math.Atan2(ca - cb, d - sa + sb) + Mod2Pi(p / 2.0));
			q = Mod2Pi(alpha - beta - t + Mod2Pi(p));
			tpqReturn = new double[] { t, p, q };
			return tpqReturn;
		}

		double[] LRL(double alpha, double beta, double d)
		{
			double sa, sb, ca, cb, c_ab, tmp_lrl, t, p, q;
			char[] mode = { 'L', 'R', 'L' };
			double[] tpqReturn;
			(sa, sb) = (Math.Sin(alpha), Math.Sin(beta));
			(ca, cb) = (Math.Cos(alpha), Math.Cos(beta));
			c_ab = Math.Cos(alpha - beta);
			tmp_lrl = (6.0 - d * d + 2.0 * c_ab + 2.0 * d * (-sa + sb)) / 8.0;
			if (Math.Abs(tmp_lrl) > 1)
				return tpqReturn = new double[] { -1, -1, -1 };
			p = Mod2Pi(2 * pi - Math.Acos(tmp_lrl));
			t = Mod2Pi(-alpha - Math.Atan2(ca - cb, d + sa - sb) + p / 2.0);
			q = Mod2Pi(Mod2Pi(beta) - alpha - t + Mod2Pi(p));
			tpqReturn = new double[] { t, p, q };
			return tpqReturn;
		}

		(double, double, double, double, bool) CheckPath(double[] args, Func<double, double, double, double[]> FamilyOfCanonicalPaths)
		{
			double best_t, best_p, best_q, best_cost, alpha, beta, d;
			double t, p, q;
			double[] tpq;
			bool isBestModeSoFar = false;
			(best_t, best_p, best_q, best_cost, alpha, beta, d) = (args[0], args[1], args[2], args[3], args[4], args[5], args[6]);
			tpq = FamilyOfCanonicalPaths(alpha, beta, d);
			(t, p, q) = (tpq[0], tpq[1], tpq[2]);
			if (t != -1 || p != -1 || q != -1)
			{
				double cost = (Math.Abs(t) + Math.Abs(p) + Math.Abs(q));
				if (cost < best_cost)
				{
					(best_t, best_p, best_q) = (t, p, q);
					best_cost = cost;
					isBestModeSoFar = true;
				}
			}
			return (best_t, best_p, best_q, best_cost, isBestModeSoFar);
		}

		(double[], double[], double[], double[], double[]) GenerateCourse(double[] length, char[] mode, double c)
		{
			double[] px = new double[4];
			double[] py = new double[4];
			double[] pyaw = new double[4];
			double[] pyawChord = new double[4];
			double[] plen = new double[3]; // Length of straight path OR angle of curve
			double[] pcost = new double[3];

			// Starts from origin reference frame
			px[0] = 0.0;
			py[0] = 0.0;
			pyaw[0] = 0.0;
			for (int i = 0; i < 3; i++)
			{ // An Optimal Path has at most 3 segments
				double l = Math.Abs(length[i]);
				char m = mode[i];
				if (m == 'S')
				{       // Straight course
						// Length for straight paths is real_len*c
						// ==> real_len = l/c
					plen[1] = l / c;
					pcost[1] = plen[1]; // Real length
										// Next position
					px[2] = px[1] + pcost[1] * Math.Cos(pyawChord[1]); // (if there is a straight segment,
					py[2] = py[1] + pcost[1] * Math.Sin(pyawChord[1]); //  is always the second one)
																	   // Orientation stays the same
					pyaw[2] = pyaw[1];
					pyawChord[2] = pyawChord[1];
				}
				else
				{           // Curving course
							// Length for curves is always the angle in curveRadius
							// ==> arc_len = angle_in_rad*radius ==> real_len = l/c
					double angleRad, chordLength, yawRot, yawChord, yawLast, yawNext;
					angleRad = l;
					yawRot = angleRad / 2;
					pcost[i] = angleRad / c; // Real length (arc)
					chordLength = 2 * rad * Math.Sin(angleRad / 2);
					yawLast = pyaw[i];
					if (m == 'L')
					{       // Left turn
						yawChord = yawLast + yawRot;
						yawNext = angleRad;
					}
					else
					{           // Right turn
						yawChord = yawLast - yawRot;
						yawNext = -angleRad;
					}
					plen[i] = yawNext; // Signed angle
									   // Next position
					px[i + 1] = px[i] + chordLength * Math.Cos(yawChord);
					py[i + 1] = py[i] + chordLength * Math.Sin(yawChord);
					// Adjust orientation -> end of arc of circumference
					pyawChord[i] = yawChord;
					pyaw[i + 1] = pyaw[i] + yawNext;
					pyawChord[i + 1] = pyaw[i + 1];
				}
			}
			return (px, py, pyaw, plen, pcost);
		}

		// Don't call this directly, use dubins_path_planning
		// ex: The end x position
		// ey: The end y position
		// eyaw: The end yaw
		// c: curvature
		(double[], double[], double[], double[], double[], char[]) DubinsPathPlanningFromOrigin(double ex, double ey, double eyaw, double c)
		{
			double dx, dy, D, d, thetaI, alpha, beta, best_t, best_p, best_q, best_cost;
			double[] checkPathArgs, genCourseLength, px, py, pyaw, plen, pcost;
			char[] best_mode;
			bool modeFlag;
			(dx, dy) = (ex, ey);
			D = Math.Sqrt(dx * dx + dy * dy); // The straight line distance that the car must travel
			d = D * c; // Distance/turning_radius
			thetaI = Mod2Pi(Math.Atan2(dy, dx)); // The yaw of the end position
			alpha = Mod2Pi(0.0 - thetaI); // The opposite of the yaw of the end poistion
			beta = Mod2Pi(eyaw - thetaI); // The difference between the desired ending yaw position and the result of going straight towards it
			(best_t, best_p, best_q) = (-1, -1, -1);
			best_mode = new char[] { 'N', 'N', 'N' }; // Default N = None
			best_cost = int.MaxValue;
			//-------------------------------------------------------------------------------------------------------------
			// Loop through all 6 of the planners, asking each one to compute a path
			//   Each planner will return t,p,q
			//   t is the (signed) arc length of the first portion of the path, 
			//   p is the (signed) arc length of the second portion,
			//   q is the (signed) arc length of the third portion
			// Find the planner that returns the path with the smallest total arc length, (abs(t) + abs(p) + abs(q))
			// Set best_t,best_p,best_q, and best_mode to the t,p,q returned by the best planner and the corresponding mode
			//-------------------------------------------------------------------------------------------------------------
			char[,] mode = { { 'L', 'S', 'L' }, { 'R', 'S', 'R' }, { 'L', 'S', 'R' }, { 'R', 'S', 'L' }, { 'R', 'L', 'R' }, { 'L', 'R', 'L' } };
			Func<double, double, double, double[]>[] FCanPaths = { LSL, RSR, LSR, RSL, RLR, LRL }; // Families of canonical paths
			for (int i = 0; i < 6; i++)
			{ // 6 families of canonical paths are optimal (Dubins)
				checkPathArgs = new double[] { best_t, best_p, best_q, best_cost, alpha, beta, d };
				(best_t, best_p, best_q, best_cost, modeFlag) = CheckPath(checkPathArgs, FCanPaths[i]);
				best_mode = (modeFlag) ? GetRow(mode, i) : best_mode; // Updates best_mode if the last path was the best
			}
			// Remove loops if present
			best_t = (best_t > 2 * pi) ? best_t - 2 * pi : best_t;
			best_p = (best_p > 2 * pi && best_mode[1] != 'S') ? best_p - 2 * pi : best_p;
			best_q = (best_q > 2 * pi) ? best_q - 2 * pi : best_q;

			genCourseLength = new double[] { best_t, best_p, best_q };
			(px, py, pyaw, plen, pcost) = GenerateCourse(genCourseLength, best_mode, c); // Turns arc lengths into points along path

			return (px, py, pyaw, plen, pcost, best_mode);
		}

		public (double[], double[], double[], double[], double[], char[]) DubinsPathPlanning(double[] s, double[] e, double c)
		{
			// Dubins path planner
			// input:
			// 	sx		x position of start point [m]
			// 	sy		y position of start point [m]
			// 	syaw	yaw angle of start point [rad]
			// 	ex		x position of end point [m]
			// 	ey		y position of end point [m]
			// 	eyaw	yaw angle of end point [rad]
			// 	c		curvature [1/m]
			// output:
			// 	px, py, pyaw, mode
			double sx, sy, syaw, ex, ey, eyaw, lex, ley, leyaw;
			double[] lpx, lpy, lpyaw, ppx, ppy, ppyaw, clen, pclen, ccost, pccost;
			double[] px = new double[4], py = new double[4], pyaw = new double[4];
			char[] mode;

			(sx, sy, syaw) = (s[0], s[1], s[2]);
			(ex, ey, eyaw) = (e[0], e[1], e[2]);

			// Get path in frame of the source
			ex = ex - sx;
			ey = ey - sy;
			lex = Math.Cos(syaw) * ex + Math.Sin(syaw) * ey; // Note that we are effectively rotating by -syaw
			ley = -Math.Sin(syaw) * ex + Math.Cos(syaw) * ey; // Note that we are effectively rotating by -syaw
			leyaw = eyaw - syaw;

			// Get the plan (w.r.t the source frame)
			(lpx, lpy, lpyaw, clen, ccost, mode) = DubinsPathPlanningFromOrigin(lex, ley, leyaw, c);

			// Convert back to world coordinates
			for (int i = 0; i < 4; i++)
			{ // Note that we are effectively rotating by syaw
				double x = lpx[i], y = lpy[i], iyaw = lpyaw[i];
				px[i] = Math.Cos(-syaw) * x + Math.Sin(-syaw) * y + sx;
				py[i] = -Math.Sin(-syaw) * x + Math.Cos(-syaw) * y + sy;
				pyaw[i] = Pi2Pi(iyaw + syaw);
			}

			(ppx, ppy, ppyaw, pclen, pccost) = (px, py, pyaw, clen, ccost);

			return (ppx, ppy, ppyaw, pclen, pccost, mode);
		}

		(float, float) GetEndArc(double angle, double Cx, double Cy, double r)
		{
			float Bx = (float)(Cx + r * Math.Cos(angle));
			float By = (float)(Cy + r * Math.Sin(angle));
			return (Bx, By);
		}

		public double GetDistancePoints(double x1, double y1, double x2, double y2)
		{
			return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
		}

		double GetAngleFromPoint(double Px, double Py, double Cx, double Cy)
		{
			return Math.Atan2(Py - Cy, Px - Cx);
		}

		double Mod2Pi(double thetaI)
		{
			return thetaI - 2.0 * pi * Math.Floor(thetaI / 2.0 / pi);
		}

		double Pi2Pi(double angle)
		{
			while (angle >= pi)
				angle = angle - 2.0 * pi;
			while (angle <= -pi)
				angle = angle + 2.0 * pi;
			return angle;
		}

		public static T[] GetRow<T>(T[,] matrix, int rowNumber)
		{
			return Enumerable.Range(0, matrix.GetLength(1))
					.Select(x => matrix[rowNumber, x])
					.ToArray();
		}
	}
}
