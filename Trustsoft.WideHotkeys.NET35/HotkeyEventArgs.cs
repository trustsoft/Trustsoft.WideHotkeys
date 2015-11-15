//------------------------Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.------------------------
// <copyright file="HotkeyEventArgs.cs" company="Trustsoft Ltd.">
//     Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.
// </copyright>
// <date>07.04.2015</date>
//------------------------Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.------------------------

namespace Trustsoft.WideHotkeys
{
    #region " Using Directives "

    using System;

    #endregion

    public class HotkeyEventArgs : EventArgs
    {
        #region " Public Properties "

        public bool Handled { get; set; }

        public Hotkey Hotkey { get; private set; }

        public string Name { get; private set; }

        #endregion

        #region " Constructors / Destructors "

        /// <summary>
        ///     Initializes a new instance of the <see cref="HotkeyEventArgs"/> class.
        /// </summary>
        /// <param name="name"> The name associated with hot key. </param>
        /// <param name="hotkey"> The hotkey. </param>
        public HotkeyEventArgs(string name, Hotkey hotkey)
        {
            this.Name = name;
            this.Hotkey = hotkey;
        }

        #endregion
    }
}