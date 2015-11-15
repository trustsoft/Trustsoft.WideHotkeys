//------------------------Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.------------------------
// <copyright file="HotkeyModifiers.cs" company="Trustsoft Ltd.">
//     Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.
// </copyright>
// <date>07.04.2015</date>
//------------------------Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.------------------------

namespace Trustsoft.WideHotkeys
{
    #region " Using Directives "

    using System;

    #endregion

    /// <summary>
    ///     Specifies the set of modifier keys.
    /// </summary>
    [Flags]
    public enum HotkeyModifiers
    {
        /// <summary>
        ///     No modifiers are pressed.
        /// </summary>
        None = 0x0,

        /// <summary>
        ///     The ALT key.
        /// </summary>
        Alt = 0x1,

        /// <summary>
        ///     The CTRL key.
        /// </summary>
        Control = 0x2,

        /// <summary>
        ///     The SHIFT key.
        /// </summary>
        Shift = 0x4,

        /// <summary>
        ///     The Windows logo key.
        /// </summary>
        Windows = 0x8,
    }
}