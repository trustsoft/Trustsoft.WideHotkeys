//------------------------Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.------------------------
// <copyright file="HotkeyManager.cs" company="Trustsoft Ltd.">
//     Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.
// </copyright>
// <date>07.04.2015</date>
//------------------------Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.------------------------

namespace Trustsoft.WideHotkeys
{
    #region " Using Directives "

    using System;
    using System.Windows.Input;
    using System.Windows.Interop;

    #endregion

    public class HotkeyManager : HotkeyManagerBase
    {
        #region " Constructors / Destructors "

        public HotkeyManager()
        {
            var parameters = new HwndSourceParameters("Hotkey sink")
                             {
                                 HwndSourceHook = this.HandleHotkey,
                                 ParentWindow = HwndMessage
                             };
            var source = new HwndSource(parameters);
            this.WindowHandle = source.Handle;
        }

        #endregion

        #region " Private Methods "

        private IntPtr HandleHotkey(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam, ref bool handled)
        {
            Hotkey hotkey;
            var result = this.HandleHotkeyMessage(hwnd, msg, wparam, lparam, ref handled, out hotkey);
            if (handled)
            {
                return result;
            }

            return result;
        }

        #endregion

        #region " Public Methods "

        public void AddOrReplace(string name,
                                 Key key,
                                 ModifierKeys flags,
                                 EventHandler<HotkeyEventArgs> handler)
        {
            var vk = (uint)KeyInterop.VirtualKeyFromKey(key);
            base.AddOrReplace(name, vk, (HotkeyModifiers)flags, handler);
        }

        #endregion
    }
}