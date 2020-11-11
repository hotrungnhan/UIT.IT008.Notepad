using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nodepad.component
{
    class codeTab : TabPage
    {
        public codeTab()
        {
            var Textbox = new TextBox();
            Textbox.Name = "textbox";
            this.Controls.Add(Textbox);
            //layout
            Textbox.Dock = DockStyle.Fill;
        }

    }

}
