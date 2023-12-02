namespace add_contact
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonAddContact = new Button();
            buttonEditContact = new Button();
            SuspendLayout();
            // 
            // buttonAddContact
            // 
            buttonAddContact.Location = new Point(43, 51);
            buttonAddContact.Name = "buttonAddContact";
            buttonAddContact.Size = new Size(189, 34);
            buttonAddContact.TabIndex = 0;
            buttonAddContact.Text = "Add Contact";
            buttonAddContact.UseVisualStyleBackColor = true;
            // 
            // buttonEditContact
            // 
            buttonEditContact.Location = new Point(43, 114);
            buttonEditContact.Name = "buttonEditContact";
            buttonEditContact.Size = new Size(189, 34);
            buttonEditContact.TabIndex = 0;
            buttonEditContact.Text = "Edit Contact";
            buttonEditContact.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(478, 244);
            Controls.Add(buttonEditContact);
            Controls.Add(buttonAddContact);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Form";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonAddContact;
        private Button buttonEditContact;
    }
}
