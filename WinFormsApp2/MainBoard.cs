using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Globalization;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Policy;
using static System.Net.WebRequestMethods;
using System.Reflection;

namespace RhythmMonopoly
{
    public partial class MainBoard : Form
    {
        #region :: ���� ���� ;:
        IniFile ini = new IniFile();
        string inipath = Application.StartupPath + @"/Settings.ini";
        //�� ��ġ ����
        bool Labellocation = false;

        #endregion 

        public MainBoard()
        {
            InitializeComponent();

            InitializeINI(inipath);

            #region :: ���� ���� ::
            //�����Լ�
            Random rd = new Random();
            //��Ʈ����
            Font font1 = new Font(FontManager.fontFamilys[0], 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

            //��Ʈ�ѹڽ� ����
            this.ControlBox = false;

            //ũ�� ����
            this.MinimumSize = new Size(1920, 1080);
            this.MaximumSize = new Size(1920, 1080);

            //�ΰ� ��ǥbot_SubMenu1_1
            labelLogo.Left = (this.ClientSize.Width - labelLogo.Width) / 2;
            labelLogo.Top = (this.ClientSize.Height - labelLogo.Height) / 2;


            int dict_idx = 0;
            #endregion

            #region :: ���� �ҷ����� ::
            //�Ƕ��� �׸��
            ini.Load(inipath);

            Dictionary<string, string> topCategorydict = new Dictionary<string, string>();
            Dictionary<string, string> botCategorydict = new Dictionary<string, string>();

            for (int i = 1; i < int.Parse(ini["Option"]["TopBotQty"].ToString()) + 1; i++)
            {
                topCategorydict.Add($"topCategory0{i}", ini["Top"][$"TopCategory{i}"].ToString());
                botCategorydict.Add($"botCategory0{i}", ini["Bot"][$"BotCategory{i}"].ToString());
            }

            string topCategory01 = ini["Top"]["TopCategory1"].ToString(); //����  
            string topCategory02 = ini["Top"]["TopCategory2"].ToString(); //����
            string topCategory03 = ini["Top"]["TopCategory3"].ToString(); //����
            string topCategory04 = ini["Top"]["TopCategory4"].ToString(); //����
            string topCategory05 = ini["Top"]["TopCategory5"].ToString(); //����
            string topCategory06 = ini["Top"]["TopCategory6"].ToString(); //����

            string botCategory01 = ini["Bot"]["BotCategory1"].ToString(); //���� + ����
            string botCategory02 = ini["Bot"]["BotCategory2"].ToString(); //���� + ����
            string botCategory03 = ini["Bot"]["BotCategory3"].ToString(); //���� + ����
            string botCategory04 = ini["Bot"]["BotCategory4"].ToString(); //���� + ����
            string botCategory05 = ini["Bot"]["BotCategory5"].ToString(); //���� + ����
            string botCategory06 = ini["Bot"]["BotCategory6"].ToString(); //���� + ����


            Dictionary<string, string> bot_SubMenu1 = new Dictionary<string, string>();
            Dictionary<string, string> bot_SubMenu2 = new Dictionary<string, string>();
            Dictionary<string, string> bot_SubMenu3 = new Dictionary<string, string>();
            Dictionary<string, string> bot_SubMenu4 = new Dictionary<string, string>();
            Dictionary<string, string> bot_SubMenu5 = new Dictionary<string, string>();
            Dictionary<string, string> bot_SubMenu6 = new Dictionary<string, string>();

            for (int i = 1; i < int.Parse(ini["Option"]["BotSubQty"].ToString())+1; i++)
            {
                bot_SubMenu1.Add($"bot_SubMenu1_{i}", ini["Bot_SubMenu1"][$"BotContent{i}"].ToString());
                bot_SubMenu2.Add($"bot_SubMenu2_{i}", ini["Bot_SubMenu2"][$"BotContent{i}"].ToString());
                bot_SubMenu3.Add($"bot_SubMenu3_{i}", ini["Bot_SubMenu3"][$"BotContent{i}"].ToString());
                bot_SubMenu4.Add($"bot_SubMenu4_{i}", ini["Bot_SubMenu4"][$"BotContent{i}"].ToString());
                bot_SubMenu5.Add($"bot_SubMenu5_{i}", ini["Bot_SubMenu5"][$"BotContent{i}"].ToString());
                bot_SubMenu6.Add($"bot_SubMenu6_{i}", ini["Bot_SubMenu6"][$"BotContent{i}"].ToString());
            }

            //���� ���̵�����
            string bot_SubMenu1_1 = ini["Bot_SubMenu1"]["BotContent1"].ToString();
            string bot_SubMenu1_2 = ini["Bot_SubMenu1"]["BotContent2"].ToString();
            string bot_SubMenu1_3 = ini["Bot_SubMenu1"]["BotContent3"].ToString();
            string bot_SubMenu1_4 = ini["Bot_SubMenu1"]["BotContent4"].ToString();
            string bot_SubMenu1_5 = ini["Bot_SubMenu1"]["BotContent5"].ToString();

            string bot_SubMenu2_1 = ini["Bot_SubMenu2"]["BotContent1"].ToString();
            string bot_SubMenu2_2 = ini["Bot_SubMenu2"]["BotContent2"].ToString();
            string bot_SubMenu2_3 = ini["Bot_SubMenu2"]["BotContent3"].ToString();
            string bot_SubMenu2_4 = ini["Bot_SubMenu2"]["BotContent4"].ToString();
            string bot_SubMenu2_5 = ini["Bot_SubMenu2"]["BotContent5"].ToString();

            string bot_SubMenu3_1 = ini["Bot_SubMenu3"]["BotContent1"].ToString();
            string bot_SubMenu3_2 = ini["Bot_SubMenu3"]["BotContent2"].ToString();
            string bot_SubMenu3_3 = ini["Bot_SubMenu3"]["BotContent3"].ToString();
            string bot_SubMenu3_4 = ini["Bot_SubMenu3"]["BotContent4"].ToString();
            string bot_SubMenu3_5 = ini["Bot_SubMenu3"]["BotContent5"].ToString();

            string bot_SubMenu4_1 = ini["Bot_SubMenu4"]["BotContent1"].ToString();
            string bot_SubMenu4_2 = ini["Bot_SubMenu4"]["BotContent2"].ToString();
            string bot_SubMenu4_3 = ini["Bot_SubMenu4"]["BotContent3"].ToString();
            string bot_SubMenu4_4 = ini["Bot_SubMenu4"]["BotContent4"].ToString();
            string bot_SubMenu4_5 = ini["Bot_SubMenu4"]["BotContent5"].ToString();

            string bot_SubMenu5_1 = ini["Bot_SubMenu5"]["BotContent1"].ToString();
            string bot_SubMenu5_2 = ini["Bot_SubMenu5"]["BotContent2"].ToString();
            string bot_SubMenu5_3 = ini["Bot_SubMenu5"]["BotContent3"].ToString();
            string bot_SubMenu5_4 = ini["Bot_SubMenu5"]["BotContent4"].ToString();
            string bot_SubMenu5_5 = ini["Bot_SubMenu5"]["BotContent5"].ToString();

            string bot_SubMenu6_1 = ini["Bot_SubMenu6"]["BotContent1"].ToString();
            string bot_SubMenu6_2 = ini["Bot_SubMenu6"]["BotContent2"].ToString();
            string bot_SubMenu6_3 = ini["Bot_SubMenu6"]["BotContent3"].ToString();
            string bot_SubMenu6_4 = ini["Bot_SubMenu6"]["BotContent4"].ToString();
            string bot_SubMenu6_5 = ini["Bot_SubMenu6"]["BotContent5"].ToString();

            //�׸� ���� ���� (����X)
            int alphaNum = int.Parse(ini["CategoryQty"]["AlphaNum"].ToString());
            int consoNum = int.Parse(ini["CategoryQty"]["ConsoNum"].ToString());
            int topNum = int.Parse(ini["CategoryQty"]["TopNum"].ToString());
            int botNum = int.Parse(ini["CategoryQty"]["BotNum"].ToString());
            int goldenNum = int.Parse(ini["CategoryQty"]["GoldenNum"].ToString());

            //�׸� ���� ���� (����O)
            int randAlphaNum = int.Parse(ini["CategoryQty"]["RandAlphaNum"].ToString());
            int randConsoNum = int.Parse(ini["CategoryQty"]["RandConsoNum"].ToString());
            int randTopNum = int.Parse(ini["CategoryQty"]["RandTopNum"].ToString());
            int randBotNum = int.Parse(ini["CategoryQty"]["RandBotNum"].ToString());
            int randGoldenNum = int.Parse(ini["CategoryQty"]["RandGoldenNum"].ToString());

            //��������
            bool isRandomize = bool.Parse(ini["Option"]["Randomize"].ToString());
            bool isGoldenFix = bool.Parse(ini["Option"]["GoldenFix"].ToString());

            //�޹��
            string BackCurrentColor = ini["Option"]["backCurrentColor"].ToString();

            #region :: INI ���� �ϴ� �� (Data ����) ::
            //ini["Top"]["topCategory1"] = topCategory01;
            //ini["Top"]["topCategory2"] = topCategory02;
            //ini["Top"]["topCategory3"] = topCategory03;
            //ini["Top"]["topCategory4"] = topCategory04;
            //ini["Top"]["topCategory5"] = topCategory05;
            //ini["Top"]["topCategory6"] = topCategory06;

            //ini["Bot"]["botCategory1"] = botCategory01;
            //ini["Bot"]["botCategory2"] = botCategory02;
            //ini["Bot"]["botCategory3"] = botCategory03;
            //ini["Bot"]["botCategory4"] = botCategory04;
            //ini["Bot"]["botCategory5"] = botCategory05;
            //ini["Bot"]["botCategory6"] = botCategory06;

            //ini["Bot_SubMenu1"]["TopContent1"] = bot_SubMenu1_1;
            //ini["Bot_SubMenu1"]["TopContent2"] = bot_SubMenu1_2;
            //ini["Bot_SubMenu1"]["TopContent3"] = bot_SubMenu1_3;

            //ini["Bot_SubMenu2"]["TopContent1"] = bot_SubMenu2_1;
            //ini["Bot_SubMenu2"]["TopContent2"] = bot_SubMenu2_2;
            //ini["Bot_SubMenu2"]["TopContent3"] = bot_SubMenu2_3;
            //ini["Bot_SubMenu2"]["TopContent4"] = bot_SubMenu2_4;

            //ini["Bot_SubMenu3"]["TopContent1"] = bot_SubMenu3_1;
            //ini["Bot_SubMenu3"]["TopContent2"] = bot_SubMenu3_2;
            //ini["Bot_SubMenu3"]["TopContent3"] = bot_SubMenu3_3;
            //ini["Bot_SubMenu3"]["TopContent4"] = bot_SubMenu3_4;
            //ini["Bot_SubMenu3"]["TopContent4"] = bot_SubMenu3_5;

            //ini["Bot_SubMenu4"]["TopContent1"] = bot_SubMenu4_1;
            //ini["Bot_SubMenu4"]["TopContent2"] = bot_SubMenu4_2;
            //ini["Bot_SubMenu4"]["TopContent3"] = bot_SubMenu4_3;
            //ini["Bot_SubMenu4"]["TopContent4"] = bot_SubMenu4_4;
            //ini["Bot_SubMenu4"]["TopContent4"] = bot_SubMenu4_5;

            //ini["Bot_SubMenu5"]["TopContent1"] = bot_SubMenu5_1;
            //ini["Bot_SubMenu5"]["TopContent2"] = bot_SubMenu5_2;
            //ini["Bot_SubMenu5"]["TopContent3"] = bot_SubMenu5_3;
            //ini["Bot_SubMenu5"]["TopContent4"] = bot_SubMenu5_4;
            //ini["Bot_SubMenu5"]["TopContent4"] = bot_SubMenu5_5;

            //ini["Bot_SubMenu6"]["TopContent1"] = bot_SubMenu6_1;
            //ini["Bot_SubMenu6"]["TopContent2"] = bot_SubMenu6_2;
            //ini["Bot_SubMenu6"]["TopContent3"] = bot_SubMenu6_3;


            ////�׸� ���� ���� (����X)
            //ini["CategoryQty"]["AlphaNum"]  = AlphaNum;
            //ini["CategoryQty"]["ConsoNum"]  = ConsoNum;
            //ini["CategoryQty"]["TopNum"]    = TopNum;
            //ini["CategoryQty"]["BotNum"]    = BotNum;
            //ini["CategoryQty"]["GoldenNum"]  = GoldenNum;

            ////�׸� ���� ���� (����O)
            //ini["CategoryQty"]["RandAlphaNum"] = AlphaNum2;
            //ini["CategoryQty"]["RandConsoNum"] = ConsoNum2;
            //ini["CategoryQty"]["RandTopNum"] = TopNum2;
            //ini["CategoryQty"]["RandBotNum"] = BotNum2;
            //ini["CategoryQty"]["RandGoldenNum"] = GoldenNum2;

            ////���� ����
            //ini["Option"]["Randomize"] = Randomize;
            //ini["Option"]["GoldenFix"] = GoldenFix;
            //ini["Option"]["backCurrentColor"] = BackCurrentColor;

            //ini.Save(inipath);
            #endregion


            #endregion

            #region :: ���� �ؽ�Ʈ ::
            //���ĺ�
            string alpha1_1 = "���ĺ� ";
            string alpha1_2 = " �� ���۵Ǵ� ��";

            //���� (2) - 8
            string conso1_1 = "������ ";
            string conso1_2 = " �� ���۵Ǵ� ��";

            //�׸�ȸ����
            int stack = 0;
            #endregion

            #region :: ���� ���� ���� ���� ::
            //�ٲ� �ʿ� ���� ��
            //���ĺ�
            string[] alphabet_ = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
            //��ư
            string[] button_ = { "1", "5", "6", "8" };
            //����
            string[] season_ = { "3", "4", "5", "6" };
            //����
            string[] gameclass_ = { "PC", "�����", "�ܼ�" };
            //����
            string[] consonant_ = { "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��"};

            string[] Dummy1_ = { bot_SubMenu1_1, bot_SubMenu1_2, bot_SubMenu1_3, bot_SubMenu1_4, bot_SubMenu1_5 };
            string[] Dummy2_ = { bot_SubMenu2_1, bot_SubMenu2_2, bot_SubMenu2_3, bot_SubMenu2_4, bot_SubMenu2_5 };
            string[] Dummy3_ = { bot_SubMenu3_1, bot_SubMenu3_2, bot_SubMenu3_3, bot_SubMenu3_4, bot_SubMenu3_5 };
            string[] Dummy4_ = { bot_SubMenu4_1, bot_SubMenu4_2, bot_SubMenu4_3, bot_SubMenu4_4, bot_SubMenu4_5 };
            string[] Dummy5_ = { bot_SubMenu5_1, bot_SubMenu5_2, bot_SubMenu5_3, bot_SubMenu5_4, bot_SubMenu5_5 };
            string[] Dummy6_ = { bot_SubMenu6_1, bot_SubMenu6_2, bot_SubMenu6_3, bot_SubMenu6_4, bot_SubMenu6_5 };

            ///�迭 ����
            //���� �Ұ���
            /// �������� ������
            string[] rdalphabet_ = alphabet_.OrderBy(x => rd.Next()).ToArray();
            string[] rdconsonant_ = consonant_.OrderBy(x => rd.Next()).ToArray();
            string[] rdbutton_ = button_.OrderBy(x => rd.Next()).ToArray();
            string[] rdseason_ = season_.OrderBy(x => rd.Next()).ToArray();
            string[] rdgameclass_ = gameclass_.OrderBy(x => rd.Next()).ToArray();
            //���� ������ ����
            string[] rddummy1_ = Dummy1_.OrderBy(x => rd.Next()).ToArray();
            string[] rddummy2_ = Dummy2_.OrderBy(x => rd.Next()).ToArray();
            string[] rddummy3_ = Dummy3_.OrderBy(x => rd.Next()).ToArray();
            string[] rddummy4_ = Dummy4_.OrderBy(x => rd.Next()).ToArray();
            string[] rddummy5_ = Dummy5_.OrderBy(x => rd.Next()).ToArray();
            string[] rddummy6_ = Dummy6_.OrderBy(x => rd.Next()).ToArray();


            //�迭 ���� ���ڿ�
            //���ĺ� �ִ� 8������
            string textAlpha1 = rdalphabet_[0].ToString() + ", " + rdalphabet_[1].ToString() + ", " + rdalphabet_[2].ToString();
            string textAlpha2 = rdalphabet_[3].ToString() + ", " + rdalphabet_[4].ToString() + ", " + rdalphabet_[5].ToString();
            string textAlpha3 = rdalphabet_[6].ToString() + ", " + rdalphabet_[7].ToString() + ", " + rdalphabet_[8].ToString();
            string textAlpha4 = rdalphabet_[9].ToString() + ", " + rdalphabet_[10].ToString() + ", " + rdalphabet_[11].ToString();
            string textAlpha5 = rdalphabet_[12].ToString() + ", " + rdalphabet_[13].ToString() + ", " + rdalphabet_[14].ToString();
            string textAlpha6 = rdalphabet_[15].ToString() + ", " + rdalphabet_[16].ToString() + ", " + rdalphabet_[17].ToString();
            string textAlpha7 = rdalphabet_[18].ToString() + ", " + rdalphabet_[19].ToString() + ", " + rdalphabet_[20].ToString();
            string textAlpha8 = rdalphabet_[21].ToString() + ", " + rdalphabet_[22].ToString() + ", " + rdalphabet_[23].ToString();

            //���� �ִ� 4������
            string textConso1 = rdconsonant_[0].ToString() + ", " + rdconsonant_[1].ToString() + ", " + rdconsonant_[2].ToString();
            string textConso2 = rdconsonant_[3].ToString() + ", " + rdconsonant_[4].ToString() + ", " + rdconsonant_[5].ToString();
            string textConso3 = rdconsonant_[6].ToString() + ", " + rdconsonant_[7].ToString() + ", " + rdconsonant_[8].ToString();
            string textConso4 = rdconsonant_[9].ToString() + ", " + rdconsonant_[10].ToString() + ", " + rdconsonant_[11].ToString();

            //���ĺ� «��
            Dictionary<string, string> alphadict = new Dictionary<string, string>();

            dict_idx  = 0;
            for (int i = 1; i < 9; i++)
            {
                alphadict.Add($"textAlpha{i}", $"{rdalphabet_[dict_idx]}, {rdalphabet_[dict_idx + 1]}, {rdalphabet_[dict_idx + 2]}");
                dict_idx += 3;
            }

            //�ѱ�«��
            Dictionary<string, string> consodict = new Dictionary<string, string>();

            dict_idx = 0;
            for (int j = 1; j < 5; j++)
            {
                consodict.Add($"textConsoo{j}", $"{rdconsonant_[dict_idx]}, {rdconsonant_[dict_idx + 1]}, {rdconsonant_[dict_idx + 2]}");
            }

            //X��ư 1��
            string textButton1 = rdbutton_[0].ToString();
            //���� 1��
            string textSeason1 = rdseason_[0].ToString();
            //���� 1��
            string textGameclass1 = rdgameclass_[0].ToString();

            //���� �׸� 6��
            string textDummy1 = rddummy1_[0].ToString();
            string textDummy2 = rddummy2_[0].ToString();
            string textDummy3 = rddummy3_[0].ToString();
            string textDummy4 = rddummy4_[0].ToString();
            string textDummy5 = rddummy5_[0].ToString();
            string textDummy6 = rddummy6_[0].ToString();
            #endregion

            #region :: ���� ���� ::

            //���ĺ� ����
            string CateAlpha1 = alpha1_1 + textAlpha1 + alpha1_2;
            string CateAlpha2 = alpha1_1 + textAlpha2 + alpha1_2;
            string CateAlpha3 = alpha1_1 + textAlpha3 + alpha1_2;
            string CateAlpha4 = alpha1_1 + textAlpha4 + alpha1_2;
            string CateAlpha5 = alpha1_1 + textAlpha5 + alpha1_2;
            string CateAlpha6 = alpha1_1 + textAlpha6 + alpha1_2;
            string CateAlpha7 = alpha1_1 + textAlpha7 + alpha1_2;
            string CateAlpha8 = alpha1_1 + textAlpha8 + alpha1_2;

            string[] CateAlpha = { CateAlpha1, CateAlpha2, CateAlpha3, CateAlpha4, CateAlpha5, CateAlpha6, CateAlpha7, CateAlpha8 }; 

            //���� ����
            string CateConso1 = conso1_1 + textConso1 + conso1_2;
            string CateConso2 = conso1_1 + textConso2 + conso1_2;
            string CateConso3 = conso1_1 + textConso3 + conso1_2;
            string CateConso4 = conso1_1 + textConso4 + conso1_2;

            string[] CateConso = { CateConso1, CateConso2, CateConso3, CateConso4 };

            //������
            string CateTop1 = topCategorydict["topCategory01"];
            string CateTop2 = topCategorydict["topCategory02"];
            string CateTop3 = topCategorydict["topCategory03"];
            string CateTop4 = topCategorydict["topCategory04"];
            string CateTop5 = topCategorydict["topCategory05"];
            string CateTop6 = topCategorydict["topCategory06"];

            string[] CateTop = { CateTop1, CateTop2, CateTop3, CateTop4, CateTop5, CateTop6 };

            //������
            string CateBot1 = textDummy1 + botCategory01;
            string CateBot2 = textDummy2 + botCategory02;
            string CateBot3 = textDummy3 + botCategory03;
            string CateBot4 = textDummy4 + botCategory04;
            string CateBot5 = textDummy5 + botCategory05;
            string CateBot6 = textDummy6 + botCategory06;

            string[] CateBot = { CateBot1, CateBot2, CateBot3, CateBot4, CateBot5, CateBot6 };

            //Ȳ�� ����
            string CateGolden1 = "Ȳ�� ����";
            string CateGolden2 = "Ȳ�� ����";
            string CateGolden3 = "Ȳ�� ����";
            string CateGolden4 = "Ȳ�� ����";
            string CateGolden5 = "Ȳ�� ����";
            string CateGolden6 = "Ȳ�� ����";
            string CateGolden7 = "Ȳ�� ����";
            string CateGolden8 = "Ȳ�� ����";
            string CateGolden9 = "Ȳ�� ����";
            string CateGolden10 = "Ȳ�� ����";
            string CateGolden11 = "Ȳ�� ����";
            string CateGolden12 = "Ȳ�� ����";
            string CateGolden13 = "Ȳ�� ����";
            string CateGolden14 = "Ȳ�� ����";
            string CateGolden15 = "Ȳ�� ����";
            string CateGolden16 = "Ȳ�� ����";
            string CateGolden17 = "Ȳ�� ����";
            string CateGolden18 = "Ȳ�� ����";
            string CateGolden19 = "Ȳ�� ����";
            string CateGolden20 = "Ȳ�� ����";
            string CateGolden21 = "Ȳ�� ����";

            string[] CateGolden = { CateGolden1, CateGolden2, CateGolden3, CateGolden4, CateGolden5, CateGolden6, CateGolden7, CateGolden8, CateGolden9, CateGolden10, CateGolden11, CateGolden12, CateGolden13, CateGolden14, CateGolden15, CateGolden16, CateGolden17, CateGolden18, CateGolden19, CateGolden20, CateGolden21};

            //���� �׸�
            string CateButton = textButton1 + " ���� �������";
            string CateGameClass = textGameclass1 + " �÷��� �������";
            string CateSeason = textSeason1 + "���� ��";
            #endregion

            #region :: ���� �迭 ���� ::

            //�׸���� ���� Dictionary ����
            Dictionary<string, string> CateDictionary = new Dictionary<string, string>();

            //���� �׸���� Dictionary�� �߰�
            CateDictionary.Add("CateButton", CateButton);
            CateDictionary.Add("CateGameClass", CateGameClass);
            CateDictionary.Add("CateSeason", CateSeason);

            //�����ƴ� �迭 ����
            if (!isRandomize)
            {
                //���ĺ� �׸���� Dictionary�� �߰�
                for (int i = 1; i < alphaNum + 1; i++)
                {
                    CateDictionary.Add(String.Format("CateAlpha{0}", i.ToString()), CateAlpha[i - 1]);
                }

                //���� �׸���� Dictionary�� �߰�
                for (int i = 1; i < consoNum + 1; i++)
                {
                    CateDictionary.Add(String.Format("CateConso{0}", i.ToString()), CateConso[i - 1]);
                }

                //���� �׸���� Dictionary�� �߰�
                for (int i = 1; i < topNum + 1; i++)
                {
                    CateDictionary.Add(String.Format("CateTop{0}", i.ToString()), CateTop[i - 1]);
                }

                //���� + ���� �׸���� Dictionary�� �߰�
                for (int i = 1; i < botNum + 1; i++)
                {
                    CateDictionary.Add(String.Format("CateBot{0}", i.ToString()), CateBot[i - 1]);
                }
            }
            //���� �迭 ����
            else
            {
                //���ĺ� �׸���� Dictionary�� �߰�
                for (int i = 1; i < randAlphaNum + 1; i++)
                {
                    CateDictionary.Add(String.Format("CateAlpha{0}", i.ToString()), CateAlpha[i - 1]);
                }

                //���� �׸���� Dictionary�� �߰�
                for (int i = 1; i < randConsoNum + 1; i++)
                {
                    CateDictionary.Add(String.Format("CateConso{0}", i.ToString()), CateConso[i - 1]);
                }

                //���� �׸���� Dictionary�� �߰�
                for (int i = 1; i < randTopNum + 1; i++)
                {
                    CateDictionary.Add(String.Format("CateTop{0}", i.ToString()), CateTop[i - 1]);
                }

                //���� + ���� �׸���� Dictionary�� �߰�
                for (int i = 1; i < randBotNum + 1; i++)
                {
                    CateDictionary.Add(String.Format("CateBot{0}", i.ToString()), CateBot[i - 1]);
                }

                //Ȳ�ݿ��� �׸���� Dictionary�� �߰�
                for (int i = 1; i < randGoldenNum + 1; i++)
                {
                    CateDictionary.Add(String.Format("CateGolden{0}", i.ToString()), CateGolden[i - 1]);
                }
            }

            //Dictionary���� Value �� ���� �� �� ����Ʈ ���� 
            List<string> CateList = new List<string>(CateDictionary.Values);
            #endregion

            #region :: �׸� ���� ::

            //���� ����Ʈ���� ������ �迭�� ���� Array ����
            string[] rdcate_ = { };
            //Ȳ�ݿ��� ��ġ ������ ��
            if (!isRandomize)
            {
                rdcate_ = CateList.OrderBy(x => rd.Next()).ToArray();
            }


            /* Ȳ�� ���谡 ������ ��ġ + �ٸ� �׸���� �������� ��ġ */
            if (!isRandomize)
            {
                //��� ��Ʈ���� �˻�
                foreach (System.Windows.Forms.Control control in this.Controls)
                {
                    //�� �˻� + Ȳ�� ���谡 �ƴ� ���
                    if (control is Label && ((Label)control).Text != "Golden")
                    {
                        //��Ʈ ���� (�Ÿ����� ���丮)
                        ((Label)control).Font = font1;
                        //�� �̸� �˻�
                        string lblname = ((Label)control).Name;
                        if (lblname.Contains("BackScreen"))
                        {
                            ((Label)control).BackColor = System.Drawing.ColorTranslator.FromHtml(BackCurrentColor);
                            continue;
                        }
                        //���Ծ��� ������ ���� ���ϵ��� (BackColor = Black)
                        else if (((Label)control).BackColor == Color.Black)
                        {

                            //���¼�
                            if (lblname.Contains("EZ2ON"))
                            {
                                ((Label)control).Image = Properties.Resources.���ε�_EZ2v2;
                                ((Label)control).BackColor = Color.White;
                                ((Label)control).Text = null;
                            }
                            //��Ƽ�
                            else if (lblname.Contains("DJMAX"))
                            {
                                ((Label)control).Image = Properties.Resources.���ε�_DJMAXv2;
                                ((Label)control).BackColor = Color.White;
                                ((Label)control).Text = null;
                            }
                            //�������
                            else if (lblname.Contains("Start"))
                            {
                                ((Label)control).Image = Properties.Resources.STARTv2;
                                ((Label)control).BackColor = Color.White;
                                ((Label)control).Text = null;
                            }
                            //����
                            else if (lblname.Contains("Free"))
                            {
                                ((Label)control).Image = Properties.Resources.FREEv2;
                                ((Label)control).BackColor = Color.Black;
                                ((Label)control).Text = null;
                            }
                            continue;
                        }
                        //�׸� �κ�
                        else if (((Label)control).Text != "")
                        {
                            //�� ����
                            Color randomColor = Color.FromArgb(rd.Next(64, 256), rd.Next(64, 256), rd.Next(64, 256));

                            //ũ�θ� Ű �� ȭ���̶� ���� ���� ��� �ٽ� ���� ������ (16���� - 10���� //���߿� �����ؾߵ�)
                            if (randomColor.ToString().Equals(BackCurrentColor))
                            {
                                randomColor = Color.FromArgb(rd.Next(64, 256), rd.Next(64, 256), rd.Next(64, 256));
                            }

                            ((Label)control).BackColor = randomColor;
                            ((Label)control).BorderStyle = BorderStyle.FixedSingle;
                            ((Label)control).ForeColor = Color.Black;

                            //�������� �׸� �߰�
                            for (int i = stack; i < rdcate_.Length;)
                            {
                                ((Label)control).Text = rdcate_[i].ToString();
                                stack++;
                                break;
                            }
                        }

                    }
                    //Ȳ�ݿ��� �� ���
                    else if (control is Label && ((Label)control).Text.Contains("Golden"))
                    {
                        ((Label)control).BackColor = Color.Yellow;
                        ((Label)control).Image = Properties.Resources.golden_keys;
                        ((Label)control).BorderStyle = BorderStyle.FixedSingle;
                        ((Label)control).Text = null;
                        continue;
                    }
                }

            }
            //��ü ���� üũ ��
            else if (isRandomize)
            {
                // ���Ӱ� ������
                rdcate_ = CateList.OrderBy(x => rd.Next()).ToArray();

                //��� ��Ʈ���� �˻�
                foreach (Control control in this.Controls)
                {
                    //�� �˻� + Ȳ�� ���谡 �ƴ� ���
                    if (control is Label)
                    {
                        //��Ʈ ����
                        ((Label)control).Font = font1;
                        //�� �̸� �˻�
                        string lblname = ((Label)control).Name;
                        if (lblname.Contains("BackScreen"))
                        {
                            ((Label)control).BackColor = System.Drawing.ColorTranslator.FromHtml(BackCurrentColor);
                            continue;
                        }
                        //���Ծ��� ������ ���� ���ϵ��� (BackColor = Black)
                        else if (((Label)control).BackColor == Color.Black)
                        {
                            //���¼�
                            if (lblname.Contains("EZ2ON"))
                            {
                                ((Label)control).Image = Properties.Resources.���ε�_EZ2v2;
                                ((Label)control).BackColor = Color.White;
                                ((Label)control).Text = null;
                            }
                            //��Ƽ�
                            else if (lblname.Contains("DJMAX"))
                            {
                                ((Label)control).Image = Properties.Resources.���ε�_DJMAXv2;
                                ((Label)control).BackColor = Color.White;
                                ((Label)control).Text = null;
                            }
                            //�������
                            else if (lblname.Contains("Start"))
                            {
                                ((Label)control).Image = Properties.Resources.STARTv2;
                                ((Label)control).BackColor = Color.White;
                                ((Label)control).Text = null;
                            }
                            //����
                            else if (lblname.Contains("Free"))
                            {
                                ((Label)control).Image = Properties.Resources.FREEv2;
                                ((Label)control).BackColor = Color.Black;
                                ((Label)control).Text = null;
                            }

                            continue;
                        }
                        //�׸� �κ�
                        else if (((Label)control).Text != "")
                        {
                            //�� ����
                            Color randomColor = Color.FromArgb(rd.Next(64, 256), rd.Next(64, 256), rd.Next(64, 256));

                            //ũ�θ� Ű �� ȭ���̶� ���� ���� ��� �ٽ� ���� ������ (16���� - 10���� //���߿� �����ؾߵ�)
                            if (randomColor.ToString().Equals(BackCurrentColor))
                            {
                                randomColor = Color.FromArgb(rd.Next(64, 256), rd.Next(64, 256), rd.Next(64, 256));
                            }

                            ((Label)control).BackColor = randomColor;
                            ((Label)control).BorderStyle = BorderStyle.FixedSingle;
                            ((Label)control).ForeColor = Color.Black;

                            //�� �׸񸶴� �ؽ�Ʈ ����
                            for (int i = stack; i < rdcate_.Length;)
                            {
                                ((Label)control).Text = rdcate_[i].ToString();
                                stack++;
                                break;
                            }
                        }
                        //Ȳ�� ���� �� ���
                        if (((Label)control).Text.Equals("Ȳ�� ����"))
                        {
                            ((Label)control).BackColor = Color.Yellow;
                            ((Label)control).Image = Properties.Resources.golden_keys;
                            ((Label)control).Text = null;
                        }
                    }
                }
            }
            #endregion

            #region :: ���� ���� ::
            //ī�װ��� ���� 22���� �Ǿ� ��.
            //���ĺ�(3) / 10 / 12 Ȳ�ݿ��� ���� �������� ���� �ӽ� �����Դϴ�.
            //string Category1 = Alpha1_1 + textAlpha1 + Alpha1_2;
            //string Category2 = Alpha1_1 + textAlpha2 + Alpha1_2;
            //string Category3 = Alpha1_1 + textAlpha3 + Alpha1_2;
            //����(2) / 10 / 12 Ȳ�ݿ��� ���� �������� ���� �ӽ� �����Դϴ�.
            //string Category4 = Conso1_1 + textConso1 + Conso1_2;
            //string Category5 = Conso1_1 + textConso2 + Conso1_2;
            //string Category6 = Conso1_1 + textcons3 + Conso1_2;
            //Ȳ�� ����(4) -3, 6
            //string Category3 = text8;
            //string Category6 = text8;
            //string Category7 = text8;
            //string Category8 = text8;
            //string Category15 = text8;
            //string Category16 = text8;
            //string Category17 = text8;
            //string Category18 = text8;
            //X���� �������(1)
            //string Category9 = textButton1 + text6;
            //�÷���(1)
            //string Category11 = textGameclass1 + text7;
            //���� ��(1)
            //string Category12 = textSeason1 + text9;
            //BGA or ����(1)
            //����, ���� ������ �͵�B
            //���� �׸�(6) - / 10 / 12 Ȳ�ݿ��� ���� �������� ���� �ӽ� �����Դϴ�. -5
            //string Category14 = text10;
            //string Category15 = text11;
            //string Category16 = text12;
            //string Category17 = text13;
            //string Category18 = text14;
            //���� + ���� �׸�(3)
            //string Category20 = textDummy1 + text16;
            //string Category21 = textDummy2 + text17;
            //string Category22 = textDummy3 + text18;
            //string Category23 = textDummy4 + text19;
            //string Category24 = textDummy5 + text20;
            //string Category25 = textDummy6 + text21;
            #endregion

            #region :: ���� ::

            //string[] rdcate_ = { };

            //Ȳ�ݿ��� ��ġ ������ ��
            //if (GoldenFix)
            //{
            //    string[] CategoryArray = { Category1, Category2, Category4, Category5, Category9, Category11, Category12, Category14, Category20, Category21, Category22, Category23, Category24, Category25 };
            //    rdcate_ = CategoryArray.OrderBy(x => rd.Next()).ToArray();
            //}

            ///* Ȳ�� ���谡 ������ ��ġ + �ٸ� �׸���� �������� ��ġ*/
            //if (!Randomize)
            //{
            //    //��� ��Ʈ���� �˻�
            //    foreach (System.Windows.Forms.Control control in this.Controls)
            //    {
            //        //�󺧸��� �ݺ��� + Ȳ�� ����ƴ� ��� ����
            //        if (control is Label && ((Label)control).Text != "Golden")
            //        {

            //            ((Label)control).Font = font1;

            //            //���Ծ��� ������ ���� ���ϵ��� (BackColor = Black)
            //            if (((Label)control).BackColor == Color.Black)
            //            {
            //                string lblname = ((Label)control).Name;

            //                //��
            //                if (lblname.Contains("EZ2ON"))
            //                {
            //                    ((Label)control).Image = Properties.Resources.���ε�_EZ2v2;
            //                    ((Label)control).BackColor = Color.White;
            //                    ((Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("DJMAX"))
            //                {
            //                    ((Label)control).Image = Properties.Resources.���ε�_DJMAXv2;
            //                    ((Label)control).BackColor = Color.White;
            //                    ((Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("Start"))
            //                {
            //                    ((Label)control).Image = Properties.Resources.STARTv2;
            //                    ((Label)control).BackColor = Color.White;
            //                    ((Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("Free"))
            //                {
            //                    ((Label)control).Image = Properties.Resources.FREEv2;
            //                    ((Label)control).BackColor = Color.Black;
            //                    ((Label)control).Text = null;
            //                }

            //                continue;
            //            }

            //            //�ƴ� �׸���� ��ó�� �����ֵ���
            //            else if (((Label)control).Text != "")
            //            {
            //                //�� ����
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((Label)control).BackColor = randomColor;
            //                ((Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((Label)control).ForeColor = Color.Black;

            //                //�� �׸񸶴� �ؽ�Ʈ ����
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }

            //        }
            //        //Ȳ�ݿ��� �� ���
            //        else if (control is Label && ((Label)control).Text.Contains("Golden"))
            //        {
            //            ((Label)control).BackColor = Color.Yellow;
            //            ((Label)control).Image = Properties.Resources.golden_keys;
            //            ((Label)control).BorderStyle = BorderStyle.FixedSingle;
            //            ((Label)control).Text = null;
            //            continue;
            //        }
            //    }

            //}
            ////��ü ����
            //else if(Randomize)
            //{
            //    string[] CategoryArray = { Category1, Category2, Category3, Category4, Category5, Category6, Category7, Category8, Category9,  Category11, Category12, Category14, Category15, Category16, Category17, Category18, Category20, Category21, Category22, Category23, Category24, Category25 };
            //    rdcate_ = CategoryArray.OrderBy(x => rd.Next()).ToArray();

            //    //��� ��Ʈ���� �˻�
            //    foreach (System.Windows.Forms.Control control in this.Controls)
            //    {
            //        //�󺧸��� �ݺ���
            //        if (control is Label)
            //        {
            //            ((Label)control).Font = font1;

            //            //�ؿ� ���
            //            if (((Label)control).Name.Equals("lblBanner"))
            //            {
            //                ((Label)control).BackColor = Color.White; ;
            //                ((Label)control).Text = "* ����� �� ���� ��ɸ� �����ϰ� �ֽ��ϴ�.";
            //                continue;
            //            }
            //            //���Ծ��� ������ ���� ���ϵ��� (BackColor = Black)
            //            else if (((Label)control).BackColor == Color.Black)
            //            {
            //                string lblname = ((Label)control).Name;

            //                //��
            //                if (lblname.Contains("Island"))
            //                {
            //                    ((Label)control).Image = Properties.Resources.���ε�v2;
            //                    ((Label)control).BackColor = Color.White;
            //                    ((Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("Start"))
            //                {
            //                    ((Label)control).Image = Properties.Resources.Start;
            //                    ((Label)control).BackColor = Color.White;
            //                    ((Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("Free"))
            //                {
            //                    ((Label)control).Image = Properties.Resources.���Ͻ�2;
            //                    ((Label)control).BackColor = Color.Black;
            //                    ((Label)control).Text = null;
            //                }

            //                continue;
            //            }

            //            //�ƴ� �׸���� ��ó�� �����ֵ���
            //            else if (((Label)control).Text != "")
            //            {
            //                //�� ����
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((Label)control).BackColor = randomColor;
            //                ((Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((Label)control).ForeColor = Color.Black;

            //                //�� �׸񸶴� �ؽ�Ʈ ����
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }

            //            if (((Label)control).Text.Equals("Ȳ�� ����"))
            //            {
            //                ((Label)control).BackColor = Color.Yellow;
            //                ((Label)control).Image = Properties.Resources.golden_keys;
            //                ((Label)control).Text = null;
            //            }
            //        }
            //    }
            //}
            ////����Ȱ��ȭ
            //if (Randomize)
            //{
            //    //��� ��Ʈ���� �˻�
            //    foreach (System.Windows.Forms.Control control in this.Controls)
            //    {
            //        //�󺧸��� �ݺ���
            //        if (control is Label)
            //        {
            //            ((Label)control).Font = font1;

            //            //////////////////////////////////////////////////// ��������ϼ���
            //            rdcate_ = CategoryArray.OrderBy(x => rd.Next()).ToArray();

            //            //�ؿ� ���
            //            if (((Label)control).Name.Equals("lblBanner"))
            //            {
            //                ((Label)control).BackColor = Color.White; ;
            //                ((Label)control).Text = "* ����� �� ���� ��ɸ� �����ϰ� �ֽ��ϴ�.";
            //                continue;
            //            }
            //            //���Ծ��� ������ ���� ���ϵ��� (BackColor = Black)
            //            else if (((Label)control).BackColor == Color.Black)
            //            {
            //                string lblname = ((Label)control).Name;

            //                //��
            //                if (lblname.Contains("Island"))
            //                {
            //                    ((Label)control).Image = Properties.Resources.���ε�v2;
            //                    ((Label)control).BackColor = Color.White;
            //                    ((Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("Start"))
            //                {
            //                    ((Label)control).Image = Properties.Resources.Start;
            //                    ((Label)control).BackColor = Color.White;
            //                    ((Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("Free"))
            //                {
            //                    ((Label)control).Image = Properties.Resources.���Ͻ�2;
            //                    ((Label)control).BackColor = Color.Black;
            //                    ((Label)control).Text = null;
            //                }

            //                continue;
            //            }

            //            //�ƴ� �׸���� ��ó�� �����ֵ���
            //            //    else if (((Label)control).Text != "")
            //            //    {
            //            //        //�� ����
            //            //        Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //            //        ((Label)control).BackColor = randomColor;
            //            //        ((Label)control).BorderStyle = BorderStyle.FixedSingle;
            //            //        ((Label)control).ForeColor = Color.Black;

            //            //        //�� �׸񸶴� �ؽ�Ʈ ����
            //            //        for (int i = stack; i < rdcate_.Length;)
            //            //        {
            //            //            ((Label)control).Text = rdcate_[i].ToString();
            //            //            stack++;
            //            //            break;
            //            //        }
            //            //    }

            //            //    if (((Label)control).Text.Equals("Ȳ�� ����"))
            //            //    {
            //            //        ((Label)control).BackColor = Color.Yellow;
            //            //        ((Label)control).Image = Properties.Resources.golden_keys;
            //            //        ((Label)control).Text = null;
            //            //    }

            //        }
            //    }
            //}
            ////������ �ƴ� �� ������ �������!
            //else
            //{
            //    //��� ��Ʈ���� �˻�
            //    foreach (System.Windows.Forms.Control control in this.Controls)
            //    {
            //        //�󺧸��� �ݺ���
            //        if (control is Label)
            //        {
            //            ((Label)control).Font = font1;

            //            //�ؿ� ���
            //            if (((Label)control).Name.Equals("lblBanner"))
            //            {
            //                ((Label)control).BackColor = Color.White; ;
            //                ((Label)control).Text = "* ����� �� ���� ��ɸ� �����ϰ� �ֽ��ϴ�.";
            //                continue;
            //            }
            //            //���Ծ��� ������ ���� ���ϵ��� (BackColor = Black)
            //            else if (((Label)control).BackColor == Color.Black)
            //            {
            //                string lblname = ((Label)control).Name;

            //                //��
            //                if (lblname.Contains("Island"))
            //                {
            //                    ((Label)control).Image = Properties.Resources.���ε�v2;
            //                    ((Label)control).BackColor = Color.White;
            //                    ((Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("Start"))
            //                {
            //                    ((Label)control).Image = Properties.Resources.Start;
            //                    ((Label)control).BackColor = Color.White;
            //                    ((Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("Free"))
            //                {
            //                    ((Label)control).Image = Properties.Resources.���Ͻ�2;
            //                    ((Label)control).BackColor = Color.Black;
            //                    ((Label)control).Text = null;
            //                }

            //                continue;
            //            }

            //            //4�׷����� ������
            //            //�׷� A
            //            else if (((Label)control).Text.Contains("A"))
            //            {
            //                //�� ����
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((Label)control).BackColor = randomColor;
            //                ((Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((Label)control).ForeColor = Color.Black;

            //                //�� �׸񸶴� �ؽ�Ʈ ����
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }
            //            if (((Label)control).Text.Equals("Ȳ�� ����"))
            //            {
            //                ((Label)control).BackColor = Color.Yellow;
            //                ((Label)control).Image = Properties.Resources.golden_keys;
            //                ((Label)control).Text = null;
            //            }

            //            //�׷� B
            //            else if (((Label)control).Text.Contains("B"))
            //            {
            //                //�� ����
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((Label)control).BackColor = randomColor;
            //                ((Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((Label)control).ForeColor = Color.Black;

            //                //�� �׸񸶴� �ؽ�Ʈ ����
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }
            //            if (((Label)control).Text.Equals("Ȳ�� ����"))
            //            {
            //                ((Label)control).BackColor = Color.Yellow;
            //                ((Label)control).Image = Properties.Resources.golden_keys;
            //                ((Label)control).Text = null;
            //            }

            //            //�׷� C
            //            else if (((Label)control).Text.Contains("C"))
            //            {
            //                //�� ����
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((Label)control).BackColor = randomColor;
            //                ((Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((Label)control).ForeColor = Color.Black;

            //                //�� �׸񸶴� �ؽ�Ʈ ����
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }
            //            if (((Label)control).Text.Equals("Ȳ�� ����"))
            //            {
            //                ((Label)control).BackColor = Color.Yellow;
            //                ((Label)control).Image = Properties.Resources.golden_keys;
            //                ((Label)control).Text = null;
            //            }

            //            //�׷� D
            //            else if (((Label)control).Text.Contains("D"))
            //            {
            //                //�� ����
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((Label)control).BackColor = randomColor;
            //                ((Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((Label)control).ForeColor = Color.Black;

            //                //�� �׸񸶴� �ؽ�Ʈ ����
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }

            //            if (((Label)control).Text.Equals("Ȳ�� ����"))
            //            {
            //                ((Label)control).BackColor = Color.Yellow;
            //                ((Label)control).Image = Properties.Resources.golden_keys;
            //                ((Label)control).Text = null;
            //            }
            //        }

            //        //�ƴ� �׸���� ��ó�� �����ֵ���
            //        //    else if (((Label)control).Text != "")
            //        //    {
            //        //        //�� ����
            //        //        Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //        //        ((Label)control).BackColor = randomColor;
            //        //        ((Label)control).BorderStyle = BorderStyle.FixedSingle;
            //        //        ((Label)control).ForeColor = Color.Black;

            //        //        //�� �׸񸶴� �ؽ�Ʈ ����
            //        //        for (int i = stack; i < rdcate_.Length;)
            //        //        {
            //        //            ((Label)control).Text = rdcate_[i].ToString();
            //        //            stack++;
            //        //            break;
            //        //        }
            //        //    }

            //        //    if (((Label)control).Text.Equals("Ȳ�� ����"))
            //        //    {
            //        //        ((Label)control).BackColor = Color.Yellow;
            //        //        ((Label)control).Image = Properties.Resources.golden_keys;
            //        //        ((Label)control).Text = null;
            //        //    }
            //    }
            //}
            #endregion

        }

        private void InitializeINI(string path)
        {
            try
            {
                if (!System.IO.File.Exists(path))
                {
                    MessageBox.Show("���� ������ �����, �� �����ڸ� �ҷ��ּ���");
                    Application.Exit();
                }

                ini.Load(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MethodBase.GetCurrentMethod().Name);
            }
        }

        #region :: ButtonEvent ::

        //���� ��ư Ŭ�� �̺�Ʈ
        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("������ �����Ͻðڽ��ϱ�?", "Ȯ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (Result == DialogResult.OK)
            {
                Environment.Exit(0);
            }
        }

        //�� ���� ��ư �̺�Ʈ
        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("������ ���� �����ðڽ��ϱ�?", "Ȯ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (Result == DialogResult.OK)
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }

        //�׸� ���� ��ư Ŭ�� �̺�Ʈ
        private void buttonSetup_Click(object sender, EventArgs e)
        {
            Popup popup = new Popup();
            popup.ShowDialog();
        }

        //��Ʈ ���� ��ư Ŭ�� �̺�Ʈ
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("�� ���α׷����� �����ý��丮�� ������\r�����ý��丮 ��ü�� ����Ǿ� �ֽ��ϴ�.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //��ũ���� ��ư Ŭ�� �̺�Ʈ
        private void btnScreenshot_Click(object sender, EventArgs e)
        {

            DialogResult Result = MessageBox.Show("���� ���� ���� �Ͻðڽ��ϱ�? \r�������� ������ ����˴ϴ�.", "���� Ȯ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (Result == DialogResult.OK)
            {
                MessageBox.Show("Ȯ���� �����ø� 3�� �� ��ũ�� ĸ�İ� �˴ϴ�.", "���� Ȯ��", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //���� ��ġ ���� (���α׷� ����)
                string localpath = System.Environment.CurrentDirectory;
                string filename = "\\�Ƕ���.png";
                string _path = localpath + filename;

                //FHD ũ�� ����
                Capture ImgCapture = new Capture(0, 0, 1920, 1080);
                ImgCapture.SetPath(_path);

                ImgCapture.CaptureImage();

                //�� �� ���� Ȯ��
                string ChangedColor = Properties.Settings.Default.BackCurrentColor;
                BackScreen.BackColor = System.Drawing.ColorTranslator.FromHtml(ChangedColor);

                if (!Labellocation)  BackScreen.BringToFront();

                CaptureImage(_path);

                MessageBox.Show("������ ����Ǿ����ϴ�.", "Ȯ��", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (!Labellocation) BackScreen.SendToBack();
                return;
            }
        }
        //�� Ŭ�� �� ȭ�� ��ȯ �̺�Ʈ
        private void labelStart_Click(object sender, EventArgs e)
        {
            if (!Labellocation)
            {
                string ChangedColor = Properties.Settings.Default.BackCurrentColor;
                //BackScreen.BackColor = System.Drawing.ColorTranslator.FromHtml(ChangedColor);
                BackScreen.BackColor = Color.Gray;

                BackScreen.BringToFront();
                Labellocation = true;
            }
            else
            {
                BackScreen.SendToBack();
                Labellocation = false;
            }
            
        }
        //�� ���� ��ư
        private void btn_Color_Click(object sender, EventArgs e)
        {
            ColorControl color = new ColorControl();
            color.ShowDialog();
        }
        #endregion

        #region :: ETC Event ::
        //ũ�� ���� �̺�Ʈ
        private void MainBoard_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(1920, 1080);
        }

        //�̹��� ĸ�� �̺�Ʈ
        private void CaptureImage(string _path)
        {
            int _refX = 0;
            int _refY = 0;
            int _imgW = 1920;
            int _imgH = 1080;

            string Filepath = _path;


            if (Filepath != string.Empty)
            {
                using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap((int)_imgW, (int)_imgH))
                {
                    using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))
                    {
                        Delay(2555);
                        g.CopyFromScreen(_refX, _refY, 0, 0, bitmap.Size);
                    }
                    bitmap.Save(Filepath, ImageFormat.Png);
                }
            }
        }
        //������ �̺�Ʈ
        public void Delay(int ms)
        {
            DateTime dateTimeNow = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, ms);
            DateTime dateTimeAdd = dateTimeNow.Add(duration);
            while (dateTimeAdd >= dateTimeNow)
            {
                System.Windows.Forms.Application.DoEvents();
                dateTimeNow = DateTime.Now;
            }
            return;
        }
        #endregion

    }
}