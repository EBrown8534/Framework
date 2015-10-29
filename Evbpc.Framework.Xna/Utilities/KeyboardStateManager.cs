using Evbpc.Framework.Windows.Forms;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keys = Evbpc.Framework.Windows.Forms.Keys;
using XnaKeys = Microsoft.Xna.Framework.Input.Keys;

namespace Evbpc.Framework.Xna.Utilities
{
    /// <summary>
    /// This provides an easy-to-use class to interact with the Keyboard in an XNA game.
    /// </summary>
    public class KeyboardStateManager
    {
        /// <summary>
        /// Gets the <code>KeyboardState</code> from the previous update.
        /// </summary>
        public KeyboardState KeyStatePrevious { get; private set; }
        /// <summary>
        /// Gets the <code>KeyboardState</code> from the current update.
        /// </summary>
        public KeyboardState KeyStateNow { get; private set; }
        /// <summary>
        /// Determines how long a key must be held for to begin triggering a repeated keypress.
        /// </summary>
        public TimeSpan HoldRepeatTrigger { get; private set; } = new TimeSpan(0, 0, 0, 0, 250);
        /// <summary>
        /// Determines how long between repeated keypresses a key must be held for to continue the repeat.
        /// </summary>
        public TimeSpan HoldRepeatDelay { get; set; } = new TimeSpan(0, 0, 0, 0, 35);

        private static Dictionary<Keys, DateTime> _keysPressedAt = new Dictionary<Keys, DateTime>();
        private static Dictionary<Keys, DateTime> _keyLastTickAt = new Dictionary<Keys, DateTime>();

        /// <summary>
        /// Updates the internal <code>KeyboardState</code> and fires relevant events.
        /// </summary>
        /// <param name="kState">The new <code>KeyboardState</code>.</param>
        public void Update(KeyboardState kState)
        {
            KeyStatePrevious = KeyStateNow;
            KeyStateNow = kState;

            var keysDownNow = GetPressedKeys(KeyStateNow);
            var keysDownPrev = GetPressedKeys(KeyStatePrevious);
            var keysPressed = GetPressedKeys();

            foreach (Keys key in keysDownNow)
            {
                if (!keysDownPrev.Contains(key))
                {
                    OnKeyDown(new KeyEventArgs(key));
                }
            }

            foreach (Keys key in keysDownPrev)
            {
                if (!keysDownNow.Contains(key))
                {
                    OnKeyUp(new KeyEventArgs(key));
                }
            }

            foreach (Keys key in keysPressed)
            {
                OnKeyPress(new KeyPressEventArgs(GetKeyChar(key)));
            }
        }

        /// <summary>
        /// Gets the <code>char</code> value represented by the <see cref="Keys"/> that was sent.
        /// </summary>
        /// <param name="key">The <see cref="Keys"/> enumeration value to examine.</param>
        /// <returns>A <code>char</code> that represents the ASCII value of the key.</returns>
        public static char GetKeyChar(Keys key)
        {
            if ((key & Keys.Shift) == Keys.Shift)
            {
                key ^= Keys.Shift;

                if ((int)key >= 0x41 && (int)key <= 0x5A)
                {
                    return (char)key;
                }

                // We made this a massive `switch` statement for the speed it provides.
                switch (key)
                {
                    case Keys.D1:
                        return '!';
                    case Keys.D2:
                        return '@';
                    case Keys.D3:
                        return '#';
                    case Keys.D4:
                        return '$';
                    case Keys.D5:
                        return '%';
                    case Keys.D6:
                        return '^';
                    case Keys.D7:
                        return '&';
                    case Keys.D8:
                        return '*';
                    case Keys.D9:
                        return '(';
                    case Keys.D0:
                        return ')';
                    case Keys.OemPeriod:
                        return '>';
                    case Keys.Oemcomma:
                        return '<';
                    case Keys.OemQuestion:
                        return '?';
                    case Keys.OemOpenBrackets:
                        return '{';
                    case Keys.OemCloseBrackets:
                        return '}';
                    case Keys.OemSemicolon:
                        return ':';
                    case Keys.OemQuotes:
                        return '"';
                    case Keys.Oemtilde:
                        return '~';
                    case Keys.Oemplus:
                        return '+';
                    case Keys.Separator:
                        return '_';
                    case Keys.OemPipe:
                        return '|';
                    case Keys.Divide:
                        return '/';
                    case Keys.Multiply:
                        return '*';
                    case Keys.Subtract:
                        return '-';
                    case Keys.Add:
                        return '+';
                }

                return (char)key;
            }
            else
            {
                if ((int)key >= 0x41 && (int)key <= 0x5A)
                {
                    return (char)((int)key + 32);
                }
                if ((int)key >= 0x30 && (int)key <= 0x39)
                {
                    return (char)key;
                }

                switch (key)
                {
                    case Keys.Separator:
                        return '-';
                    case Keys.Oemplus:
                        return '=';
                    case Keys.Divide:
                        return '/';
                    case Keys.Multiply:
                        return '*';
                    case Keys.Subtract:
                        return '-';
                    case Keys.Add:
                        return '+';
                    case Keys.NumPad0:
                    case Keys.NumPad1:
                    case Keys.NumPad2:
                    case Keys.NumPad3:
                    case Keys.NumPad4:
                    case Keys.NumPad5:
                    case Keys.NumPad6:
                    case Keys.NumPad7:
                    case Keys.NumPad8:
                    case Keys.NumPad9:
                        return key.ToString().Substring(6, 1)[0];
                    case Keys.OemPeriod:
                        return '.';
                    case Keys.Oemcomma:
                        return ',';
                    case Keys.OemQuestion:
                        return '/';
                    case Keys.OemPipe:
                        return '\\';
                    case Keys.OemOpenBrackets:
                        return '[';
                    case Keys.OemCloseBrackets:
                        return ']';
                    case Keys.OemSemicolon:
                        return ';';
                    case Keys.OemQuotes:
                        return '\'';
                    case Keys.Oemtilde:
                        return '`';
                    case Keys.Decimal:
                        return '.';
                    default:
                        return (char)key;
                }
            }
        }

        private List<Keys> GetPressedKeys(KeyboardState k)
        {
            var pressedKeys = new List<Keys>();

            foreach (XnaKeys key in k.GetPressedKeys())
            {
                pressedKeys.Add(XnaKeyToKey(key));

                if (!_keysPressedAt.ContainsKey(XnaKeyToKey(key)))
                {
                    _keysPressedAt.Add(XnaKeyToKey(key), DateTime.UtcNow);
                }
            }

            return pressedKeys;
        }

        /// <summary>
        /// Raises the <see cref="KeyDown"/> event.
        /// </summary>
        /// <param name="e">A <see cref="KeyEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onkeydown(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnKeyDown(KeyEventArgs e)
        {
            var handler = KeyDown;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="KeyPress"/> event.
        /// </summary>
        /// <param name="e">A <see cref="KeyPressEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onkeypress(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnKeyPress(KeyPressEventArgs e)
        {
            var handler = KeyPress;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="KeyUp"/> event.
        /// </summary>
        /// <param name="e">A <see cref="KeyEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onkeyup(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnKeyUp(KeyEventArgs e)
        {
            var handler = KeyUp;
            handler?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs when a key is pressed while the control has focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.keydown(v=vs.110).aspx
        /// </remarks>
        public event EventHandler<KeyEventArgs> KeyDown;
        /// <summary>
        /// Occurs when a character. space or backspace key is pressed while the control has focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.keypress(v=vs.110).aspx
        /// </remarks>
        public event EventHandler<KeyPressEventArgs> KeyPress;
        /// <summary>
        /// Occurs when a key is released while the control has focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.keyup(v=vs.110).aspx
        /// </remarks>
        public event EventHandler<KeyEventArgs> KeyUp;

        private List<Keys> GetPressedKeys()
        {
            var pressedKeys = GetPressedKeys(KeyStateNow);
            var prevPressedKeys = GetPressedKeys(KeyStatePrevious);

            var result = new List<Keys>();
            bool shiftPressed = false;

            foreach (Keys key in pressedKeys)
            {
                if ((key & Keys.Shift) == Keys.Shift)
                {
                    shiftPressed = true;
                }
                else
                {
                    if (IsKeyUp(prevPressedKeys, key))
                    {
                        result.Add(key);

                        if (_keysPressedAt.ContainsKey(key))
                        {
                            _keysPressedAt.Remove(key);
                        }

                        if (_keyLastTickAt.ContainsKey(key))
                        {
                            _keyLastTickAt.Remove(key);
                        }
                    }
                    else
                    {
                        if (_keysPressedAt.ContainsKey(key))
                        {
                            TimeSpan timeDifference = DateTime.UtcNow - _keysPressedAt[key];

                            if (timeDifference > HoldRepeatTrigger && (_keyLastTickAt.ContainsKey(key) && DateTime.UtcNow - _keyLastTickAt[key] > HoldRepeatDelay || !_keyLastTickAt.ContainsKey(key)))
                            {
                                result.Add(key);

                                if (_keyLastTickAt.ContainsKey(key))
                                {
                                    _keyLastTickAt[key] = DateTime.UtcNow;
                                }
                                else
                                {
                                    _keyLastTickAt.Add(key, DateTime.UtcNow);
                                }
                            }
                        }
                    }

                    if (!_keysPressedAt.ContainsKey(key))
                    {
                        _keysPressedAt.Add(key, DateTime.UtcNow);
                    }
                }
            }

            if (shiftPressed)
            {
                for (int i = 0; i < result.Count; i++)
                {
                    result[i] |= Keys.Shift;
                }
            }

            return result;
        }

        private static bool IsPressedState(List<Keys> pressedKeys, Keys key, bool state)
        {
            for (int i = 0; i < pressedKeys.Count; i++)
            {
                if (pressedKeys[i] == key)
                {
                    return state;
                }
            }

            return !state;
        }

        private static bool IsKeyDown(List<Keys> pressedKeys, Keys key) => IsPressedState(pressedKeys, key, true);

        private static bool IsKeyUp(List<Keys> pressedKeys, Keys key) => IsPressedState(pressedKeys, key, false);

        private static Keys XnaKeyToKey(XnaKeys key)
        {
            Keys kv = Keys.None;

            switch (key)
            {
                case XnaKeys.OemComma:
                    kv = Keys.Oemcomma;
                    break;
                case XnaKeys.OemTilde:
                    kv = Keys.Oemtilde;
                    break;
                case XnaKeys.OemPlus:
                    kv = Keys.Oemplus;
                    break;
                default:
                    if (Enum.IsDefined(typeof(Keys), key.ToString()) | key.ToString().Contains(","))
                    {
                        kv |= (Keys)Enum.Parse(typeof(Keys), key.ToString());
                    }
                    break;
            }

            if (key == XnaKeys.LeftShift)
            {
                kv = Keys.LShiftKey | Keys.Shift;
            }
            if (key == XnaKeys.RightShift)
            {
                kv = Keys.RShiftKey | Keys.Shift;
            }

            return kv;
        }
    }
}
