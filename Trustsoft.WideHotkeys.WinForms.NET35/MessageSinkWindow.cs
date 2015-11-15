//------------------------Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.------------------------
// <copyright file="NativeWindowEx.cs" company="Trustsoft Ltd.">
//     Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.
// </copyright>
// <date>08.04.2015</date>
//------------------------Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.------------------------

namespace Trustsoft.WideHotkeys
{
    #region " Using Directives "

    using System;
    using System.Security.Permissions;
    using System.Windows.Forms;

    #endregion

    internal sealed class MessageSinkWindow : NativeWindow, IDisposable
    {
        #region " Constants "

        private const int WM_HOTKEY = 0x0312;

        #endregion

        #region " Fields "

        private readonly HotkeyManager hotkeyManager;

        #endregion

        #region " Public Properties "

        /// <summary>
        ///     Gets a value indicating whether the window handle has been created.
        /// </summary>
        /// <value> <b> True </b> if the handle has been created. <b> False </b> otherwise. </value>
        public bool IsHandleCreated
        {
            get
            {
                return this.Handle != IntPtr.Zero;
            }
        }

        #endregion

        #region " Constructors / Destructors "

        /// <summary>
        ///     Initializes an instance of the <see cref="T:System.Windows.Forms.NativeWindow"/> class.
        /// </summary>
        public MessageSinkWindow(HotkeyManager hotkeyManager)
        {
            this.hotkeyManager = hotkeyManager;
            this.CreateHandle(new CreateParams {ClassName = "Message"});
        }

        #endregion

        #region " Protected Methods "

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                bool handled = false;
                this.hotkeyManager.HandleHotkey(this.Handle, m.Msg, m.WParam, m.LParam, ref handled);

                if (handled)
                {
                    return;
                }
            }

            base.WndProc(ref m);
        }

        #endregion

        #region " Implementation of IDisposable "

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // release unmanaged resource
            if (this.IsHandleCreated)
            {
                this.DestroyHandle();
            }
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}