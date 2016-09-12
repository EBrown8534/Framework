using Evbpc.Framework.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Physics
{
    public struct LineF
    {
        public PointF Start { get; }
        public PointF End { get; }
        public Vector2F Vector { get; }

        public RectangleF Bounds => new RectangleF(Start.X, Start.Y, End.X - Start.X, End.Y - Start.X);

        public LineF(PointF start, PointF end)
        {
            Start = start;
            End = end;
            Vector = new Vector2F(End.X - Start.X, End.Y - Start.Y);
        }

        /// <summary>
        /// Gets the <see cref="PointF"/> at which the current <see cref="LineF"/> intersects the target <see cref="LineF"/>.
        /// </summary>
        /// <param name="l">The target <see cref="LineF"/> to test.</param>
        /// <returns>The <see cref="PointF"/> intersection point. Returns <code>null</code> if the lines are parallel, or do not intersect with each line's segment.</returns>
        public PointF? Intersect(LineF l) => Intersect(this, l);

        public static PointF? Intersect(LineF l1, LineF l2)
        {
            var intPoint = IntersectForever(l1, l2);

            if (intPoint == null)
            {
                return null;
            }

            // So we know the intersection point were the lines extended forever, we just need to see if the point fits on our source lines.
            if (l1.RectContainsPoint(intPoint.Value) && l2.RectContainsPoint(intPoint.Value))
            {
                return intPoint;
            }

            return null;
        }

        /// <summary>
        /// Determines if the <see cref="Bounds"/> contains the specified <see cref="PointF"/>.
        /// </summary>
        /// <param name="pt">The <see cref="PointF"/> to test.</param>
        /// <returns>True if the <see cref="PointF"/> fits in the current <see cref="Bounds"/>.</returns>
        /// <remarks>
        /// If it is already know that the <see cref="PointF"/> fits on the <see cref="LineF"/> at <b>some</b> location, then this is an inexpensive operation to see if the <see cref="PointF"/> is within the current <see cref="LineF"/> segment.
        /// </remarks>
        public bool RectContainsPoint(PointF pt) => (pt.X >= Start.X && pt.X <= End.X && pt.Y >= Start.Y && pt.Y <= End.Y)
                                                    || (pt.X >= Start.X && pt.X <= End.X && pt.Y <= Start.Y && pt.Y >= End.Y)
                                                    || (pt.X <= Start.X && pt.X >= End.X && pt.Y >= Start.Y && pt.Y <= End.Y)
                                                    || (pt.X <= Start.X && pt.X >= End.X && pt.Y <= Start.Y && pt.Y >= End.Y);

        /// <summary>
        /// Returns a <see cref="PointF"/> which represents the intersection of this line and the specified line if they were extended in each direction forever.
        /// </summary>
        /// <param name="l">The line to intersect with.</param>
        /// <returns>The intersection <see cref="PointF"/> of the two lines. If the lines are parallel then returns <code>null</code>. If the lines coincide, this also returns <code>null</code>.</returns>
        public PointF? IntersectForever(LineF l) => IntersectForever(this, l);

        public static PointF? IntersectForever(LineF l1, LineF l2)
        {
            if (l1.End.X == l1.Start.X)
            {
                // First line is a vertical line
                if (l2.End.X == l2.Start.X)
                {
                    // Second line is also vertical, parallel
                    return null;
                }

                // Intersection point is a lot easier, just plug the `Start.X` into the second line's formula.
                var m = (float)(l2.End.Y - l2.Start.Y) / (l2.End.X - l2.Start.X);
                var b = -(m * l2.Start.X) + l2.Start.Y;

                return new PointF(l1.Start.X, m * l1.Start.X + b);
            }

            if (l2.End.X == l2.Start.X)
            {
                // Second line is a vertical line
                // Intersection point is a lot easier, just plug the `line.Start.X` into the first line's formula.
                var m = (float)(l1.End.Y - l1.Start.Y) / (l1.End.X - l1.Start.X);
                var b = -(m * l1.Start.X) + l1.Start.Y;

                return new PointF(l2.Start.X, m * l2.Start.X + b);
            }

            // We'll need the slopes of both lines
            var m1 = (float)(l1.End.Y - l1.Start.Y) / (l1.End.X - l1.Start.X);
            var m2 = (float)(l2.End.Y - l2.Start.Y) / (l2.End.X - l2.Start.X);

            // (Mostly) equal slopes indicate the lines are parallel and will never intersect.
            if (Math.Abs(m1 - m2) < float.Epsilon * 2)
            {
                return null;
            }

            // The slopes are different enough that we need the intercepts
            var b1 = -(m1 * l1.Start.X) + l1.Start.Y;
            var b2 = -(m2 * l2.Start.X) + l2.Start.Y;

            // Get the X and Y coordinates of the intersection, we'll solve the two formulas for `x`, which gives us the following transformations:
            //      y = m1 * x + b1, y = m2 * x + b2
            //      m1 * x + b1 = m2 * x + b2
            //      m1 * x = m2 * x + b2 - b1
            //      m1 * x - m2 * x = b2 - b1
            //      (m1 - m2) * x = b2 - b1
            //      x = (b2 - b1) / (m1 - m2)
            var x = (b2 - b1) / (m1 - m2);
            var y = m1 * x + b1;

            return new PointF(x, y);
        }
    }
}
