using System.Windows.Controls;
using System.Windows.Forms;

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
            this.mainbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainbox.EnableAutoDragDrop = true;
            this.mainbox.Location = new System.Drawing.Point(68, 0);
            this.mainbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainbox.Name = "mainbox";
            this.mainbox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.mainbox.Size = new System.Drawing.Size(481, 381);
            this.mainbox.TabIndex = 1;
            this.mainbox.Text = "";
            this.mainbox.WordWrap = false;
            this.mainbox.TextChanged += new System.EventHandler(this.TextColorUp);
            // 
            // linebox
            // 
            this.linebox.Dock = System.Windows.Forms.DockStyle.Left;
            this.linebox.Enabled = false;
            this.linebox.Location = new System.Drawing.Point(0, 0);
            this.linebox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.linebox.Name = "linebox";
            this.linebox.Size = new System.Drawing.Size(68, 381);
            this.linebox.TabIndex = 1;
            this.linebox.Text = "1";
            this.linebox.WordWrap = false;
            // 
            // TextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainbox);
            this.Controls.Add(this.linebox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TextBox";
            this.Size = new System.Drawing.Size(549, 381);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox mainbox;
        public System.Windows.Forms.RichTextBox linebox;
    }
}
