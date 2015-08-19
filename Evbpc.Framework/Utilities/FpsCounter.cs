using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Evbpc.Framework.Utilities
{
    /// <summary>
    /// A utilitarian class for calculating FPS.
    /// </summary>
    public class FpsCounter
    {
        private List<DateTime> _frames;
        private TimeSpan _expirationTime = new TimeSpan(1, 0, 0);

        /// <summary>
        /// Gets the amount of time after which a frame would expire.
        /// </summary>
        public TimeSpan ExpirationTime { get { return _expirationTime; } }

        /// <summary>
        /// Returns the list of Frames that are stored within the <see cref="FpsCounter"/>.
        /// </summary>
        public IEnumerable<DateTime> Frames { get { return _frames.ToArray(); /* prevent the internal `List<DateTime>` from being modified by the outside */ } }

        /// <summary>
        /// Creates a new instance of the <see cref="FpsCounter"/>.
        /// </summary>
        public FpsCounter()
        {
            _frames = new List<DateTime>();
        }

        /// <summary>
        /// Creates a new instance of the <see cref="FpsCounter"/> with the specified <see cref="ExpirationTime"/>.
        /// </summary>
        /// <param name="expirationTime">The <code>TimeSpan</code> that represents the <see cref="ExpirationTime"/> for this <see cref="FpsCounter"/> instance.</param>
        public FpsCounter(TimeSpan expirationTime)
            : this()
        {
            _expirationTime = expirationTime;
        }

        /// <summary>
        /// Indicates that a frame has passed. This should be called on each instance of a frame being drawn or updated (but not both).
        /// </summary>
        public void AddFrame()
        {
            _frames.Add(DateTime.UtcNow);

            for (int i = 0; i < _frames.Count; i++)
                if (_frames[i] - DateTime.UtcNow > _expirationTime)
                    _frames.RemoveAt(i);
                else
                    break;
        }

        /// <summary>
        /// Gets the FPS between the last two <see cref="Frames"/>.
        /// </summary>
        /// <returns>The immediate FPS as represented by the time difference of the last two <see cref="Frames"/>.</returns>
        public int Immediate()
        {
            if (_frames.Count > 2)
                return 1000 / (int)(_frames[_frames.Count - 1] - _frames[_frames.Count - 2]).TotalMilliseconds;
            else
                return 0;
        }

        /// <summary>
        /// Gets the average FPS over the last specified number of seconds.
        /// </summary>
        /// <param name="previousSeconds">The number of seconds previous to now that should be measured.</param>
        /// <returns>The average FPS for the time interval.</returns>
        public int LastSeconds(int previousSeconds = 1)
        {
            DateTime now = DateTime.UtcNow;
            int n = 0;
            TimeSpan difference = new TimeSpan(0, 0, previousSeconds);

            for (int i = _frames.Count - 1; i >= 0; i--)
                if (now - _frames[i] < difference)
                    n++;
                else
                    break;

            if (n > 1)
                return (int)(n / (_frames[_frames.Count - 1] - _frames[_frames.Count - n]).TotalSeconds);

            return 0;
        }

        /// <summary>
        /// Gets the average FPS over the last specified number of minutes.
        /// </summary>
        /// <param name="previousMinutes">The number of minutes before now that should be included.</param>
        /// <returns>The average FPS for the time interval.</returns>
        public int LastMinutes(int previousMinutes = 1)
        {
            DateTime now = DateTime.UtcNow;
            int n = 0;
            TimeSpan difference = new TimeSpan(0, previousMinutes, 0);

            for (int i = _frames.Count - 1; i >= 0; i--)
                if (now - _frames[i] < difference)
                    n++;
                else
                    break;

            if (n > 1)
                return (int)(n / (_frames[_frames.Count - 1] - _frames[_frames.Count - n]).TotalSeconds);

            return 0;
        }

        /// <summary>
        /// Gets the average FPS over the last specified number of hours.
        /// </summary>
        /// <param name="previousHours">The number of hours before now that should be included.</param>
        /// <returns>The average FPS for the time interval.</returns>
        public int LastHours(int previousHours = 1)
        {
            DateTime now = DateTime.UtcNow;
            int n = 0;
            TimeSpan difference = new TimeSpan(previousHours, 0, 0);

            for (int i = _frames.Count - 1; i >= 0; i--)
                if (now - _frames[i] < difference)
                    n++;
                else
                    break;

            if (n > 1)
                return (int)(n / (_frames[_frames.Count - 1] - _frames[_frames.Count - n]).TotalSeconds);

            return 0;
        }

        /// <summary>
        /// Gets the average FPS over the last specified <code>TimeSpan</code>.
        /// </summary>
        /// <param name="previousTime">The <code>TimeSpan</code> before now that should be included.</param>
        /// <returns>The average FPS for the time interval.</returns>
        public int LastTimeSpan(TimeSpan previousTime)
        {
            DateTime now = DateTime.UtcNow;
            int n = 0;
            TimeSpan difference = previousTime;

            for (int i = _frames.Count - 1; i >= 0; i--)
                if (now - _frames[i] < difference)
                    n++;
                else
                    break;

            if (n > 1)
                return (int)(n / (_frames[_frames.Count - 1] - _frames[_frames.Count - n]).TotalSeconds);

            return 0;
        }

        /// <summary>
        /// Gets the average framerate between two <code>DateTime</code> values, inclusively.
        /// </summary>
        /// <param name="start">The <code>DateTime</code> to begin the calculation at.</param>
        /// <param name="end">The <code>DateTime</code> to end the calculation at.</param>
        /// <returns>The average FPS for the time interval.</returns>
        public int BetweenTimes(DateTime start, DateTime end)
        {
            int n = 0;
            TimeSpan difference = end - start;

            for (int i = _frames.Count - 1; i >= 0; i--)
                if (_frames[i] >= start && _frames[i] <= end)
                    n++;
                else if (_frames[i] < start)
                    break;

            if (n > 1)
                return (int)(n / (_frames[_frames.Count - 1] - _frames[_frames.Count - n]).TotalSeconds);

            return 0;
        }
    }
}
