using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Globalization;
using System.ComponentModel.Design;

namespace RhythmMonopoly
{
    public partial class MainBoard : Form
    {
        public MainBoard()
        {
            InitializeComponent();

            #region :: 어플 설정 ::

            //컨트롤박스 제거
            this.ControlBox = false;
            //StringBuilder
            StringBuilder sb = new StringBuilder(); 
            //랜덤함수
            Random rd = new Random();
            //폰트설정
            Font font1 = new Font(FontManager.fontFamilys[0], 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

            //크기 관련
            this.MinimumSize = new Size(1920, 1080);
            this.MaximumSize = new Size(1920, 1080);

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

            //느낌 5개
            string feelcontent1 = Properties.Settings.Default.feelcontent1;
            string feelcontent2 = Properties.Settings.Default.feelcontent2;
            string feelcontent3 = Properties.Settings.Default.feelcontent3;
            string feelcontent4 = Properties.Settings.Default.feelcontent4;
            string feelcontent5 = Properties.Settings.Default.feelcontent5;

            //BGA 내용물 5개
            string bgacontent1 = Properties.Settings.Default.bgacontent1;
            string bgacontent2 = Properties.Settings.Default.bgacontent2;
            string bgacontent3 = Properties.Settings.Default.bgacontent3;
            string bgacontent4 = Properties.Settings.Default.bgacontent4;
            string bgacontent5 = Properties.Settings.Default.bgacontent5;

            //언어
            string languagecontent1 = Properties.Settings.Default.languagecontent1;
            string languagecontent2 = Properties.Settings.Default.languagecontent2;
            string languagecontent3 = Properties.Settings.Default.languagecontent3;

            //하위 더미데이터 불러오는 곳 3,4,5
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

            //항목 숫자 변수
            int AlphaNum = Properties.Settings.Default.AlphaNum;
            int ConsoNum = Properties.Settings.Default.ConsoNum;
            int TopNum = Properties.Settings.Default.TopNum;
            int BotNum = Properties.Settings.Default.BotNum;

            //랜덤변수
            bool Randomize = Properties.Settings.Default.Randomize;
            bool GoldenFix = Properties.Settings.Default.GoldenFix;

            #endregion

            #region :: 변수 텍스트 ::
            /* 변경 불가능 한 항목들 14개 */
            //알파벳 (3) - 3
            string text1_1 = "알파벳 ";
            string text1_2 = " 로 시작되는 곡";

            //브가 (1) - 4
            string text2_1 = "BGA 안에 ";
            string text2_2 = " 이(가) 포함된 곡";

            //노래보컬 언어 (1) - 5
            string text3 = " 보컬이 포함된 곡";

            //자음 (3) - 8
            string text5_1 = "발음이 ";
            string text5_2 = " 로 시작되는 곡";

            //X라인 리듬게임 (1) - 9
            string text6 = " 라인 리듬게임";

            //플랫폼 (1) - 10
            string text7 = " 기종 게임";

            //황금열쇠 (2) - 12
            string text8 = "황금 열쇠";

            //계절 곡 (1) - 13
            string text9 = " 계절 곡";

            //변경 가능한 항목들 - 9개
            //6개 - 상위항목만
            string text10 = TopCategory01;
            string text11 = TopCategory02;
            string text12 = TopCategory03;
            string text13 = TopCategory04;
            string text14 = TopCategory05;
            string text15 = TopCategory06;
            //3개 - 상위 정하고 하위항목 3,4,5 1개씩
            string text16 = BotCategory01; //Dummydata1_1 ~ 1_3
            string text17 = BotCategory02; //Dummydata2_1 ~ 2_4
            string text18 = BotCategory03; //Dummydata3_1 ~ 3_5

            //항목회전용
            int stack = 0;
            #endregion

            #region :: 대충 변수용 내용 설정 ::
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
            //언어 변경은 3개까지
            string[] language_ = { languagecontent1, languagecontent2, languagecontent3 };

            ///변경 할 수 있어야 되는 것들
            //느낌
            string[] feels_ = { feelcontent1, feelcontent2, feelcontent3, feelcontent4, feelcontent5 };
            //브가 포함
            string[] bga_ = { bgacontent1, bgacontent2, bgacontent3, bgacontent4, bgacontent5 };

            //추가적으로 제공되는 더미 데이터들 저장소 (3,4,5)
            string[] Dummy1_ = { dummycontent1_1, dummycontent1_2, dummycontent1_3};
            string[] Dummy2_ = { dummycontent2_1, dummycontent2_2, dummycontent2_3, dummycontent2_4};
            string[] Dummy3_ = { dummycontent3_1, dummycontent3_2, dummycontent3_3, dummycontent3_4, dummycontent3_5};


            ///배열 섞기
            //변경 불가능
            /// 랜덤으로 돌리기
            string[] rdalphabet_ = alphabet_.OrderBy(x => rd.Next()).ToArray();
            string[] rdConsonant_ = consonant_.OrderBy(x => rd.Next()).ToArray();
            string[] rdbutton_ = button_.OrderBy(x => rd.Next()).ToArray();
            string[] rdseason_ = season_.OrderBy(x => rd.Next()).ToArray();
            string[] rdgameclass_ = gameclass_.OrderBy(x => rd.Next()).ToArray();
            string[] rdfeels_ = feels_.OrderBy(x => rd.Next()).ToArray();
            string[] rdBGA_ = bga_.OrderBy(x => rd.Next()).ToArray();
            string[] rdlang_ = language_.OrderBy(x => rd.Next()).ToArray();
            //변경 가능한 더미
            string[] rddummy1_ = Dummy1_.OrderBy(x => rd.Next()).ToArray();
            string[] rddummy2_ = Dummy2_.OrderBy(x => rd.Next()).ToArray();
            string[] rddummy3_ = Dummy3_.OrderBy(x => rd.Next()).ToArray();
            

            //배열 변수 문자열
            //만약 개수 조정이 필요할 경우에는 많은 수정이 필요합니다람쥐
            //알파벳 3개 / 2개로 임시 변경
            string textAlpha1 = rdalphabet_[0].ToString() + ", " + rdalphabet_[1].ToString() + ", " + rdalphabet_[2].ToString();
            string textAlpha2 = rdalphabet_[3].ToString() + ", " + rdalphabet_[4].ToString() + ", " + rdalphabet_[5].ToString();
            //string textAlpha3 = rdalphabet_[6].ToString() + ", " + rdalphabet_[7].ToString() + ", " + rdalphabet_[8].ToString();
            //자음 3개 / 2개로 임시 변경
            string textcons1 = rdConsonant_[0].ToString() + ", " + rdConsonant_[1].ToString() + ", " + rdConsonant_[2].ToString();
            string textcons2 = rdConsonant_[3].ToString() + ", " + rdConsonant_[4].ToString() + ", " + rdConsonant_[5].ToString();
            //string textcons3 = rdConsonant_[6].ToString() + ", " + rdConsonant_[7].ToString() + ", " + rdConsonant_[8].ToString();






            //BGA 1개
            string textBGA1 = rdBGA_[0].ToString();
            //보컬 언어 1개
            string textLang1 = rdlang_[0].ToString();
            //X버튼 1개
            string textButton1 = rdbutton_[0].ToString();
            //계절 1개
            string textSeason1 = rdseason_[0].ToString();
            //기종 1개
            string textGameclass1 = rdgameclass_[0].ToString();
            //느낌 1개
            string textFeels1 = rdfeels_[0].ToString();
            //하위 더미 3개
            string textDummy1 = rddummy1_[0].ToString();
            string textDummy2 = rddummy2_[0].ToString();
            string textDummy3 = rddummy3_[0].ToString();

            //15개 + 황금열쇠 2개 + 변경 가능 상위 항목 5개 = 22개

            #endregion

            #region :: 변수 최종 정리 ::
            //카테고리는 최종 22개가 되야 함.
            //알파벳 (3) / 10/12 황금열쇠 숫자 변경으로 인해 임시 변경입니다.
            string Category1 = text1_1 + textAlpha1 + text1_2;
            string Category2 = text1_1 + textAlpha2 + text1_2;
            //string Category3 = text1_1 + textAlpha3 + text1_2;
            //자음 (2) / 10/12 황금열쇠 숫자 변경으로 인해 임시 변경입니다.
            string Category4 = text5_1 + textcons1 + text5_2;
            string Category5 = text5_1 + textcons2 + text5_2;
            //string Category6 = text5_1 + textcons3 + text5_2;
            //황금 열쇠 (4) - 3, 6
            string Category3 = text8;
            string Category6 = text8;
            string Category7 = text8;
            string Category8 = text8;
            string Category14 = text8;
            string Category15 = text8;
            string Category16 = text8;
            string Category17 = text8;
            //X라인 리듬게임 (1)
            string Category9 = textButton1 + text6;
            //노래보컬 언어 (1)
            string Category10 = textLang1 + text3;
            //플랫폼 (1)
            string Category11 = textGameclass1 + text7;
            //계절 곡 (1)
            string Category12 = textSeason1 + text9;
            //BGA or 포토 (1)
            string Category13 = text2_1 + textBGA1 + text2_2;

            //더미, 변경 가능한 것들B
            //상위 항목만 (6) - / 10/12 황금열쇠 숫자 변경으로 인해 임시 변경입니다. -2
            //string Category14 = text10;
            //string Category15 = text11;
            //string Category16 = text12;
            //string Category17 = text13;
            string Category18 = text14;
            string Category19 = text15;
            //상위 + 하위 항목 (3)
            string Category20 = textDummy1 + text16;
            string Category21 = textDummy2 + text17; 
            string Category22 = textDummy3 + text18;

            #region :: 구버전 ::

            ////브가
            //string Category2 = text2_1 + textBGA1 + text2_2;
            ////언어
            //string Category3 = textLang1 + text3;
            ////동시수록곡
            //string Category4 = text4;
            ////자음
            //string Category5 = text5_1 + textcons1 + text5_2;
            ////X라인 리듬게임
            //string Category6 = textButton1 + text6;
            ////플랫폼
            //string Category7 = textGameclass1 + text7;
            ////황금열쇠
            //string Category8 = text8;
            ////느낌
            //string Category9 = textSeason1 + text9;
            ////계절
            //string Category10 = textSeason1 + text10;
            ////EDM
            //string Category11 = text11;
            ////기강잡기
            //string Category12 = text12;
            ////아침알람
            //string Category13 = text13;
            ////뭐하지
            //string Category14 = text14;
            //string Category15 = text15;
            //string Category16 = text16;
            //string Category17 = text17;
            //하위 항목 설정 가능하도록 하는 친구들
            #endregion

            #endregion

            #region :: 항목 배열 최종 제작 ::

            string[] rdcate_ = { };

            //황금열쇠 위치 고정일 시
            if (GoldenFix)
            {
                string[] CategoryArray = { Category1, Category2, Category4, Category5, Category9, Category10, Category11, Category12, Category13, Category18, Category19, Category20, Category21, Category22 };
                rdcate_ = CategoryArray.OrderBy(x => rd.Next()).ToArray();
            }
            #endregion

            #region :: 라벨 채우기 ::


            /* 황금 열쇠가 정해진 위치 + 다른 항목들은 랜덤으로 배치*/
            if (GoldenFix && !Randomize)
            {
                //모든 컨트롤을 검사
                foreach (System.Windows.Forms.Control control in this.Controls)
                {

                    //라벨마다 반복문 + 황금 열쇠아닐 경우 진행
                    if (control is System.Windows.Forms.Label && ((System.Windows.Forms.Label)control).Text != "Golden")
                    {

                        ((System.Windows.Forms.Label)control).Font = font1;

                        //밑에 배너
                        if (((System.Windows.Forms.Label)control).Name.Equals("lblBanner"))
                        {
                            ((System.Windows.Forms.Label)control).BackColor = Color.White; ;
                            ((System.Windows.Forms.Label)control).Text = "* 현재는 판 제작 기능만 제공하고 있습니다.";
                            continue;
                        }

                        //변함없는 값들은 변경 안하도록 (BackColor = Black)
                        else if (((System.Windows.Forms.Label)control).BackColor == Color.Black)
                        {
                            string lblname = ((System.Windows.Forms.Label)control).Name;

                            //라벨
                            if (lblname.Contains("Island"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.무인도v2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.White;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }
                            else if (lblname.Contains("Start"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.Start;
                                ((System.Windows.Forms.Label)control).BackColor = Color.White;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }
                            else if (lblname.Contains("Free"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.뱅하싶2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.Black;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }

                            continue;
                        }

                        //아닌 항목들은 말처럼 쓸수있도록
                        else if (((System.Windows.Forms.Label)control).Text != "")
                        {
                            //색 변경
                            Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

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
            //전체 랜덤
            else if(Randomize)
            {
                string[] CategoryArray = { Category1, Category2, Category3, Category4, Category5, Category6, Category7, Category8, Category9, Category10, Category11, Category12, Category13, Category14, Category15, Category16, Category17, Category18, Category19, Category20, Category21, Category22 };
                rdcate_ = CategoryArray.OrderBy(x => rd.Next()).ToArray();

                //모든 컨트롤을 검사
                foreach (System.Windows.Forms.Control control in this.Controls)
                {
                    //라벨마다 반복문
                    if (control is System.Windows.Forms.Label)
                    {
                        ((System.Windows.Forms.Label)control).Font = font1;


                        //밑에 배너
                        if (((System.Windows.Forms.Label)control).Name.Equals("lblBanner"))
                        {
                            ((System.Windows.Forms.Label)control).BackColor = Color.White; ;
                            ((System.Windows.Forms.Label)control).Text = "* 현재는 판 제작 기능만 제공하고 있습니다.";
                            continue;
                        }
                        //변함없는 값들은 변경 안하도록 (BackColor = Black)
                        else if (((System.Windows.Forms.Label)control).BackColor == Color.Black)
                        {
                            string lblname = ((System.Windows.Forms.Label)control).Name;

                            //라벨
                            if (lblname.Contains("Island"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.무인도v2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.White;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }
                            else if (lblname.Contains("Start"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.Start;
                                ((System.Windows.Forms.Label)control).BackColor = Color.White;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }
                            else if (lblname.Contains("Free"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.뱅하싶2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.Black;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }

                            continue;
                        }

                        //아닌 항목들은 말처럼 쓸수있도록
                        else if (((System.Windows.Forms.Label)control).Text != "")
                        {
                            //색 변경
                            Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

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

                        if (((System.Windows.Forms.Label)control).Text.Equals("황금 열쇠"))
                        {
                            ((System.Windows.Forms.Label)control).BackColor = Color.Yellow;
                            ((System.Windows.Forms.Label)control).Image = Properties.Resources.golden_keys;
                            ((System.Windows.Forms.Label)control).Text = null;
                        }
                    }
                }
            }

















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

        //종료
        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("정말로 종료하시겠습니까?", "확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (Result == DialogResult.OK)
            {
                Environment.Exit(0);
            }
        }

        //판 섞기
        private void btnReset_Click(object sender, EventArgs e)
        {

            DialogResult Result = MessageBox.Show("정말로 판을 섞으시겠습니까?", "확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (Result == DialogResult.OK)
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }

        //옵션
        private void buttonSetup_Click(object sender, EventArgs e)
        {
            Popup popup = new Popup();
            popup.ShowDialog();
        }

        //폰트 정보
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("이 프로그램에는 메이플스토리가 제공한\r메이플스토리 서체가 적용되어 있습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //스크린샷
        private void btnScreenshot_Click(object sender, EventArgs e)
        {

            MessageBox.Show("하루동안 만졌는데 에러떠서 막아놨습니다.\r언젠간 정상화 되겠죠?.", "확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;

            //DialogResult Result = MessageBox.Show("현재 판을 저장 하시겠습니까? \r바탕화면에 저장됩니다.", "저장 확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //if (Result == DialogResult.OK)
            //{
            //    //저장 위치 지정 (바탕화면)
            //    string localpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //    string filename = "\\판때기.png";
            //    string _path = localpath + filename;


            //    //테스트
            //    string Hello = string.Empty;


            //    //변수 지정 필요
            //    Capture ImgCapture = new Capture(0,0,100,100);
            //    ImgCapture.SetPath(_path);
            //    ImgCapture.CaptureImage();

            //    MessageBox.Show("바탕화면에 저장되었습니다.", "확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    return;
            //}
        }

        #endregion

        #region :: ETC Event ::
        //크기 고정 이벤트
        private void MainBoard_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(1920, 1080);
        }
        #endregion
    }
}