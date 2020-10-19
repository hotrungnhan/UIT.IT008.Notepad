using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Nodepad.component;
using Nodepad.component.Enum;

namespace Nodepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Nodepad.component.TextBox FindTextBox(codeTab tab)
        {
            var firstitem = tab.Controls.Find("textbox", true).FirstOrDefault();
            if (firstitem is Nodepad.component.TextBox)
            {
                var textbox = (Nodepad.component.TextBox)firstitem;
                return textbox;
            }
            return null;
        }
        private void SaveTextFile_Click(object sender, EventArgs e)
        {
            var textbox = FindTextBox((codeTab)this.tabControl1.SelectedTab);
            textbox.SaveFile();
        }
        private void LoadTextFile_Click(object sender, EventArgs e)
        {
            var textbox = FindTextBox((codeTab)this.tabControl1.SelectedTab);
            textbox.LoadFile();
        }
        private void new_BTN(object sender, EventArgs e)
        {
            var tab = new codeTab();
            tab.Text = $"New draft ({tabControl1.TabPages.Count})";
            tabControl1.Controls.Add(tab);
        }

        private void KeyDownpaste(object sender, KeyEventArgs e)
        {

            //if (e.Control && e.KeyCode == Keys.V)
            //{
            //    richTextBox1.Text += (string)Clipboard.GetData("Text");
            //    e.Handled = true;
            //    Console.WriteLine("paste");
            //}
            //var a = $"{e.Control}";
            //Console.WriteLine(a);
            //if (e.Control && e.KeyCode == Keys.C)
            //{
            //    Console.WriteLine("copy");
            //    Clipboard.SetText(richTextBox1.SelectedText);
            //    e.Handled = true;
            //}
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Copy_click(object sender, EventArgs e)
        {
            var textbox = FindTextBox((codeTab)this.tabControl1.SelectedTab);
            textbox.Copy();
        }
        private void Paste_click(object sender, EventArgs e)
        {
            var textbox = FindTextBox((codeTab)this.tabControl1.SelectedTab);
            textbox.Paste();
        }

        private void SubMenu_Click(object sender, EventArgs e)
        {
            var currentItem = sender as ToolStripMenuItem;
            if (currentItem != null)
            {
                ((ToolStripMenuItem)currentItem.OwnerItem).DropDownItems
                    .OfType<ToolStripMenuItem>().ToList()
                    .ForEach(item =>
                    {
                        item.Checked = false;
                    });
                // set tab Lang item;
                var currenttab = FindTextBox((codeTab)this.tabControl1.SelectedTab);
                //Console.WriteLine((currentItem.Tag).ToString());
                currenttab.Lang = LangFunc.getCodeByExtension((currentItem.Tag).ToString());
                //Check the current items
                currentItem.Checked = true;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
