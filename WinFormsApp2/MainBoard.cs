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

namespace RhythmMonopoly
{
    public partial class MainBoard : Form
    {

        //라벨 위치 변수
        bool Labellocation = false;

        public MainBoard()
        {
            InitializeComponent();

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

            //로고 좌표
            labelLogo.Left = (this.ClientSize.Width - labelLogo.Width) / 2;
            labelLogo.Top = (this.ClientSize.Height - labelLogo.Height) / 2;

            #endregion

            #region :: 변수 불러오기 ::

            //판때기 항목들
            string TopCategory01 = Properties.Settings.Default.TopCategory01; //상위  
            string TopCategory02 = Properties.Settings.Default.TopCategory02; //상위
            string TopCategory03 = Properties.Settings.Default.TopCategory03; //상위
            string TopCategory04 = Properties.Settings.Default.TopCategory04; //상위
            string TopCategory05 = Properties.Settings.Default.TopCategory05; //상위
            string TopCategory06 = Properties.Settings.Default.TopCategory06; //상위

            string BotCategory01 = Properties.Settings.Default.BotCategory01; //상위 + 하위
            string BotCategory02 = Properties.Settings.Default.BotCategory02; //상위 + 하위
            string BotCategory03 = Properties.Settings.Default.BotCategory03; //상위 + 하위
            string BotCategory04 = Properties.Settings.Default.BotCategory04; //상위 + 하위
            string BotCategory05 = Properties.Settings.Default.BotCategory05; //상위 + 하위
            string BotCategory06 = Properties.Settings.Default.BotCategory06; //상위 + 하위


            //하위 더미데이터
            string dummycontent1_1 = Properties.Settings.Default.dummycontent1_1;
            string dummycontent1_2 = Properties.Settings.Default.dummycontent1_2;
            string dummycontent1_3 = Properties.Settings.Default.dummycontent1_3;

            string dummycontent2_1 = Properties.Settings.Default.dummycontent2_1;
            string dummycontent2_2 = Properties.Settings.Default.dummycontent2_2;
            string dummycontent2_3 = Properties.Settings.Default.dummycontent2_3;
            string dummycontent2_4 = Properties.Settings.Default.dummycontent2_4;

            string dummycontent3_1 = Properties.Settings.Default.dummycontent3_1;
            string dummycontent3_2 = Properties.Settings.Default.dummycontent3_2;
            string dummycontent3_3 = Properties.Settings.Default.dummycontent3_3;
            string dummycontent3_4 = Properties.Settings.Default.dummycontent3_4;
            string dummycontent3_5 = Properties.Settings.Default.dummycontent3_5;

            string dummycontent4_1 = Properties.Settings.Default.dummycontent4_1;
            string dummycontent4_2 = Properties.Settings.Default.dummycontent4_2;
            string dummycontent4_3 = Properties.Settings.Default.dummycontent4_3;
            string dummycontent4_4 = Properties.Settings.Default.dummycontent4_4;
            string dummycontent4_5 = Properties.Settings.Default.dummycontent4_5;

            string dummycontent5_1 = Properties.Settings.Default.dummycontent5_1;
            string dummycontent5_2 = Properties.Settings.Default.dummycontent5_2;
            string dummycontent5_3 = Properties.Settings.Default.dummycontent5_3;
            string dummycontent5_4 = Properties.Settings.Default.dummycontent5_4;
            string dummycontent5_5 = Properties.Settings.Default.dummycontent5_5;

            string dummycontent6_1 = Properties.Settings.Default.dummycontent6_1;
            string dummycontent6_2 = Properties.Settings.Default.dummycontent6_2;
            string dummycontent6_3 = Properties.Settings.Default.dummycontent6_3;


            //항목 숫자 변수
            int AlphaNum = Properties.Settings.Default.AlphaNum;
            int ConsoNum = Properties.Settings.Default.ConsoNum;
            int TopNum = Properties.Settings.Default.TopNum;
            int BotNum = Properties.Settings.Default.BottomNum;
            int GoldenNum = Properties.Settings.Default.GoldenNum;

            //랜덤변수
            bool Randomize = Properties.Settings.Default.Randomize;
            bool GoldenFix = Properties.Settings.Default.GoldenFix;

            //뒷배경
            string BackCurrentColor = Properties.Settings.Default.BackCurrentColor;

            #endregion

            #region :: 변수 텍스트 ::
            //알파벳
            string Alpha1_1 = "알파벳 ";
            string Alpha1_2 = " 로 시작되는 곡";

            //자음 (2) - 8
            string Conso1_1 = "발음이 ";
            string Conso1_2 = " 로 시작되는 곡";

            //항목회전용
            int stack = 0;
            #endregion

            #region :: 변수 랜덤 내용 설정 ::
            //바꿀 필요 없는 것
            //알파벳
            string[] alphabet_ = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
            //버튼
            string[] button_ = { "4", "5", "6", "8" };
            //계절
            string[] season_ = { "봄", "여름", "가을", "겨울" };
            //기종
            string[] gameclass_ = { "PC", "모바일", "콘솔" };
            //자음
            string[] consonant_ = { "ㄱ", "ㄴ", "ㄷ", "ㄹ", "ㅁ", "ㅂ", "ㅅ", "ㅇ", "ㅈ", "ㅊ", "ㅋ", "ㅌ", "ㅍ", "ㅎ"};

            //추가적으로 제공되는 더미 데이터들 저장소 (3,4,5)
            string[] Dummy1_ = { dummycontent1_1, dummycontent1_2, dummycontent1_3};
            string[] Dummy2_ = { dummycontent2_1, dummycontent2_2, dummycontent2_3, dummycontent2_4};
            string[] Dummy3_ = { dummycontent3_1, dummycontent3_2, dummycontent3_3, dummycontent3_4, dummycontent3_5};
            string[] Dummy4_ = { dummycontent4_1, dummycontent4_2, dummycontent4_3, dummycontent4_4, dummycontent4_5};
            string[] Dummy5_ = { dummycontent5_1, dummycontent5_2, dummycontent5_3, dummycontent5_4, dummycontent5_5};
            string[] Dummy6_ = { dummycontent6_1, dummycontent6_2, dummycontent6_3 };

            ///배열 섞기
            //변경 불가능
            /// 랜덤으로 돌리기
            string[] rdalphabet_ = alphabet_.OrderBy(x => rd.Next()).ToArray();
            string[] rdConsonant_ = consonant_.OrderBy(x => rd.Next()).ToArray();
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
            string textConso1 = rdConsonant_[0].ToString() + ", " + rdConsonant_[1].ToString() + ", " + rdConsonant_[2].ToString();
            string textConso2 = rdConsonant_[3].ToString() + ", " + rdConsonant_[4].ToString() + ", " + rdConsonant_[5].ToString();
            string textConso3 = rdConsonant_[6].ToString() + ", " + rdConsonant_[7].ToString() + ", " + rdConsonant_[8].ToString();
            string textConso4 = rdConsonant_[9].ToString() + ", " + rdConsonant_[10].ToString() + ", " + rdConsonant_[11].ToString();

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
            string CateAlpha1 = Alpha1_1 + textAlpha1 + Alpha1_2;
            string CateAlpha2 = Alpha1_1 + textAlpha2 + Alpha1_2;
            string CateAlpha3 = Alpha1_1 + textAlpha3 + Alpha1_2;
            string CateAlpha4 = Alpha1_1 + textAlpha4 + Alpha1_2;
            string CateAlpha5 = Alpha1_1 + textAlpha5 + Alpha1_2;
            string CateAlpha6 = Alpha1_1 + textAlpha6 + Alpha1_2;
            string CateAlpha7 = Alpha1_1 + textAlpha7 + Alpha1_2;
            string CateAlpha8 = Alpha1_1 + textAlpha8 + Alpha1_2;

            string[] CateAlpha = { CateAlpha1, CateAlpha2, CateAlpha3, CateAlpha4, CateAlpha5, CateAlpha6, CateAlpha7, CateAlpha8 }; 

            //자음 변수
            string CateConso1 = Conso1_1 + textConso1 + Conso1_2;
            string CateConso2 = Conso1_1 + textConso2 + Conso1_2;
            string CateConso3 = Conso1_1 + textConso3 + Conso1_2;
            string CateConso4 = Conso1_1 + textConso4 + Conso1_2;

            string[] CateConso = { CateConso1, CateConso2, CateConso3, CateConso4 };

            //상위만
            string CateTop1 = TopCategory01;
            string CateTop2 = TopCategory02;
            string CateTop3 = TopCategory03;
            string CateTop4 = TopCategory04;
            string CateTop5 = TopCategory05;
            string CateTop6 = TopCategory06;

            string[] CateTop = { CateTop1, CateTop2, CateTop3, CateTop4, CateTop5, CateTop6 };

            //하위만
            string CateBot1 = textDummy1 + BotCategory01;
            string CateBot2 = textDummy2 + BotCategory02;
            string CateBot3 = textDummy3 + BotCategory03;
            string CateBot4 = textDummy4 + BotCategory04;
            string CateBot5 = textDummy5 + BotCategory05;
            string CateBot6 = textDummy6 + BotCategory06;

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

            string[] CateGolden = { CateGolden1, CateGolden2, CateGolden3, CateGolden4, CateGolden5, CateGolden6, CateGolden7, CateGolden8 };

            //고정 항목
            string CateButton = textButton1 + " 라인 리듬게임";
            string CateGameClass = textGameclass1 + " 플랫폼 리듬게임";
            string CateSeason = textSeason1 + " 계절 곡";
            #endregion

            #region :: 신형 배열 제작 ::

            //항목들을 담을 Dictionary 생성
            Dictionary<string, string> CateDictionary = new Dictionary<string, string>();

            //고정 항목들을 Dictionary에 추가
            CateDictionary.Add("CateButton", CateButton);
            CateDictionary.Add("CateGameClass", CateGameClass);
            CateDictionary.Add("CateSeason", CateSeason);

            //알파벳 항목들을 Dictionary에 추가
            for (int i = 1; i < AlphaNum + 1; i++)
            {
                CateDictionary.Add(String.Format("CateAlpha{0}", i.ToString()), CateAlpha[i-1]);
            }

            //자음 항목들을 Dictionary에 추가
            for (int i = 1; i < ConsoNum + 1; i++)
            {
                CateDictionary.Add(String.Format("CateConso{0}", i.ToString()), CateConso[i - 1]);
            }

            //상위 항목들을 Dictionary에 추가
            for (int i = 1; i < TopNum + 1; i++)
            {
                CateDictionary.Add(String.Format("CateTop{0}", i.ToString()), CateTop[i - 1]);
            }

            //상위 + 하위 항목들을 Dictionary에 추가
            for (int i = 1; i < BotNum + 1; i++)
            {
                CateDictionary.Add(String.Format("CateBot{0}", i.ToString()), CateBot[i - 1]);
            }

            //Dictionary에서 Value 값 추출 후 새 리스트 제작 
            var CateList = new List<string>(CateDictionary.Values);
            #endregion

            #region :: 항목 삽입 ::

            //제작 리스트에서 무작위 배열로 담을 Array 지정
            string[] rdcate_ = { };
            //황금열쇠 위치 고정일 시
            if (GoldenFix)
            {
                rdcate_ = CateList.OrderBy(x => rd.Next()).ToArray();
            }


            /* 황금 열쇠가 정해진 위치 + 다른 항목들은 랜덤으로 배치 */
            if (!Randomize)
            {
                //모든 컨트롤을 검사
                foreach (System.Windows.Forms.Control control in this.Controls)
                {
                    //라벨 검사 + 황금 열쇠가 아닐 경우
                    if (control is System.Windows.Forms.Label && ((System.Windows.Forms.Label)control).Text != "Golden")
                    {
                        //폰트 변경 (신메이플 스토리)
                        ((System.Windows.Forms.Label)control).Font = font1;
                        //라벨 이름 검사
                        string lblname = ((System.Windows.Forms.Label)control).Name;
                        if (lblname.Contains("BackScreen"))
                        {
                            ((System.Windows.Forms.Label)control).BackColor = System.Drawing.ColorTranslator.FromHtml(BackCurrentColor);
                            continue;
                        }
                        //변함없는 값들은 변경 안하도록 (BackColor = Black)
                        else if (((System.Windows.Forms.Label)control).BackColor == Color.Black)
                        {

                            //투온섬
                            if (lblname.Contains("EZ2ON"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.무인도_EZ2v2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.White;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }
                            //디맥섬
                            else if (lblname.Contains("DJMAX"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.무인도_DJMAXv2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.White;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }
                            //출발지점
                            else if (lblname.Contains("Start"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.STARTv2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.White;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }
                            //자유
                            else if (lblname.Contains("Free"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.FREEv2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.Black;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }
                            continue;
                        }
                        //항목 부분
                        else if (((System.Windows.Forms.Label)control).Text != "")
                        {
                            //색 변경
                            Color randomColor = Color.FromArgb(rd.Next(64, 256), rd.Next(0, 20), rd.Next(64, 256));

                            ((System.Windows.Forms.Label)control).BackColor = randomColor;
                            ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
                            ((System.Windows.Forms.Label)control).ForeColor = Color.Black;

                            //무작위로 항목 추가
                            for (int i = stack; i < rdcate_.Length;)
                            {
                                ((System.Windows.Forms.Label)control).Text = rdcate_[i].ToString();
                                stack++;
                                break;
                            }
                        }

                    }
                    //황금열쇠 일 경우
                    else if (control is System.Windows.Forms.Label && ((System.Windows.Forms.Label)control).Text.Contains("Golden"))
                    {
                        ((System.Windows.Forms.Label)control).BackColor = Color.Yellow;
                        ((System.Windows.Forms.Label)control).Image = Properties.Resources.golden_keys;
                        ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
                        ((System.Windows.Forms.Label)control).Text = null;
                        continue;
                    }
                }

            }
            //전체 랜덤 체크 시
            else if (Randomize)
            {
                //황금열쇠 개수 만큼 추가
                for (int i = 0; i < GoldenNum; i++)
                {
                    CateList.Add("황금 열쇠");
                }

                //황금열쇠 추가 후 새롭게 무작위
                rdcate_ = CateList.OrderBy(x => rd.Next()).ToArray();

                //모든 컨트롤을 검사
                foreach (System.Windows.Forms.Control control in this.Controls)
                {
                    //라벨 검사 + 황금 열쇠가 아닐 경우
                    if (control is System.Windows.Forms.Label)
                    {
                        //폰트 설정
                        ((System.Windows.Forms.Label)control).Font = font1;
                        //라벨 이름 검사
                        string lblname = ((System.Windows.Forms.Label)control).Name;
                        if (lblname.Contains("BackScreen"))
                        {
                            ((System.Windows.Forms.Label)control).BackColor = System.Drawing.ColorTranslator.FromHtml(BackCurrentColor);
                            continue;
                        }
                        //변함없는 값들은 변경 안하도록 (BackColor = Black)
                        else if (((System.Windows.Forms.Label)control).BackColor == Color.Black)
                        {

                            //투온섬
                            if (lblname.Contains("EZ2ON"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.무인도_EZ2v2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.White;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }
                            //디맥섬
                            else if (lblname.Contains("DJMAX"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.무인도_DJMAXv2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.White;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }
                            //출발지점
                            else if (lblname.Contains("Start"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.STARTv2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.White;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }
                            //자유
                            else if (lblname.Contains("Free"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.FREEv2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.Black;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }

                            continue;
                        }
                        //항목 부분
                        else if (((System.Windows.Forms.Label)control).Text != "")
                        {
                            //색 변경
                            Color randomColor = Color.FromArgb(rd.Next(64, 256), rd.Next(0, 20), rd.Next(64, 256));

                            ((System.Windows.Forms.Label)control).BackColor = randomColor;
                            ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
                            ((System.Windows.Forms.Label)control).ForeColor = Color.Black;

                            //라벨 항목마다 텍스트 변경
                            for (int i = stack; i < rdcate_.Length;)
                            {
                                ((System.Windows.Forms.Label)control).Text = rdcate_[i].ToString();
                                stack++;
                                break;
                            }
                        }
                        //황금 열쇠 일 경우
                        if (((System.Windows.Forms.Label)control).Text.Equals("황금 열쇠"))
                        {
                            ((System.Windows.Forms.Label)control).BackColor = Color.Yellow;
                            ((System.Windows.Forms.Label)control).Image = Properties.Resources.golden_keys;
                            ((System.Windows.Forms.Label)control).Text = null;
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
            //        if (control is System.Windows.Forms.Label && ((System.Windows.Forms.Label)control).Text != "Golden")
            //        {

            //            ((System.Windows.Forms.Label)control).Font = font1;

            //            //변함없는 값들은 변경 안하도록 (BackColor = Black)
            //            if (((System.Windows.Forms.Label)control).BackColor == Color.Black)
            //            {
            //                string lblname = ((System.Windows.Forms.Label)control).Name;

            //                //라벨
            //                if (lblname.Contains("EZ2ON"))
            //                {
            //                    ((System.Windows.Forms.Label)control).Image = Properties.Resources.무인도_EZ2v2;
            //                    ((System.Windows.Forms.Label)control).BackColor = Color.White;
            //                    ((System.Windows.Forms.Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("DJMAX"))
            //                {
            //                    ((System.Windows.Forms.Label)control).Image = Properties.Resources.무인도_DJMAXv2;
            //                    ((System.Windows.Forms.Label)control).BackColor = Color.White;
            //                    ((System.Windows.Forms.Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("Start"))
            //                {
            //                    ((System.Windows.Forms.Label)control).Image = Properties.Resources.STARTv2;
            //                    ((System.Windows.Forms.Label)control).BackColor = Color.White;
            //                    ((System.Windows.Forms.Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("Free"))
            //                {
            //                    ((System.Windows.Forms.Label)control).Image = Properties.Resources.FREEv2;
            //                    ((System.Windows.Forms.Label)control).BackColor = Color.Black;
            //                    ((System.Windows.Forms.Label)control).Text = null;
            //                }

            //                continue;
            //            }

            //            //아닌 항목들은 말처럼 쓸수있도록
            //            else if (((System.Windows.Forms.Label)control).Text != "")
            //            {
            //                //색 변경
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((System.Windows.Forms.Label)control).BackColor = randomColor;
            //                ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((System.Windows.Forms.Label)control).ForeColor = Color.Black;

            //                //라벨 항목마다 텍스트 변경
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((System.Windows.Forms.Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }

            //        }
            //        //황금열쇠 일 경우
            //        else if (control is System.Windows.Forms.Label && ((System.Windows.Forms.Label)control).Text.Contains("Golden"))
            //        {
            //            ((System.Windows.Forms.Label)control).BackColor = Color.Yellow;
            //            ((System.Windows.Forms.Label)control).Image = Properties.Resources.golden_keys;
            //            ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
            //            ((System.Windows.Forms.Label)control).Text = null;
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
            //        if (control is System.Windows.Forms.Label)
            //        {
            //            ((System.Windows.Forms.Label)control).Font = font1;

            //            //밑에 배너
            //            if (((System.Windows.Forms.Label)control).Name.Equals("lblBanner"))
            //            {
            //                ((System.Windows.Forms.Label)control).BackColor = Color.White; ;
            //                ((System.Windows.Forms.Label)control).Text = "* 현재는 판 제작 기능만 제공하고 있습니다.";
            //                continue;
            //            }
            //            //변함없는 값들은 변경 안하도록 (BackColor = Black)
            //            else if (((System.Windows.Forms.Label)control).BackColor == Color.Black)
            //            {
            //                string lblname = ((System.Windows.Forms.Label)control).Name;

            //                //라벨
            //                if (lblname.Contains("Island"))
            //                {
            //                    ((System.Windows.Forms.Label)control).Image = Properties.Resources.무인도v2;
            //                    ((System.Windows.Forms.Label)control).BackColor = Color.White;
            //                    ((System.Windows.Forms.Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("Start"))
            //                {
            //                    ((System.Windows.Forms.Label)control).Image = Properties.Resources.Start;
            //                    ((System.Windows.Forms.Label)control).BackColor = Color.White;
            //                    ((System.Windows.Forms.Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("Free"))
            //                {
            //                    ((System.Windows.Forms.Label)control).Image = Properties.Resources.뱅하싶2;
            //                    ((System.Windows.Forms.Label)control).BackColor = Color.Black;
            //                    ((System.Windows.Forms.Label)control).Text = null;
            //                }

            //                continue;
            //            }

            //            //아닌 항목들은 말처럼 쓸수있도록
            //            else if (((System.Windows.Forms.Label)control).Text != "")
            //            {
            //                //색 변경
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((System.Windows.Forms.Label)control).BackColor = randomColor;
            //                ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((System.Windows.Forms.Label)control).ForeColor = Color.Black;

            //                //라벨 항목마다 텍스트 변경
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((System.Windows.Forms.Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }

            //            if (((System.Windows.Forms.Label)control).Text.Equals("황금 열쇠"))
            //            {
            //                ((System.Windows.Forms.Label)control).BackColor = Color.Yellow;
            //                ((System.Windows.Forms.Label)control).Image = Properties.Resources.golden_keys;
            //                ((System.Windows.Forms.Label)control).Text = null;
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
            //        if (control is System.Windows.Forms.Label)
            //        {
            //            ((System.Windows.Forms.Label)control).Font = font1;

            //            //////////////////////////////////////////////////// 여기부터하세요
            //            rdcate_ = CategoryArray.OrderBy(x => rd.Next()).ToArray();

            //            //밑에 배너
            //            if (((System.Windows.Forms.Label)control).Name.Equals("lblBanner"))
            //            {
            //                ((System.Windows.Forms.Label)control).BackColor = Color.White; ;
            //                ((System.Windows.Forms.Label)control).Text = "* 현재는 판 제작 기능만 제공하고 있습니다.";
            //                continue;
            //            }
            //            //변함없는 값들은 변경 안하도록 (BackColor = Black)
            //            else if (((System.Windows.Forms.Label)control).BackColor == Color.Black)
            //            {
            //                string lblname = ((System.Windows.Forms.Label)control).Name;

            //                //라벨
            //                if (lblname.Contains("Island"))
            //                {
            //                    ((System.Windows.Forms.Label)control).Image = Properties.Resources.무인도v2;
            //                    ((System.Windows.Forms.Label)control).BackColor = Color.White;
            //                    ((System.Windows.Forms.Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("Start"))
            //                {
            //                    ((System.Windows.Forms.Label)control).Image = Properties.Resources.Start;
            //                    ((System.Windows.Forms.Label)control).BackColor = Color.White;
            //                    ((System.Windows.Forms.Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("Free"))
            //                {
            //                    ((System.Windows.Forms.Label)control).Image = Properties.Resources.뱅하싶2;
            //                    ((System.Windows.Forms.Label)control).BackColor = Color.Black;
            //                    ((System.Windows.Forms.Label)control).Text = null;
            //                }

            //                continue;
            //            }

            //            //아닌 항목들은 말처럼 쓸수있도록
            //            //    else if (((System.Windows.Forms.Label)control).Text != "")
            //            //    {
            //            //        //색 변경
            //            //        Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //            //        ((System.Windows.Forms.Label)control).BackColor = randomColor;
            //            //        ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
            //            //        ((System.Windows.Forms.Label)control).ForeColor = Color.Black;

            //            //        //라벨 항목마다 텍스트 변경
            //            //        for (int i = stack; i < rdcate_.Length;)
            //            //        {
            //            //            ((System.Windows.Forms.Label)control).Text = rdcate_[i].ToString();
            //            //            stack++;
            //            //            break;
            //            //        }
            //            //    }

            //            //    if (((System.Windows.Forms.Label)control).Text.Equals("황금 열쇠"))
            //            //    {
            //            //        ((System.Windows.Forms.Label)control).BackColor = Color.Yellow;
            //            //        ((System.Windows.Forms.Label)control).Image = Properties.Resources.golden_keys;
            //            //        ((System.Windows.Forms.Label)control).Text = null;
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
            //        if (control is System.Windows.Forms.Label)
            //        {
            //            ((System.Windows.Forms.Label)control).Font = font1;

            //            //밑에 배너
            //            if (((System.Windows.Forms.Label)control).Name.Equals("lblBanner"))
            //            {
            //                ((System.Windows.Forms.Label)control).BackColor = Color.White; ;
            //                ((System.Windows.Forms.Label)control).Text = "* 현재는 판 제작 기능만 제공하고 있습니다.";
            //                continue;
            //            }
            //            //변함없는 값들은 변경 안하도록 (BackColor = Black)
            //            else if (((System.Windows.Forms.Label)control).BackColor == Color.Black)
            //            {
            //                string lblname = ((System.Windows.Forms.Label)control).Name;

            //                //라벨
            //                if (lblname.Contains("Island"))
            //                {
            //                    ((System.Windows.Forms.Label)control).Image = Properties.Resources.무인도v2;
            //                    ((System.Windows.Forms.Label)control).BackColor = Color.White;
            //                    ((System.Windows.Forms.Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("Start"))
            //                {
            //                    ((System.Windows.Forms.Label)control).Image = Properties.Resources.Start;
            //                    ((System.Windows.Forms.Label)control).BackColor = Color.White;
            //                    ((System.Windows.Forms.Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("Free"))
            //                {
            //                    ((System.Windows.Forms.Label)control).Image = Properties.Resources.뱅하싶2;
            //                    ((System.Windows.Forms.Label)control).BackColor = Color.Black;
            //                    ((System.Windows.Forms.Label)control).Text = null;
            //                }

            //                continue;
            //            }

            //            //4그룹으로 나누기
            //            //그룹 A
            //            else if (((System.Windows.Forms.Label)control).Text.Contains("A"))
            //            {
            //                //색 변경
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((System.Windows.Forms.Label)control).BackColor = randomColor;
            //                ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((System.Windows.Forms.Label)control).ForeColor = Color.Black;

            //                //라벨 항목마다 텍스트 변경
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((System.Windows.Forms.Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }
            //            if (((System.Windows.Forms.Label)control).Text.Equals("황금 열쇠"))
            //            {
            //                ((System.Windows.Forms.Label)control).BackColor = Color.Yellow;
            //                ((System.Windows.Forms.Label)control).Image = Properties.Resources.golden_keys;
            //                ((System.Windows.Forms.Label)control).Text = null;
            //            }

            //            //그룹 B
            //            else if (((System.Windows.Forms.Label)control).Text.Contains("B"))
            //            {
            //                //색 변경
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((System.Windows.Forms.Label)control).BackColor = randomColor;
            //                ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((System.Windows.Forms.Label)control).ForeColor = Color.Black;

            //                //라벨 항목마다 텍스트 변경
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((System.Windows.Forms.Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }
            //            if (((System.Windows.Forms.Label)control).Text.Equals("황금 열쇠"))
            //            {
            //                ((System.Windows.Forms.Label)control).BackColor = Color.Yellow;
            //                ((System.Windows.Forms.Label)control).Image = Properties.Resources.golden_keys;
            //                ((System.Windows.Forms.Label)control).Text = null;
            //            }

            //            //그룹 C
            //            else if (((System.Windows.Forms.Label)control).Text.Contains("C"))
            //            {
            //                //색 변경
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((System.Windows.Forms.Label)control).BackColor = randomColor;
            //                ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((System.Windows.Forms.Label)control).ForeColor = Color.Black;

            //                //라벨 항목마다 텍스트 변경
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((System.Windows.Forms.Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }
            //            if (((System.Windows.Forms.Label)control).Text.Equals("황금 열쇠"))
            //            {
            //                ((System.Windows.Forms.Label)control).BackColor = Color.Yellow;
            //                ((System.Windows.Forms.Label)control).Image = Properties.Resources.golden_keys;
            //                ((System.Windows.Forms.Label)control).Text = null;
            //            }

            //            //그룹 D
            //            else if (((System.Windows.Forms.Label)control).Text.Contains("D"))
            //            {
            //                //색 변경
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((System.Windows.Forms.Label)control).BackColor = randomColor;
            //                ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((System.Windows.Forms.Label)control).ForeColor = Color.Black;

            //                //라벨 항목마다 텍스트 변경
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((System.Windows.Forms.Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }

            //            if (((System.Windows.Forms.Label)control).Text.Equals("황금 열쇠"))
            //            {
            //                ((System.Windows.Forms.Label)control).BackColor = Color.Yellow;
            //                ((System.Windows.Forms.Label)control).Image = Properties.Resources.golden_keys;
            //                ((System.Windows.Forms.Label)control).Text = null;
            //            }
            //        }

            //        //아닌 항목들은 말처럼 쓸수있도록
            //        //    else if (((System.Windows.Forms.Label)control).Text != "")
            //        //    {
            //        //        //색 변경
            //        //        Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //        //        ((System.Windows.Forms.Label)control).BackColor = randomColor;
            //        //        ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
            //        //        ((System.Windows.Forms.Label)control).ForeColor = Color.Black;

            //        //        //라벨 항목마다 텍스트 변경
            //        //        for (int i = stack; i < rdcate_.Length;)
            //        //        {
            //        //            ((System.Windows.Forms.Label)control).Text = rdcate_[i].ToString();
            //        //            stack++;
            //        //            break;
            //        //        }
            //        //    }

            //        //    if (((System.Windows.Forms.Label)control).Text.Equals("황금 열쇠"))
            //        //    {
            //        //        ((System.Windows.Forms.Label)control).BackColor = Color.Yellow;
            //        //        ((System.Windows.Forms.Label)control).Image = Properties.Resources.golden_keys;
            //        //        ((System.Windows.Forms.Label)control).Text = null;
            //        //    }
            //    }
            //}
            #endregion

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

            DialogResult Result = MessageBox.Show("현재 판을 저장 하시겠습니까? \r바탕화면에 저장됩니다.", "저장 확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (Result == DialogResult.OK)
            {
                MessageBox.Show("확인을 누르시면 3초 뒤 스크린 캡쳐가 됩니다.", "저장 확인", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //저장 위치 지정 (바탕화면)
                string localpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
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

                MessageBox.Show("바탕화면에 저장되었습니다.", "확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                BackScreen.BackColor = System.Drawing.ColorTranslator.FromHtml(ChangedColor);

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