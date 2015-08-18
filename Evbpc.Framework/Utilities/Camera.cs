using Evbpc.Framework.Drawing;
using Evbpc.Framework.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Utilities
{
    public class Camera
    {
        public ITrackableObject TrackObject { get; private set; }
        public PointF Position { get; private set; }
        public SizeF Size { get; private set; }
        public float Scale { get; private set; }

        /// <summary>
        /// Gets the <see cref="RectangleF"/> that represents how close to the edge of the <see cref="Bounds"/> an <see cref="ITrackableObject"/> must be for the <see cref="Camera"/> to pan.
        /// </summary>
        /// <remarks>
        /// The values for this <see cref="RectangleF"/> represent the percentage of difference between the center of the <see cref="Camera.Bounds"/> and the edge of the <see cref="Camera.Bounds"/>. A value of <c>0.5</c> in each field will mean that the centre 50% of the screen will pan about.
        /// 
        /// This value cannot be set directly as it could cause the <see cref="Camera"/> to "jump" very quickly, and create a graphics issue. If you wish to change this value you should create a new instance of the <see cref="Camera"/> class.
        /// </remarks>
        public RectangleF TriggerBounds { get; private set; }

        public RectangleF Bounds { get { return new RectangleF(Position, Size); } }
        public PointF AbsoluteCenter { get { return new PointF(Position.X + Size.Width / 2f, Position.Y + Size.Height / 2f); } }
        public PointF RelativeCenter { get { return new PointF(Size.Width / 2f, Size.Height / 2f); } }

        /// <summary>
        /// Creates a new instance of the <see cref="Camera"/> class from the specified <see cref="TrackObject"/> and <see cref="TriggerBounds"/>.
        /// </summary>
        /// <param name="mObject">An <see cref="ITrackableObject"/> to follow.</param>
        /// <param name="mTriggerBounds">A <see cref="RectangleF"/> that represents how close to the edge of the screen an <see cref="ITrackableObject"/> must be to trigger panning.</param>
        public Camera(ITrackableObject mObject, RectangleF mTriggerBounds)
        {
            TrackObject = mObject;
            TriggerBounds = mTriggerBounds;

            if (mObject != null)
                mObject.PositionChanged += mObject_PositionChanged;
        }

        private void mObject_PositionChanged(object sender, PositionChangedEventArgs e) { }

        /// <summary>
        /// This method will <b>immediately</b> move the <see cref="Camera"/> to center on the <see cref="ITrackableObject"/>. If you wish to pan smoothly, you should use <see cref="CenterCamera(float)"/>.
        /// </summary>
        /// <remarks>
        /// This is effectively the same as the <see cref="CenterCamera(float)"/> method with an value of <c>0</c> specified.
        /// </remarks>
        public void CenterCamera() { }
        /// <summary>
        /// This method will smoothly center the <see cref="Camera"/> to the <see cref="ITrackableObject"/>.
        /// </summary>
        /// <param name="animationTime">A value that indicates how long (in seconds) it should take the <see cref="Camera"/> to center on the <see cref="ITrackableObject"/>. Smaller values will mean a quicker movement, but may also cause jumpy-ness.</param>
        /// <remarks>
        /// If a value of <c>0</c> is provided for the <c>animationTime</c>, then this has the same effect as the <see cref="CenterCamera()"/> method.
        /// </remarks>
        public void CenterCamera(float animationTime) { }
        public void SetPosition(PointF position) { Position = position; }
        public void MoveCamera(Vector2F vector) { Position = new PointF(Position.X + vector.X, Position.Y + vector.Y); }
        public void SetSize(SizeF size) { Size = size; }
        public void ResizeCamera(Vector2F adjustment) { Size = new SizeF(Size.Width + adjustment.X, Size.Height + adjustment.Y); }
        public void SetScale(float scale) { Scale = scale; }
        public void ScaleCamera(float adjustment) { Scale += adjustment; }

        public static bool operator ==(Camera a, Camera b) { return a.Position == b.Position && a.Size == b.Size && a.Scale == b.Scale; }
        public static bool operator !=(Camera a, Camera b) { return !(a == b); }

        public static Camera Empty = new Camera(null, RectangleF.Empty);
    }
}
