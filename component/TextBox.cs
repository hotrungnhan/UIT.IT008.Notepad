using System;
using System.Resources;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Nodepad.component.Enum;
using Nodepad.Properties;

namespace Nodepad.component
{
    public partial class TextBox : UserControl
    {
        public LangCode Lang { get; set; }
        public string FileURL { get; set; }
        public FileState State { get; set; }
        public TextBox()
        {
            InitializeComponent();
            Lang = LangCode.Plain;
            FileURL = "";
            State = FileState.unsave;
            //SETUP LAYOUT

        }
        public void SaveAsFile()
        {
            var saveDialog = new SaveFileDialog();
            //saveFile1.Filter = "RTF Files|*.txt";
            saveDialog.Filter = Resources.FilterExtension;
            saveDialog.Title = "Save an File";
            saveDialog.FilterIndex = (int)Lang + 1; // filter index bat dau tu 1, enum bat dau tu 0;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                this.FileURL = saveDialog.FileName;
                try
                {
                    this.mainbox.SaveFile(this.FileURL, RichTextBoxStreamType.UnicodePlainText);
                    if (this.Parent is codeTab)
                        this.Parent.Text = Path.GetFileNameWithoutExtension(this.FileURL);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }

                Lang = LangFunc.getCodeByExtension(Path.GetExtension(this.FileURL));
            }
        }

        public void SaveFile()
        {
            if (!String.IsNullOrEmpty(FileURL))
            {
                this.mainbox.SaveFile(FileURL, RichTextBoxStreamType.UnicodePlainText);
            }
            else
            {
                SaveAsFile();
            }
        }

        public void LoadFile()
        {
            var openDialog = new OpenFileDialog();
            openDialog.Filter = Resources.FilterExtension;
            openDialog.Title = "Open an file";
            openDialog.FilterIndex = 5;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                this.FileURL = openDialog.FileName;
                try
                {
                    this.mainbox.LoadFile(this.FileURL, RichTextBoxStreamType.UnicodePlainText);
                    if (this.Parent is codeTab)
                        this.Parent.Text = Path.GetFileNameWithoutExtension(this.FileURL);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                Console.WriteLine(Path.GetExtension(this.FileURL));
                Lang = LangFunc.getCodeByExtension(Path.GetExtension(this.FileURL));

            }
        }

        private void TextColorUp(object sender, EventArgs e)
        {
            Console.WriteLine("text" + mainbox.Text);
            string keywords = @"\b(public|private|partial|static|namespace|class|using|void|foreach|in)\b";
            // getting types/classes from the text 
            string types = @"\b(Console)\b";
            MatchCollection typeMatches = Regex.Matches(mainbox.Text, types);

            // getting comments (inline or multiline)
            string comments = @"(\/\/.+?$|\/\*.+?\*\/)";
            MatchCollection commentMatches = Regex.Matches(mainbox.Text, comments, RegexOptions.Multiline);

            // getting strings
            string strings = "\".+?\"";
            var rx = new Regex(keywords).Matches(mainbox.Text);
            MatchCollection stringMatches = Regex.Matches(mainbox.Text, strings);
            int index = mainbox.SelectionStart;
            foreach (Match m in rx)
            {
                mainbox.Select(m.Index, m.Value.Length);
                mainbox.SelectionColor = Color.Purple;
                mainbox.SelectionStart = index;
                mainbox.SelectionColor = Color.Black;

            }
            foreach (Match m in typeMatches)
            {
                mainbox.Select(m.Index, m.Value.Length);
                mainbox.SelectionColor = Color.Purple;
                mainbox.SelectionStart = index;
                mainbox.SelectionColor = Color.Black;

            }
            foreach (Match m in stringMatches)
            {
                mainbox.Select(m.Index, m.Value.Length);
                mainbox.SelectionColor = Color.Purple;
                mainbox.SelectionStart = index;
                mainbox.SelectionColor = Color.Black;

            }
        }
        public void Copy()
        {
            this.mainbox.Copy();
        }
        public void Paste()
        {

            DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Text);
            mainbox.Paste(myFormat);
        }
        public void SelectAll()
        {
            this.mainbox.SelectAll();
        }
    }
}