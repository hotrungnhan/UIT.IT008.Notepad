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
using System.IO;

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
        //??? nhung co ve huu dung
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
        //------------------------------------------------------------------------------------------
        // Phan chuc nang thuc dung ne !
        //File ne
        //Save file ne
        private void SaveTextFile_Click(object sender, EventArgs e)
        {
            var textbox = FindTextBox((codeTab)this.tabControl1.SelectedTab);
            textbox.SaveFile();
        }
        //Load file ne
        private void LoadTextFile_Click(object sender, EventArgs e)
        {
            var textbox = FindTextBox((codeTab)this.tabControl1.SelectedTab);
            textbox.LoadFile();
        }
        // New tab ne
        private void new_BTN(object sender, EventArgs e)
        {
            var tab = new codeTab();
            tab.Text = $"New draft ({tabControl1.TabPages.Count})";
            tabControl1.Controls.Add(tab);
            //chung current sang tab moi tao
            tabControl1.SelectedTab = tab;

        }
        //New win ne
        private void OpenNewNodepad(object sender, EventArgs e)
        {
            Form1 NewNote = new Form1();
            int Index = System.Windows.Forms.Application.OpenForms.Count;

            NewNote.Text = "NewNodepad (" + Index.ToString() + ")";
            NewNote.Show();
        }
        //exit ne
        private void exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        // Cha bik la j ne
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
        //------------------------------------------------------------------------------
        //EDIT ne
        // Cut ne
        private void Cut_click(object sender, EventArgs e)
        {
            var textbox = FindTextBox((codeTab)this.tabControl1.SelectedTab);
            //Xem ham dan trong Textbox.design.cs nhe 
            //Chu dich de mainbox private nen tui viet dam ba ham o trong do
            textbox.CutSelectedTextInMainBox();
        }
        //Copy ne
        private void Copy_click(object sender, EventArgs e)
        {
            var textbox = FindTextBox((codeTab)this.tabControl1.SelectedTab);
            textbox.Copy();
        }
        //Paste ne
        private void Paste_click(object sender, EventArgs e)
        {
            var textbox = FindTextBox((codeTab)this.tabControl1.SelectedTab);
            textbox.Paste();
        }
        //Undo ne
        private void undo_Click(object sender, EventArgs e)
        {
            var textBox = FindTextBox((codeTab)this.tabControl1.SelectedTab);
            textBox.UndoMainBox();
        }
        //Redo ne
        private void redo_Click(object sender, EventArgs e)
        {
            var textBox = FindTextBox((codeTab)this.tabControl1.SelectedTab);
            textBox.RedoMainBox();
        }
        //delete ne
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var textBox = FindTextBox((codeTab)this.tabControl1.SelectedTab);

            textBox.DeleteSelectedTextInMainBox();
        }
        //Select All ne
        private void SelectAll_Click(object sender, EventArgs e)
        {
            var textBox = FindTextBox((codeTab)this.tabControl1.SelectedTab);
            textBox.SelectAllTextInMainBox();
        }

        //Khong bik la j nhung xoa di se error nhe
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //Viet tiep ne
        #region ToolstripButton

        private void Print_Click(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {

            if (tabControl1.TabCount != 1)
            {
                tabControl1.SelectedTab.Dispose();
                tabControl1.SelectTab(tabControl1.TabCount - 1);
            }
            else
                exit_Click(sender, e);
        }

        private void CloseAll_Click(object sender, EventArgs e)
        {
            tabControl1.Dispose();
            new_BTN(sender, e);
        }

        private void Find_Click(object sender, EventArgs e)
        {

        }

        private void Replace_Click(object sender, EventArgs e)
        {

        }


        #endregion
    }
}