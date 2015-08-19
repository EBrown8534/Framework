using Evbpc.Framework.Drawing;
using Evbpc.Framework.Physics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Utilities
{
    /// <summary>
    /// Represents an object that tracks and updates it's position based on another object, and can be used to determine where rendering should take place.
    /// </summary>
    public class Camera : ITrackableObject
    {
        private PointF _Position;
        private SizeF _Size;

        /// <summary>
        /// Gets the <see cref="ITrackableObject"/> that is being tracked by this <see cref="Camera"/> instance.
        /// </summary>
        public ITrackableObject TrackObject { get; private set; }
        /// <summary>
        /// Gets the <see cref="PointF"/> that is the current location of this <see cref="Camera"/> instance.
        /// </summary>
        public PointF Position { get { return _Position; } private set { if (_Position != value) { var oldPosition = _Position; _Position = value; OnTrackableObjectChanged(new TrackableObjectChangedEventArgs(_Position, oldPosition, Size, Size)); } } }
        /// <summary>
        /// Gets the <see cref="SizeF"/> of this <see cref="Camera"/> instance.
        /// </summary>
        public SizeF Size { get { return _Size; } private set { if (_Size != value) { var oldSize = _Size; _Size = value; OnTrackableObjectChanged(new TrackableObjectChangedEventArgs(Position, Position, _Size, oldSize)); } } }
        /// <summary>
        /// Gets the <code>float</code> value that represents how this <see cref="Camera"/> instance should scale (or zoom). A value of <code>1.0f</code> is the default, and indicates that it should not be zoomed.
        /// </summary>
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

        /// <summary>
        /// Gets the <see cref="RectangleF"/> that represents the entire covered portion of this <see cref="Camera"/> instance.
        /// </summary>
        public RectangleF Bounds { get { return new RectangleF(Position, Size); } }
        /// <summary>
        /// Gets the <see cref="PointF"/> that represents the global center position of this <see cref="Camera"/> instance.
        /// </summary>
        public PointF AbsoluteCenter { get { return new PointF(Position.X + Size.Width / 2.0f, Position.Y + Size.Height / 2.0f); } }
        /// <summary>
        /// Gets the <see cref="PointF"/> that represents the center of the <see cref="Size"/> of this <see cref="Camera"/> instance.
        /// </summary>
        public PointF RelativeCenter { get { return new PointF(Size.Width / 2.0f, Size.Height / 2.0f); } }

        /// <summary>
        /// Creates a new instance of the <see cref="Camera"/> class from the specified <see cref="TrackObject"/> and <see cref="TriggerBounds"/>.
        /// </summary>
        /// <param name="trackObject">An <see cref="ITrackableObject"/> to follow.</param>
        /// <param name="triggerBounds">A <see cref="RectangleF"/> that represents how close to the edge of the screen an <see cref="ITrackableObject"/> must be to trigger panning.</param>
        public Camera(ITrackableObject trackObject, RectangleF triggerBounds)
        {
            if (trackObject == null || trackObject == this)
                throw new ArgumentException("The trackObject must not be null or this instance.");

            TrackObject = trackObject;
            TriggerBounds = triggerBounds;
            trackObject.TrackableObjectChanged += trackObject_TrackableObjectChanged;
        }

        private void trackObject_TrackableObjectChanged(object sender, TrackableObjectChangedEventArgs e)
        {
            // We should make the new camera position the same as the position of the entity, minus the centering
            _Position = new PointF((TrackObject.Position.X + TrackObject.Size.Width) / 2.0f - RelativeCenter.X, (TrackObject.Position.Y + TrackObject.Size.Height) / 2.0f - RelativeCenter.Y);
        }

        /// <summary>
        /// This method will <b>immediately</b> move the <see cref="Camera"/> to center on the <see cref="ITrackableObject"/>. If you wish to pan smoothly, you should use <see cref="CenterCamera(float)"/>.
        /// </summary>
        /// <remarks>
        /// This is effectively the same as the <see cref="CenterCamera(float)"/> method with an value of <c>0</c> specified.
        /// </remarks>
        public void CenterCamera() { CenterCamera(0); }
        /// <summary>
        /// This method will smoothly center the <see cref="Camera"/> to the <see cref="ITrackableObject"/>.
        /// </summary>
        /// <param name="animationTime">A value that indicates how long (in seconds) it should take the <see cref="Camera"/> to center on the <see cref="ITrackableObject"/>. Smaller values will mean a quicker movement, but may also cause jumpy-ness.</param>
        /// <remarks>
        /// If a value of <c>0</c> is provided for the <c>animationTime</c>, then this has the same effect as the <see cref="CenterCamera()"/> method.
        /// </remarks>
        public void CenterCamera(float animationTime) { /* TODO: Implement this method. */ }
        /// <summary>
        /// Updates the <see cref="Position"/> of the current <see cref="Camera"/> instance to the value specified.
        /// </summary>
        /// <param name="position">A <see cref="PointF"/> representing the new <see cref="Position"/> of the <see cref="Camera"/>.</param>
        public void SetPosition(PointF position) { Position = position; }
        /// <summary>
        /// Alters the <see cref="Position"/> of the current <see cref="Camera"/> instance by the specified <see cref="Vector2F"/>.
        /// </summary>
        /// <param name="vector">The distance to move the <see cref="Camera"/>.</param>
        public void MoveCamera(Vector2F vector) { Position = new PointF(Position.X + vector.X, Position.Y + vector.Y); }
        /// <summary>
        /// Updates the <see cref="Size"/> of the current <see cref="Camera"/> instance.
        /// </summary>
        /// <param name="size">A <see cref="SizeF"/> representing the new <see cref="Size"/> of the <see cref="Camera"/>.</param>
        public void SetSize(SizeF size) { Size = size; }
        /// <summary>
        /// Alters the <see cref="Size"/> of the current <see cref="Camera"/> instance by the specified <see cref="Vector2F"/>.
        /// </summary>
        /// <param name="adjustment">The <see cref="Vector2F"/> representing how much to increase/decrease the <see cref="Size"/>.</param>
        public void ResizeCamera(Vector2F adjustment) { Size = new SizeF(Size.Width + adjustment.X, Size.Height + adjustment.Y); }
        /// <summary>
        /// Updates the <see cref="Scale"/> of the current <see cref="Camera"/> instance to the specified value.
        /// </summary>
        /// <param name="scale">The new value for the <see cref="Scale"/> value of the <see cref="Camera"/>.</param>
        public void SetScale(float scale) { Scale = scale; }
        /// <summary>
        /// Alters the <see cref="Scale"/> of the current <see cref="Camera"/> instance by the specified value.
        /// </summary>
        /// <param name="adjustment">The value representing how much to zoom/unzoom the <see cref="Camera"/>.</param>
        public void ScaleCamera(float adjustment) { Scale += adjustment; }
        /// <summary>
        /// Determines if the current <see cref="Camera"/> instances contains the <see cref="ITrackableObject"/>.
        /// </summary>
        /// <param name="testObject">The <see cref="ITrackableObject"/> to test.</param>
        /// <param name="entirelyContained">If true, will only return true if the testObject is entirely contained in the <see cref="Camera.Bounds"/>, otherwise will return true if any part of the testObject is contained.</param>
        /// <returns>If entirelyContained is true, returns true only if the entire testObject is contained within <see cref="Camera.Bounds"/>. If entirelyContained is false, returns true if any part of the testObject is contained within <see cref="Camera.Bounds"/>.</returns>
        public bool Contains(ITrackableObject testObject, bool entirelyContained)
        {
            if (entirelyContained)
                return Bounds.Contains(new RectangleF(testObject.Position, testObject.Size));
            else
            {
                // We're only checking corner cases as we are assuming that the `testObject` is not *bigger* than the `Camera`. If it is, then that's a different issue. (We'll likely fix this in the future, just not today!)
                if (Bounds.Contains(testObject.Position))
                    return true;

                if (Bounds.Contains(testObject.Position.X, testObject.Size.Height))
                    return true;

                if (Bounds.Contains(testObject.Size.Width, testObject.Position.Y))
                    return true;

                if (Bounds.Contains(testObject.Size.Width, testObject.Size.Height))
                    return true;
            }

            return false;
        }

        private void OnTrackableObjectChanged(TrackableObjectChangedEventArgs e) { var handler = TrackableObjectChanged; if (handler != null) { handler(this, e); } }

        /// <summary>
        /// An event that may be subscribed to for notification of when the <see cref="Position"/> property of this <see cref="Camera"/> instance changes.
        /// </summary>
        public event EventHandler<TrackableObjectChangedEventArgs> TrackableObjectChanged;
    }
}
