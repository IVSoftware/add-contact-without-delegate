namespace add_contact
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Disposed += (sender, e) =>AddOrEditContactForm.Dispose();
            buttonAddContact.Click += (sender, e) =>
            {
                switch (AddOrEditContactForm.ShowDialog(this))
                {
                    case DialogResult.OK: 
                        MessageBox.Show($"Added: {AddOrEditContactForm.Contact}"); 
                        break;
                    case DialogResult.Cancel: MessageBox.Show("Cancelled!"); break;
                }
            };
            buttonEditContact.Click += (sender, e) =>
            {
                var mockEditContact = new Contact { Name = "Tommy IV" };
                switch (AddOrEditContactForm.ShowDialog(this, mockEditContact))
                {
                    case DialogResult.OK:
                        MessageBox.Show($"Edited: {AddOrEditContactForm.Contact}");
                        break;
                    case DialogResult.Cancel: MessageBox.Show("Cancelled!"); break;
                }                
            };
        }
        AddOrEditContactForm AddOrEditContactForm { get; } = new AddOrEditContactForm();
    }
}
