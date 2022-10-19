using System;
using System.CodeDom.Compiler;
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
        #region :: 변수 설정 ::
        //숫자
        int AlphaNum = Properties.Settings.Default.AlphaNum;  //알파벳
        int ConsoNum = Properties.Settings.Default.ConsoNum;  //자음
        int TopNum = Properties.Settings.Default.TopNum;    //상위만  
        int BotNum = Properties.Settings.Default.BottomNum;    //상위+하위
        int GoldenNum = Properties.Settings.Default.GoldenNum; //황금열쇠

        int TempAlpha = 0;
        int TempConso = 0;
        int TempTop = 0;
        int TempBot = 0;
        #endregion

        bool SaveChecked = false;

        //저장 여부 Popup으로 보내는 용도
        public bool SaveChecking
        {
            get { return this.SaveChecked;  }
            set { this.SaveChecked = value; }
        }

        public Controller()
        {
            InitializeComponent();
            
            //컨트롤박스 제거
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            //크기 관련
            this.MinimumSize = new Size(300, 350);
            this.MaximumSize = new Size(300, 350);

            #region :: 변수 삽입 :: 
            SpinAlpha.Value = AlphaNum;
            SpinConso.Value = ConsoNum;
            SpinTop.Value = TopNum;
            SpinBot.Value = BotNum;
            #endregion

            //폰트 설정
            Font font1 = new Font(FontManager.fontFamilys[0], 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

            List<Control> Conlist = Get_All_Controls(this).ToList();

            foreach (System.Windows.Forms.Control control in Conlist)
            {
                if (control is System.Windows.Forms.Label)
                {
                    ((System.Windows.Forms.Label)control).Font = font1;
                }
            }
        }

        //GroupBox 내부 Control 찾기
        public IEnumerable<Control> Get_All_Controls(Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => Get_All_Controls(ctrl)).Concat(controls).Where(p => p is Label);
        }

        #region :: Event ::
        //저장 버튼 이벤트 
        private void button1_Click(object sender, EventArgs e)
        {            
            //임시 변수
            TempAlpha = int.Parse(SpinAlpha.Value.ToString());
            TempConso = int.Parse(SpinConso.Value.ToString());
            TempTop = int.Parse(SpinTop.Value.ToString());
            TempBot = int.Parse(SpinBot.Value.ToString());

            if (SaveCheck(TempAlpha, TempConso, TempTop, TempBot))
            {
                DialogResult result = MessageBox.Show("값을 저장하시겠습니까?", "저장 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Properties.Settings.Default.AlphaNum = TempAlpha;
                    Properties.Settings.Default.ConsoNum = TempConso;
                    Properties.Settings.Default.TopNum = TempTop;
                    Properties.Settings.Default.BottomNum = TempBot;

                    Properties.Settings.Default.Save();


                    MessageBox.Show("저장이 완료되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SaveChecked = true;
                }
            }
        }

        //종료 이벤트
        private void Controller_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        //저장 확인 이벤트
        private bool SaveCheck(int Alpha, int Conso, int Top, int Bot)
        {
            TempAlpha = Alpha;
            TempConso = Conso;
            TempTop = Top;
            TempBot = Bot;

            if (Alpha + Conso + Top + Bot != 11)
            {
                MessageBox.Show("모든 항목의 합은 11이 되어야 합니다.", "저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        #endregion

    }
}
