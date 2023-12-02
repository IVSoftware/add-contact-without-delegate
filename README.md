# Add or Edit Contact with ShowDialog

This is a bit tricky. Your question starts out as being about learning to use delegates, and Jimi's answer has given that a good treatment [▲]. But, your post (as it reads today) states that your primary concern is:

>#1. Am I approaching this problem in a completely non-best practice way? 

The aim of this answer is to offer a perspective on that.
___
##### Built to the Task

The `ShowDialog()` method is already well-suited for what you're doing. Unlike the `Show` method, the `Form.Handle` does not dispose as a result of closing the dialog, so you can show it repeatedly without consequence. To use it this way, you would make it a member of your `MainForm` class, and wait for the `MainForm.Disposed` event to dispose its `Handle`.

Since `AddOrEditContactForm` keeps its state, no event is required. Just check whether the operation was accepted or canceled, and inspect the `Contact` property if it's known to be valid.

[![add contact work flow][1]][1]

```
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
```
___

Then, to optionally make this a multi-purpose Add or Edit form, just overload the `ShowDialog` to accept a `Contact` to preload, and of none is provided clear all the controls to give the user a fresh start.

```
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
    /// Make a new contact, or edit an existing one.
    /// </summary>
    public DialogResult ShowDialog(Form owner, object? args = null)
    {
        Owner = owner;
        if (args is Contact contact)
        {
            Text = "Edit Contact";
            textBoxName.Text = contact.Name;
        }
        else localClearForm();
        return base.ShowDialog(owner);
            
        void localClearForm()
        {
            Text = "Add Contact";
            foreach (var textBox in Controls.OfType<TextBox>()) textBox.Clear();
            foreach (var combobox in Controls.OfType<ComboBox>()) combobox.SelectedIndex = -1;
        }
    }
}
```

___

###### Mock Contact

```
public class Contact
{
    public string? Name { get; set; }
    public override string ToString() => $"Name: {Name}";
}
```


  [1]: https://i.stack.imgur.com/Bh7u3.png