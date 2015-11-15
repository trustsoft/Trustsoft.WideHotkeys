//------------------------Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.------------------------
// <copyright file="Hotkey.cs" company="Trustsoft Ltd.">
//     Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.
// </copyright>
// <date>07.04.2015</date>
//------------------------Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.------------------------

namespace Trustsoft.WideHotkeys
{
    #region " Using Directives "

    using System;
    using System.Runtime.InteropServices;

    using Trustsoft.WideHotkeys.Interop;

    #endregion

    /// <summary>
    ///     Represents global (system-wide) hot key.
    /// </summary>
    public class Hotkey
    {
        #region " Static Fields "

        private static int nextId;

        #endregion

        #region " Fields "

        private IntPtr windowHandle;

        #endregion

        #region " Public Properties "

        public EventHandler<HotkeyEventArgs> Handler { get; private set; }

        /// <summary>
        ///     Gets a numeric id of <see cref="Hotkey"/>.
        /// </summary>
        public int Id { get; private set; }

        public HotkeyModifiers Modifiers { get; private set; }

        public bool Registered { get; private set; }

        public uint VirtualKey { get; private set; }

        #endregion

        #region " Constructors / Destructors "

        public Hotkey(uint virtualKey, HotkeyModifiers flags, EventHandler<HotkeyEventArgs> handler)
        {
            this.Id = ++nextId;
            this.VirtualKey = virtualKey;
            this.Modifiers = flags;
            this.Handler = handler;
        }

        #endregion

        #region " Public Methods "

        public void Register(IntPtr windowHandle, string name)
        {
            if (!NativeMethods.RegisterHotKey(windowHandle, this.Id, this.Modifiers, this.VirtualKey))
            {
                var hr = Marshal.GetHRForLastWin32Error();
                var ex = Marshal.GetExceptionForHR(hr);

                //if ((uint)hr == 0x80070581)
                //    throw new HotkeyAlreadyRegisteredException(name, ex);
                throw ex;
            }
            this.windowHandle = windowHandle;
            this.Registered = true;
        }

        public void Unregister()
        {
            if (this.windowHandle != IntPtr.Zero)
            {
                if (!NativeMethods.UnregisterHotKey(this.windowHandle, this.Id))
                {
                    var hr = Marshal.GetHRForLastWin32Error();
                    throw Marshal.GetExceptionForHR(hr);
                }
                this.windowHandle = IntPtr.Zero;
                this.Registered = false;
            }
        }

        #endregion
    }
}