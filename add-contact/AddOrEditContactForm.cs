using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace add_contact
{
    public partial class AddOrEditContactForm : Form
    {
        public AddOrEditContactForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            CancelButton = buttonCancel;
            AcceptButton = buttonOK;
            buttonOK.Enabled = false;
            buttonOK.Click += (sender, e) =>
            {
                Contact = new Contact { Name = textBoxName.Text };
                DialogResult = DialogResult.OK;
            };
            buttonCancel.Click += (sender, e) => DialogResult = DialogResult.Cancel;
            textBoxName.TextChanged += (sender, e) => validateForm();
        }
        private void validateForm()
        {
            if( !string.IsNullOrEmpty(textBoxName.Text)) // && textBoxEmail.Text.IsValidEmail() etc...
            {
                buttonOK.Enabled = true;
            }
            else  buttonOK.Enabled = false;
        }
        public Contact? Contact { get; private set; }
        /// <summary>
        /// Made a new contact, or edit an existing one.
        /// </summary>
        public DialogResult ShowDialog(IWin32Window owner, object? args = null)
        {
            if (args is Contact contact)
            {
                textBoxName.Text = contact.Name;
            }
            else localClearForm();
            return base.ShowDialog(owner);
            
            void localClearForm()
            {
                foreach (var textBox in Controls.OfType<TextBox>()) textBox.Clear();
                foreach (var combobox in Controls.OfType<ComboBox>()) combobox.SelectedIndex = -1;
            }
        }
    }
    public class Contact
    {
        public string? Name { get; set; }
        public override string ToString() => $"Name: {Name}";
    }
}
