﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
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

        bool Randomize = false;
        bool SuperRandom = false;
        bool GoldenFix = false;

        bool isMake = false;

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
        
        //Dict
        int BotSubQty = 0;
        int TopQty = 0;
        int BotQty = 0;

        //???????
        int bot1Qty = 0;
        int bot2Qty = 0;
        int bot3Qty = 0;
        int bot4Qty = 0;
        int bot5Qty = 0;
        int bot6Qty = 0;
        int bot7Qty = 0;
        int bot8Qty = 0;
        int bot9Qty = 0;

        //Dict
        //Top
        Dictionary<string, string> TopMenuDict = new Dictionary<string, string>();
        Dictionary<string, string> BotMenuDict = new Dictionary<string, string>();

        Dictionary<string, string> botSubMenu1Dict = new Dictionary<string, string>();
        Dictionary<string, string> botSubMenu2Dict = new Dictionary<string, string>();
        Dictionary<string, string> botSubMenu3Dict = new Dictionary<string, string>();
        Dictionary<string, string> botSubMenu4Dict = new Dictionary<string, string>();
        Dictionary<string, string> botSubMenu5Dict = new Dictionary<string, string>();
        Dictionary<string, string> botSubMenu6Dict = new Dictionary<string, string>();
        Dictionary<string, string> botSubMenu7Dict = new Dictionary<string, string>();
        Dictionary<string, string> botSubMenu8Dict = new Dictionary<string, string>();
        Dictionary<string, string> botSubMenu9Dict = new Dictionary<string, string>();

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

            ChkRandom.Font = font1;
            ChkRandom.Checked = Randomize;
            chkSuperRandom.Checked = SuperRandom;

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
                }
            }
            //콤보박스 항목 추가 이벤트
            AddComboboxItems();

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

                TopQty = int.Parse(ini["Option"]["TopQty"].ToString());
                BotQty = int.Parse(ini["Option"]["BotQty"].ToString());

                #region :: 값 불러오기 ::

                if (!isMake)
                {
                    for (int i = 0; i < TopQty; i++)
                    {
                        TopMenuDict.Add($"TopCategory0{i + 1}", ini["Top"][$"TopCategory{i + 1}"].ToString());
                    }
                    for (int i = 0; i < BotQty; i++)
                    {
                        BotMenuDict.Add($"BotCategory0{i + 1}", ini["Bot"][$"BotCategory{i + 1}"].ToString());
                    }
                    isMake = true;
                }

                //하위 더미데이터 불러오는 곳
                BotSubQty = int.Parse(ini["Option"]["BotSubQty"].ToString()); //서브갯수 설정
                //하위 더미데이터
                botSubMenu1Dict = MakeDict("Bot_SubMenu1", 1);
                bot1Qty = int.Parse(ini["Bot_SubMenu1"]["Qty"].ToString());

                botSubMenu2Dict = MakeDict("Bot_SubMenu2", 2);
                bot2Qty = int.Parse(ini["Bot_SubMenu2"]["Qty"].ToString());

                botSubMenu3Dict = MakeDict("Bot_SubMenu3", 3);
                bot3Qty = int.Parse(ini["Bot_SubMenu3"]["Qty"].ToString());

                botSubMenu4Dict = MakeDict("Bot_SubMenu4", 4);
                bot4Qty = int.Parse(ini["Bot_SubMenu4"]["Qty"].ToString());

                botSubMenu5Dict = MakeDict("Bot_SubMenu5", 5);
                bot5Qty = int.Parse(ini["Bot_SubMenu5"]["Qty"].ToString());

                botSubMenu6Dict = MakeDict("Bot_SubMenu6", 6);
                bot6Qty = int.Parse(ini["Bot_SubMenu6"]["Qty"].ToString());

                botSubMenu7Dict = MakeDict("Bot_SubMenu7", 7);
                bot7Qty = int.Parse(ini["Bot_SubMenu7"]["Qty"].ToString());

                botSubMenu8Dict = MakeDict("Bot_SubMenu8", 8);
                bot8Qty = int.Parse(ini["Bot_SubMenu8"]["Qty"].ToString());

                botSubMenu9Dict = MakeDict("Bot_SubMenu9", 9);
                bot9Qty = int.Parse(ini["Bot_SubMenu9"]["Qty"].ToString());

                Randomize = bool.Parse(ini["Option"]["Randomize"].ToString());
                GoldenFix = bool.Parse(ini["Option"]["GoldenFix"].ToString());
                SuperRandom = bool.Parse(ini["Option"]["SuperRandom"].ToString());

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

            for (int i = 1; i < BotSubQty + 1; i++)
            {
                if (ini[$"Bot_SubMenu{a}"][$"BotContent{i}"].ToString() == null)
                {
                    ini[$"Bot_SubMenu{a}"][$"BotContent{i}"] = string.Empty;
                    ini.Save(inipath);
                }

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
                string text = cmbCategoryTop.Text;

                switch (text)
                {
                    case var a when text.Contains("상-"):
                        {
                            txtCategoryTop.Enabled = true;
                            cmbCategoryBottom.Enabled = false;
                            txtCategoryBottom.Enabled = false;
                            cmbCategoryBottom.Items.Clear();
                            txtCategoryBottom.Text = "";
                        }
                        break;
                    case var a when text.Contains("하-"):
                        {
                            txtCategoryTop.Enabled = true;
                            cmbCategoryBottom.Enabled = true;
                            txtCategoryBottom.Enabled = true;
                            cmbCategoryBottom.Items.Clear();
                        }
                        break;
                }

                switch (text)
                {
                    //상위
                    case var a when text.Contains("상-1"):
                        txtCategoryTop.Text = TopMenuDict["TopCategory01"].ToString();
                        break;
                    case var a when text.Contains("상-2"):
                        txtCategoryTop.Text = TopMenuDict["TopCategory02"].ToString();
                        break;
                    case var a when text.Contains("상-3"):
                        txtCategoryTop.Text = TopMenuDict["TopCategory03"].ToString();
                        break;
                    case var a when text.Contains("상-4"):
                        txtCategoryTop.Text = TopMenuDict["TopCategory04"].ToString();
                        break;
                    case var a when text.Contains("상-5"):
                        txtCategoryTop.Text = TopMenuDict["TopCategory05"].ToString();
                        break;
                    case var a when text.Contains("상-6"):
                        txtCategoryTop.Text = TopMenuDict["TopCategory06"].ToString();
                        break;
                    //하위
                    case var a when text.Contains("하-1"):
                        {
                            txtCategoryTop.Text = BotMenuDict["BotCategory01"].ToString();

                            for (int i = 1; i < BotSubQty + 1; i++)
                            {
                                cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu1Dict[$"Bot_SubMenu1_{i}"]);
                            }

                            cmbCategoryBottom.SelectedIndex = 0;
                        }
                        break;
                    case var a when text.Contains("하-2"):
                        {
                            txtCategoryTop.Text = BotMenuDict["BotCategory02"].ToString();

                            for (int i = 1; i < BotSubQty + 1; i++)
                            {
                                cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu2Dict[$"Bot_SubMenu2_{i}"]);
                            }

                            cmbCategoryBottom.SelectedIndex = 0;
                        }
                        break;
                    case var a when text.Contains("하-3"):
                        {
                            txtCategoryTop.Text = BotMenuDict["BotCategory03"].ToString();

                            for (int i = 1; i < BotSubQty + 1; i++)
                            {
                                cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu3Dict[$"Bot_SubMenu3_{i}"]);
                            }

                            cmbCategoryBottom.SelectedIndex = 0;
                        }
                        break;
                    case var a when text.Contains("하-4"):
                        {
                            txtCategoryTop.Text = BotMenuDict["BotCategory04"].ToString();

                            for (int i = 1; i < BotSubQty + 1; i++)
                            {
                                cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu4Dict[$"Bot_SubMenu4_{i}"]);
                            }

                            cmbCategoryBottom.SelectedIndex = 0;
                        }
                        break;
                    case var a when text.Contains("하-5"):
                        {
                            txtCategoryTop.Text = BotMenuDict["BotCategory05"].ToString();

                            for (int i = 1; i < BotSubQty + 1; i++)
                            {
                                cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu5Dict[$"Bot_SubMenu5_{i}"]);
                            }

                            cmbCategoryBottom.SelectedIndex = 0;
                        }
                        break;
                    case var a when text.Contains("하-6"):
                        {
                            txtCategoryTop.Text = BotMenuDict["BotCategory06"].ToString();

                            for (int i = 1; i < BotSubQty + 1; i++)
                            {
                                cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu6Dict[$"Bot_SubMenu6_{i}"]);
                            }

                            cmbCategoryBottom.SelectedIndex = 0;
                        }
                        break;
                    case var a when text.Contains("하-7"):
                        {
                            txtCategoryTop.Text = BotMenuDict["BotCategory07"].ToString();

                            for (int i = 1; i < BotSubQty + 1; i++)
                            {
                                cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu7Dict[$"Bot_SubMenu7_{i}"]);
                            }

                            cmbCategoryBottom.SelectedIndex = 0;
                        }
                        break;
                    case var a when text.Contains("하-8"):
                        {
                            txtCategoryTop.Text = BotMenuDict["BotCategory08"].ToString();

                            for (int i = 1; i < BotSubQty + 1; i++)
                            {
                                cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu8Dict[$"Bot_SubMenu8_{i}"]);
                            }

                            cmbCategoryBottom.SelectedIndex = 0;
                        }
                        break;
                    case var a when text.Contains("하-9"):
                        {
                            txtCategoryTop.Text = BotMenuDict["BotCategory09"].ToString();

                            for (int i = 1; i < BotSubQty + 1; i++)
                            {
                                cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu9Dict[$"Bot_SubMenu9_{i}"]);
                            }

                            cmbCategoryBottom.SelectedIndex = 0;
                        }
                        break;
                }

                #region :: 구형 ::
                //상위 항목 선택 후 그것에 대한 설정
                //if (cmbCategoryTop.Text.Contains("상-1"))
                //{
                //    txtCategoryTop.Text = TopCategory01;
                //}
                //else if (cmbCategoryTop.Text.Contains("상-2"))
                //{
                //    txtCategoryTop.Text = TopCategory02;
                //}
                //else if (cmbCategoryTop.Text.Contains("상-3"))
                //{
                //    txtCategoryTop.Text = TopCategory03;
                //}
                //else if (cmbCategoryTop.Text.Contains("상-4"))
                //{
                //    txtCategoryTop.Text = TopCategory04;
                //}
                //else if (cmbCategoryTop.Text.Contains("상-5"))
                //{
                //    txtCategoryTop.Text = TopCategory05;
                //}
                //else if (cmbCategoryTop.Text.Contains("상-6"))
                //{
                //    txtCategoryTop.Text = TopCategory06;
                //}
                //if (cmbCategoryTop.Text.Contains("하-1"))
                // {
                //     txtCategoryTop.Text = BotCategory01;

                //     for (int i = 1; i < bot1Qty+1; i++)
                //     {
                //         cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu1Dict[$"Bot_SubMenu1_{i}"]);
                //     }

                //     cmbCategoryBottom.SelectedIndex = 0;
                // }
                // else if (cmbCategoryTop.Text.Contains("하-2"))
                // {
                //     txtCategoryTop.Text = BotCategory02;

                //     for (int i = 1; i < bot2Qty + 1; i++)
                //     {
                //         cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu2Dict[$"Bot_SubMenu2_{i}"]);
                //     }

                //     cmbCategoryBottom.SelectedIndex = 0;
                // }
                // else if (cmbCategoryTop.Text.Contains("하-3"))
                // {
                //     txtCategoryTop.Text = BotCategory03;

                //     for (int i = 1; i < bot3Qty + 1; i++)
                //     {
                //         cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu3Dict[$"Bot_SubMenu3_{i}"]);
                //     }

                //     cmbCategoryBottom.SelectedIndex = 0;
                // }
                // else if (cmbCategoryTop.Text.Contains("하-4"))
                // {
                //     txtCategoryTop.Text = BotCategory04;

                //     cmbCategoryBottom.Items.Clear();

                //     for (int i = 1; i < bot4Qty + 1; i++)
                //     {
                //         cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu4Dict[$"Bot_SubMenu4_{i}"]);
                //     }
                //     cmbCategoryBottom.SelectedIndex = 0;
                // }
                // else if (cmbCategoryTop.Text.Contains("하-5"))
                // {
                //     txtCategoryTop.Text = BotCategory05;

                //     for (int i = 1; i < bot5Qty + 1; i++)
                //     {
                //         cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu5Dict[$"Bot_SubMenu5_{i}"]);
                //     }
                //     cmbCategoryBottom.SelectedIndex = 0;
                // }
                // else if (cmbCategoryTop.Text.Contains("하-6"))
                // {
                //     txtCategoryTop.Text = BotCategory06;

                //     cmbCategoryBottom.Items.Clear();

                //     for (int i = 1; i < bot6Qty + 1; i++)
                //     {
                //         cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu6Dict[$"Bot_SubMenu6_{i}"]);
                //     }
                //     cmbCategoryBottom.SelectedIndex = 0;
                // }
                // else if (cmbCategoryTop.Text.Contains("하-7"))
                // {
                //     txtCategoryTop.Text = BotCategory07;

                //     cmbCategoryBottom.Items.Clear();

                //     for (int i = 1; i < bot7Qty + 1; i++)
                //     {
                //         cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu7Dict[$"Bot_SubMenu7_{i}"]);
                //     }
                //     cmbCategoryBottom.SelectedIndex = 0;
                // }
                // else if (cmbCategoryTop.Text.Contains("하-8"))
                // {
                //     txtCategoryTop.Text = BotCategory08;

                //     cmbCategoryBottom.Items.Clear();

                //     for (int i = 1; i < bot8Qty + 1; i++)
                //     {
                //         cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu8Dict[$"Bot_SubMenu8_{i}"]);
                //     }
                //     cmbCategoryBottom.SelectedIndex = 0;
                // }
                // else if (cmbCategoryTop.Text.Contains("하-9"))
                // {
                //     txtCategoryTop.Text = BotCategory09;

                //     cmbCategoryBottom.Items.Clear();

                //     for (int i = 1; i < bot9Qty + 1; i++)
                //     {
                //         cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu9Dict[$"Bot_SubMenu9_{i}"]);
                //     }
                //     cmbCategoryBottom.SelectedIndex = 0;
                // }
                #endregion
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
                else if (cmbCategoryTop.Text.Contains("하-7"))
                {
                    switch (categorytxt)
                    {
                        case string read when categorytxt.Contains("하-1"):
                            txtCategoryBottom.Text = botSubMenu7Dict["Bot_SubMenu1"];
                            break;
                        case string read when categorytxt.Contains("하-2"):
                            txtCategoryBottom.Text = botSubMenu7Dict["Bot_SubMenu2"];
                            break;
                        case string read when categorytxt.Contains("하-3"):
                            txtCategoryBottom.Text = botSubMenu7Dict["Bot_SubMenu3"];
                            break;
                        case string read when categorytxt.Contains("하-4"):
                            txtCategoryBottom.Text = botSubMenu7Dict["Bot_SubMenu4"];
                            break;
                        case string read when categorytxt.Contains("하-5"):
                            txtCategoryBottom.Text = botSubMenu7Dict["Bot_SubMenu5"];
                            break;
                    }
                }
                else if (cmbCategoryTop.Text.Contains("하-8"))
                {
                    switch (categorytxt)
                    {
                        case string read when categorytxt.Contains("하-1"):
                            txtCategoryBottom.Text = botSubMenu8Dict["Bot_SubMenu1"];
                            break;
                        case string read when categorytxt.Contains("하-2"):
                            txtCategoryBottom.Text = botSubMenu8Dict["Bot_SubMenu2"];
                            break;
                        case string read when categorytxt.Contains("하-3"):
                            txtCategoryBottom.Text = botSubMenu8Dict["Bot_SubMenu3"];
                            break;
                        case string read when categorytxt.Contains("하-4"):
                            txtCategoryBottom.Text = botSubMenu8Dict["Bot_SubMenu4"];
                            break;
                        case string read when categorytxt.Contains("하-5"):
                            txtCategoryBottom.Text = botSubMenu8Dict["Bot_SubMenu5"];
                            break;
                    }
                }
                else if (cmbCategoryTop.Text.Contains("하-9"))
                {
                    switch (categorytxt)
                    {
                        case string read when categorytxt.Contains("하-1"):
                            txtCategoryBottom.Text = botSubMenu9Dict["Bot_SubMenu1"];
                            break;
                        case string read when categorytxt.Contains("하-2"):
                            txtCategoryBottom.Text = botSubMenu9Dict["Bot_SubMenu2"];
                            break;
                        case string read when categorytxt.Contains("하-3"):
                            txtCategoryBottom.Text = botSubMenu9Dict["Bot_SubMenu3"];
                            break;
                        case string read when categorytxt.Contains("하-4"):
                            txtCategoryBottom.Text = botSubMenu9Dict["Bot_SubMenu4"];
                            break;
                        case string read when categorytxt.Contains("하-5"):
                            txtCategoryBottom.Text = botSubMenu9Dict["Bot_SubMenu5"];
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

                                //항목의 전체개수가 바뀌면 J를 바꿔주세요.
                                for (int j = 1; j < BotSubQty + 1; j++)
                                {
                                    if (_TempCateBot.Contains(String.Format($"하위{j}")))
                                    {
                                        BotCatadata = $"BotContent{j}";
                                        botidx = j;
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

                    //CataSaveText();

                    AddComboboxItems();

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
            //if (cmbCategoryTop.Text.Contains("상-1"))
            //{
            //    TopCat = txtCategoryTop.Text;
            //}
            //else if (cmbCategoryTop.Text.Contains("상-2"))
            //{
            //    TopCategory02 = txtCategoryTop.Text;
            //}
            //else if (cmbCategoryTop.Text.Contains("상-3"))
            //{
            //    TopCategory03 = txtCategoryTop.Text;
            //}
            //else if (cmbCategoryTop.Text.Contains("상-4"))
            //{
            //    TopCategory04 = txtCategoryTop.Text;
            //}
            //else if (cmbCategoryTop.Text.Contains("상-5"))
            //{
            //    TopCategory05 = txtCategoryTop.Text;
            //}
            //else if (cmbCategoryTop.Text.Contains("상-6"))
            //{
            //    TopCategory06 = txtCategoryTop.Text;
            //}
            //else if (cmbCategoryTop.Text.Contains("하-1"))
            //{
            //    BotCategory01 = txtCategoryTop.Text;
            //    string categorytxt = cmbCategoryBottom.Text;

            //    switch (categorytxt)
            //    {
            //        case string read when categorytxt.Contains("하-1"):
            //            txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu1"];
            //            break;
            //        case string read when categorytxt.Contains("하-2"):
            //            txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu2"];
            //            break;
            //        case string read when categorytxt.Contains("하-3"):
            //            txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu3"];
            //            break;
            //        case string read when categorytxt.Contains("하-4"):
            //            txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu4"];
            //            break;
            //        case string read when categorytxt.Contains("하-5"):
            //            txtCategoryBottom.Text = botSubMenu1Dict["Bot_SubMenu5"];
            //            break;
            //    }
            //}
            //else if (cmbCategoryTop.Text.Contains("하-2"))
            //{
            //    BotCategory02 = txtCategoryTop.Text;

            //    string categorytxt = cmbCategoryBottom.Text;

            //    switch (categorytxt)
            //    {
            //        case string read when categorytxt.Contains("하-1"):
            //            txtCategoryBottom.Text = botSubMenu2Dict["Bot_SubMenu1"];
            //            break;
            //        case string read when categorytxt.Contains("하-2"):
            //            txtCategoryBottom.Text = botSubMenu2Dict["Bot_SubMenu2"];
            //            break;
            //        case string read when categorytxt.Contains("하-3"):
            //            txtCategoryBottom.Text = botSubMenu2Dict["Bot_SubMenu3"];
            //            break;
            //        case string read when categorytxt.Contains("하-4"):
            //            txtCategoryBottom.Text = botSubMenu2Dict["Bot_SubMenu4"];
            //            break;
            //        case string read when categorytxt.Contains("하-5"):
            //            txtCategoryBottom.Text = botSubMenu2Dict["Bot_SubMenu5"];
            //            break;
            //    }

            //}
            //else if (cmbCategoryTop.Text.Contains("하-3"))
            //{
            //    BotCategory03 = txtCategoryTop.Text;

            //    string categorytxt = cmbCategoryBottom.Text;

            //    switch (categorytxt)
            //    {
            //        case string read when categorytxt.Contains("하-1"):
            //            txtCategoryBottom.Text = botSubMenu3Dict["Bot_SubMenu1"];
            //            break;
            //        case string read when categorytxt.Contains("하-2"):
            //            txtCategoryBottom.Text = botSubMenu3Dict["Bot_SubMenu2"];
            //            break;
            //        case string read when categorytxt.Contains("하-3"):
            //            txtCategoryBottom.Text = botSubMenu3Dict["Bot_SubMenu3"];
            //            break;
            //        case string read when categorytxt.Contains("하-4"):
            //            txtCategoryBottom.Text = botSubMenu3Dict["Bot_SubMenu4"];
            //            break;
            //        case string read when categorytxt.Contains("하-5"):
            //            txtCategoryBottom.Text = botSubMenu3Dict["Bot_SubMenu5"];
            //            break;
            //    }

            //}
            ////임시 5/5/3
            //else if (cmbCategoryTop.Text.Contains("하-4"))
            //{
            //    BotCategory04 = txtCategoryTop.Text;

            //    string categorytxt = cmbCategoryBottom.Text;

            //    switch (categorytxt)
            //    {
            //        case string read when categorytxt.Contains("하-1"):
            //            txtCategoryBottom.Text = botSubMenu4Dict["Bot_SubMenu1"];
            //            break;
            //        case string read when categorytxt.Contains("하-2"):
            //            txtCategoryBottom.Text = botSubMenu4Dict["Bot_SubMenu2"];
            //            break;
            //        case string read when categorytxt.Contains("하-3"):
            //            txtCategoryBottom.Text = botSubMenu4Dict["Bot_SubMenu3"];
            //            break;
            //        case string read when categorytxt.Contains("하-4"):
            //            txtCategoryBottom.Text = botSubMenu4Dict["Bot_SubMenu4"];
            //            break;
            //        case string read when categorytxt.Contains("하-5"):
            //            txtCategoryBottom.Text = botSubMenu4Dict["Bot_SubMenu5"];
            //            break;
            //    }

            //}
            //else if (cmbCategoryTop.Text.Contains("하-5"))
            //{
            //    BotCategory05 = txtCategoryTop.Text;

            //    string categorytxt = cmbCategoryBottom.Text;

            //    switch (categorytxt)
            //    {
            //        case string read when categorytxt.Contains("하-1"):
            //            txtCategoryBottom.Text = botSubMenu5Dict["Bot_SubMenu1"];
            //            break;
            //        case string read when categorytxt.Contains("하-2"):
            //            txtCategoryBottom.Text = botSubMenu5Dict["Bot_SubMenu2"];
            //            break;
            //        case string read when categorytxt.Contains("하-3"):
            //            txtCategoryBottom.Text = botSubMenu5Dict["Bot_SubMenu3"];
            //            break;
            //        case string read when categorytxt.Contains("하-4"):
            //            txtCategoryBottom.Text = botSubMenu5Dict["Bot_SubMenu4"];
            //            break;
            //        case string read when categorytxt.Contains("하-5"):
            //            txtCategoryBottom.Text = botSubMenu5Dict["Bot_SubMenu5"];
            //            break;
            //    }

            //}
            //else if (cmbCategoryTop.Text.Contains("하-6"))
            //{
            //    BotCategory06 = txtCategoryTop.Text;

            //    string categorytxt = cmbCategoryBottom.Text;

            //    switch (categorytxt)
            //    {
            //        case string read when categorytxt.Contains("하-1"):
            //            txtCategoryBottom.Text = botSubMenu6Dict["Bot_SubMenu1"];
            //            break;
            //        case string read when categorytxt.Contains("하-2"):
            //            txtCategoryBottom.Text = botSubMenu6Dict["Bot_SubMenu2"];
            //            break;
            //        case string read when categorytxt.Contains("하-3"):
            //            txtCategoryBottom.Text = botSubMenu6Dict["Bot_SubMenu3"];
            //            break;
            //        case string read when categorytxt.Contains("하-4"):
            //            txtCategoryBottom.Text = botSubMenu6Dict["Bot_SubMenu4"];
            //            break;
            //        case string read when categorytxt.Contains("하-5"):
            //            txtCategoryBottom.Text = botSubMenu6Dict["Bot_SubMenu5"];
            //            break;
            //    }
            //}
            //else if (cmbCategoryTop.Text.Contains("하-7"))
            //{
            //    BotCategory07 = txtCategoryTop.Text;

            //    string categorytxt = cmbCategoryBottom.Text;

            //    switch (categorytxt)
            //    {
            //        case string read when categorytxt.Contains("하-1"):
            //            txtCategoryBottom.Text = botSubMenu7Dict["Bot_SubMenu1"];
            //            break;
            //        case string read when categorytxt.Contains("하-2"):
            //            txtCategoryBottom.Text = botSubMenu7Dict["Bot_SubMenu2"];
            //            break;
            //        case string read when categorytxt.Contains("하-3"):
            //            txtCategoryBottom.Text = botSubMenu7Dict["Bot_SubMenu3"];
            //            break;
            //        case string read when categorytxt.Contains("하-4"):
            //            txtCategoryBottom.Text = botSubMenu7Dict["Bot_SubMenu4"];
            //            break;
            //        case string read when categorytxt.Contains("하-5"):
            //            txtCategoryBottom.Text = botSubMenu7Dict["Bot_SubMenu5"];
            //            break;
            //    }
            //}
            //else if (cmbCategoryTop.Text.Contains("하-8"))
            //{
            //    BotCategory08 = txtCategoryTop.Text;

            //    string categorytxt = cmbCategoryBottom.Text;

            //    switch (categorytxt)
            //    {
            //        case string read when categorytxt.Contains("하-1"):
            //            txtCategoryBottom.Text = botSubMenu8Dict["Bot_SubMenu1"];
            //            break;
            //        case string read when categorytxt.Contains("하-2"):
            //            txtCategoryBottom.Text = botSubMenu8Dict["Bot_SubMenu2"];
            //            break;
            //        case string read when categorytxt.Contains("하-3"):
            //            txtCategoryBottom.Text = botSubMenu8Dict["Bot_SubMenu3"];
            //            break;
            //        case string read when categorytxt.Contains("하-4"):
            //            txtCategoryBottom.Text = botSubMenu8Dict["Bot_SubMenu4"];
            //            break;
            //        case string read when categorytxt.Contains("하-5"):
            //            txtCategoryBottom.Text = botSubMenu8Dict["Bot_SubMenu5"];
            //            break;
            //    }
            //}
            //else if (cmbCategoryTop.Text.Contains("하-9"))
            //{
            //    BotCategory09 = txtCategoryTop.Text;

            //    string categorytxt = cmbCategoryBottom.Text;

            //    switch (categorytxt)
            //    {
            //        case string read when categorytxt.Contains("하-1"):
            //            txtCategoryBottom.Text = botSubMenu9Dict["Bot_SubMenu1"];
            //            break;
            //        case string read when categorytxt.Contains("하-2"):
            //            txtCategoryBottom.Text = botSubMenu9Dict["Bot_SubMenu2"];
            //            break;
            //        case string read when categorytxt.Contains("하-3"):
            //            txtCategoryBottom.Text = botSubMenu9Dict["Bot_SubMenu3"];
            //            break;
            //        case string read when categorytxt.Contains("하-4"):
            //            txtCategoryBottom.Text = botSubMenu9Dict["Bot_SubMenu4"];
            //            break;
            //        case string read when categorytxt.Contains("하-5"):
            //            txtCategoryBottom.Text = botSubMenu9Dict["Bot_SubMenu5"];
            //            break;
            //    }
            //}
        }

        private void AddComboboxItems()
        {
            cmbCategoryTop.Items.Clear();
            cmbCategoryBottom.Items.Clear();

            txtCategoryBottom.Text = "";
            txtCategoryTop.Text = "";

            string[] TopList = TopMenuDict.Values.ToArray();
            string[] BotList = BotMenuDict.Values.ToArray();


            //수정 : 모든 항목이 전체적으로 다 보이도록 변경되었습니다다다.
            //원래는 랜덤시와 비랜덤시가 구분되어있었는데 전체적으로 수정가능하게 변경되어서 .. ㅋㅋ
            //랜덤
            if (Randomize)
            {
                //상위 항목 추가
                if (RandTopNum != 0)
                {
                    for (int i = 1; i < TopQty; i++)
                    {
                        cmbCategoryTop.Items.Add(String.Format("(상-{0}) - " + TopList[i - 1], i.ToString()));
                    }
                }
                //하위 항목 추가
                if (RandBotNum != 0)
                {
                    for (int i = 1; i < BotQty; i++)
                    {
                        cmbCategoryTop.Items.Add(String.Format("(하-{0}) - " + BotList[i - 1], i.ToString()));
                    }
                }
            }
            //랜덤아니면
            else
            {
                for (int i = 1; i < TopQty; i++)
                {
                    cmbCategoryTop.Items.Add(String.Format("(상-{0}) - " + TopList[i - 1], i.ToString()));
                }

                for (int i = 1; i < BotQty; i++)
                {
                    cmbCategoryTop.Items.Add(String.Format("(하-{0}) - " + BotList[i - 1], i.ToString()));
                }
            }

            cmbCategoryTop.SelectedIndex = TopIndex;

            #region :: 몰루  :: 
            if (cmbCategoryTop.Text.Contains("상-1"))
            {
                txtCategoryTop.Text = TopMenuDict["TopCategory01"].ToString();
                txtCategoryTop.Enabled = true;
                cmbCategoryBottom.Enabled = false;
                txtCategoryBottom.Enabled = false;
                cmbCategoryBottom.Items.Clear();
                txtCategoryBottom.Text = "";
            }
            else if (cmbCategoryTop.Text.Contains("상-2"))
            {
                txtCategoryTop.Text = TopMenuDict["TopCategory02"].ToString();
                txtCategoryTop.Enabled = true;
                cmbCategoryBottom.Enabled = false;
                txtCategoryBottom.Enabled = false;
                cmbCategoryBottom.Items.Clear();
                txtCategoryBottom.Text = "";
            }
            else if (cmbCategoryTop.Text.Contains("상-3"))
            {
                txtCategoryTop.Text = TopMenuDict["TopCategory03"].ToString();
                txtCategoryTop.Enabled = true;
                cmbCategoryBottom.Enabled = false;
                txtCategoryBottom.Enabled = false;
                cmbCategoryBottom.Items.Clear();
                txtCategoryBottom.Text = "";
            }
            else if (cmbCategoryTop.Text.Contains("상-4"))
            {
                txtCategoryTop.Text = TopMenuDict["TopCategory04"].ToString();
                txtCategoryTop.Enabled = true;
                cmbCategoryBottom.Enabled = false;
                txtCategoryBottom.Enabled = false;
                cmbCategoryBottom.Items.Clear();
                txtCategoryBottom.Text = "";
            }
            else if (cmbCategoryTop.Text.Contains("상-5"))
            {
                txtCategoryTop.Text = TopMenuDict["TopCategory05"].ToString();
                txtCategoryTop.Enabled = true;
                cmbCategoryBottom.Enabled = false;
                txtCategoryBottom.Enabled = false;
                cmbCategoryBottom.Items.Clear();
                txtCategoryBottom.Text = "";
            }
            else if (cmbCategoryTop.Text.Contains("상-6"))
            {
                txtCategoryTop.Text = TopMenuDict["TopCategory06"].ToString();
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = false;
                txtCategoryBottom.Enabled = false;
                cmbCategoryBottom.Items.Clear();
                txtCategoryBottom.Text = "";
            }
            else if (cmbCategoryTop.Text.Contains("하-1"))
            {
                txtCategoryTop.Text = BotMenuDict["BotCategory01"].ToString();
                txtCategoryTop.Enabled = true;
                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                for (int i = 1; i < BotSubQty + 1; i++)
                {
                    cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu1Dict[$"Bot_SubMenu1_{i}"]);
                }

                cmbCategoryBottom.SelectedIndex = 0;
            }
            else if (cmbCategoryTop.Text.Contains("하-2"))
            {
                txtCategoryTop.Text = BotMenuDict["BotCategory02"].ToString();
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                for (int i = 1; i < BotSubQty + 1; i++)
                {
                    cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu2Dict[$"Bot_SubMenu2_{i}"]);
                }

                cmbCategoryBottom.SelectedIndex = 0;
            }
            else if (cmbCategoryTop.Text.Contains("하-3"))
            {
                txtCategoryTop.Text = BotMenuDict["BotCategory03"].ToString();
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                for (int i = 1; i < BotSubQty + 1; i++)
                {
                    cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu3Dict[$"Bot_SubMenu3_{i}"]);
                }

                cmbCategoryBottom.SelectedIndex = 0;
            }
            else if (cmbCategoryTop.Text.Contains("하-4"))
            {
                txtCategoryTop.Text = BotMenuDict["BotCategory04"].ToString();
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                for (int i = 1; i < BotSubQty + 1; i++)
                {
                    cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu4Dict[$"Bot_SubMenu4_{i}"]);
                }

                cmbCategoryBottom.SelectedIndex = 0;
            }
            else if (cmbCategoryTop.Text.Contains("하-5"))
            {
                txtCategoryTop.Text = BotMenuDict["BotCategory05"].ToString();
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                for (int i = 1; i < BotSubQty + 1; i++)
                {
                    cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu5Dict[$"Bot_SubMenu5_{i}"]);
                }

                cmbCategoryBottom.SelectedIndex = 0;
            }
            else if (cmbCategoryTop.Text.Contains("하-6"))
            {
                txtCategoryTop.Text = BotMenuDict["BotCategory06"].ToString();
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                for (int i = 1; i < BotSubQty + 1; i++)
                {
                    cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu6Dict[$"Bot_SubMenu6_{i}"]);
                }
                cmbCategoryBottom.SelectedIndex = 0;
            }
            else if (cmbCategoryTop.Text.Contains("하-7"))
            {
                txtCategoryTop.Text = BotMenuDict["BotCategory07"].ToString();
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                for (int i = 1; i < BotSubQty + 1; i++)
                {
                    cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu7Dict[$"Bot_SubMenu7_{i}"]);
                }

                cmbCategoryBottom.SelectedIndex = 0;
            }
            else if (cmbCategoryTop.Text.Contains("하-8"))
            {
                txtCategoryTop.Text = BotMenuDict["BotCategory08"].ToString();
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                for (int i = 1; i < BotSubQty + 1; i++)
                {
                    cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu8Dict[$"Bot_SubMenu8_{i}"]);
                }

                cmbCategoryBottom.SelectedIndex = 0;
            }
            else if (cmbCategoryTop.Text.Contains("하-9"))
            {
                txtCategoryTop.Text = BotMenuDict["BotCategory09"].ToString();
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                for (int i = 1; i < BotSubQty + 1; i++)
                {
                    cmbCategoryBottom.Items.Add($"하위{i} - " + botSubMenu9Dict[$"Bot_SubMenu9_{i}"]);
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
            ini["Option"]["Randomize"] = _TempRandomize;
            ini.Save(inipath);

            SaveChecked2 = true;
        }

        private void chkSuperRandom_CheckedChanged(object sender, EventArgs e)
        {
            bool _TempRandomize = chkSuperRandom.Checked;
            if (_TempRandomize == SuperRandom)
            {
                SaveChecked2 = false;
                return;
            }
            ini["Option"]["SuperRandom"] = _TempRandomize;
            ini.Save(inipath);

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
