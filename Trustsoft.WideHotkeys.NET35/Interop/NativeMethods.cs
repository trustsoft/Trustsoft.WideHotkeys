﻿//------------------------Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.------------------------
// <copyright file="NativeMethods.cs" company="Trustsoft Ltd.">
//     Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.
// </copyright>
// <date>07.04.2015</date>
//------------------------Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.------------------------

namespace Trustsoft.WideHotkeys.Interop
{
    #region " Using Directives "

    using System;
    using System.Runtime.InteropServices;

    #endregion

    internal static class NativeMethods
    {
        #region " Static Methods "

        public static bool RegisterHotKey(IntPtr hWnd, int id, HotkeyModifiers modifiers, uint virtualKey)
        {
            return RegisterHotkey(hWnd, id, (uint)modifiers, virtualKey);
        }

        /// <summary>
        ///     The RegisterHotkey function defines a system-wide hot key.
        /// </summary>
        /// <param name="hWnd">
        ///     A handle to the window that will receive WM_HOTKEY messages generated by the hot key. If
        ///     this parameter is NULL, WM_HOTKEY messages are posted to the message queue of the calling
        ///     thread and must be processed in the message loop.
        /// </param>
        /// <param name="id">
        ///     Specifies the identifier of the hot key. No other hot key in the calling thread should
        ///     have the same identifier. An application must specify a value in the range 0x0000 through
        ///     0xBFFF. A shared DLL must specify a value in the range 0xC000 through 0xFFFF (the range
        ///     returned by the GlobalAddAtom function). To avoid conflicts with hot-key identifiers
        ///     defined by other shared DLLs, a DLL should use the GlobalAddAtom function to obtain the
        ///     hot-key identifier.
        /// </param>
        /// <param name="fsModifiers">
        ///     Specifies keys that must be pressed in combination with the key specified by the
        ///     virtualKeys parameter in order to generate the WM_HOTKEY message. The
        ///     <paramref name="fsModifiers"/>parameter can be a combination of the following values.
        ///     <see cref="HotkeyModifiers"/>.Alt Either ALT key must be held down.
        ///     <see cref="HotkeyModifiers"/>.Control Either CTRL key must be held down.
        ///     <see cref="HotkeyModifiers"/>.Shift Either SHIFT key must be held down.
        ///     <see cref="HotkeyModifiers"/>.Windows Either WINDOWS key was held down.
        /// </param>
        /// <param name="virtualKeys"> Specifies the virtual-key code of the hot key. </param>
        /// <returns> </returns>
        [DllImport(ExternDll.User32, EntryPoint = @"RegisterHotKey", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool RegisterHotkey(IntPtr hWnd, int id, uint fsModifiers, uint virtualKeys);

        /// <summary>
        ///     The UnregisterHotkey function frees a hot key previously registered by the calling thread.
        /// </summary>
        /// <param name="hWnd">
        ///     Handle to the window associated with the hot key to be freed. This parameter should be
        ///     NULL if the hot key is not associated with a window.
        /// </param>
        /// <param name="id">
        ///     Specifies the identifier of the hot key to be freed.
        /// </param>
        /// <returns> </returns>
        [DllImport(ExternDll.User32, EntryPoint = @"UnregisterHotKey", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        #endregion
    }
}