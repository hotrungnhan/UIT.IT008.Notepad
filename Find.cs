using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nodepad
{
    public partial class Find : Form
    {
        public string Find_Text { get; set; }
        public string Replace_Text { get; set; }
        public Find()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Find_Text = this.Find_textbox_tabpage1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Find_Text = this.find_textbox_tabpage2.Text;
            Replace_Text = this.replace_texbox_tabpage2.Text;
        }
    }
}
