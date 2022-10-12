using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RhythmMonopoly
{
    public partial class Controller : Form
    {
        public Controller()
        {
            InitializeComponent();

            //폰트 설정
            Font font1 = new Font(FontManager.fontFamilys[0], 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                if (control is System.Windows.Forms.Label)
                {
                    string lblname = ((System.Windows.Forms.Label)control).Name;
                    ((System.Windows.Forms.Label)control).Font = font1;
                }
            }
        }
    }
}
