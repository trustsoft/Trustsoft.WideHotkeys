namespace Trustsoft.WideHotkeys.WinForms.Demo.NET45
{
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.InitializeComponent();
            var hkm = new HotkeyManager();
            hkm.AddOrReplace("Increment", Keys.S | Keys.Control | Keys.Alt, this.OnHotkey1);
            hkm.AddOrReplace("Decrement", Keys.D | Keys.Control | Keys.Alt, this.OnHotkey2);
        }

        private void OnHotkey1(object sender, HotkeyEventArgs e)
        {
            this.listBox.Items.Add("Ctrl+Alt+S Hotkey pressed");

            e.Handled = true;
        }

        private void OnHotkey2(object sender, HotkeyEventArgs e)
        {
            this.listBox.Items.Add("Ctrl+Alt+D Hotkey pressed");

            e.Handled = true;
        }
    }
}
