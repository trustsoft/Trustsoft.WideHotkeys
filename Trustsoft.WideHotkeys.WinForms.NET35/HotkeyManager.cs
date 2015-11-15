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
    using System.Windows.Forms;

    #endregion

    public class HotkeyManager : HotkeyManagerBase
    {
        #region " Static Methods "

        private static HotkeyModifiers GetModifiers(Keys hotkey)
        {
            var noMod = hotkey & ~Keys.Modifiers;
            var flags = HotkeyModifiers.None;
            if (hotkey.HasFlag(Keys.Alt))
            {
                flags |= HotkeyModifiers.Alt;
            }
            if (hotkey.HasFlag(Keys.Control))
            {
                flags |= HotkeyModifiers.Control;
            }
            if (hotkey.HasFlag(Keys.Shift))
            {
                flags |= HotkeyModifiers.Shift;
            }

            //if (noMod == Keys.LWin || noMod == Keys.RWin)
            //    flags |= HotkeyModifiers.Windows;
            if (hotkey.HasFlag(Keys.LWin))
            {
                flags |= HotkeyModifiers.Windows;
            }
            if (hotkey.HasFlag(Keys.RWin))
            {
                flags |= HotkeyModifiers.Windows;
            }
            return flags;
        }

        #endregion

        #region " Fields "

        private readonly MessageSinkWindow messageSinkWindow;

        #endregion

        #region " Constructors / Destructors "

        public HotkeyManager()
        {
            this.messageSinkWindow = new MessageSinkWindow(this);
            this.WindowHandle = this.messageSinkWindow.Handle;
        }

        #endregion

        #region " Internal Methods "

        internal IntPtr HandleHotkey(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam, ref bool handled)
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

        public void AddOrReplace(string name, Keys keys, EventHandler<HotkeyEventArgs> handler)
        {
            var flags = GetModifiers(keys);
            var vk = unchecked((uint)(keys & ~Keys.Modifiers));
            AddOrReplace(name, vk, flags, handler);
        }

        #endregion
    }
    static class Extensions
    {
        public static bool HasFlag(this Keys keys, Keys flag)
        {
            return (keys & flag) == flag;
        }
    }
}