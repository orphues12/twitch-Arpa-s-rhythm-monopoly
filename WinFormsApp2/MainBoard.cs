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
        #region :: 전역 변수 ;:
        IniFile ini = new IniFile();
        string inipath = Application.StartupPath + @"/Settings.ini";
        //라벨 위치 변수
        bool Labellocation = false;

        #endregion 

        public MainBoard()
        {
            InitializeComponent();

            InitializeINI(inipath);

            #region :: 어플 설정 ::
            //랜덤함수
            Random rd = new Random();
            //폰트설정
            Font font1 = new Font(FontManager.fontFamilys[0], 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

            //컨트롤박스 제거
            this.ControlBox = false;

            //크기 관련
            this.MinimumSize = new Size(1920, 1080);
            this.MaximumSize = new Size(1920, 1080);

            //로고 좌표bot_SubMenu1_1
            labelLogo.Left = (this.ClientSize.Width - labelLogo.Width) / 2;
            labelLogo.Top = (this.ClientSize.Height - labelLogo.Height) / 2;


            int dict_idx = 0;
            #endregion

            #region :: 변수 불러오기 ::
            //판때기 항목들
            ini.Load(inipath);

            Dictionary<string, string> topCategorydict = new Dictionary<string, string>();
            Dictionary<string, string> botCategorydict = new Dictionary<string, string>();

            for (int i = 1; i < int.Parse(ini["Option"]["TopBotQty"].ToString()) + 1; i++)
            {
                topCategorydict.Add($"topCategory0{i}", ini["Top"][$"TopCategory{i}"].ToString());
                botCategorydict.Add($"botCategory0{i}", ini["Bot"][$"BotCategory{i}"].ToString());
            }

            string topCategory01 = ini["Top"]["TopCategory1"].ToString(); //상위  
            string topCategory02 = ini["Top"]["TopCategory2"].ToString(); //상위
            string topCategory03 = ini["Top"]["TopCategory3"].ToString(); //상위
            string topCategory04 = ini["Top"]["TopCategory4"].ToString(); //상위
            string topCategory05 = ini["Top"]["TopCategory5"].ToString(); //상위
            string topCategory06 = ini["Top"]["TopCategory6"].ToString(); //상위

            string botCategory01 = ini["Bot"]["BotCategory1"].ToString(); //상위 + 하위
            string botCategory02 = ini["Bot"]["BotCategory2"].ToString(); //상위 + 하위
            string botCategory03 = ini["Bot"]["BotCategory3"].ToString(); //상위 + 하위
            string botCategory04 = ini["Bot"]["BotCategory4"].ToString(); //상위 + 하위
            string botCategory05 = ini["Bot"]["BotCategory5"].ToString(); //상위 + 하위
            string botCategory06 = ini["Bot"]["BotCategory6"].ToString(); //상위 + 하위


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

            //하위 더미데이터
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

            //항목 숫자 변수 (랜덤X)
            int alphaNum = int.Parse(ini["CategoryQty"]["AlphaNum"].ToString());
            int consoNum = int.Parse(ini["CategoryQty"]["ConsoNum"].ToString());
            int topNum = int.Parse(ini["CategoryQty"]["TopNum"].ToString());
            int botNum = int.Parse(ini["CategoryQty"]["BotNum"].ToString());
            int goldenNum = int.Parse(ini["CategoryQty"]["GoldenNum"].ToString());

            //항목 숫자 변수 (랜덤O)
            int randAlphaNum = int.Parse(ini["CategoryQty"]["RandAlphaNum"].ToString());
            int randConsoNum = int.Parse(ini["CategoryQty"]["RandConsoNum"].ToString());
            int randTopNum = int.Parse(ini["CategoryQty"]["RandTopNum"].ToString());
            int randBotNum = int.Parse(ini["CategoryQty"]["RandBotNum"].ToString());
            int randGoldenNum = int.Parse(ini["CategoryQty"]["RandGoldenNum"].ToString());

            //랜덤변수
            bool isRandomize = bool.Parse(ini["Option"]["Randomize"].ToString());
            bool isGoldenFix = bool.Parse(ini["Option"]["GoldenFix"].ToString());

            //뒷배경
            string BackCurrentColor = ini["Option"]["backCurrentColor"].ToString();

            #region :: INI 저장 하는 곳 (Data 연동) ::
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


            ////항목 숫자 변수 (랜덤X)
            //ini["CategoryQty"]["AlphaNum"]  = AlphaNum;
            //ini["CategoryQty"]["ConsoNum"]  = ConsoNum;
            //ini["CategoryQty"]["TopNum"]    = TopNum;
            //ini["CategoryQty"]["BotNum"]    = BotNum;
            //ini["CategoryQty"]["GoldenNum"]  = GoldenNum;

            ////항목 숫자 변수 (랜덤O)
            //ini["CategoryQty"]["RandAlphaNum"] = AlphaNum2;
            //ini["CategoryQty"]["RandConsoNum"] = ConsoNum2;
            //ini["CategoryQty"]["RandTopNum"] = TopNum2;
            //ini["CategoryQty"]["RandBotNum"] = BotNum2;
            //ini["CategoryQty"]["RandGoldenNum"] = GoldenNum2;

            ////랜덤 관련
            //ini["Option"]["Randomize"] = Randomize;
            //ini["Option"]["GoldenFix"] = GoldenFix;
            //ini["Option"]["backCurrentColor"] = BackCurrentColor;

            //ini.Save(inipath);
            #endregion


            #endregion

            #region :: 변수 텍스트 ::
            //알파벳
            string alpha1_1 = "알파벳 ";
            string alpha1_2 = " 로 시작되는 곡";

            //자음 (2) - 8
            string conso1_1 = "발음이 ";
            string conso1_2 = " 로 시작되는 곡";

            //항목회전용
            int stack = 0;
            #endregion

            #region :: 변수 랜덤 내용 설정 ::
            //바꿀 필요 없는 것
            //알파벳
            string[] alphabet_ = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
            //버튼
            string[] button_ = { "1", "5", "6", "8" };
            //계절
            string[] season_ = { "3", "4", "5", "6" };
            //기종
            string[] gameclass_ = { "PC", "모바일", "콘솔" };
            //자음
            string[] consonant_ = { "ㄱ", "ㄴ", "ㄷ", "ㄹ", "ㅁ", "ㅂ", "ㅅ", "ㅇ", "ㅈ", "ㅊ", "ㅋ", "ㅌ", "ㅍ", "ㅎ"};

            string[] Dummy1_ = { bot_SubMenu1_1, bot_SubMenu1_2, bot_SubMenu1_3, bot_SubMenu1_4, bot_SubMenu1_5 };
            string[] Dummy2_ = { bot_SubMenu2_1, bot_SubMenu2_2, bot_SubMenu2_3, bot_SubMenu2_4, bot_SubMenu2_5 };
            string[] Dummy3_ = { bot_SubMenu3_1, bot_SubMenu3_2, bot_SubMenu3_3, bot_SubMenu3_4, bot_SubMenu3_5 };
            string[] Dummy4_ = { bot_SubMenu4_1, bot_SubMenu4_2, bot_SubMenu4_3, bot_SubMenu4_4, bot_SubMenu4_5 };
            string[] Dummy5_ = { bot_SubMenu5_1, bot_SubMenu5_2, bot_SubMenu5_3, bot_SubMenu5_4, bot_SubMenu5_5 };
            string[] Dummy6_ = { bot_SubMenu6_1, bot_SubMenu6_2, bot_SubMenu6_3, bot_SubMenu6_4, bot_SubMenu6_5 };

            ///배열 섞기
            //변경 불가능
            /// 랜덤으로 돌리기
            string[] rdalphabet_ = alphabet_.OrderBy(x => rd.Next()).ToArray();
            string[] rdconsonant_ = consonant_.OrderBy(x => rd.Next()).ToArray();
            string[] rdbutton_ = button_.OrderBy(x => rd.Next()).ToArray();
            string[] rdseason_ = season_.OrderBy(x => rd.Next()).ToArray();
            string[] rdgameclass_ = gameclass_.OrderBy(x => rd.Next()).ToArray();
            //변경 가능한 더미
            string[] rddummy1_ = Dummy1_.OrderBy(x => rd.Next()).ToArray();
            string[] rddummy2_ = Dummy2_.OrderBy(x => rd.Next()).ToArray();
            string[] rddummy3_ = Dummy3_.OrderBy(x => rd.Next()).ToArray();
            string[] rddummy4_ = Dummy4_.OrderBy(x => rd.Next()).ToArray();
            string[] rddummy5_ = Dummy5_.OrderBy(x => rd.Next()).ToArray();
            string[] rddummy6_ = Dummy6_.OrderBy(x => rd.Next()).ToArray();


            //배열 변수 문자열
            //알파벳 최대 8개까지
            string textAlpha1 = rdalphabet_[0].ToString() + ", " + rdalphabet_[1].ToString() + ", " + rdalphabet_[2].ToString();
            string textAlpha2 = rdalphabet_[3].ToString() + ", " + rdalphabet_[4].ToString() + ", " + rdalphabet_[5].ToString();
            string textAlpha3 = rdalphabet_[6].ToString() + ", " + rdalphabet_[7].ToString() + ", " + rdalphabet_[8].ToString();
            string textAlpha4 = rdalphabet_[9].ToString() + ", " + rdalphabet_[10].ToString() + ", " + rdalphabet_[11].ToString();
            string textAlpha5 = rdalphabet_[12].ToString() + ", " + rdalphabet_[13].ToString() + ", " + rdalphabet_[14].ToString();
            string textAlpha6 = rdalphabet_[15].ToString() + ", " + rdalphabet_[16].ToString() + ", " + rdalphabet_[17].ToString();
            string textAlpha7 = rdalphabet_[18].ToString() + ", " + rdalphabet_[19].ToString() + ", " + rdalphabet_[20].ToString();
            string textAlpha8 = rdalphabet_[21].ToString() + ", " + rdalphabet_[22].ToString() + ", " + rdalphabet_[23].ToString();

            //자음 최대 4개까지
            string textConso1 = rdconsonant_[0].ToString() + ", " + rdconsonant_[1].ToString() + ", " + rdconsonant_[2].ToString();
            string textConso2 = rdconsonant_[3].ToString() + ", " + rdconsonant_[4].ToString() + ", " + rdconsonant_[5].ToString();
            string textConso3 = rdconsonant_[6].ToString() + ", " + rdconsonant_[7].ToString() + ", " + rdconsonant_[8].ToString();
            string textConso4 = rdconsonant_[9].ToString() + ", " + rdconsonant_[10].ToString() + ", " + rdconsonant_[11].ToString();

            //알파벳 짬통
            Dictionary<string, string> alphadict = new Dictionary<string, string>();

            dict_idx  = 0;
            for (int i = 1; i < 9; i++)
            {
                alphadict.Add($"textAlpha{i}", $"{rdalphabet_[dict_idx]}, {rdalphabet_[dict_idx + 1]}, {rdalphabet_[dict_idx + 2]}");
                dict_idx += 3;
            }

            //한글짬통
            Dictionary<string, string> consodict = new Dictionary<string, string>();

            dict_idx = 0;
            for (int j = 1; j < 5; j++)
            {
                consodict.Add($"textConsoo{j}", $"{rdconsonant_[dict_idx]}, {rdconsonant_[dict_idx + 1]}, {rdconsonant_[dict_idx + 2]}");
            }

            //X버튼 1개
            string textButton1 = rdbutton_[0].ToString();
            //계절 1개
            string textSeason1 = rdseason_[0].ToString();
            //기종 1개
            string textGameclass1 = rdgameclass_[0].ToString();

            //하위 항목 6개
            string textDummy1 = rddummy1_[0].ToString();
            string textDummy2 = rddummy2_[0].ToString();
            string textDummy3 = rddummy3_[0].ToString();
            string textDummy4 = rddummy4_[0].ToString();
            string textDummy5 = rddummy5_[0].ToString();
            string textDummy6 = rddummy6_[0].ToString();
            #endregion

            #region :: 신형 변수 ::

            //알파벳 변수
            string CateAlpha1 = alpha1_1 + textAlpha1 + alpha1_2;
            string CateAlpha2 = alpha1_1 + textAlpha2 + alpha1_2;
            string CateAlpha3 = alpha1_1 + textAlpha3 + alpha1_2;
            string CateAlpha4 = alpha1_1 + textAlpha4 + alpha1_2;
            string CateAlpha5 = alpha1_1 + textAlpha5 + alpha1_2;
            string CateAlpha6 = alpha1_1 + textAlpha6 + alpha1_2;
            string CateAlpha7 = alpha1_1 + textAlpha7 + alpha1_2;
            string CateAlpha8 = alpha1_1 + textAlpha8 + alpha1_2;

            string[] CateAlpha = { CateAlpha1, CateAlpha2, CateAlpha3, CateAlpha4, CateAlpha5, CateAlpha6, CateAlpha7, CateAlpha8 }; 

            //자음 변수
            string CateConso1 = conso1_1 + textConso1 + conso1_2;
            string CateConso2 = conso1_1 + textConso2 + conso1_2;
            string CateConso3 = conso1_1 + textConso3 + conso1_2;
            string CateConso4 = conso1_1 + textConso4 + conso1_2;

            string[] CateConso = { CateConso1, CateConso2, CateConso3, CateConso4 };

            //상위만
            string CateTop1 = topCategorydict["topCategory01"];
            string CateTop2 = topCategorydict["topCategory02"];
            string CateTop3 = topCategorydict["topCategory03"];
            string CateTop4 = topCategorydict["topCategory04"];
            string CateTop5 = topCategorydict["topCategory05"];
            string CateTop6 = topCategorydict["topCategory06"];

            string[] CateTop = { CateTop1, CateTop2, CateTop3, CateTop4, CateTop5, CateTop6 };

            //하위만
            string CateBot1 = textDummy1 + botCategory01;
            string CateBot2 = textDummy2 + botCategory02;
            string CateBot3 = textDummy3 + botCategory03;
            string CateBot4 = textDummy4 + botCategory04;
            string CateBot5 = textDummy5 + botCategory05;
            string CateBot6 = textDummy6 + botCategory06;

            string[] CateBot = { CateBot1, CateBot2, CateBot3, CateBot4, CateBot5, CateBot6 };

            //황금 열쇠
            string CateGolden1 = "황금 열쇠";
            string CateGolden2 = "황금 열쇠";
            string CateGolden3 = "황금 열쇠";
            string CateGolden4 = "황금 열쇠";
            string CateGolden5 = "황금 열쇠";
            string CateGolden6 = "황금 열쇠";
            string CateGolden7 = "황금 열쇠";
            string CateGolden8 = "황금 열쇠";
            string CateGolden9 = "황금 열쇠";
            string CateGolden10 = "황금 열쇠";
            string CateGolden11 = "황금 열쇠";
            string CateGolden12 = "황금 열쇠";
            string CateGolden13 = "황금 열쇠";
            string CateGolden14 = "황금 열쇠";
            string CateGolden15 = "황금 열쇠";
            string CateGolden16 = "황금 열쇠";
            string CateGolden17 = "황금 열쇠";
            string CateGolden18 = "황금 열쇠";
            string CateGolden19 = "황금 열쇠";
            string CateGolden20 = "황금 열쇠";
            string CateGolden21 = "황금 열쇠";

            string[] CateGolden = { CateGolden1, CateGolden2, CateGolden3, CateGolden4, CateGolden5, CateGolden6, CateGolden7, CateGolden8, CateGolden9, CateGolden10, CateGolden11, CateGolden12, CateGolden13, CateGolden14, CateGolden15, CateGolden16, CateGolden17, CateGolden18, CateGolden19, CateGolden20, CateGolden21};

            //고정 항목
            string CateButton = textButton1 + " 라인 리듬게임";
            string CateGameClass = textGameclass1 + " 플랫폼 리듬게임";
            string CateSeason = textSeason1 + "글자 곡";
            #endregion

            #region :: 신형 배열 제작 ::

            //항목들을 담을 Dictionary 생성
            Dictionary<string, string> CateDictionary = new Dictionary<string, string>();

            //고정 항목들을 Dictionary에 추가
            CateDictionary.Add("CateButton", CateButton);
            CateDictionary.Add("CateGameClass", CateGameClass);
            CateDictionary.Add("CateSeason", CateSeason);

            //랜덤아닌 배열 제작
            if (!isRandomize)
            {
                //알파벳 항목들을 Dictionary에 추가
                for (int i = 1; i < alphaNum + 1; i++)
                {
                    CateDictionary.Add(String.Format("CateAlpha{0}", i.ToString()), CateAlpha[i - 1]);
                }

                //자음 항목들을 Dictionary에 추가
                for (int i = 1; i < consoNum + 1; i++)
                {
                    CateDictionary.Add(String.Format("CateConso{0}", i.ToString()), CateConso[i - 1]);
                }

                //상위 항목들을 Dictionary에 추가
                for (int i = 1; i < topNum + 1; i++)
                {
                    CateDictionary.Add(String.Format("CateTop{0}", i.ToString()), CateTop[i - 1]);
                }

                //상위 + 하위 항목들을 Dictionary에 추가
                for (int i = 1; i < botNum + 1; i++)
                {
                    CateDictionary.Add(String.Format("CateBot{0}", i.ToString()), CateBot[i - 1]);
                }
            }
            //랜덤 배열 제작
            else
            {
                //알파벳 항목들을 Dictionary에 추가
                for (int i = 1; i < randAlphaNum + 1; i++)
                {
                    CateDictionary.Add(String.Format("CateAlpha{0}", i.ToString()), CateAlpha[i - 1]);
                }

                //자음 항목들을 Dictionary에 추가
                for (int i = 1; i < randConsoNum + 1; i++)
                {
                    CateDictionary.Add(String.Format("CateConso{0}", i.ToString()), CateConso[i - 1]);
                }

                //상위 항목들을 Dictionary에 추가
                for (int i = 1; i < randTopNum + 1; i++)
                {
                    CateDictionary.Add(String.Format("CateTop{0}", i.ToString()), CateTop[i - 1]);
                }

                //상위 + 하위 항목들을 Dictionary에 추가
                for (int i = 1; i < randBotNum + 1; i++)
                {
                    CateDictionary.Add(String.Format("CateBot{0}", i.ToString()), CateBot[i - 1]);
                }

                //황금열쇠 항목들을 Dictionary에 추가
                for (int i = 1; i < randGoldenNum + 1; i++)
                {
                    CateDictionary.Add(String.Format("CateGolden{0}", i.ToString()), CateGolden[i - 1]);
                }
            }

            //Dictionary에서 Value 값 추출 후 새 리스트 제작 
            List<string> CateList = new List<string>(CateDictionary.Values);
            #endregion

            #region :: 항목 삽입 ::

            //제작 리스트에서 무작위 배열로 담을 Array 지정
            string[] rdcate_ = { };
            //황금열쇠 위치 고정일 시
            if (!isRandomize)
            {
                rdcate_ = CateList.OrderBy(x => rd.Next()).ToArray();
            }


            /* 황금 열쇠가 정해진 위치 + 다른 항목들은 랜덤으로 배치 */
            if (!isRandomize)
            {
                //모든 컨트롤을 검사
                foreach (System.Windows.Forms.Control control in this.Controls)
                {
                    //라벨 검사 + 황금 열쇠가 아닐 경우
                    if (control is Label && ((Label)control).Text != "Golden")
                    {
                        //폰트 변경 (신메이플 스토리)
                        ((Label)control).Font = font1;
                        //라벨 이름 검사
                        string lblname = ((Label)control).Name;
                        if (lblname.Contains("BackScreen"))
                        {
                            ((Label)control).BackColor = System.Drawing.ColorTranslator.FromHtml(BackCurrentColor);
                            continue;
                        }
                        //변함없는 값들은 변경 안하도록 (BackColor = Black)
                        else if (((Label)control).BackColor == Color.Black)
                        {

                            //투온섬
                            if (lblname.Contains("EZ2ON"))
                            {
                                ((Label)control).Image = Properties.Resources.무인도_EZ2v2;
                                ((Label)control).BackColor = Color.White;
                                ((Label)control).Text = null;
                            }
                            //디맥섬
                            else if (lblname.Contains("DJMAX"))
                            {
                                ((Label)control).Image = Properties.Resources.무인도_DJMAXv2;
                                ((Label)control).BackColor = Color.White;
                                ((Label)control).Text = null;
                            }
                            //출발지점
                            else if (lblname.Contains("Start"))
                            {
                                ((Label)control).Image = Properties.Resources.STARTv2;
                                ((Label)control).BackColor = Color.White;
                                ((Label)control).Text = null;
                            }
                            //자유
                            else if (lblname.Contains("Free"))
                            {
                                ((Label)control).Image = Properties.Resources.FREEv2;
                                ((Label)control).BackColor = Color.Black;
                                ((Label)control).Text = null;
                            }
                            continue;
                        }
                        //항목 부분
                        else if (((Label)control).Text != "")
                        {
                            //색 변경
                            Color randomColor = Color.FromArgb(rd.Next(64, 256), rd.Next(64, 256), rd.Next(64, 256));

                            //크로마 키 용 화면이랑 색이 같을 경우 다시 색을 조정함 (16진수 - 10진수 //나중에 수정해야됨)
                            if (randomColor.ToString().Equals(BackCurrentColor))
                            {
                                randomColor = Color.FromArgb(rd.Next(64, 256), rd.Next(64, 256), rd.Next(64, 256));
                            }

                            ((Label)control).BackColor = randomColor;
                            ((Label)control).BorderStyle = BorderStyle.FixedSingle;
                            ((Label)control).ForeColor = Color.Black;

                            //무작위로 항목 추가
                            for (int i = stack; i < rdcate_.Length;)
                            {
                                ((Label)control).Text = rdcate_[i].ToString();
                                stack++;
                                break;
                            }
                        }

                    }
                    //황금열쇠 일 경우
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
            //전체 랜덤 체크 시
            else if (isRandomize)
            {
                // 새롭게 무작위
                rdcate_ = CateList.OrderBy(x => rd.Next()).ToArray();

                //모든 컨트롤을 검사
                foreach (Control control in this.Controls)
                {
                    //라벨 검사 + 황금 열쇠가 아닐 경우
                    if (control is Label)
                    {
                        //폰트 설정
                        ((Label)control).Font = font1;
                        //라벨 이름 검사
                        string lblname = ((Label)control).Name;
                        if (lblname.Contains("BackScreen"))
                        {
                            ((Label)control).BackColor = System.Drawing.ColorTranslator.FromHtml(BackCurrentColor);
                            continue;
                        }
                        //변함없는 값들은 변경 안하도록 (BackColor = Black)
                        else if (((Label)control).BackColor == Color.Black)
                        {
                            //투온섬
                            if (lblname.Contains("EZ2ON"))
                            {
                                ((Label)control).Image = Properties.Resources.무인도_EZ2v2;
                                ((Label)control).BackColor = Color.White;
                                ((Label)control).Text = null;
                            }
                            //디맥섬
                            else if (lblname.Contains("DJMAX"))
                            {
                                ((Label)control).Image = Properties.Resources.무인도_DJMAXv2;
                                ((Label)control).BackColor = Color.White;
                                ((Label)control).Text = null;
                            }
                            //출발지점
                            else if (lblname.Contains("Start"))
                            {
                                ((Label)control).Image = Properties.Resources.STARTv2;
                                ((Label)control).BackColor = Color.White;
                                ((Label)control).Text = null;
                            }
                            //자유
                            else if (lblname.Contains("Free"))
                            {
                                ((Label)control).Image = Properties.Resources.FREEv2;
                                ((Label)control).BackColor = Color.Black;
                                ((Label)control).Text = null;
                            }

                            continue;
                        }
                        //항목 부분
                        else if (((Label)control).Text != "")
                        {
                            //색 변경
                            Color randomColor = Color.FromArgb(rd.Next(64, 256), rd.Next(64, 256), rd.Next(64, 256));

                            //크로마 키 용 화면이랑 색이 같을 경우 다시 색을 조정함 (16진수 - 10진수 //나중에 수정해야됨)
                            if (randomColor.ToString().Equals(BackCurrentColor))
                            {
                                randomColor = Color.FromArgb(rd.Next(64, 256), rd.Next(64, 256), rd.Next(64, 256));
                            }

                            ((Label)control).BackColor = randomColor;
                            ((Label)control).BorderStyle = BorderStyle.FixedSingle;
                            ((Label)control).ForeColor = Color.Black;

                            //라벨 항목마다 텍스트 변경
                            for (int i = stack; i < rdcate_.Length;)
                            {
                                ((Label)control).Text = rdcate_[i].ToString();
                                stack++;
                                break;
                            }
                        }
                        //황금 열쇠 일 경우
                        if (((Label)control).Text.Equals("황금 열쇠"))
                        {
                            ((Label)control).BackColor = Color.Yellow;
                            ((Label)control).Image = Properties.Resources.golden_keys;
                            ((Label)control).Text = null;
                        }
                    }
                }
            }
            #endregion

            #region :: 구형 변수 ::
            //카테고리는 최종 22개가 되야 함.
            //알파벳(3) / 10 / 12 황금열쇠 숫자 변경으로 인해 임시 변경입니다.
            //string Category1 = Alpha1_1 + textAlpha1 + Alpha1_2;
            //string Category2 = Alpha1_1 + textAlpha2 + Alpha1_2;
            //string Category3 = Alpha1_1 + textAlpha3 + Alpha1_2;
            //자음(2) / 10 / 12 황금열쇠 숫자 변경으로 인해 임시 변경입니다.
            //string Category4 = Conso1_1 + textConso1 + Conso1_2;
            //string Category5 = Conso1_1 + textConso2 + Conso1_2;
            //string Category6 = Conso1_1 + textcons3 + Conso1_2;
            //황금 열쇠(4) -3, 6
            //string Category3 = text8;
            //string Category6 = text8;
            //string Category7 = text8;
            //string Category8 = text8;
            //string Category15 = text8;
            //string Category16 = text8;
            //string Category17 = text8;
            //string Category18 = text8;
            //X라인 리듬게임(1)
            //string Category9 = textButton1 + text6;
            //플랫폼(1)
            //string Category11 = textGameclass1 + text7;
            //계절 곡(1)
            //string Category12 = textSeason1 + text9;
            //BGA or 포토(1)
            //더미, 변경 가능한 것들B
            //상위 항목만(6) - / 10 / 12 황금열쇠 숫자 변경으로 인해 임시 변경입니다. -5
            //string Category14 = text10;
            //string Category15 = text11;
            //string Category16 = text12;
            //string Category17 = text13;
            //string Category18 = text14;
            //상위 + 하위 항목(3)
            //string Category20 = textDummy1 + text16;
            //string Category21 = textDummy2 + text17;
            //string Category22 = textDummy3 + text18;
            //string Category23 = textDummy4 + text19;
            //string Category24 = textDummy5 + text20;
            //string Category25 = textDummy6 + text21;
            #endregion

            #region :: 구형 ::

            //string[] rdcate_ = { };

            //황금열쇠 위치 고정일 시
            //if (GoldenFix)
            //{
            //    string[] CategoryArray = { Category1, Category2, Category4, Category5, Category9, Category11, Category12, Category14, Category20, Category21, Category22, Category23, Category24, Category25 };
            //    rdcate_ = CategoryArray.OrderBy(x => rd.Next()).ToArray();
            //}

            ///* 황금 열쇠가 정해진 위치 + 다른 항목들은 랜덤으로 배치*/
            //if (!Randomize)
            //{
            //    //모든 컨트롤을 검사
            //    foreach (System.Windows.Forms.Control control in this.Controls)
            //    {
            //        //라벨마다 반복문 + 황금 열쇠아닐 경우 진행
            //        if (control is Label && ((Label)control).Text != "Golden")
            //        {

            //            ((Label)control).Font = font1;

            //            //변함없는 값들은 변경 안하도록 (BackColor = Black)
            //            if (((Label)control).BackColor == Color.Black)
            //            {
            //                string lblname = ((Label)control).Name;

            //                //라벨
            //                if (lblname.Contains("EZ2ON"))
            //                {
            //                    ((Label)control).Image = Properties.Resources.무인도_EZ2v2;
            //                    ((Label)control).BackColor = Color.White;
            //                    ((Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("DJMAX"))
            //                {
            //                    ((Label)control).Image = Properties.Resources.무인도_DJMAXv2;
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

            //            //아닌 항목들은 말처럼 쓸수있도록
            //            else if (((Label)control).Text != "")
            //            {
            //                //색 변경
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((Label)control).BackColor = randomColor;
            //                ((Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((Label)control).ForeColor = Color.Black;

            //                //라벨 항목마다 텍스트 변경
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }

            //        }
            //        //황금열쇠 일 경우
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
            ////전체 랜덤
            //else if(Randomize)
            //{
            //    string[] CategoryArray = { Category1, Category2, Category3, Category4, Category5, Category6, Category7, Category8, Category9,  Category11, Category12, Category14, Category15, Category16, Category17, Category18, Category20, Category21, Category22, Category23, Category24, Category25 };
            //    rdcate_ = CategoryArray.OrderBy(x => rd.Next()).ToArray();

            //    //모든 컨트롤을 검사
            //    foreach (System.Windows.Forms.Control control in this.Controls)
            //    {
            //        //라벨마다 반복문
            //        if (control is Label)
            //        {
            //            ((Label)control).Font = font1;

            //            //밑에 배너
            //            if (((Label)control).Name.Equals("lblBanner"))
            //            {
            //                ((Label)control).BackColor = Color.White; ;
            //                ((Label)control).Text = "* 현재는 판 제작 기능만 제공하고 있습니다.";
            //                continue;
            //            }
            //            //변함없는 값들은 변경 안하도록 (BackColor = Black)
            //            else if (((Label)control).BackColor == Color.Black)
            //            {
            //                string lblname = ((Label)control).Name;

            //                //라벨
            //                if (lblname.Contains("Island"))
            //                {
            //                    ((Label)control).Image = Properties.Resources.무인도v2;
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
            //                    ((Label)control).Image = Properties.Resources.뱅하싶2;
            //                    ((Label)control).BackColor = Color.Black;
            //                    ((Label)control).Text = null;
            //                }

            //                continue;
            //            }

            //            //아닌 항목들은 말처럼 쓸수있도록
            //            else if (((Label)control).Text != "")
            //            {
            //                //색 변경
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((Label)control).BackColor = randomColor;
            //                ((Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((Label)control).ForeColor = Color.Black;

            //                //라벨 항목마다 텍스트 변경
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }

            //            if (((Label)control).Text.Equals("황금 열쇠"))
            //            {
            //                ((Label)control).BackColor = Color.Yellow;
            //                ((Label)control).Image = Properties.Resources.golden_keys;
            //                ((Label)control).Text = null;
            //            }
            //        }
            //    }
            //}
            ////랜덤활성화
            //if (Randomize)
            //{
            //    //모든 컨트롤을 검사
            //    foreach (System.Windows.Forms.Control control in this.Controls)
            //    {
            //        //라벨마다 반복문
            //        if (control is Label)
            //        {
            //            ((Label)control).Font = font1;

            //            //////////////////////////////////////////////////// 여기부터하세요
            //            rdcate_ = CategoryArray.OrderBy(x => rd.Next()).ToArray();

            //            //밑에 배너
            //            if (((Label)control).Name.Equals("lblBanner"))
            //            {
            //                ((Label)control).BackColor = Color.White; ;
            //                ((Label)control).Text = "* 현재는 판 제작 기능만 제공하고 있습니다.";
            //                continue;
            //            }
            //            //변함없는 값들은 변경 안하도록 (BackColor = Black)
            //            else if (((Label)control).BackColor == Color.Black)
            //            {
            //                string lblname = ((Label)control).Name;

            //                //라벨
            //                if (lblname.Contains("Island"))
            //                {
            //                    ((Label)control).Image = Properties.Resources.무인도v2;
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
            //                    ((Label)control).Image = Properties.Resources.뱅하싶2;
            //                    ((Label)control).BackColor = Color.Black;
            //                    ((Label)control).Text = null;
            //                }

            //                continue;
            //            }

            //            //아닌 항목들은 말처럼 쓸수있도록
            //            //    else if (((Label)control).Text != "")
            //            //    {
            //            //        //색 변경
            //            //        Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //            //        ((Label)control).BackColor = randomColor;
            //            //        ((Label)control).BorderStyle = BorderStyle.FixedSingle;
            //            //        ((Label)control).ForeColor = Color.Black;

            //            //        //라벨 항목마다 텍스트 변경
            //            //        for (int i = stack; i < rdcate_.Length;)
            //            //        {
            //            //            ((Label)control).Text = rdcate_[i].ToString();
            //            //            stack++;
            //            //            break;
            //            //        }
            //            //    }

            //            //    if (((Label)control).Text.Equals("황금 열쇠"))
            //            //    {
            //            //        ((Label)control).BackColor = Color.Yellow;
            //            //        ((Label)control).Image = Properties.Resources.golden_keys;
            //            //        ((Label)control).Text = null;
            //            //    }

            //        }
            //    }
            //}
            ////랜덤이 아닐 시 정해진 순서대로!
            //else
            //{
            //    //모든 컨트롤을 검사
            //    foreach (System.Windows.Forms.Control control in this.Controls)
            //    {
            //        //라벨마다 반복문
            //        if (control is Label)
            //        {
            //            ((Label)control).Font = font1;

            //            //밑에 배너
            //            if (((Label)control).Name.Equals("lblBanner"))
            //            {
            //                ((Label)control).BackColor = Color.White; ;
            //                ((Label)control).Text = "* 현재는 판 제작 기능만 제공하고 있습니다.";
            //                continue;
            //            }
            //            //변함없는 값들은 변경 안하도록 (BackColor = Black)
            //            else if (((Label)control).BackColor == Color.Black)
            //            {
            //                string lblname = ((Label)control).Name;

            //                //라벨
            //                if (lblname.Contains("Island"))
            //                {
            //                    ((Label)control).Image = Properties.Resources.무인도v2;
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
            //                    ((Label)control).Image = Properties.Resources.뱅하싶2;
            //                    ((Label)control).BackColor = Color.Black;
            //                    ((Label)control).Text = null;
            //                }

            //                continue;
            //            }

            //            //4그룹으로 나누기
            //            //그룹 A
            //            else if (((Label)control).Text.Contains("A"))
            //            {
            //                //색 변경
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((Label)control).BackColor = randomColor;
            //                ((Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((Label)control).ForeColor = Color.Black;

            //                //라벨 항목마다 텍스트 변경
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }
            //            if (((Label)control).Text.Equals("황금 열쇠"))
            //            {
            //                ((Label)control).BackColor = Color.Yellow;
            //                ((Label)control).Image = Properties.Resources.golden_keys;
            //                ((Label)control).Text = null;
            //            }

            //            //그룹 B
            //            else if (((Label)control).Text.Contains("B"))
            //            {
            //                //색 변경
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((Label)control).BackColor = randomColor;
            //                ((Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((Label)control).ForeColor = Color.Black;

            //                //라벨 항목마다 텍스트 변경
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }
            //            if (((Label)control).Text.Equals("황금 열쇠"))
            //            {
            //                ((Label)control).BackColor = Color.Yellow;
            //                ((Label)control).Image = Properties.Resources.golden_keys;
            //                ((Label)control).Text = null;
            //            }

            //            //그룹 C
            //            else if (((Label)control).Text.Contains("C"))
            //            {
            //                //색 변경
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((Label)control).BackColor = randomColor;
            //                ((Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((Label)control).ForeColor = Color.Black;

            //                //라벨 항목마다 텍스트 변경
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }
            //            if (((Label)control).Text.Equals("황금 열쇠"))
            //            {
            //                ((Label)control).BackColor = Color.Yellow;
            //                ((Label)control).Image = Properties.Resources.golden_keys;
            //                ((Label)control).Text = null;
            //            }

            //            //그룹 D
            //            else if (((Label)control).Text.Contains("D"))
            //            {
            //                //색 변경
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((Label)control).BackColor = randomColor;
            //                ((Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((Label)control).ForeColor = Color.Black;

            //                //라벨 항목마다 텍스트 변경
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }

            //            if (((Label)control).Text.Equals("황금 열쇠"))
            //            {
            //                ((Label)control).BackColor = Color.Yellow;
            //                ((Label)control).Image = Properties.Resources.golden_keys;
            //                ((Label)control).Text = null;
            //            }
            //        }

            //        //아닌 항목들은 말처럼 쓸수있도록
            //        //    else if (((Label)control).Text != "")
            //        //    {
            //        //        //색 변경
            //        //        Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //        //        ((Label)control).BackColor = randomColor;
            //        //        ((Label)control).BorderStyle = BorderStyle.FixedSingle;
            //        //        ((Label)control).ForeColor = Color.Black;

            //        //        //라벨 항목마다 텍스트 변경
            //        //        for (int i = stack; i < rdcate_.Length;)
            //        //        {
            //        //            ((Label)control).Text = rdcate_[i].ToString();
            //        //            stack++;
            //        //            break;
            //        //        }
            //        //    }

            //        //    if (((Label)control).Text.Equals("황금 열쇠"))
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
                    MessageBox.Show("설정 파일이 없어요, 판 개발자를 불러주세요");
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

        //종료 버튼 클릭 이벤트
        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("정말로 종료하시겠습니까?", "확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (Result == DialogResult.OK)
            {
                Environment.Exit(0);
            }
        }

        //판 섞기 버튼 이벤트
        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("정말로 판을 섞으시겠습니까?", "확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (Result == DialogResult.OK)
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }

        //항목 설정 버튼 클릭 이벤트
        private void buttonSetup_Click(object sender, EventArgs e)
        {
            Popup popup = new Popup();
            popup.ShowDialog();
        }

        //폰트 정보 버튼 클릭 이벤트
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("이 프로그램에는 메이플스토리가 제공한\r메이플스토리 서체가 적용되어 있습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //스크린샷 버튼 클릭 이벤트
        private void btnScreenshot_Click(object sender, EventArgs e)
        {

            DialogResult Result = MessageBox.Show("현재 판을 저장 하시겠습니까? \r실행파일 폴더에 저장됩니다.", "저장 확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (Result == DialogResult.OK)
            {
                MessageBox.Show("확인을 누르시면 3초 뒤 스크린 캡쳐가 됩니다.", "저장 확인", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //저장 위치 지정 (프로그램 폴더)
                string localpath = System.Environment.CurrentDirectory;
                string filename = "\\판때기.png";
                string _path = localpath + filename;

                //FHD 크기 지정
                Capture ImgCapture = new Capture(0, 0, 1920, 1080);
                ImgCapture.SetPath(_path);

                ImgCapture.CaptureImage();

                //라벨 색 최종 확인
                string ChangedColor = Properties.Settings.Default.BackCurrentColor;
                BackScreen.BackColor = System.Drawing.ColorTranslator.FromHtml(ChangedColor);

                if (!Labellocation)  BackScreen.BringToFront();

                CaptureImage(_path);

                MessageBox.Show("사진이 저장되었습니다.", "확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (!Labellocation) BackScreen.SendToBack();
                return;
            }
        }
        //라벨 클릭 시 화면 전환 이벤트
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
        //색 설정 버튼
        private void btn_Color_Click(object sender, EventArgs e)
        {
            ColorControl color = new ColorControl();
            color.ShowDialog();
        }
        #endregion

        #region :: ETC Event ::
        //크기 고정 이벤트
        private void MainBoard_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(1920, 1080);
        }

        //이미지 캡쳐 이벤트
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
        //딜레이 이벤트
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