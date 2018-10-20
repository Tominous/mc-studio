using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace MCStudio
{
    /*
    * KeyboardHook.cs by Nate Shoffner
    * http://nateshoffner.com
    */
    
    [Flags]
    public enum ModifierKeys : uint
    {
        None = 0,
        Alt = 1,
        Control = 2,
        Shift = 4,
    }

    public class KeyPressedEventArgs : EventArgs
    {
        internal KeyPressedEventArgs(ModifierKeys modifiers, Keys key)
        {
            Modifiers = modifiers;
            Key = key;
        }

        public Keys Key { get; private set; }
        public ModifierKeys Modifiers { get; private set; }
    }

    public class KeyboardHook : IDisposable
    {
        #region P/Invokes

        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        #endregion

        #region Delegates

        public delegate void KeyHookDelegate(object sender, EventArgs e);

        #endregion

        private readonly List<KeyHook> _keys = new List<KeyHook>();
        private readonly Timer _timer;

        public KeyboardHook()
        {
            _timer = new Timer { Interval = 75 };
            _timer.Elapsed += _timer_Elapsed;
        }

        public bool Enabled
        {
            get { return _timer.Enabled; }

            set
            {
                if (value)
                    _timer.Start();
                else
                    _timer.Stop();
            }
        }

        public event EventHandler<KeyPressedEventArgs> KeyPressed;

        public bool Hook(Keys key, ModifierKeys modifiers = ModifierKeys.None, KeyHookDelegate pressed = null)
        {
            if (_timer.Enabled)
                _timer.Stop();

            var exists = _keys.Find(x => x.Key == key && x.Modifiers == modifiers) != null;

            if (!exists)
            {
                _keys.Add(new KeyHook(key, modifiers, pressed));
                _keys.Sort((k1, k2) => new HookComparer().Compare(k1, k2));
            }

            if (_keys.Count > 0)
                _timer.Start();

            return !exists;
        }

        public bool Unhook(Keys key, ModifierKeys modifiers = ModifierKeys.None)
        {
            if (_timer.Enabled)
                _timer.Stop();

            var i = _keys.FindIndex(x => x.Key == key && x.Modifiers == modifiers);

            if (i >= 0)
            {
                _keys.RemoveAt(i);
                return true;
            }

            if (_keys.Count > 0)
                _timer.Start();

            return false;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            PollKeyStates();
        }

        private void PollKeyStates()
        {
            var altPressed = Convert.ToBoolean(GetAsyncKeyState(Keys.Menu));
            var controlPressed = Convert.ToBoolean(GetAsyncKeyState(Keys.ControlKey));
            var shiftPressed = Convert.ToBoolean(GetAsyncKeyState(Keys.ShiftKey));

            var pressedKeys = new List<Keys>();

            foreach (var key in _keys)
            {
                if ((GetAsyncKeyState(key.Key) == -32767))
                    pressedKeys.Add(key.Key);
            }

            foreach (var key in _keys)
            {
                if (!pressedKeys.Contains(key.Key))
                    continue;

                if ((key.Modifiers & ModifierKeys.None) == ModifierKeys.None)
                {
                    if ((key.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt && !altPressed)
                        continue;
                    if ((key.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && !controlPressed)
                        continue;
                    if ((key.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift && !shiftPressed)
                        continue;
                }

                pressedKeys.Remove(key.Key);

                KeyPressed?.Invoke(this, new KeyPressedEventArgs(key.Modifiers, key.Key));
            }
        }

        #region Nested type: HookComparer

        private class HookComparer : IComparer<KeyHook>
        {
            private static int GetModifierCount(ModifierKeys modifiers)
            {
                var iValue = (int)modifiers;
                var bitCount = 0;

                while (iValue != 0)
                {
                    iValue = iValue & (iValue - 1);
                    bitCount++;
                }

                return bitCount;
            }

            #region Implementation of IComparer<KeyHook>

            public int Compare(KeyHook x, KeyHook y)
            {
                var keyCompare = x.Key.CompareTo(y.Key);
                if (keyCompare != 0)
                    return keyCompare;

                var modifierCount = GetModifierCount(y.Modifiers).CompareTo(GetModifierCount(x.Modifiers));
                if (modifierCount != 0)
                    return modifierCount;

                return ((int)x.Modifiers).CompareTo((int)y.Modifiers);
            }

            #endregion
        }

        #region Implementation of IDisposable

        public void Dispose()
        {
            _timer.Stop();
            _timer.Dispose();
        }

        #endregion

        #region Nested type: KeyHook

        private class KeyHook
        {
            public KeyHook(Keys key, ModifierKeys modifiers, KeyHookDelegate pressed = null)
            {
                Key = key;
                Modifiers = modifiers;
                Pressed = pressed;
            }

            public Keys Key { get; private set; }
            public ModifierKeys Modifiers { get; private set; }
            public KeyHookDelegate Pressed { get; private set; }
        }

        #endregion
    }
    #endregion
}
