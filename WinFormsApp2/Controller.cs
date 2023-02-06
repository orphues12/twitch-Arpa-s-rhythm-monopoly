using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RhythmMonopoly
{
    public partial class Controller : Form
    {
        #region :: 변수 설정 ::
        IniFile ini = new IniFile();
        string inipath = Application.StartupPath + "\\Settings.ini";

        //숫자 (랜덤X)
        int alphaNum = 0;  //알파벳
        int consoNum = 0;  //자음
        int topNum = 0;    //상위만  
        int botNum = 0;    //상위+하위
        int goldenNum = 0; //황금열쇠

        //숫자 (랜덤O)
        int randAlphaNum = 0;  //알파벳
        int randConsoNum = 0;  //자음
        int randTopNum = 0;    //상위만  
        int randBotNum = 0;    //상위+하위
        int randGoldenNum = 0; //황금열쇠

        int tempAlpha = 0;
        int tempConso = 0;
        int tempTop = 0;
        int tempBot = 0;
        int tempGolden = 0;
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

            InitializeINI(inipath);
            
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
                SpinAlpha.Value = alphaNum;
                SpinConso.Value = consoNum;
                SpinTop.Value = topNum;
                SpinBot.Value = botNum;
                SpinGolden.Value = goldenNum;
            }
            else
            {
                SpinAlpha.Value = randAlphaNum;
                SpinConso.Value = randConsoNum;
                SpinTop.Value = randTopNum;
                SpinBot.Value = randBotNum;
                SpinGolden.Value = randGoldenNum;
            }
            #endregion

            //폰트 설정
            Font font1 = new Font(FontManager.fontFamilys[0], 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

            List<Control> Conlist = Get_All_Controls(this).ToList();

            foreach (Control control in Conlist)
            {
                if (control is Label)
                {
                    ((Label)control).Font = font1;
                }
            }

            if (!Randomize)
            {
                SpinGolden.Enabled = false;
            }
        }

        private void InitializeINI(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("설정 파일이 없어요. 누가 가지고 있을까요?");
                Application.Exit();
            }

            ini.Load(path);

            //숫자 (랜덤X)
            alphaNum = int.Parse(ini["CategoryQty"]["AlphaNum"].ToString());  //알파벳
            consoNum = int.Parse(ini["CategoryQty"]["ConsoNum"].ToString());  //자음
            topNum = int.Parse(ini["CategoryQty"]["TopNum"].ToString());    //상위만  
            botNum = int.Parse(ini["CategoryQty"]["BotNum"].ToString());    //상위+하위
            goldenNum = int.Parse(ini["CategoryQty"]["GoldenNum"].ToString()); //황금열쇠

            //숫자 (랜덤O)
            randAlphaNum = int.Parse(ini["CategoryQty"]["RandAlphaNum"].ToString());//알파벳
            randConsoNum = int.Parse(ini["CategoryQty"]["RandConsoNum"].ToString()); ;  //자음
            randTopNum = int.Parse(ini["CategoryQty"]["RandTopNum"].ToString()); ;    //상위만  
            randBotNum = int.Parse(ini["CategoryQty"]["RandBotNum"].ToString()); ;    //상위+하위
            randGoldenNum = int.Parse(ini["CategoryQty"]["RandGoldenNum"].ToString()); //황금열쇠
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
            tempAlpha = int.Parse(SpinAlpha.Value.ToString());
            tempConso = int.Parse(SpinConso.Value.ToString());
            tempTop = int.Parse(SpinTop.Value.ToString());
            tempBot = int.Parse(SpinBot.Value.ToString());
            tempGolden = int.Parse(SpinGolden.Value.ToString());


            if (SaveCheck(tempAlpha, tempConso, tempTop, tempBot, tempGolden))
            {
                DialogResult result = MessageBox.Show("값을 저장하시겠습니까?", "저장 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (!Randomize)
                    {
                        ini["CategoryQty"]["AlphaNum"] = tempAlpha;
                        ini["CategoryQty"]["ConsoNum"] = tempConso;
                        ini["CategoryQty"]["TopNum"] = tempTop;
                        ini["CategoryQty"]["BotNum"] = tempBot;
                        ini["CategoryQty"]["GoldenNum"] = tempGolden;
                    }
                    else
                    {
                        ini["CategoryQty"]["RandAlphaNum"] = tempAlpha;
                        ini["CategoryQty"]["RandConsoNum"] = tempConso;
                        ini["CategoryQty"]["RandTopNum"] = tempTop;
                        ini["CategoryQty"]["RandBotNum"] = tempBot;
                        ini["CategoryQty"]["RandGoldenNum"] = tempGolden;
                    }
                    ini.Save(inipath);

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
            if (!Randomize && Alpha + Conso + Top + Bot != 14)
            {
                MessageBox.Show("모든 항목의 합은 14이 되어야 합니다.", "저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (Randomize && Alpha + Conso + Top + Bot + Golden != 22)
            {
                MessageBox.Show("모든 항목의 합은 22가 되어야 합니다.", "저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        //도움말 버튼
        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("알파벳 6, 자음 4\n상위 6, 상위+하위 9\n이 각 항목마다 최대 수입니다.", "도움말", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("황금 열쇠는 랜덤 일시에만 조정이 가능합니다.", "도움말", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("모든 항목의 수의 합은\n랜덤 O: 22개\n랜덤 X: 14개\n을(를) 정확하게 맞추어 주세요.", "도움말", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

    }
}
