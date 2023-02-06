using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace RhythmMonopoly
{
    public partial class OptionPopup : Form
    {
        #region :: 변수 ::

        IniFile ini = new IniFile();
        string inipath = Application.StartupPath + "\\Settings.ini";


        //판때기 항목들
        string TopCategory01 = string.Empty; //상위  
        string TopCategory02 = string.Empty; //상위
        string TopCategory03 = string.Empty; //상위
        string TopCategory04 = string.Empty; //상위
        string TopCategory05 = string.Empty; //상위
        string TopCategory06 = string.Empty; //상위

        string BotCategory01 = string.Empty; //상위 + 하위
        string BotCategory02 = string.Empty; //상위 + 하위
        string BotCategory03 = string.Empty; //상위 + 하위
        string BotCategory04 = string.Empty; //상위 + 하위
        string BotCategory05 = string.Empty; //상위 + 하위
        string BotCategory06 = string.Empty; //상위 + 하위



        //하위 더미데이터 불러오는 곳
        string bot_SubMenu1_1 = string.Empty;
        string bot_SubMenu1_2 = string.Empty;
        string bot_SubMenu1_3 = string.Empty;
        string bot_SubMenu1_4 = string.Empty;
        string bot_SubMenu1_5 = string.Empty;

        string bot_SubMenu2_1 = string.Empty;
        string bot_SubMenu2_2 = string.Empty;
        string bot_SubMenu2_3 = string.Empty;
        string bot_SubMenu2_4 = string.Empty;
        string bot_SubMenu2_5 = string.Empty;

        string bot_SubMenu3_1 = string.Empty;
        string bot_SubMenu3_2 = string.Empty;
        string bot_SubMenu3_3 = string.Empty;
        string bot_SubMenu3_4 = string.Empty;
        string bot_SubMenu3_5 = string.Empty;

        string bot_SubMenu4_1 = string.Empty;
        string bot_SubMenu4_2 = string.Empty;
        string bot_SubMenu4_3 = string.Empty;
        string bot_SubMenu4_4 = string.Empty;
        string bot_SubMenu4_5 = string.Empty;

        string bot_SubMenu5_1 = string.Empty;
        string bot_SubMenu5_2 = string.Empty;
        string bot_SubMenu5_3 = string.Empty;
        string bot_SubMenu5_4 = string.Empty;
        string bot_SubMenu5_5 = string.Empty;

        string bot_SubMenu6_1 = string.Empty;
        string bot_SubMenu6_2 = string.Empty;
        string bot_SubMenu6_3 = string.Empty;
        string bot_SubMenu6_4 = string.Empty;
        string bot_SubMenu6_5 = string.Empty;

        bool Randomize = false;
        bool GoldenFix = false;

        //Combobox 숫자관련
        int TopNum =  0;
        int BotNum =  0;

        int RandTopNum = 0;
        int RandBotNum = 0;


        //저장 여부
        bool SaveChecked = false;
        bool SaveChecked2 = false;
        bool StartCheck = true;

        //목차
        int TopIndex = -1;
        int botIndex = 0;

        //???????
        int bot1Qty = 0;
        int bot2Qty = 0;
        int bot3Qty = 0;
        int bot4Qty = 0;
        int bot5Qty = 0;
        int bot6Qty = 0;

        //Dict

        Dictionary<string, string> botSubMenu1Dict = new Dictionary<string, string>();
        Dictionary<string, string> botSubMenu2Dict = new Dictionary<string, string>();
        Dictionary<string, string> botSubMenu3Dict = new Dictionary<string, string>();
        Dictionary<string, string> botSubMenu4Dict = new Dictionary<string, string>();
        Dictionary<string, string> botSubMenu5Dict = new Dictionary<string, string>();
        Dictionary<string, string> botSubMenu6Dict = new Dictionary<string, string>();

        #region :: 백업 ::
        ////판때기 항목들
        //string TopCategory01 = Properties.Settings.Default.TopCategory01; //상위  
        //string TopCategory02 = Properties.Settings.Default.TopCategory02; //상위
        //string TopCategory03 = Properties.Settings.Default.TopCategory03; //상위
        //string TopCategory04 = Properties.Settings.Default.TopCategory04; //상위
        //string TopCategory05 = Properties.Settings.Default.TopCategory05; //상위
        //string TopCategory06 = Properties.Settings.Default.TopCategory06; //상위

        //string BotCategory01 = Properties.Settings.Default.BotCategory01; //상위 + 하위
        //string BotCategory02 = Properties.Settings.Default.BotCategory02; //상위 + 하위
        //string BotCategory03 = Properties.Settings.Default.BotCategory03; //상위 + 하위
        //string BotCategory04 = Properties.Settings.Default.BotCategory04; //상위 + 하위
        //string BotCategory05 = Properties.Settings.Default.BotCategory05; //상위 + 하위
        //string BotCategory06 = Properties.Settings.Default.BotCategory06; //상위 + 하위



        ////하위 더미데이터 불러오는 곳
        //string dummycontent1_1 = Properties.Settings.Default.dummycontent1_1;
        //string dummycontent1_2 = Properties.Settings.Default.dummycontent1_2;
        //string dummycontent1_3 = Properties.Settings.Default.dummycontent1_3;

        //string dummycontent2_1 = Properties.Settings.Default.dummycontent2_1;
        //string dummycontent2_2 = Properties.Settings.Default.dummycontent2_2;
        //string dummycontent2_3 = Properties.Settings.Default.dummycontent2_3;
        //string dummycontent2_4 = Properties.Settings.Default.dummycontent2_4;

        //string dummycontent3_1 = Properties.Settings.Default.dummycontent3_1;
        //string dummycontent3_2 = Properties.Settings.Default.dummycontent3_2;
        //string dummycontent3_3 = Properties.Settings.Default.dummycontent3_3;
        //string dummycontent3_4 = Properties.Settings.Default.dummycontent3_4;
        //string dummycontent3_5 = Properties.Settings.Default.dummycontent3_5;

        //string dummycontent4_1 = Properties.Settings.Default.dummycontent4_1;
        //string dummycontent4_2 = Properties.Settings.Default.dummycontent4_2;
        //string dummycontent4_3 = Properties.Settings.Default.dummycontent4_3;
        //string dummycontent4_4 = Properties.Settings.Default.dummycontent4_4;
        //string dummycontent4_5 = Properties.Settings.Default.dummycontent4_5;

        //string dummycontent5_1 = Properties.Settings.Default.dummycontent5_1;
        //string dummycontent5_2 = Properties.Settings.Default.dummycontent5_2;
        //string dummycontent5_3 = Properties.Settings.Default.dummycontent5_3;
        //string dummycontent5_4 = Properties.Settings.Default.dummycontent5_4;
        //string dummycontent5_5 = Properties.Settings.Default.dummycontent5_5;

        //string dummycontent6_1 = Properties.Settings.Default.dummycontent6_1;
        //string dummycontent6_2 = Properties.Settings.Default.dummycontent6_2;
        //string dummycontent6_3 = Properties.Settings.Default.dummycontent6_3;

        //bool Randomize = Properties.Settings.Default.Randomize;
        //bool GoldenFix = Properties.Settings.Default.GoldenFix;


        ////저장 여부
        //bool SaveChecked = false;
        //bool SaveChecked2 = false;
        //bool StartCheck = true;

        ////목차
        //int TopIndex = -1;
        //int botIndex = 0;

        ////Combobox 숫자관련
        //int TopNum = Properties.Settings.Default.TopNum;
        //int BotNum = Properties.Settings.Default.BottomNum;

        //int TopNum2 = Properties.Settings.Default.TopNum2;
        //int BotNum2 = Properties.Settings.Default.BottomNum2;

        #endregion

        //랜덤 체크 데이터 넘겨주기
        public bool RandomizeCheck
        {
            get { return this.ChkRandom.Checked; }
            set { this.ChkRandom.Checked = value; }
        }

        #endregion

        #region :: Form Event ::

        public OptionPopup()
        {
            InitializeComponent();

            InitializeINI(inipath);

            //크기 고정

            //컨트롤박스 제거
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            //크기 관련
            this.MinimumSize = new Size(450, 400);
            this.MaximumSize = new Size(450, 400);

            //폰트설정
            Font font1 = new Font(FontManager.fontFamilys[0], 16, FontStyle.Regular, GraphicsUnit.Point, ((byte)(129)));
            Font font2 = new Font(FontManager.fontFamilys[0], 40, FontStyle.Regular, GraphicsUnit.Point, ((byte)(129)));
            Font font3 = new Font(FontManager.fontFamilys[0], 24, FontStyle.Regular, GraphicsUnit.Point, ((byte)(129)));

            ChkRandom.Font = font1;
            ChkRandom.Checked = Randomize;

            //모든 컨트롤 점검
            foreach (Control control in this.Controls)
            {
                //라벨 확인
                if (control is Label)
                {
                    //라벨 이름으로 원하는 항목의 폰트 설정 변경
                    string lblname = ((Label)control).Name;
                    //일반 라벨
                    ((Label)control).Font = font1;
                    //패널 라벨
                    if (lblname.Contains("Panel"))
                    {
                        ((Label)control).Font = font2;
                    }
                    //타이틀 라벨
                    else if (lblname.Contains("Title"))
                    {
                        ((Label)control).Font = font3;
                    }
                }
            }
            //콤보박스 항목 추가 이벤트
            addCombobox();

            //콤보박스 설정에 대한 사용가능 여부 초기 값(False)
            txtCategoryTop.Enabled = false;
            cmbCategoryBottom.Enabled = false;
            txtCategoryBottom.Enabled = false;
        }

        private void InitializeINI(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    MessageBox.Show("설정 파일이 없어요. 누가 가지고 있을까요?");
                    Application.Exit();
                }

                ini.Load(path);

                #region :: 값 불러오기 ::

                //판때기 항목들
                TopCategory01 = ini["Top"]["TopCategory1"].ToString(); //상위  
                TopCategory02 = ini["Top"]["TopCategory2"].ToString(); //상위
                TopCategory03 = ini["Top"]["TopCategory3"].ToString(); //상위
                TopCategory04 = ini["Top"]["TopCategory4"].ToString(); //상위
                TopCategory05 = ini["Top"]["TopCategory5"].ToString(); //상위
                TopCategory06 = ini["Top"]["TopCategory6"].ToString(); //상위

                BotCategory01 = ini["Bot"]["BotCategory1"].ToString(); //상위 + 하위
                BotCategory02 = ini["Bot"]["BotCategory2"].ToString(); //상위 + 하위
                BotCategory03 = ini["Bot"]["BotCategory3"].ToString(); //상위 + 하위
                BotCategory04 = ini["Bot"]["BotCategory4"].ToString(); //상위 + 하위
                BotCategory05 = ini["Bot"]["BotCategory5"].ToString(); //상위 + 하위
                BotCategory06 = ini["Bot"]["BotCategory6"].ToString(); //상위 + 하위



                //하위 더미데이터 불러오는 곳
                //하위 더미데이터
                bot_SubMenu1_1 = ini["Bot_SubMenu1"]["BotContent1"].ToString();
                bot_SubMenu1_2 = ini["Bot_SubMenu1"]["BotContent2"].ToString();
                bot_SubMenu1_3 = ini["Bot_SubMenu1"]["BotContent3"].ToString();
                bot_SubMenu1_4 = ini["Bot_SubMenu1"]["BotContent4"].ToString();
                bot_SubMenu1_5 = ini["Bot_SubMenu1"]["BotContent5"].ToString();

                botSubMenu1Dict = MakeDict("Bot_SubMenu1", 1);
                bot1Qty = int.Parse(ini["Bot_SubMenu1"]["Qty"].ToString());


                bot_SubMenu2_1 = ini["Bot_SubMenu2"]["BotContent1"].ToString();
                bot_SubMenu2_2 = ini["Bot_SubMenu2"]["BotContent2"].ToString();
                bot_SubMenu2_3 = ini["Bot_SubMenu2"]["BotContent3"].ToString();
                bot_SubMenu2_4 = ini["Bot_SubMenu2"]["BotContent4"].ToString();
                bot_SubMenu2_5 = ini["Bot_SubMenu2"]["BotContent5"].ToString();

                botSubMenu2Dict = MakeDict("Bot_SubMenu2", 2);
                bot2Qty = int.Parse(ini["Bot_SubMenu2"]["Qty"].ToString());

                bot_SubMenu3_1 = ini["Bot_SubMenu3"]["BotContent1"].ToString();
                bot_SubMenu3_2 = ini["Bot_SubMenu3"]["BotContent2"].ToString();
                bot_SubMenu3_3 = ini["Bot_SubMenu3"]["BotContent3"].ToString();
                bot_SubMenu3_4 = ini["Bot_SubMenu3"]["BotContent4"].ToString();
                bot_SubMenu3_5 = ini["Bot_SubMenu3"]["BotContent5"].ToString();

                botSubMenu3Dict = MakeDict("Bot_SubMenu3", 3);
                bot3Qty = int.Parse(ini["Bot_SubMenu3"]["Qty"].ToString());

                bot_SubMenu4_1 = ini["Bot_SubMenu4"]["BotContent1"].ToString();
                bot_SubMenu4_2 = ini["Bot_SubMenu4"]["BotContent2"].ToString();
                bot_SubMenu4_3 = ini["Bot_SubMenu4"]["BotContent3"].ToString();
                bot_SubMenu4_4 = ini["Bot_SubMenu4"]["BotContent4"].ToString();
                bot_SubMenu4_5 = ini["Bot_SubMenu4"]["BotContent5"].ToString();

                botSubMenu4Dict = MakeDict("Bot_SubMenu4", 4);
                bot4Qty = int.Parse(ini["Bot_SubMenu4"]["Qty"].ToString());

                bot_SubMenu5_1 = ini["Bot_SubMenu5"]["BotContent1"].ToString();
                bot_SubMenu5_2 = ini["Bot_SubMenu5"]["BotContent2"].ToString();
                bot_SubMenu5_3 = ini["Bot_SubMenu5"]["BotContent3"].ToString();
                bot_SubMenu5_4 = ini["Bot_SubMenu5"]["BotContent4"].ToString();
                bot_SubMenu5_5 = ini["Bot_SubMenu5"]["BotContent5"].ToString();

                botSubMenu5Dict = MakeDict("Bot_SubMenu5", 5);
                bot5Qty = int.Parse(ini["Bot_SubMenu5"]["Qty"].ToString());

                bot_SubMenu6_1 = ini["Bot_SubMenu6"]["BotContent1"].ToString();
                bot_SubMenu6_2 = ini["Bot_SubMenu6"]["BotContent2"].ToString();
                bot_SubMenu6_3 = ini["Bot_SubMenu6"]["BotContent3"].ToString();
                bot_SubMenu6_4 = ini["Bot_SubMenu6"]["BotContent4"].ToString();
                bot_SubMenu6_5 = ini["Bot_SubMenu6"]["BotContent5"].ToString();

                botSubMenu6Dict = MakeDict("Bot_SubMenu6", 6);
                bot6Qty = int.Parse(ini["Bot_SubMenu6"]["Qty"].ToString());

                Randomize = bool.Parse(ini["Option"]["Randomize"].ToString());
                GoldenFix = bool.Parse(ini["Option"]["GoldenFix"].ToString());

                //숫자관련
                TopNum = int.Parse(ini["CategoryQty"]["TopNum"].ToString());
                BotNum = int.Parse(ini["CategoryQty"]["BotNum"].ToString());

                RandTopNum = int.Parse(ini["CategoryQty"]["RandTopNum"].ToString());
                RandBotNum = int.Parse(ini["CategoryQty"]["RandBotNum"].ToString());

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MethodBase.GetCurrentMethod().Name);
                return;
            }
        }

        //2월 언저리 새로 추가
        private Dictionary<string, string> MakeDict(string name, int a)
        {
            Dictionary<string, string> tempdict = new Dictionary<string, string>();
            int botQty = 0;

            for (int i = 1; i < 6; i++)
            {
                tempdict.Add(name + $"_{i}", ini[$"Bot_SubMenu{a}"][$"BotContent{i}"].ToString());

                //값이 있으면 Qty값 증가
                if (tempdict[$"{name}_{i}"].ToString() != string.Empty) botQty++;
            }
            ini[$"Bot_SubMenu{a}"]["Qty"] = botQty;
            ini.Save(inipath);

            return tempdict;
        }

        #endregion

        
        #region ::: 항목 추가 설정 이벤트 모음 :::

        #region :: Combobox Event ::
        private void cmbCategoryTop_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //상위 항목 선택 후 그것에 대한 설정
                if (cmbCategoryTop.Text.Contains("상-1"))
                {
                    txtCategoryTop.Text = TopCategory01;
                    txtCategoryTop.Enabled = true;
                    cmbCategoryBottom.Enabled = false;
                    txtCategoryBottom.Enabled = false;
                    cmbCategoryBottom.Items.Clear();
                    txtCategoryBottom.Text = "";
                    return;
                }
                else if (cmbCategoryTop.Text.Contains("상-2"))
                {
                    txtCategoryTop.Text = TopCategory02;
                    txtCategoryTop.Enabled = true;
                    cmbCategoryBottom.Enabled = false;
                    txtCategoryBottom.Enabled = false;
                    cmbCategoryBottom.Items.Clear();
                    txtCategoryBottom.Text = "";
                    return;
                }
                else if (cmbCategoryTop.Text.Contains("상-3"))
                {
                    txtCategoryTop.Text = TopCategory03;
                    txtCategoryTop.Enabled = true;
                    cmbCategoryBottom.Enabled = false;
                    txtCategoryBottom.Enabled = false;
                    cmbCategoryBottom.Items.Clear();
                    txtCategoryBottom.Text = "";
                    return;
                }
                else if (cmbCategoryTop.Text.Contains("상-4"))
                {
                    txtCategoryTop.Text = TopCategory04;
                    txtCategoryTop.Enabled = true;
                    cmbCategoryBottom.Enabled = false;
                    txtCategoryBottom.Enabled = false;
                    cmbCategoryBottom.Items.Clear();
                    txtCategoryBottom.Text = "";
                    return;
                }
                else if (cmbCategoryTop.Text.Contains("상-5"))
                {
                    txtCategoryTop.Text = TopCategory05;
                    txtCategoryTop.Enabled = true;
                    cmbCategoryBottom.Enabled = false;
                    txtCategoryBottom.Enabled = false;
                    cmbCategoryBottom.Items.Clear();
                    txtCategoryBottom.Text = "";
                    return;
                }
                else if (cmbCategoryTop.Text.Contains("상-6"))
                {
                    txtCategoryTop.Text = TopCategory06;
                    txtCategoryTop.Enabled = true;

                    cmbCategoryBottom.Enabled = false;
                    txtCategoryBottom.Enabled = false;
                    cmbCategoryBottom.Items.Clear();
                    txtCategoryBottom.Text = "";
                    return;
                }
                else if (cmbCategoryTop.Text.Contains("하-1"))
                {
                    txtCategoryTop.Text = BotCategory01;
                    txtCategoryTop.Enabled = true;
                    cmbCategoryBottom.Enabled = true;
                    txtCategoryBottom.Enabled = true;

                    cmbCategoryBottom.Items.Clear();

                    for (int i = 1; i < bot1Qty+1; i++)
                    {
                        cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu1Dict[$"Bot_SubMenu1_{i}"]);
                    }

                    //cmbCategoryBottom.Items.Add("하위1 - " + dummycontent1_1);
                    //cmbCategoryBottom.Items.Add("하위2 - " + dummycontent1_2);
                    //cmbCategoryBottom.Items.Add("하위3 - " + dummycontent1_3);

                    cmbCategoryBottom.SelectedIndex = 0;
                    return;
                }
                else if (cmbCategoryTop.Text.Contains("하-2"))
                {
                    txtCategoryTop.Text = BotCategory02;
                    txtCategoryTop.Enabled = true;

                    cmbCategoryBottom.Enabled = true;
                    txtCategoryBottom.Enabled = true;

                    cmbCategoryBottom.Items.Clear();

                    for (int i = 1; i < bot2Qty + 1; i++)
                    {
                        cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu2Dict[$"Bot_SubMenu2_{i}"]);
                    }


                    //cmbCategoryBottom.Items.Add("하위1 - " + dummycontent2_1);
                    //cmbCategoryBottom.Items.Add("하위2 - " + dummycontent2_2);
                    //cmbCategoryBottom.Items.Add("하위3 - " + dummycontent2_3);
                    //cmbCategoryBottom.Items.Add("하위4 - " + dummycontent2_4);

                    cmbCategoryBottom.SelectedIndex = 0;
                    return;
                }
                else if (cmbCategoryTop.Text.Contains("하-3"))
                {
                    txtCategoryTop.Text = BotCategory03;
                    txtCategoryTop.Enabled = true;

                    cmbCategoryBottom.Enabled = true;
                    txtCategoryBottom.Enabled = true;

                    cmbCategoryBottom.Items.Clear();

                    for (int i = 1; i < bot3Qty + 1; i++)
                    {
                        cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu3Dict[$"Bot_SubMenu3_{i}"]);
                    }



                    //cmbCategoryBottom.Items.Add("하위1 - " + dummycontent3_1);
                    //cmbCategoryBottom.Items.Add("하위2 - " + dummycontent3_2);
                    //cmbCategoryBottom.Items.Add("하위3 - " + dummycontent3_3);
                    //cmbCategoryBottom.Items.Add("하위4 - " + dummycontent3_4);
                    //cmbCategoryBottom.Items.Add("하위5 - " + dummycontent3_5);

                    cmbCategoryBottom.SelectedIndex = 0;
                    return;
                }
                else if (cmbCategoryTop.Text.Contains("하-4"))
                {
                    txtCategoryTop.Text = BotCategory04;
                    txtCategoryTop.Enabled = true;

                    cmbCategoryBottom.Enabled = true;
                    txtCategoryBottom.Enabled = true;

                    cmbCategoryBottom.Items.Clear();

                    for (int i = 1; i < bot4Qty + 1; i++)
                    {
                        cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu4Dict[$"Bot_SubMenu4_{i}"]);
                    }


                    //cmbCategoryBottom.Items.Add("하위1 - " + dummycontent4_1);
                    //cmbCategoryBottom.Items.Add("하위2 - " + dummycontent4_2);
                    //cmbCategoryBottom.Items.Add("하위3 - " + dummycontent4_3);
                    //cmbCategoryBottom.Items.Add("하위4 - " + dummycontent4_4);
                    //cmbCategoryBottom.Items.Add("하위5 - " + dummycontent4_5);

                    cmbCategoryBottom.SelectedIndex = 0;
                    return;
                }
                else if (cmbCategoryTop.Text.Contains("하-5"))
                {
                    txtCategoryTop.Text = BotCategory05;
                    txtCategoryTop.Enabled = true;

                    cmbCategoryBottom.Enabled = true;
                    txtCategoryBottom.Enabled = true;

                    cmbCategoryBottom.Items.Clear();

                    for (int i = 1; i < bot5Qty + 1; i++)
                    {
                        cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu5Dict[$"Bot_SubMenu5_{i}"]);
                    }
                    cmbCategoryBottom.SelectedIndex = 0;
                }
                else if (cmbCategoryTop.Text.Contains("하-6"))
                {
                    txtCategoryTop.Text = BotCategory06;
                    txtCategoryTop.Enabled = true;

                    cmbCategoryBottom.Enabled = true;
                    txtCategoryBottom.Enabled = true;

                    cmbCategoryBottom.Items.Clear();

                    for (int i = 1; i < bot6Qty + 1; i++)
                    {
                        cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu6Dict[$"Bot_SubMenu6_{i}"]);
                    }

                    cmbCategoryBottom.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MethodBase.GetCurrentMethod().Name);
            }
        }

        private void cmbCategorybottom_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //하위 콤보박스 정리
                txtCategoryBottom.Clear();

                string categorytxt = cmbCategoryBottom.Text;

                //상위+하위 항목 선택시 그것에 대한 설정
                if (cmbCategoryTop.Text.Contains("하-1"))
                {
                    switch (categorytxt)
                    {
                        case string read when categorytxt.Contains("하-1"):
                            txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu1"];
                            break;
                        case string read when categorytxt.Contains("하-2"):
                            txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu2"];
                            break;
                        case string read when categorytxt.Contains("하-3"):
                            txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu3"];
                            break;
                        case string read when categorytxt.Contains("하-4"):
                            txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu4"];
                            break;
                        case string read when categorytxt.Contains("하-5"):
                            txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu5"];
                            break;
                    }

                    //if (cmbCategoryBottom.Text.Contains("하위1"))
                    //{
                    //    txtCategoryBottom.Text = dummycontent1_1;
                    //}
                    //else if (cmbCategoryBottom.Text.Contains("하위2"))
                    //{
                    //    txtCategoryBottom.Text = dummycontent1_2;
                    //}
                    //else if (cmbCategoryBottom.Text.Contains("하위3"))
                    //{
                    //    txtCategoryBottom.Text = dummycontent1_3;
                    //}
                }
                else if (cmbCategoryTop.Text.Contains("하-2"))
                {
                    switch (categorytxt)
                    {
                        case string read when categorytxt.Contains("하-1"):
                            txtCategoryBottom.Text = botSubMenu2Dict["Bot_SubMenu1"];
                            break;
                        case string read when categorytxt.Contains("하-2"):
                            txtCategoryBottom.Text = botSubMenu2Dict["Bot_SubMenu2"];
                            break;
                        case string read when categorytxt.Contains("하-3"):
                            txtCategoryBottom.Text = botSubMenu2Dict["Bot_SubMenu3"];
                            break;
                        case string read when categorytxt.Contains("하-4"):
                            txtCategoryBottom.Text = botSubMenu2Dict["Bot_SubMenu4"];
                            break;
                        case string read when categorytxt.Contains("하-5"):
                            txtCategoryBottom.Text = botSubMenu2Dict["Bot_SubMenu5"];
                            break;
                    }
                }
                else if (cmbCategoryTop.Text.Contains("하-3"))
                {
                    switch (categorytxt)
                    {
                        case string read when categorytxt.Contains("하-1"):
                            txtCategoryBottom.Text = botSubMenu3Dict["Bot_SubMenu1"];
                            break;
                        case string read when categorytxt.Contains("하-2"):
                            txtCategoryBottom.Text = botSubMenu3Dict["Bot_SubMenu2"];
                            break;
                        case string read when categorytxt.Contains("하-3"):
                            txtCategoryBottom.Text = botSubMenu3Dict["Bot_SubMenu3"];
                            break;
                        case string read when categorytxt.Contains("하-4"):
                            txtCategoryBottom.Text = botSubMenu3Dict["Bot_SubMenu4"];
                            break;
                        case string read when categorytxt.Contains("하-5"):
                            txtCategoryBottom.Text = botSubMenu3Dict["Bot_SubMenu5"];
                            break;
                    }
                }
                else if (cmbCategoryTop.Text.Contains("하-4"))
                {
                    switch (categorytxt)
                    {
                        case string read when categorytxt.Contains("하-1"):
                            txtCategoryBottom.Text = botSubMenu4Dict["Bot_SubMenu1"];
                            break;
                        case string read when categorytxt.Contains("하-2"):
                            txtCategoryBottom.Text = botSubMenu4Dict["Bot_SubMenu2"];
                            break;
                        case string read when categorytxt.Contains("하-3"):
                            txtCategoryBottom.Text = botSubMenu4Dict["Bot_SubMenu3"];
                            break;
                        case string read when categorytxt.Contains("하-4"):
                            txtCategoryBottom.Text = botSubMenu4Dict["Bot_SubMenu4"];
                            break;
                        case string read when categorytxt.Contains("하-5"):
                            txtCategoryBottom.Text = botSubMenu4Dict["Bot_SubMenu5"];
                            break;
                    }
                }
                else if (cmbCategoryTop.Text.Contains("하-5"))
                {
                    switch (categorytxt)
                    {
                        case string read when categorytxt.Contains("하-1"):
                            txtCategoryBottom.Text = botSubMenu5Dict["Bot_SubMenu1"];
                            break;
                        case string read when categorytxt.Contains("하-2"):
                            txtCategoryBottom.Text = botSubMenu5Dict["Bot_SubMenu2"];
                            break;
                        case string read when categorytxt.Contains("하-3"):
                            txtCategoryBottom.Text = botSubMenu5Dict["Bot_SubMenu3"];
                            break;
                        case string read when categorytxt.Contains("하-4"):
                            txtCategoryBottom.Text = botSubMenu5Dict["Bot_SubMenu4"];
                            break;
                        case string read when categorytxt.Contains("하-5"):
                            txtCategoryBottom.Text = botSubMenu5Dict["Bot_SubMenu5"];
                            break;
                    }
                }
                else if (cmbCategoryTop.Text.Contains("하-6"))
                {
                    switch (categorytxt)
                    {
                        case string read when categorytxt.Contains("하-1"):
                            txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu1"];
                            break;
                        case string read when categorytxt.Contains("하-2"):
                            txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu2"];
                            break;
                        case string read when categorytxt.Contains("하-3"):
                            txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu3"];
                            break;
                        case string read when categorytxt.Contains("하-4"):
                            txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu4"];
                            break;
                        case string read when categorytxt.Contains("하-5"):
                            txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu5"];
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Source != null)
                    Console.WriteLine("IOException source: {0}", ex.Source);
                throw;
            }
        }

        #endregion

        #region :: Button Event ::
        //항목 저장버튼
        private void Savebutton1_Click(object sender, EventArgs e)
        {
            try
            {
                //예외처리
                if (cmbCategoryTop.SelectedItem == null)
                {
                    MessageBox.Show("항목을 선택하여 주십시오.", "저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (txtCategoryTop.Text == "")
                {
                    MessageBox.Show("상위 항목을 입력하여 주십시오.", "저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (txtCategoryBottom.Text == "" && cmbCategoryBottom.Items.Count != 0)
                {
                    MessageBox.Show("하위 항목을 입력하여 주십시오.", "저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                #region :: 구형 ::
                /* 저장 방식 */
                // 1. 상위 항목 선택
                // 1-2. 하위 항목 변경 필요 시 하위 항목 선택
                // 2. 변경 하고 싶은 항목(상위나 하위) 이름 변경
                // 3. 이름 변경 후 [저장] 버튼 클릭
                // 4. 확인문 출력
                // 5. Properties 내부 값을 업데이트
                // 5-2. 업데이트 값이 바로 반영 되지 않는데 이 부분을 해결하기 위해 임시 변수 사용
                // 5-3. 업데이트 후 창을 닫으려고 할 때 재부팅 여부 물어보기 (필수)
                #endregion

                /* 저장 방식 (2023. 02 기준)*/
                // 1. 상위 항목 선택
                // 1-2. 하위 항목 변경 필요 시 하위 항목 선택
                // 2. 변경 하고 싶은 항목(상위나 하위) 이름 변경
                // 3. 이름 변경 후 [저장] 버튼 클릭
                // 4. 확인문 출력
                // 5. Properties 내부 값을 업데이트
                // 5-2. 업데이트 값이 바로 반영 되지 않는데 이 부분을 해결하기 위해 임시 변수 사용
                // 5-3. 업데이트 후 창을 닫으려고 할 때 재부팅 여부 물어보기 (필수)

                //항목 저장 버튼 클릭
                DialogResult Result = MessageBox.Show("저장하시겠습니까?", "저장 확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (Result == DialogResult.OK)
                {
                    /* 변수저장 */
                    //윗라인 
                    string _TempCateTop = cmbCategoryTop.Text;
                    string _TempCateChangeTop = txtCategoryTop.Text;
                    //아랫라인
                    string _TempCateBot = cmbCategoryBottom.Text;
                    string _TempCateChangeBot = txtCategoryBottom.Text;


                    //목차용 변수 지정 및 초기화
                    string TopCatadata = string.Empty;
                    string BotCatadata = string.Empty;
                    int botidx = 0;

                    #region :: 목차 데이터 찾는 코드 ::
                    //상위
                    if (_TempCateTop.Contains("(상-"))
                    {
                        //값 찾아서 목차용 변수에 값 대입
                        for (int i = 1; i < TopNum+1; i++)
                        {
                            if (_TempCateTop.Contains(String.Format($"(상-{i})")))
                            {
                                TopCatadata = String.Format("TopCategory{0}",i.ToString());
                                break;
                            }
                        }
                    }

                    //하위
                    else if (_TempCateTop.Contains("(하-"))
                    {
                        for (int i = 1; i < BotNum + 1; i++)
                        {
                            //i값을 항목과 검사
                            if (_TempCateTop.Contains(String.Format("(하-{0})", i.ToString())))
                            {
                                TopCatadata = String.Format("BotCategory{0}", i.ToString());

                                //항목의 전체개수가 바뀌면 J를 바꿔주세요. (현재는 모든 항목이 5개라서 6 넣어둠)
                                for (int j = 1; j < 6; j++)
                                {
                                    if (_TempCateBot.Contains(String.Format($"하위{j}")))
                                    {
                                        BotCatadata = $"BotContent{j}";
                                        botidx = i;
                                        break;
                                    }
                                }
                                break;
                            }
                            
                        }
                    }

                    #endregion

                    //데이터 저장
                    string idx = TopCatadata.Substring(TopCatadata.Length - 1, 1);
                    if (TopCatadata.ToUpper().Contains("TOP"))
                    {
                        ini["Top"][$"TopCategory{idx}"] = _TempCateChangeTop; 
                    }
                    else
                    {
                        ini["Bot"][$"BotCategory{idx}"] = _TempCateChangeTop;
                    }

                    if (BotCatadata != string.Empty)
                    {
                        ini[$"Bot_SubMenu{botidx}"][$"{BotCatadata}"] = _TempCateChangeBot;
                    }

                    ini.Save(inipath);

                    TopIndex = cmbCategoryTop.SelectedIndex;
                    botIndex = cmbCategoryBottom.SelectedIndex;

                    MessageBox.Show("저장이 완료되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SaveChecked = true;

                    InitializeINI(inipath);

                    CataSaveText();

                    addCombobox();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MethodBase.GetCurrentMethod().Name);
            }

        }

        //컨트롤러
        private void btnController_Click(object sender, EventArgs e)
        {
            Controller con = new Controller();
            con.ShowDialog();

            if (con.SaveChecking)
            {
                MessageBox.Show("항목 수의 변경으로 인하여 강제적으로\n프로그램을 재시작 합니다.", "종료 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                SaveChecked = false;
                SaveChecked2 = false;
                Application.Restart();
                Environment.Exit(0);
            }
        }

        //INI 열기

        private void btnOpenINI_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("Notepad.exe", inipath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MethodBase.GetCurrentMethod().Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region :: ETC Event ::
        //엔터 키 이벤트
        private void Enter_KeyDown1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Savebutton1_Click(sender, e);
            }
        }

        private void CataSaveText()
        {
            if (cmbCategoryTop.Text.Contains("상-1"))
            {
                TopCategory01 = txtCategoryTop.Text;
            }
            else if (cmbCategoryTop.Text.Contains("상-2"))
            {
                TopCategory02 = txtCategoryTop.Text;
            }
            else if (cmbCategoryTop.Text.Contains("상-3"))
            {
                TopCategory03 = txtCategoryTop.Text;
            }
            else if (cmbCategoryTop.Text.Contains("상-4"))
            {
                TopCategory04 = txtCategoryTop.Text;
            }
            else if (cmbCategoryTop.Text.Contains("상-5"))
            {
                TopCategory05 = txtCategoryTop.Text;
            }
            else if (cmbCategoryTop.Text.Contains("상-6"))
            {
                TopCategory06 = txtCategoryTop.Text;
            }
            else if (cmbCategoryTop.Text.Contains("하-1"))
            {
                BotCategory01 = txtCategoryTop.Text;
                string categorytxt = cmbCategoryBottom.Text;

                switch (categorytxt)
                {
                    case string read when categorytxt.Contains("하-1"):
                        txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu1"];
                        break;
                    case string read when categorytxt.Contains("하-2"):
                        txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu2"];
                        break;
                    case string read when categorytxt.Contains("하-3"):
                        txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu3"];
                        break;
                    case string read when categorytxt.Contains("하-4"):
                        txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu4"];
                        break;
                    case string read when categorytxt.Contains("하-5"):
                        txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu5"];
                        break;
                }

                //if (cmbCategoryBottom.Text.Contains("하위1"))
                //{
                //    dummycontent1_1 = txtCategoryBottom.Text;
                //}
                //else if (cmbCategoryBottom.Text.Contains("하위2"))
                //{
                //    dummycontent1_2 = txtCategoryBottom.Text;
                //}
                //else if (cmbCategoryBottom.Text.Contains("하위3"))
                //{
                //    dummycontent1_3 = txtCategoryBottom.Text;
                //}
            }
            else if (cmbCategoryTop.Text.Contains("하-2"))
            {
                BotCategory02 = txtCategoryTop.Text;

                string categorytxt = cmbCategoryBottom.Text;

                switch (categorytxt)
                {
                    case string read when categorytxt.Contains("하-1"):
                        txtCategoryBottom.Text = botSubMenu2Dict["Bot_SubMenu1"];
                        break;
                    case string read when categorytxt.Contains("하-2"):
                        txtCategoryBottom.Text = botSubMenu2Dict["Bot_SubMenu2"];
                        break;
                    case string read when categorytxt.Contains("하-3"):
                        txtCategoryBottom.Text = botSubMenu2Dict["Bot_SubMenu3"];
                        break;
                    case string read when categorytxt.Contains("하-4"):
                        txtCategoryBottom.Text = botSubMenu2Dict["Bot_SubMenu4"];
                        break;
                    case string read when categorytxt.Contains("하-5"):
                        txtCategoryBottom.Text = botSubMenu2Dict["Bot_SubMenu5"];
                        break;
                }

            }
            else if (cmbCategoryTop.Text.Contains("하-3"))
            {
                BotCategory03 = txtCategoryTop.Text;

                string categorytxt = cmbCategoryBottom.Text;

                switch (categorytxt)
                {
                    case string read when categorytxt.Contains("하-1"):
                        txtCategoryBottom.Text = botSubMenu3Dict["Bot_SubMenu1"];
                        break;
                    case string read when categorytxt.Contains("하-2"):
                        txtCategoryBottom.Text = botSubMenu3Dict["Bot_SubMenu2"];
                        break;
                    case string read when categorytxt.Contains("하-3"):
                        txtCategoryBottom.Text = botSubMenu3Dict["Bot_SubMenu3"];
                        break;
                    case string read when categorytxt.Contains("하-4"):
                        txtCategoryBottom.Text = botSubMenu3Dict["Bot_SubMenu4"];
                        break;
                    case string read when categorytxt.Contains("하-5"):
                        txtCategoryBottom.Text = botSubMenu3Dict["Bot_SubMenu5"];
                        break;
                }

            }
            //임시 5/5/3
            else if (cmbCategoryTop.Text.Contains("하-4"))
            {
                BotCategory04 = txtCategoryTop.Text;

                string categorytxt = cmbCategoryBottom.Text;

                switch (categorytxt)
                {
                    case string read when categorytxt.Contains("하-1"):
                        txtCategoryBottom.Text = botSubMenu4Dict["Bot_SubMenu1"];
                        break;
                    case string read when categorytxt.Contains("하-2"):
                        txtCategoryBottom.Text = botSubMenu4Dict["Bot_SubMenu2"];
                        break;
                    case string read when categorytxt.Contains("하-3"):
                        txtCategoryBottom.Text = botSubMenu4Dict["Bot_SubMenu3"];
                        break;
                    case string read when categorytxt.Contains("하-4"):
                        txtCategoryBottom.Text = botSubMenu4Dict["Bot_SubMenu4"];
                        break;
                    case string read when categorytxt.Contains("하-5"):
                        txtCategoryBottom.Text = botSubMenu4Dict["Bot_SubMenu5"];
                        break;
                }

            }
            else if (cmbCategoryTop.Text.Contains("하-5"))
            {
                BotCategory05 = txtCategoryTop.Text;

                string categorytxt = cmbCategoryBottom.Text;

                switch (categorytxt)
                {
                    case string read when categorytxt.Contains("하-1"):
                        txtCategoryBottom.Text = botSubMenu5Dict["Bot_SubMenu1"];
                        break;
                    case string read when categorytxt.Contains("하-2"):
                        txtCategoryBottom.Text = botSubMenu5Dict["Bot_SubMenu2"];
                        break;
                    case string read when categorytxt.Contains("하-3"):
                        txtCategoryBottom.Text = botSubMenu5Dict["Bot_SubMenu3"];
                        break;
                    case string read when categorytxt.Contains("하-4"):
                        txtCategoryBottom.Text = botSubMenu5Dict["Bot_SubMenu4"];
                        break;
                    case string read when categorytxt.Contains("하-5"):
                        txtCategoryBottom.Text = botSubMenu5Dict["Bot_SubMenu5"];
                        break;
                }

            }
            else if (cmbCategoryTop.Text.Contains("하-6"))
            {
                BotCategory06 = txtCategoryTop.Text;

                string categorytxt = cmbCategoryBottom.Text;

                switch (categorytxt)
                {
                    case string read when categorytxt.Contains("하-1"):
                        txtCategoryBottom.Text = botSubMenu6Dict["Bot_SubMenu1"];
                        break;
                    case string read when categorytxt.Contains("하-2"):
                        txtCategoryBottom.Text = botSubMenu6Dict["Bot_SubMenu2"];
                        break;
                    case string read when categorytxt.Contains("하-3"):
                        txtCategoryBottom.Text = botSubMenu6Dict["Bot_SubMenu3"];
                        break;
                    case string read when categorytxt.Contains("하-4"):
                        txtCategoryBottom.Text = botSubMenu6Dict["Bot_SubMenu4"];
                        break;
                    case string read when categorytxt.Contains("하-5"):
                        txtCategoryBottom.Text = botSubMenu6Dict["Bot_SubMenu5"];
                        break;
                }
            }
        }

        private void addCombobox()
        {
            //하위 항목만 저장했을때 안바뀌도록
            if (cmbCategoryTop.Items.Contains(txtCategoryTop.Text) && txtCategoryTop.Text != "")
            {
            }
            cmbCategoryTop.Items.Clear();
            cmbCategoryBottom.Items.Clear();

            txtCategoryBottom.Text = "";
            txtCategoryTop.Text = "";

            string[] TopList = { TopCategory01, TopCategory02, TopCategory03, TopCategory04, TopCategory05, TopCategory06 };
            string[] BotList = { BotCategory01, BotCategory02, BotCategory03, BotCategory04, BotCategory05, BotCategory06 };

            //랜덤
            if (Randomize)
            {
                //상위 항목 추가
                if (RandTopNum != 0)
                {
                    for (int i = 1; i < RandTopNum + 1; i++)
                    {
                        cmbCategoryTop.Items.Add(String.Format("(상-{0}) - " + TopList[i - 1], i.ToString()));
                    }
                }
                //하위 항목 추가
                if (RandBotNum != 0)
                {
                    for (int i = 1; i < RandBotNum + 1; i++)
                    {
                        cmbCategoryTop.Items.Add(String.Format("(하-{0}) - " + BotList[i - 1], i.ToString()));
                    }
                }
            }
            //랜덤아니면
            else
            {
                for (int i = 1; i < TopNum + 1; i++)
                {
                    cmbCategoryTop.Items.Add(String.Format("(상-{0}) - " + TopList[i - 1], i.ToString()));
                }

                for (int i = 1; i < BotNum + 1; i++)
                {
                    cmbCategoryTop.Items.Add(String.Format("(하-{0}) - " + BotList[i - 1], i.ToString()));
                }
            }

            cmbCategoryTop.SelectedIndex = TopIndex;

            #region :: 몰루  :: 
            if (cmbCategoryTop.Text.Contains("상-1"))
            {
                txtCategoryTop.Text = TopCategory01;
                txtCategoryTop.Enabled = true;
                cmbCategoryBottom.Enabled = false;
                txtCategoryBottom.Enabled = false;
                cmbCategoryBottom.Items.Clear();
                txtCategoryBottom.Text = "";
            }
            else if (cmbCategoryTop.Text.Contains("상-2"))
            {
                txtCategoryTop.Text = TopCategory02;
                txtCategoryTop.Enabled = true;
                cmbCategoryBottom.Enabled = false;
                txtCategoryBottom.Enabled = false;
                cmbCategoryBottom.Items.Clear();
                txtCategoryBottom.Text = "";
            }
            else if (cmbCategoryTop.Text.Contains("상-3"))
            {
                txtCategoryTop.Text = TopCategory03;
                txtCategoryTop.Enabled = true;
                cmbCategoryBottom.Enabled = false;
                txtCategoryBottom.Enabled = false;
                cmbCategoryBottom.Items.Clear();
                txtCategoryBottom.Text = "";
            }
            else if (cmbCategoryTop.Text.Contains("상-4"))
            {
                txtCategoryTop.Text = TopCategory04;
                txtCategoryTop.Enabled = true;
                cmbCategoryBottom.Enabled = false;
                txtCategoryBottom.Enabled = false;
                cmbCategoryBottom.Items.Clear();
                txtCategoryBottom.Text = "";
            }
            else if (cmbCategoryTop.Text.Contains("상-5"))
            {
                txtCategoryTop.Text = TopCategory05;
                txtCategoryTop.Enabled = true;
                cmbCategoryBottom.Enabled = false;
                txtCategoryBottom.Enabled = false;
                cmbCategoryBottom.Items.Clear();
                txtCategoryBottom.Text = "";
            }
            else if (cmbCategoryTop.Text.Contains("상-6"))
            {
                txtCategoryTop.Text = TopCategory06;
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = false;
                txtCategoryBottom.Enabled = false;
                cmbCategoryBottom.Items.Clear();
                txtCategoryBottom.Text = "";
            }
            else if (cmbCategoryTop.Text.Contains("하-1"))
            {
                txtCategoryTop.Text = BotCategory01;
                txtCategoryTop.Enabled = true;
                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                for (int i = 1; i < bot1Qty + 1; i++)
                {
                    cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu1Dict[$"Bot_SubMenu1_{i}"]);
                }

                cmbCategoryBottom.SelectedIndex = 0;
            }
            else if (cmbCategoryTop.Text.Contains("하-2"))
            {
                txtCategoryTop.Text = BotCategory02;
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                for (int i = 1; i < bot2Qty + 1; i++)
                {
                    cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu2Dict[$"Bot_SubMenu2_{i}"]);
                }

                cmbCategoryBottom.SelectedIndex = 0;
            }
            else if (cmbCategoryTop.Text.Contains("하-3"))
            {
                txtCategoryTop.Text = BotCategory03;
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                for (int i = 1; i < bot3Qty + 1; i++)
                {
                    cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu3Dict[$"Bot_SubMenu3_{i}"]);
                }

                cmbCategoryBottom.SelectedIndex = 0;
            }
            else if (cmbCategoryTop.Text.Contains("하-4"))
            {
                txtCategoryTop.Text = BotCategory04;
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                for (int i = 1; i < bot4Qty + 1; i++)
                {
                    cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu4Dict[$"Bot_SubMenu4_{i}"]);
                }

                cmbCategoryBottom.SelectedIndex = 0;
            }
            else if (cmbCategoryTop.Text.Contains("하-5"))
            {
                txtCategoryTop.Text = BotCategory05;
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                for (int i = 1; i < bot5Qty + 1; i++)
                {
                    cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu5Dict[$"Bot_SubMenu5_{i}"]);
                }

                cmbCategoryBottom.SelectedIndex = 0;
            }
            else if (cmbCategoryTop.Text.Contains("하-6"))
            {
                txtCategoryTop.Text = BotCategory06;
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                for (int i = 1; i < bot6Qty + 1; i++)
                {
                    cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu6Dict[$"Bot_SubMenu6_{i}"]);
                }
                cmbCategoryBottom.SelectedIndex = 0;
            }
            #endregion

            if (!StartCheck)
            {
                cmbCategoryBottom.SelectedIndex = botIndex;
            }

            StartCheck = false;

        }
        #endregion

        #endregion

        #region :: ETC 이벤트 ::
        //창닫기 이벤트
        private void Popup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SaveChecked)
            {
                DialogResult dialogResult = MessageBox.Show("수정된 항목이 있습니다. 프로그램을 재시작 하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    SaveChecked = false;
                    SaveChecked2 = false;
                    Application.Restart();
                    Environment.Exit(0);
                }
            }
            else if (SaveChecked2)
            {
                DialogResult dialogResult = MessageBox.Show("수정된 항목이 있습니다. 프로그램을 재시작 하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    SaveChecked = false;
                    SaveChecked2 = false;
                    Application.Restart();
                    Environment.Exit(0);
                }
            }
        }

        //랜덤 체크 확인 이벤트
        private void ChkRandom_CheckedChanged(object sender, EventArgs e)
        {
            bool _TempRandomize = ChkRandom.Checked;

            if (_TempRandomize == Randomize)
            {
                SaveChecked2 = false;
                return;
            }
            Properties.Settings.Default.Randomize = _TempRandomize;
            Properties.Settings.Default.Save();

            SaveChecked2 = true;
        }

        #endregion

        #region :: 미사용 ::
        #region ::: 기존 항목 설정 이벤트 모음 :::

        #region :: Combobox Event ::
        //private void cmbCategoryTop2_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    if (cmbCategoryTop2.Text.ToString() == "BGA")
        //    {
        //        cmbCategoryBottom2.Enabled = true;
        //        txtCategoryBottom2.Enabled = true;
        //        cmbCategoryBottom2.Items.Clear();
        //        txtCategoryBottom2.Text = "";

        //        cmbCategoryBottom2.Items.Add("하위 항목 1");
        //        cmbCategoryBottom2.Items.Add("하위 항목 2");
        //        cmbCategoryBottom2.Items.Add("하위 항목 3");
        //        cmbCategoryBottom2.Items.Add("하위 항목 4");
        //        cmbCategoryBottom2.Items.Add("하위 항목 5");

        //        cmbCategoryBottom2.SelectedIndex = 0;
        //    }
        //    else if (cmbCategoryTop2.Text.ToString() == "느낌")
        //    {
        //        cmbCategoryBottom2.Enabled = true;
        //        txtCategoryBottom2.Enabled = true;
        //        cmbCategoryBottom2.Items.Clear();
        //        txtCategoryBottom2.Text = "";

        //        cmbCategoryBottom2.Items.Add("하위 항목 1");
        //        cmbCategoryBottom2.Items.Add("하위 항목 2");
        //        cmbCategoryBottom2.Items.Add("하위 항목 3");
        //        cmbCategoryBottom2.Items.Add("하위 항목 4");
        //        cmbCategoryBottom2.Items.Add("하위 항목 5");


        //        cmbCategoryBottom2.SelectedIndex = 0;
        //    }
        //    else if (cmbCategoryTop2.Text.ToString() == "보컬 언어")
        //    {
        //        cmbCategoryBottom2.Enabled = true;
        //        txtCategoryBottom2.Enabled = true;
        //        cmbCategoryBottom2.Items.Clear();
        //        txtCategoryBottom2.Text = "";

        //        cmbCategoryBottom2.Items.Add("하위 항목 1");
        //        cmbCategoryBottom2.Items.Add("하위 항목 2");
        //        cmbCategoryBottom2.Items.Add("하위 항목 3");

        //        cmbCategoryBottom2.SelectedIndex = 0;
        //    }
        //}

        //private void cmbCategorybottom2_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    txtCategoryBottom2.Clear();

        //    if (cmbCategoryTop2.Text.ToString() == "BGA")
        //    {
        //        if (cmbCategoryBottom2.Text.ToString() == "하위 항목 1")
        //        {
        //            txtCategoryBottom2.Text = dummycontent4_1;
        //        }
        //        else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 2")
        //        {
        //            txtCategoryBottom2.Text = dummycontent4_2;
        //        }
        //        else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 3")
        //        {
        //            txtCategoryBottom2.Text = dummycontent4_3;
        //        }
        //        else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 4")
        //        {
        //            txtCategoryBottom2.Text = dummycontent4_4;
        //        }
        //        else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 5")
        //        {
        //            txtCategoryBottom2.Text = dummycontent4_5;
        //        }
        //    }
        //    else if (cmbCategoryTop2.Text.ToString() == "느낌")
        //    {

        //        if (cmbCategoryBottom2.Text.ToString() == "하위 항목 1")
        //        {
        //            txtCategoryBottom2.Text = dummycontent5_1;
        //        }
        //        else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 2")
        //        {
        //            txtCategoryBottom2.Text = dummycontent5_2;
        //        }
        //        else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 3")
        //        {
        //            txtCategoryBottom2.Text = dummycontent5_3;
        //        }
        //        else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 4")
        //        {
        //            txtCategoryBottom2.Text = dummycontent5_4;
        //        }
        //        else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 5")
        //        {
        //            txtCategoryBottom2.Text = dummycontent5_5;
        //        }
        //    }
        //    else if (cmbCategoryTop2.Text.ToString() == "보컬 언어")
        //    {

        //        if (cmbCategoryBottom2.Text.ToString() == "하위 항목 1")
        //        {
        //            txtCategoryBottom2.Text = dummycontent6_1;
        //        }
        //        else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 2")
        //        {
        //            txtCategoryBottom2.Text = dummycontent6_2;
        //        }
        //        else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 3")
        //        {
        //            txtCategoryBottom2.Text = dummycontent6_3;
        //        }
        //    }
        //}
        //#endregion

        //#region :: button Event ::

        //private void Savebutton2_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (cmbCategoryTop2.SelectedItem == null)
        //        {
        //            MessageBox.Show("항목을 선택하여 주십시오.", "저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //        else if (txtCategoryBottom2.Text == "")
        //        {
        //            MessageBox.Show("하위 항목을 입력하여 주십시오.", "저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }

        //        /* 저장 방식 */
        //        // 1. 상위 항목 선택
        //        // 1-2. 하위 항목 변경 필요 시 하위 항목 선택
        //        // 2. 변경 하고 싶은 항목(상위나 하위) 이름 변경
        //        // 3. 이름 변경 후 [저장] 버튼 클릭
        //        // 4. 확인문 출력
        //        // 5. Properties 내부 값을 업데이트
        //        // 5-2. 업데이트 값이 바로 반영 되지 않는데 이 부분을 해결하기 위해 임시 변수 사용
        //        // 5-3. 업데이트 후 창을 닫으려고 할 때 재부팅 여부 물어보기 (필수)

        //        //항목 저장 버튼 클릭
        //        DialogResult Result = MessageBox.Show("저장하시겠습니까?", "저장 확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        //        if (Result == DialogResult.OK)
        //        {
        //            /* 변수저장 */
        //            //윗라인 
        //            string _TempCateTop = cmbCategoryTop2.Text;
        //            //아랫라인
        //            string _TempCateBot = cmbCategoryBottom2.Text;
        //            string _TempCateChangeBot = txtCategoryBottom2.Text;

        //            //목차용 변수 지정 및 초기화
        //            string BotCatadata = string.Empty;

        //            #region :: 목차 데이터 찾는 코드 ::

        //            if (_TempCateTop == "BGA")
        //            {

        //                if (_TempCateBot == "하위 항목 1")
        //                {
        //                    BotCatadata = "dummycontent4_1";
        //                }
        //                else if (_TempCateBot == "하위 항목 2")
        //                {
        //                    BotCatadata = "dummycontent4_2";
        //                }
        //                else if (_TempCateBot == "하위 항목 3")
        //                {
        //                    BotCatadata = "dummycontent4_3";
        //                }
        //                else if (_TempCateBot == "하위 항목 4")
        //                {
        //                    BotCatadata = "dummycontent4_4";
        //                }
        //                else if (_TempCateBot == "하위 항목 5")
        //                {
        //                    BotCatadata = "dummycontent4_5";
        //                }
        //            }
        //            else if (_TempCateTop == "느낌")
        //            {

        //                if (_TempCateBot == "하위 항목 1")
        //                {
        //                    BotCatadata = "dummycontent5_1";
        //                }
        //                else if (_TempCateBot == "하위 항목 2")
        //                {
        //                    BotCatadata = "dummycontent5_2";
        //                }
        //                else if (_TempCateBot == "하위 항목 3")
        //                {
        //                    BotCatadata = "dummycontent5_3";
        //                }
        //                else if (_TempCateBot == "하위 항목 4")
        //                {
        //                    BotCatadata = "dummycontent5_4";
        //                }
        //                else if (_TempCateBot == "하위 항목 5")
        //                {
        //                    BotCatadata = "dummycontent5_5";
        //                }
        //            }
        //            else if (_TempCateTop == "보컬 언어")
        //            {
        //                if (_TempCateBot == "하위 항목 1")
        //                {
        //                    BotCatadata = "dummycontent6_1";
        //                }
        //                else if (_TempCateBot == "하위 항목 2")
        //                {
        //                    BotCatadata = "dummycontent6_2";
        //                }
        //                else if (_TempCateBot == "하위 항목 3")
        //                {
        //                    BotCatadata = "dummycontent6_3";
        //                }
        //            }
        //            #endregion

        //            //데이터 저장
        //            if (BotCatadata == string.Empty)
        //            {
        //                MessageBox.Show("하위 항목은 공백이 될 수 없습니다.", "저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return;
        //            }
        //            Properties.Settings.Default[BotCatadata] = _TempCateChangeBot;
        //            CataSaveText2();

        //            MessageBox.Show("저장이 완료되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //            SaveChecked = true;

        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        if (ex.Source != null)
        //            Console.WriteLine("IOException source: {0}", ex.Source);
        //        throw;
        //    }
        //}

        //#endregion

        //#region :: ETC Event ::
        ////엔터 키 이벤트
        //private void Enter_KeyDown2(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        Savebutton2_Click(sender, e);
        //    }
        //}


        //private void CataSaveText2()
        //{
        //    if (cmbCategoryTop2.Text.Contains("BGA"))
        //    {
        //        if (cmbCategoryBottom2.Text.Contains("하위 항목 1"))
        //        {
        //            dummycontent4_1 = txtCategoryBottom2.Text;
        //        }
        //        else if (cmbCategoryBottom2.Text.Contains("하위 항목 2"))
        //        {
        //            dummycontent4_2 = txtCategoryBottom2.Text;
        //        }
        //        else if (cmbCategoryBottom2.Text.Contains("하위 항목 3"))
        //        {
        //            dummycontent4_3 = txtCategoryBottom2.Text;
        //        }
        //        else if (cmbCategoryBottom2.Text.Contains("하위 항목 4"))
        //        {
        //            dummycontent4_4 = txtCategoryBottom2.Text;
        //        }
        //        else if (cmbCategoryBottom2.Text.Contains("하위 항목 5"))
        //        {
        //            dummycontent4_5 = txtCategoryBottom2.Text;
        //        }
        //    }
        //    else if (cmbCategoryTop2.Text.Contains("느낌"))
        //    {
        //        if (cmbCategoryBottom2.Text.Contains("하위 항목 1"))
        //        {
        //            dummycontent5_1 = txtCategoryBottom2.Text;
        //        }
        //        else if (cmbCategoryBottom2.Text.Contains("하위 항목 2"))
        //        {
        //            dummycontent5_2 = txtCategoryBottom2.Text;
        //        }
        //        else if (cmbCategoryBottom2.Text.Contains("하위 항목 3"))
        //        {
        //            dummycontent5_3 = txtCategoryBottom2.Text;
        //        }
        //        else if (cmbCategoryBottom2.Text.Contains("하위 항목 4"))
        //        {
        //            dummycontent5_4 = txtCategoryBottom2.Text;
        //        }
        //        else if (cmbCategoryBottom2.Text.Contains("하위 항목 5"))
        //        {
        //            dummycontent5_5 = txtCategoryBottom2.Text;
        //        }
        //    }

        //    else if (cmbCategoryTop2.Text.Contains("보컬 언어"))
        //    {
        //        if (cmbCategoryBottom2.Text.Contains("하위 항목 1"))
        //        {
        //            dummycontent6_1 = txtCategoryBottom2.Text;
        //        }
        //        else if (cmbCategoryBottom2.Text.Contains("하위 항목 2"))
        //        {
        //            dummycontent6_2 = txtCategoryBottom2.Text;
        //        }
        //        else if (cmbCategoryBottom2.Text.Contains("하위 항목 3"))
        //        {
        //            dummycontent6_3 = txtCategoryBottom2.Text;
        //        }
        //    }
        //}
        #endregion

        #endregion

        #endregion

    }
}
