namespace Nodepad.component
{
    partial class TextBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainbox = new System.Windows.Forms.RichTextBox();
            this.linebox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // mainbox
            // 
            this.mainbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainbox.Location = new System.Drawing.Point(72, 0);
            this.mainbox.Name = "mainbox";
            this.mainbox.Size = new System.Drawing.Size(1010, 621);
            this.mainbox.TabIndex = 2;
            this.mainbox.Text = "";
            this.mainbox.TextChanged += new System.EventHandler(this.TextColorUp);
            // 
            // linebox
            // 
            this.linebox.Dock = System.Windows.Forms.DockStyle.Left;
            this.linebox.Enabled = false;
            this.linebox.Location = new System.Drawing.Point(0, 0);
            this.linebox.Name = "linebox";
            this.linebox.Size = new System.Drawing.Size(72, 621);
            this.linebox.TabIndex = 1;
            this.linebox.Text = "";
            // 
            // TextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linebox);
            this.Controls.Add(this.mainbox);
            this.Name = "TextBox";
            this.Size = new System.Drawing.Size(1082, 621);
            this.ResumeLayout(false);

            OriginalText = "";
        }

        #endregion

        private System.Windows.Forms.RichTextBox mainbox;
        private System.Windows.Forms.RichTextBox linebox;
        private string OriginalText;

        public  System.Windows.Forms.RichTextBox _mainbox;
        public System.Windows.Forms.RichTextBox GetMainBox()
        {
            return mainbox;
        }
        public void SetOriginalText(string LoadText)
        {
            OriginalText = LoadText;
        }
        public string GetOriginalText()
        {
            return OriginalText;
        }
        public void SelectAllTextInMainBox()
        {
            mainbox.SelectAll();
        }
        public string SelectedTextInMainBox()
        {
            return mainbox.SelectedText;
        }
        public void DeleteSelectedTextInMainBox()
        {
            this.mainbox.SelectedText = "";
        }
        public void CopySelectedTextInMainBox()
        {
            this.mainbox.Copy();
        }
        public void PasteSelectedTextInMainBox()
        {
            this.mainbox.Paste();
        }
        public void CutSelectedTextInMainBox()
        {
            this.mainbox.Cut();
        }
        public void UndoMainBox()
        {
            this.mainbox.Undo();
        }
        public int GetLength()
        {
            return mainbox.Text.Length;
        }
        public void RedoMainBox()
        {
            this.mainbox.Redo();
        }

        //save

    }
}