//------------------------Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.------------------------
// <copyright file="HotkeyManagerBase.cs" company="Trustsoft Ltd.">
//     Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.
// </copyright>
// <date>07.04.2015</date>
//------------------------Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.------------------------

namespace Trustsoft.WideHotkeys
{
    #region " Using Directives "

    using System;
    using System.Collections.Generic;

    #endregion

    /// <summary>
    ///     Provides the base class from which the classes that represent specific hotkey manager are derived.
    /// </summary>
    public abstract class HotkeyManagerBase
    {
        #region " Constants "

        // ReSharper disable once InconsistentNaming
        private const int WM_HOTKEY = 0x0312;

        #endregion

        #region " Static Fields "

        protected static readonly IntPtr HwndMessage = (IntPtr)(-3);

        #endregion

        #region " Fields "

        private readonly Dictionary<int, string> hotkeyNames = new Dictionary<int, string>();
        private readonly Dictionary<string, Hotkey> hotkeys = new Dictionary<string, Hotkey>();

        #endregion

        #region " Protected Properties "

        protected IntPtr WindowHandle { get; set; }

        #endregion

        #region " Protected Methods "

        protected void AddOrReplace(string name,
                                    uint virtualKey,
                                    HotkeyModifiers flags,
                                    EventHandler<HotkeyEventArgs> handler)
        {
            var hotkey = new Hotkey(virtualKey, flags, handler);
            lock (this.hotkeys)
            {
                this.Remove(name);
                this.hotkeys.Add(name, hotkey);
                this.hotkeyNames.Add(hotkey.Id, name);
                if (this.WindowHandle != IntPtr.Zero)
                {
                    hotkey.Register(this.WindowHandle, name);
                }
            }
        }

        protected IntPtr HandleHotkeyMessage(IntPtr windowHandle,
                                             int msg,
                                             IntPtr wParam,
                                             IntPtr lParam,
                                             ref bool handled,
                                             out Hotkey hotkey)
        {
            if (msg == WM_HOTKEY)
            {
                int id = wParam.ToInt32();
                string name;
                lock (this.hotkeys)
                {
                    if (this.hotkeyNames.TryGetValue(id, out name))
                    {
                        hotkey = this.hotkeys[name];
                        var handler = hotkey.Handler;
                        if (handler != null)
                        {
                            var e = new HotkeyEventArgs(name, hotkey);
                            handler(this, e);
                            handled = e.Handled;
                        }
                    }
                }
            }
            hotkey = null;
            return IntPtr.Zero;
        }

        #endregion

        #region " Public Methods "

        public void Remove(string name)
        {
            lock (this.hotkeys)
            {
                Hotkey hotkey;
                if (this.hotkeys.TryGetValue(name, out hotkey))
                {
                    this.hotkeys.Remove(name);
                    this.hotkeyNames.Remove(hotkey.Id);
                    if (this.WindowHandle != IntPtr.Zero)
                    {
                        hotkey.Unregister();
                    }
                }
            }
        }

        public void Remove(int hotkeyId)
        {
            lock (this.hotkeys)
            {
                string name;
                if (this.hotkeyNames.TryGetValue(hotkeyId, out name))
                {
                    this.Remove(name);
                }
            }
        }

        #endregion
    }
}