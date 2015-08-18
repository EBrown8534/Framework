using Evbpc.Framework.Windows.Forms;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evbpc.Framework.Xna.Utilities
{
    /// <summary>
    /// This provides an easy-to-use class to interact with the Keyboard in an XNA game.
    /// </summary>
    public class KeyboardStateManager
    {
        private KeyboardState _kPrev;
        private KeyboardState _kNow;

        /// <summary>
        /// Gets the <code>KeyboardState</code> from the previous update.
        /// </summary>
        public KeyboardState KeyStatePrevious { get { return _kPrev; } }
        /// <summary>
        /// Gets the <code>KeyboardState</code> from the current update.
        /// </summary>
        public KeyboardState KeyStateNow { get { return _kNow; } }

        /// <summary>
        /// Updates the internal <code>KeyboardState</code> and fires relevant events.
        /// </summary>
        /// <param name="kState">The new <code>KeyboardState</code>.</param>
        public void Update(KeyboardState kState)
        {
            _kPrev = _kNow;
            _kNow = kState;

            List<Evbpc.Framework.Windows.Forms.Keys> keysDownNow = GetPressedKeys(_kNow);
            List<Evbpc.Framework.Windows.Forms.Keys> keysDownPrev = GetPressedKeys(_kPrev);
            List<Evbpc.Framework.Windows.Forms.Keys> keysPressed = GetPressedKeys();

            foreach (Evbpc.Framework.Windows.Forms.Keys keyDownNow in keysDownNow)
                if (!keysDownPrev.Contains(keyDownNow))
                    OnKeyDown(new KeyEventArgs(keyDownNow));

            foreach (Evbpc.Framework.Windows.Forms.Keys keyDownPrev in keysDownPrev)
                if (!keysDownNow.Contains(keyDownPrev))
                    OnKeyUp(new KeyEventArgs(keyDownPrev));

            foreach (Evbpc.Framework.Windows.Forms.Keys pressedKey in keysPressed)
                OnKeyPress(new KeyPressEventArgs(GetKeyChar(pressedKey)));
        }

        /// <summary>
        /// Gets the <code>char</code> value represented by the <see cref="Evbpc.Framework.Windows.Forms.Keys"/> that was sent.
        /// </summary>
        /// <param name="key">The <see cref="Evbpc.Framework.Windows.Forms.Keys"/> enumeration value to examine.</param>
        /// <returns>A <code>char</code> that represents the ASCII value of the key.</returns>
        public static char GetKeyChar(Evbpc.Framework.Windows.Forms.Keys key)
        {
            if ((key & Evbpc.Framework.Windows.Forms.Keys.Shift) == Evbpc.Framework.Windows.Forms.Keys.Shift)
            {
                key = key ^ Framework.Windows.Forms.Keys.Shift;

                if ((int)key >= 0x41 && (int)key <= 0x5A)
                    return (char)key;

                // We made this a massive `switch` statement for the speed it provides.
                switch (key)
                {
                    case Framework.Windows.Forms.Keys.D1:
                        return '!';
                    case Framework.Windows.Forms.Keys.D2:
                        return '@';
                    case Framework.Windows.Forms.Keys.D3:
                        return '#';
                    case Framework.Windows.Forms.Keys.D4:
                        return '$';
                    case Framework.Windows.Forms.Keys.D5:
                        return '%';
                    case Framework.Windows.Forms.Keys.D6:
                        return '^';
                    case Framework.Windows.Forms.Keys.D7:
                        return '&';
                    case Framework.Windows.Forms.Keys.D8:
                        return '*';
                    case Framework.Windows.Forms.Keys.D9:
                        return '(';
                    case Framework.Windows.Forms.Keys.D0:
                        return ')';
                    case Framework.Windows.Forms.Keys.OemPeriod:
                        return '>';
                    case Framework.Windows.Forms.Keys.Oemcomma:
                        return '<';
                    case Framework.Windows.Forms.Keys.OemQuestion:
                        return '?';
                    case Framework.Windows.Forms.Keys.OemOpenBrackets:
                        return '{';
                    case Framework.Windows.Forms.Keys.OemCloseBrackets:
                        return '}';
                    case Framework.Windows.Forms.Keys.OemSemicolon:
                        return ':';
                    case Framework.Windows.Forms.Keys.OemQuotes:
                        return '"';
                    case Framework.Windows.Forms.Keys.Oemtilde:
                        return '~';
                    case Framework.Windows.Forms.Keys.Oemplus:
                        return '+';
                    case Framework.Windows.Forms.Keys.Separator:
                        return '_';
                    case Framework.Windows.Forms.Keys.OemPipe:
                        return '|';
                    case Framework.Windows.Forms.Keys.Divide:
                        return '/';
                    case Framework.Windows.Forms.Keys.Multiply:
                        return '*';
                    case Framework.Windows.Forms.Keys.Subtract:
                        return '-';
                    case Framework.Windows.Forms.Keys.Add:
                        return '+';
                }

                return (char)key;
            }
            else
            {
                if ((int)key >= 0x41 && (int)key <= 0x5A)
                    return (char)((int)key + 32);
                else if ((int)key >= 0x30 && (int)key <= 0x39)
                    return (char)key;
                else
                {
                    switch (key)
                    {
                        case Framework.Windows.Forms.Keys.Separator:
                            return '-';
                        case Framework.Windows.Forms.Keys.Oemplus:
                            return '=';
                        case Framework.Windows.Forms.Keys.Divide:
                            return '/';
                        case Framework.Windows.Forms.Keys.Multiply:
                            return '*';
                        case Framework.Windows.Forms.Keys.Subtract:
                            return '-';
                        case Framework.Windows.Forms.Keys.Add:
                            return '+';
                        case Framework.Windows.Forms.Keys.NumPad0:
                        case Framework.Windows.Forms.Keys.NumPad1:
                        case Framework.Windows.Forms.Keys.NumPad2:
                        case Framework.Windows.Forms.Keys.NumPad3:
                        case Framework.Windows.Forms.Keys.NumPad4:
                        case Framework.Windows.Forms.Keys.NumPad5:
                        case Framework.Windows.Forms.Keys.NumPad6:
                        case Framework.Windows.Forms.Keys.NumPad7:
                        case Framework.Windows.Forms.Keys.NumPad8:
                        case Framework.Windows.Forms.Keys.NumPad9:
                            return key.ToString().Substring(6, 1)[0];
                        case Framework.Windows.Forms.Keys.OemPeriod:
                            return '.';
                        case Framework.Windows.Forms.Keys.Oemcomma:
                            return ',';
                        case Framework.Windows.Forms.Keys.OemQuestion:
                            return '/';
                        case Framework.Windows.Forms.Keys.OemPipe:
                            return '\\';
                        case Framework.Windows.Forms.Keys.OemOpenBrackets:
                            return '[';
                        case Framework.Windows.Forms.Keys.OemCloseBrackets:
                            return ']';
                        case Framework.Windows.Forms.Keys.OemSemicolon:
                            return ';';
                        case Framework.Windows.Forms.Keys.OemQuotes:
                            return '\'';
                        case Framework.Windows.Forms.Keys.Oemtilde:
                            return '`';
                        case Framework.Windows.Forms.Keys.Decimal:
                            return '.';
                        default:
                            return (char)key;
                    }
                }
            }
        }

        private static Dictionary<Framework.Windows.Forms.Keys, DateTime> keysPressedAt = new Dictionary<Framework.Windows.Forms.Keys, DateTime>();
        private static Dictionary<Framework.Windows.Forms.Keys, DateTime> keyLastTickAt = new Dictionary<Framework.Windows.Forms.Keys, DateTime>();

        private List<Framework.Windows.Forms.Keys> GetPressedKeys(KeyboardState k)
        {
            List<Framework.Windows.Forms.Keys> pressedKeys = new List<Framework.Windows.Forms.Keys>();

            foreach (Microsoft.Xna.Framework.Input.Keys key in k.GetPressedKeys())
            {
                pressedKeys.Add(XnaKeyToKey(key));

                if (!keysPressedAt.ContainsKey(XnaKeyToKey(key)))
                    keysPressedAt.Add(XnaKeyToKey(key), DateTime.Now);
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
        protected virtual void OnKeyDown(KeyEventArgs e) { if (KeyDown != null) { KeyDown(this, e); } }
        /// <summary>
        /// Raises the <see cref="KeyPress"/> event.
        /// </summary>
        /// <param name="e">A <see cref="KeyPressEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onkeypress(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnKeyPress(KeyPressEventArgs e) { if (KeyPress != null) { KeyPress(this, e); } }
        /// <summary>
        /// Raises the <see cref="KeyUp"/> event.
        /// </summary>
        /// <param name="e">A <see cref="KeyEventArgs"/> that contains the event data.</param>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.onkeyup(v=vs.110).aspx
        /// </remarks>
        protected virtual void OnKeyUp(KeyEventArgs e) { if (KeyUp != null) { KeyUp(this, e); } }

        /// <summary>
        /// Occurs when a key is pressed while the control has focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.keydown(v=vs.110).aspx
        /// </remarks>
        public event KeyEventHandler KeyDown;
        /// <summary>
        /// Occurs when a character. space or backspace key is pressed while the control has focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.keypress(v=vs.110).aspx
        /// </remarks>
        public event KeyPressEventHandler KeyPress;
        /// <summary>
        /// Occurs when a key is released while the control has focus.
        /// </summary>
        /// <remarks>
        /// http://msdn.microsoft.com/en-us/library/system.windows.forms.control.keyup(v=vs.110).aspx
        /// </remarks>
        public event KeyEventHandler KeyUp;

        private List<Framework.Windows.Forms.Keys> GetPressedKeys()
        {
            List<Framework.Windows.Forms.Keys> pressedKeys = GetPressedKeys(_kNow);
            List<Framework.Windows.Forms.Keys> prevPressedKeys = GetPressedKeys(_kPrev);

            List<Framework.Windows.Forms.Keys> result = new List<Framework.Windows.Forms.Keys>();
            bool shiftPressed = false;

            for (int i = 0; i < pressedKeys.Count; i++)
            {
                if ((pressedKeys[i] & Framework.Windows.Forms.Keys.Shift) == Framework.Windows.Forms.Keys.Shift)
                    shiftPressed = true;
                else
                {
                    if (IsKeyUp(prevPressedKeys, pressedKeys[i]))
                    {
                        result.Add(pressedKeys[i]);

                        if (keysPressedAt.ContainsKey(pressedKeys[i]))
                            keysPressedAt.Remove(pressedKeys[i]);

                        if (keyLastTickAt.ContainsKey(pressedKeys[i]))
                            keyLastTickAt.Remove(pressedKeys[i]);
                    }
                    else
                    {
                        if (keysPressedAt.ContainsKey(pressedKeys[i]))
                        {
                            TimeSpan timeDifference = DateTime.Now - keysPressedAt[pressedKeys[i]];

                            if (timeDifference > new TimeSpan(0, 0, 0, 0, 250) && (keyLastTickAt.ContainsKey(pressedKeys[i]) && DateTime.Now - keyLastTickAt[pressedKeys[i]] > new TimeSpan(0, 0, 0, 0, 35) || !keyLastTickAt.ContainsKey(pressedKeys[i])))
                            {
                                result.Add(pressedKeys[i]);

                                if (keyLastTickAt.ContainsKey(pressedKeys[i]))
                                    keyLastTickAt[pressedKeys[i]] = DateTime.Now;
                                else
                                    keyLastTickAt.Add(pressedKeys[i], DateTime.Now);
                                //keysHeld[pressedKeys[i]] = DateTime.Now;
                            }
                        }
                    }

                    if (!keysPressedAt.ContainsKey(pressedKeys[i]))
                        keysPressedAt.Add(pressedKeys[i], DateTime.Now);
                }
            }

            if (shiftPressed)
                for (int i = 0; i < result.Count; i++)
                    result[i] = result[i] | Framework.Windows.Forms.Keys.Shift;

            return result;
        }

        private static bool IsKeyDown(List<Framework.Windows.Forms.Keys> pressedKeys, Framework.Windows.Forms.Keys key)
        {
            for (int i = 0; i < pressedKeys.Count; i++)
                if (pressedKeys[i] == key)
                    return true;

            return false;
        }

        private static bool IsKeyUp(List<Framework.Windows.Forms.Keys> pressedKeys, Framework.Windows.Forms.Keys key)
        {
            for (int i = 0; i < pressedKeys.Count; i++)
                if (pressedKeys[i] == key)
                    return false;

            return true;
        }

        private static Framework.Windows.Forms.Keys XnaKeyToKey(Microsoft.Xna.Framework.Input.Keys key)
        {
            Framework.Windows.Forms.Keys kv = Framework.Windows.Forms.Keys.None;

            switch (key)
            {
                case Microsoft.Xna.Framework.Input.Keys.OemComma:
                    kv = Framework.Windows.Forms.Keys.Oemcomma;
                    break;
                case Microsoft.Xna.Framework.Input.Keys.OemTilde:
                    kv = Framework.Windows.Forms.Keys.Oemtilde;
                    break;
                case Microsoft.Xna.Framework.Input.Keys.OemPlus:
                    kv = Framework.Windows.Forms.Keys.Oemplus;
                    break;
                default:
                    if (Enum.IsDefined(typeof(Framework.Windows.Forms.Keys), key.ToString()) | key.ToString().Contains(","))
                        kv = kv | (Framework.Windows.Forms.Keys)Enum.Parse(typeof(Framework.Windows.Forms.Keys), key.ToString());
                    break;
            }

            //if ((key & Microsoft.Xna.Framework.Input.Keys.LeftShift) == Microsoft.Xna.Framework.Input.Keys.LeftShift)
            //{
            //    //kv = kv | Framework.Windows.Forms.Keys.LShiftKey;
            //    kv = kv | Framework.Windows.Forms.Keys.Shift;
            //}
            //if ((key & Microsoft.Xna.Framework.Input.Keys.RightShift) == Microsoft.Xna.Framework.Input.Keys.RightShift)
            //{
            //    //kv = kv | Framework.Windows.Forms.Keys.RShiftKey;
            //    kv = kv | Framework.Windows.Forms.Keys.Shift;
            //}
            //if ((key & Microsoft.Xna.Framework.Input.Keys.RightShift) == Microsoft.Xna.Framework.Input.Keys.RightShift)
            if (key == Microsoft.Xna.Framework.Input.Keys.LeftShift)
                kv = Framework.Windows.Forms.Keys.LShiftKey | Framework.Windows.Forms.Keys.Shift;
            if (key == Microsoft.Xna.Framework.Input.Keys.RightShift)
                kv = Framework.Windows.Forms.Keys.RShiftKey | Framework.Windows.Forms.Keys.Shift;
            
            return kv;
        }
    }
}
