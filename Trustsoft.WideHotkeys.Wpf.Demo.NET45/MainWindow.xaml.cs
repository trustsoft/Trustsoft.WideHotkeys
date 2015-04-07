//------------------------Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.------------------------
// <copyright file="MainWindow.xaml.cs" company="Trustsoft Ltd.">
//     Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.
// </copyright>
// <date>07.04.2015</date>
//------------------------Copyright © 2012-2015 Trustsoft Ltd. All rights reserved.------------------------

namespace Trustsoft.WideHotkeys.Wpf.Demo
{
    #region " Using Directives "

    using System.Windows.Input;

    #endregion

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region " Constructors / Destructors "

        public MainWindow()
        {
            this.InitializeComponent();
            var hkm = new HotkeyManager();
            hkm.AddOrReplace("Increment", Key.S, ModifierKeys.Control | ModifierKeys.Alt, this.OnHotkey1);
            hkm.AddOrReplace("Decrement", Key.D, ModifierKeys.Control | ModifierKeys.Alt, this.OnHotkey2);
        }

        #endregion

        #region " Private Methods "

        private void OnHotkey1(object sender, HotkeyEventArgs e)
        {
            this.ListBox.Items.Add("Ctrl+Alt+S Hotkey pressed");

            e.Handled = true;
        }

        private void OnHotkey2(object sender, HotkeyEventArgs e)
        {
            this.ListBox.Items.Add("Ctrl+Alt+D Hotkey pressed");

            e.Handled = true;
        }

        #endregion
    }
}