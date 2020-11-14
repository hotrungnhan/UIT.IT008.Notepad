﻿using System;
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
        //public void SaveFlagHandler()
        //{
        //    var textbox = FindTextBox((codeTab)this.tabControl1.SelectedTab);
        //    if (textbox.GetMainBox().Text != textbox.GetOriginalText())
        //        textbox.State = FileState.unsave;
        //    else
        //        textbox.State = FileState.save;
        //}
        //------------------------------------------------------------------------------------------
        // Phan chuc nang thuc dung ne !
        #region File_ne
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
            //Luu trang thai ban dau cua file dc load
            textbox.SetOriginalText(textbox.GetMainBox().Text);
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

            while (tabControl1.TabCount > 0)
                Close_Click(sender, e);
            Application.Exit();
        }
        #endregion File_ne
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
        #region EDIT_NE
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
        #endregion EDIT_NE



        //Viet tiep ne
        #region ToolstripButton

        private void Print_Click(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            var textbox = FindTextBox((codeTab)this.tabControl1.SelectedTab);
            textbox.SaveFlagHandler();
            if (textbox.State == FileState.unsave)
            {
                if (MessageBox.Show("Do you want to save changes to your text?", "My Application",
                                                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveTextFile_Click(sender, e);
                else
                    if (tabControl1.TabCount > 1)
                    {
                        tabControl1.SelectedTab.Dispose();
                        tabControl1.SelectTab(tabControl1.TabCount - 1);
                    }
                    else
                        this.tabControl1.TabPages.Clear();
            }
            else
            {
                if (tabControl1.TabCount > 1)
                {
                    tabControl1.SelectedTab.Dispose();
                    tabControl1.SelectTab(tabControl1.TabCount - 1);
                }
                else
                    this.tabControl1.TabPages.Clear();
            }
        }

        private void CloseAll_Click(object sender, EventArgs e)
        {
            while (tabControl1.TabCount > 0)
                Close_Click(sender, e);
        }

        private void Find_Click(object sender, EventArgs e)
        {
            var textbox = FindTextBox((codeTab)this.tabControl1.SelectedTab);
            
            using (Find find = new Find())
            {
                if (find.ShowDialog() == DialogResult.OK)
                {
                    int start = 0;
                    int index = 0;
                    string textfind = find.Find_Text;
                    int lengthfind = find.Find_Text.Length;
                    int lengthText = textbox.GetLength();
                    while (start < lengthText)
                    {
                        index = textbox.GetMainBox().Text.IndexOf(textfind, start);
                        if (index == -1) break;
                        
                    }
                }
            }
        }

        private void Replace_Click(object sender, EventArgs e)
        {

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            exit_Click(sender, e);
        }

        #endregion
    }
}