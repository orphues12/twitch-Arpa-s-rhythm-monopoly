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
        //숫자 (랜덤X)
        int AlphaNum = Properties.Settings.Default.AlphaNum;  //알파벳
        int ConsoNum = Properties.Settings.Default.ConsoNum;  //자음
        int TopNum = Properties.Settings.Default.TopNum;    //상위만  
        int BotNum = Properties.Settings.Default.BottomNum;    //상위+하위
        int GoldenNum = Properties.Settings.Default.GoldenNum; //황금열쇠

        //숫자 (랜덤O)
        int AlphaNum2 = Properties.Settings.Default.AlphaNum2;  //알파벳
        int ConsoNum2 = Properties.Settings.Default.ConsoNum2;  //자음
        int TopNum2 = Properties.Settings.Default.TopNum2;    //상위만  
        int BotNum2 = Properties.Settings.Default.BottomNum2;    //상위+하위
        int GoldenNum2 = Properties.Settings.Default.GoldenNum2; //황금열쇠

        int TempAlpha = 0;
        int TempConso = 0;
        int TempTop = 0;
        int TempBot = 0;
        int TempGolden = 0;
        #endregion

        bool SaveChecked = false;
        bool Randomize;

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
            this.MinimumSize = new Size(300, 420);
            this.MaximumSize = new Size(300, 420);

            //랜덤 (황금 열쇠 변동과 연동됨)
            OptionPopup popup1 = new OptionPopup();
            Randomize = popup1.RandomizeCheck;
            popup1.Close();

            #region :: 변수 삽입 :: 
            if (!Randomize)
            {
                SpinAlpha.Value = AlphaNum;
                SpinConso.Value = ConsoNum;
                SpinTop.Value = TopNum;
                SpinBot.Value = BotNum;
                SpinGolden.Value = GoldenNum;
            }
            else
            {
                SpinAlpha.Value = AlphaNum2;
                SpinConso.Value = ConsoNum2;
                SpinTop.Value = TopNum2;
                SpinBot.Value = BotNum2;
                SpinGolden.Value = GoldenNum2;
            }
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

            if (!Randomize)
            {
                SpinGolden.Enabled = false;
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
            TempGolden = int.Parse(SpinGolden.Value.ToString());

            if (SaveCheck(TempAlpha, TempConso, TempTop, TempBot, TempGolden))
            {
                DialogResult result = MessageBox.Show("값을 저장하시겠습니까?", "저장 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (!Randomize)
                    {
                        Properties.Settings.Default.AlphaNum = TempAlpha;
                        Properties.Settings.Default.ConsoNum = TempConso;
                        Properties.Settings.Default.TopNum = TempTop;
                        Properties.Settings.Default.BottomNum = TempBot;
                        Properties.Settings.Default.GoldenNum = TempGolden;
                    }
                    else
                    {
                        Properties.Settings.Default.AlphaNum2 = TempAlpha;
                        Properties.Settings.Default.ConsoNum2 = TempConso;
                        Properties.Settings.Default.TopNum2 = TempTop;
                        Properties.Settings.Default.BottomNum2 = TempBot;
                        Properties.Settings.Default.GoldenNum2 = TempGolden;
                    }

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
        private bool SaveCheck(int Alpha, int Conso, int Top, int Bot, int Golden)
        {
            if (!Randomize && Alpha + Conso + Top + Bot != 11)
            {
                MessageBox.Show("모든 항목의 합은 11이 되어야 합니다.", "저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Randomize && Alpha + Conso + Top + Bot + Golden != 19)
            {
                MessageBox.Show("모든 항목의 합은 19가 되어야 합니다.", "저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        //도움말 버튼
        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("알파벳 6, 자음 4\n상위 6, 상위+하위 6\n이 각 항목마다 최대 수입니다.", "도움말", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("황금 열쇠는 랜덤 일시에만 조정이 가능합니다.", "도움말", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("모든 항목의 수의 합은\n랜덤 O: 19개\n랜덤 X: 11개\n을(를) 정확하게 맞추어 주세요.", "도움말", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

    }
}
