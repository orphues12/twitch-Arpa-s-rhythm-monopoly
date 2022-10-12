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

            #region :: ���� ���� ::

            //��Ʈ�ѹڽ� ����
            this.ControlBox = false;
            //StringBuilder
            StringBuilder sb = new StringBuilder(); 
            //�����Լ�
            Random rd = new Random();
            //��Ʈ����
            Font font1 = new Font(FontManager.fontFamilys[0], 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

            //ũ�� ����
            this.MinimumSize = new Size(1920, 1080);
            this.MaximumSize = new Size(1920, 1080);

            #endregion

            #region :: ���� �ҷ����� ::

            //�Ƕ��� �׸��
            string TopCategory01 = Properties.Settings.Default.TopCategory01; //����  
            string TopCategory02 = Properties.Settings.Default.TopCategory02; //����
            string TopCategory03 = Properties.Settings.Default.TopCategory03; //����
            string TopCategory04 = Properties.Settings.Default.TopCategory04; //����
            string TopCategory05 = Properties.Settings.Default.TopCategory05; //����
            string TopCategory06 = Properties.Settings.Default.TopCategory06; //����
            string BotCategory01 = Properties.Settings.Default.BotCategory01; //���� + ����
            string BotCategory02 = Properties.Settings.Default.BotCategory02; //���� + ����
            string BotCategory03 = Properties.Settings.Default.BotCategory03; //���� + ����

            //���� 5��
            string feelcontent1 = Properties.Settings.Default.feelcontent1;
            string feelcontent2 = Properties.Settings.Default.feelcontent2;
            string feelcontent3 = Properties.Settings.Default.feelcontent3;
            string feelcontent4 = Properties.Settings.Default.feelcontent4;
            string feelcontent5 = Properties.Settings.Default.feelcontent5;

            //BGA ���빰 5��
            string bgacontent1 = Properties.Settings.Default.bgacontent1;
            string bgacontent2 = Properties.Settings.Default.bgacontent2;
            string bgacontent3 = Properties.Settings.Default.bgacontent3;
            string bgacontent4 = Properties.Settings.Default.bgacontent4;
            string bgacontent5 = Properties.Settings.Default.bgacontent5;

            //���
            string languagecontent1 = Properties.Settings.Default.languagecontent1;
            string languagecontent2 = Properties.Settings.Default.languagecontent2;
            string languagecontent3 = Properties.Settings.Default.languagecontent3;

            //���� ���̵����� �ҷ����� �� 3,4,5
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

            //�׸� ���� ����
            int AlphaNum = Properties.Settings.Default.AlphaNum;
            int ConsoNum = Properties.Settings.Default.ConsoNum;
            int TopNum = Properties.Settings.Default.TopNum;
            int BotNum = Properties.Settings.Default.BotNum;

            //��������
            bool Randomize = Properties.Settings.Default.Randomize;
            bool GoldenFix = Properties.Settings.Default.GoldenFix;

            #endregion

            #region :: ���� �ؽ�Ʈ ::
            /* ���� �Ұ��� �� �׸�� 14�� */
            //���ĺ� (3) - 3
            string text1_1 = "���ĺ� ";
            string text1_2 = " �� ���۵Ǵ� ��";

            //�갡 (1) - 4
            string text2_1 = "BGA �ȿ� ";
            string text2_2 = " ��(��) ���Ե� ��";

            //�뷡���� ��� (1) - 5
            string text3 = " ������ ���Ե� ��";

            //���� (3) - 8
            string text5_1 = "������ ";
            string text5_2 = " �� ���۵Ǵ� ��";

            //X���� ������� (1) - 9
            string text6 = " ���� �������";

            //�÷��� (1) - 10
            string text7 = " ���� ����";

            //Ȳ�ݿ��� (2) - 12
            string text8 = "Ȳ�� ����";

            //���� �� (1) - 13
            string text9 = " ���� ��";

            //���� ������ �׸�� - 9��
            //6�� - �����׸�
            string text10 = TopCategory01;
            string text11 = TopCategory02;
            string text12 = TopCategory03;
            string text13 = TopCategory04;
            string text14 = TopCategory05;
            string text15 = TopCategory06;
            //3�� - ���� ���ϰ� �����׸� 3,4,5 1����
            string text16 = BotCategory01; //Dummydata1_1 ~ 1_3
            string text17 = BotCategory02; //Dummydata2_1 ~ 2_4
            string text18 = BotCategory03; //Dummydata3_1 ~ 3_5

            //�׸�ȸ����
            int stack = 0;
            #endregion

            #region :: ���� ������ ���� ���� ::
            //�ٲ� �ʿ� ���� ��
            //���ĺ�
            string[] alphabet_ = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
            //��ư
            string[] button_ = { "4", "5", "6", "8" };
            //����
            string[] season_ = { "��", "����", "����", "�ܿ�" };
            //����
            string[] gameclass_ = { "PC", "�����", "�ܼ�" };
            //����
            string[] consonant_ = { "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��", "��"};
            //��� ������ 3������
            string[] language_ = { languagecontent1, languagecontent2, languagecontent3 };

            ///���� �� �� �־�� �Ǵ� �͵�
            //����
            string[] feels_ = { feelcontent1, feelcontent2, feelcontent3, feelcontent4, feelcontent5 };
            //�갡 ����
            string[] bga_ = { bgacontent1, bgacontent2, bgacontent3, bgacontent4, bgacontent5 };

            //�߰������� �����Ǵ� ���� �����͵� ����� (3,4,5)
            string[] Dummy1_ = { dummycontent1_1, dummycontent1_2, dummycontent1_3};
            string[] Dummy2_ = { dummycontent2_1, dummycontent2_2, dummycontent2_3, dummycontent2_4};
            string[] Dummy3_ = { dummycontent3_1, dummycontent3_2, dummycontent3_3, dummycontent3_4, dummycontent3_5};


            ///�迭 ����
            //���� �Ұ���
            /// �������� ������
            string[] rdalphabet_ = alphabet_.OrderBy(x => rd.Next()).ToArray();
            string[] rdConsonant_ = consonant_.OrderBy(x => rd.Next()).ToArray();
            string[] rdbutton_ = button_.OrderBy(x => rd.Next()).ToArray();
            string[] rdseason_ = season_.OrderBy(x => rd.Next()).ToArray();
            string[] rdgameclass_ = gameclass_.OrderBy(x => rd.Next()).ToArray();
            string[] rdfeels_ = feels_.OrderBy(x => rd.Next()).ToArray();
            string[] rdBGA_ = bga_.OrderBy(x => rd.Next()).ToArray();
            string[] rdlang_ = language_.OrderBy(x => rd.Next()).ToArray();
            //���� ������ ����
            string[] rddummy1_ = Dummy1_.OrderBy(x => rd.Next()).ToArray();
            string[] rddummy2_ = Dummy2_.OrderBy(x => rd.Next()).ToArray();
            string[] rddummy3_ = Dummy3_.OrderBy(x => rd.Next()).ToArray();
            

            //�迭 ���� ���ڿ�
            //���� ���� ������ �ʿ��� ��쿡�� ���� ������ �ʿ��մϴٶ���
            //���ĺ� 3�� / 2���� �ӽ� ����
            string textAlpha1 = rdalphabet_[0].ToString() + ", " + rdalphabet_[1].ToString() + ", " + rdalphabet_[2].ToString();
            string textAlpha2 = rdalphabet_[3].ToString() + ", " + rdalphabet_[4].ToString() + ", " + rdalphabet_[5].ToString();
            //string textAlpha3 = rdalphabet_[6].ToString() + ", " + rdalphabet_[7].ToString() + ", " + rdalphabet_[8].ToString();
            //���� 3�� / 2���� �ӽ� ����
            string textcons1 = rdConsonant_[0].ToString() + ", " + rdConsonant_[1].ToString() + ", " + rdConsonant_[2].ToString();
            string textcons2 = rdConsonant_[3].ToString() + ", " + rdConsonant_[4].ToString() + ", " + rdConsonant_[5].ToString();
            //string textcons3 = rdConsonant_[6].ToString() + ", " + rdConsonant_[7].ToString() + ", " + rdConsonant_[8].ToString();






            //BGA 1��
            string textBGA1 = rdBGA_[0].ToString();
            //���� ��� 1��
            string textLang1 = rdlang_[0].ToString();
            //X��ư 1��
            string textButton1 = rdbutton_[0].ToString();
            //���� 1��
            string textSeason1 = rdseason_[0].ToString();
            //���� 1��
            string textGameclass1 = rdgameclass_[0].ToString();
            //���� 1��
            string textFeels1 = rdfeels_[0].ToString();
            //���� ���� 3��
            string textDummy1 = rddummy1_[0].ToString();
            string textDummy2 = rddummy2_[0].ToString();
            string textDummy3 = rddummy3_[0].ToString();

            //15�� + Ȳ�ݿ��� 2�� + ���� ���� ���� �׸� 5�� = 22��

            #endregion

            #region :: ���� ���� ���� ::
            //ī�װ����� ���� 22���� �Ǿ� ��.
            //���ĺ� (3) / 10/12 Ȳ�ݿ��� ���� �������� ���� �ӽ� �����Դϴ�.
            string Category1 = text1_1 + textAlpha1 + text1_2;
            string Category2 = text1_1 + textAlpha2 + text1_2;
            //string Category3 = text1_1 + textAlpha3 + text1_2;
            //���� (2) / 10/12 Ȳ�ݿ��� ���� �������� ���� �ӽ� �����Դϴ�.
            string Category4 = text5_1 + textcons1 + text5_2;
            string Category5 = text5_1 + textcons2 + text5_2;
            //string Category6 = text5_1 + textcons3 + text5_2;
            //Ȳ�� ���� (4) - 3, 6
            string Category3 = text8;
            string Category6 = text8;
            string Category7 = text8;
            string Category8 = text8;
            string Category14 = text8;
            string Category15 = text8;
            string Category16 = text8;
            string Category17 = text8;
            //X���� ������� (1)
            string Category9 = textButton1 + text6;
            //�뷡���� ��� (1)
            string Category10 = textLang1 + text3;
            //�÷��� (1)
            string Category11 = textGameclass1 + text7;
            //���� �� (1)
            string Category12 = textSeason1 + text9;
            //BGA or ���� (1)
            string Category13 = text2_1 + textBGA1 + text2_2;

            //����, ���� ������ �͵�B
            //���� �׸� (6) - / 10/12 Ȳ�ݿ��� ���� �������� ���� �ӽ� �����Դϴ�. -2
            //string Category14 = text10;
            //string Category15 = text11;
            //string Category16 = text12;
            //string Category17 = text13;
            string Category18 = text14;
            string Category19 = text15;
            //���� + ���� �׸� (3)
            string Category20 = textDummy1 + text16;
            string Category21 = textDummy2 + text17; 
            string Category22 = textDummy3 + text18;

            #region :: ������ ::

            ////�갡
            //string Category2 = text2_1 + textBGA1 + text2_2;
            ////���
            //string Category3 = textLang1 + text3;
            ////���ü��ϰ�
            //string Category4 = text4;
            ////����
            //string Category5 = text5_1 + textcons1 + text5_2;
            ////X���� �������
            //string Category6 = textButton1 + text6;
            ////�÷���
            //string Category7 = textGameclass1 + text7;
            ////Ȳ�ݿ���
            //string Category8 = text8;
            ////����
            //string Category9 = textSeason1 + text9;
            ////����
            //string Category10 = textSeason1 + text10;
            ////EDM
            //string Category11 = text11;
            ////�Ⱝ���
            //string Category12 = text12;
            ////��ħ�˶�
            //string Category13 = text13;
            ////������
            //string Category14 = text14;
            //string Category15 = text15;
            //string Category16 = text16;
            //string Category17 = text17;
            //���� �׸� ���� �����ϵ��� �ϴ� ģ����
            #endregion

            #endregion

            #region :: �׸� �迭 ���� ���� ::

            string[] rdcate_ = { };

            //Ȳ�ݿ��� ��ġ ������ ��
            if (GoldenFix)
            {
                string[] CategoryArray = { Category1, Category2, Category4, Category5, Category9, Category10, Category11, Category12, Category13, Category18, Category19, Category20, Category21, Category22 };
                rdcate_ = CategoryArray.OrderBy(x => rd.Next()).ToArray();
            }
            #endregion

            #region :: �� ä��� ::


            /* Ȳ�� ���谡 ������ ��ġ + �ٸ� �׸���� �������� ��ġ*/
            if (GoldenFix && !Randomize)
            {
                //��� ��Ʈ���� �˻�
                foreach (System.Windows.Forms.Control control in this.Controls)
                {

                    //�󺧸��� �ݺ��� + Ȳ�� ����ƴ� ��� ����
                    if (control is System.Windows.Forms.Label && ((System.Windows.Forms.Label)control).Text != "Golden")
                    {

                        ((System.Windows.Forms.Label)control).Font = font1;

                        //�ؿ� ���
                        if (((System.Windows.Forms.Label)control).Name.Equals("lblBanner"))
                        {
                            ((System.Windows.Forms.Label)control).BackColor = Color.White; ;
                            ((System.Windows.Forms.Label)control).Text = "* ����� �� ���� ��ɸ� �����ϰ� �ֽ��ϴ�.";
                            continue;
                        }

                        //���Ծ��� ������ ���� ���ϵ��� (BackColor = Black)
                        else if (((System.Windows.Forms.Label)control).BackColor == Color.Black)
                        {
                            string lblname = ((System.Windows.Forms.Label)control).Name;

                            //��
                            if (lblname.Contains("Island"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.���ε�v2;
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
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.���Ͻ�2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.Black;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }

                            continue;
                        }

                        //�ƴ� �׸���� ��ó�� �����ֵ���
                        else if (((System.Windows.Forms.Label)control).Text != "")
                        {
                            //�� ����
                            Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

                            ((System.Windows.Forms.Label)control).BackColor = randomColor;
                            ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
                            ((System.Windows.Forms.Label)control).ForeColor = Color.Black;

                            //�� �׸񸶴� �ؽ�Ʈ ����
                            for (int i = stack; i < rdcate_.Length;)
                            {
                                ((System.Windows.Forms.Label)control).Text = rdcate_[i].ToString();
                                stack++;
                                break;
                            }
                        }

                    }
                    //Ȳ�ݿ��� �� ���
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
            //��ü ����
            else if(Randomize)
            {
                string[] CategoryArray = { Category1, Category2, Category3, Category4, Category5, Category6, Category7, Category8, Category9, Category10, Category11, Category12, Category13, Category14, Category15, Category16, Category17, Category18, Category19, Category20, Category21, Category22 };
                rdcate_ = CategoryArray.OrderBy(x => rd.Next()).ToArray();

                //��� ��Ʈ���� �˻�
                foreach (System.Windows.Forms.Control control in this.Controls)
                {
                    //�󺧸��� �ݺ���
                    if (control is System.Windows.Forms.Label)
                    {
                        ((System.Windows.Forms.Label)control).Font = font1;


                        //�ؿ� ���
                        if (((System.Windows.Forms.Label)control).Name.Equals("lblBanner"))
                        {
                            ((System.Windows.Forms.Label)control).BackColor = Color.White; ;
                            ((System.Windows.Forms.Label)control).Text = "* ����� �� ���� ��ɸ� �����ϰ� �ֽ��ϴ�.";
                            continue;
                        }
                        //���Ծ��� ������ ���� ���ϵ��� (BackColor = Black)
                        else if (((System.Windows.Forms.Label)control).BackColor == Color.Black)
                        {
                            string lblname = ((System.Windows.Forms.Label)control).Name;

                            //��
                            if (lblname.Contains("Island"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.���ε�v2;
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
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.���Ͻ�2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.Black;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }

                            continue;
                        }

                        //�ƴ� �׸���� ��ó�� �����ֵ���
                        else if (((System.Windows.Forms.Label)control).Text != "")
                        {
                            //�� ����
                            Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

                            ((System.Windows.Forms.Label)control).BackColor = randomColor;
                            ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
                            ((System.Windows.Forms.Label)control).ForeColor = Color.Black;

                            //�� �׸񸶴� �ؽ�Ʈ ����
                            for (int i = stack; i < rdcate_.Length;)
                            {
                                ((System.Windows.Forms.Label)control).Text = rdcate_[i].ToString();
                                stack++;
                                break;
                            }
                        }

                        if (((System.Windows.Forms.Label)control).Text.Equals("Ȳ�� ����"))
                        {
                            ((System.Windows.Forms.Label)control).BackColor = Color.Yellow;
                            ((System.Windows.Forms.Label)control).Image = Properties.Resources.golden_keys;
                            ((System.Windows.Forms.Label)control).Text = null;
                        }
                    }
                }
            }

















            ////����Ȱ��ȭ
            //if (Randomize)
            //{
            //    //��� ��Ʈ���� �˻�
            //    foreach (System.Windows.Forms.Control control in this.Controls)
            //    {
            //        //�󺧸��� �ݺ���
            //        if (control is System.Windows.Forms.Label)
            //        {
            //            ((System.Windows.Forms.Label)control).Font = font1;

            //            //////////////////////////////////////////////////// ��������ϼ���
            //            rdcate_ = CategoryArray.OrderBy(x => rd.Next()).ToArray();

            //            //�ؿ� ���
            //            if (((System.Windows.Forms.Label)control).Name.Equals("lblBanner"))
            //            {
            //                ((System.Windows.Forms.Label)control).BackColor = Color.White; ;
            //                ((System.Windows.Forms.Label)control).Text = "* ����� �� ���� ��ɸ� �����ϰ� �ֽ��ϴ�.";
            //                continue;
            //            }
            //            //���Ծ��� ������ ���� ���ϵ��� (BackColor = Black)
            //            else if (((System.Windows.Forms.Label)control).BackColor == Color.Black)
            //            {
            //                string lblname = ((System.Windows.Forms.Label)control).Name;

            //                //��
            //                if (lblname.Contains("Island"))
            //                {
            //                    ((System.Windows.Forms.Label)control).Image = Properties.Resources.���ε�v2;
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
            //                    ((System.Windows.Forms.Label)control).Image = Properties.Resources.���Ͻ�2;
            //                    ((System.Windows.Forms.Label)control).BackColor = Color.Black;
            //                    ((System.Windows.Forms.Label)control).Text = null;
            //                }

            //                continue;
            //            }

            //            //�ƴ� �׸���� ��ó�� �����ֵ���
            //            //    else if (((System.Windows.Forms.Label)control).Text != "")
            //            //    {
            //            //        //�� ����
            //            //        Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //            //        ((System.Windows.Forms.Label)control).BackColor = randomColor;
            //            //        ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
            //            //        ((System.Windows.Forms.Label)control).ForeColor = Color.Black;

            //            //        //�� �׸񸶴� �ؽ�Ʈ ����
            //            //        for (int i = stack; i < rdcate_.Length;)
            //            //        {
            //            //            ((System.Windows.Forms.Label)control).Text = rdcate_[i].ToString();
            //            //            stack++;
            //            //            break;
            //            //        }
            //            //    }

            //            //    if (((System.Windows.Forms.Label)control).Text.Equals("Ȳ�� ����"))
            //            //    {
            //            //        ((System.Windows.Forms.Label)control).BackColor = Color.Yellow;
            //            //        ((System.Windows.Forms.Label)control).Image = Properties.Resources.golden_keys;
            //            //        ((System.Windows.Forms.Label)control).Text = null;
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
            //        if (control is System.Windows.Forms.Label)
            //        {
            //            ((System.Windows.Forms.Label)control).Font = font1;

            //            //�ؿ� ���
            //            if (((System.Windows.Forms.Label)control).Name.Equals("lblBanner"))
            //            {
            //                ((System.Windows.Forms.Label)control).BackColor = Color.White; ;
            //                ((System.Windows.Forms.Label)control).Text = "* ����� �� ���� ��ɸ� �����ϰ� �ֽ��ϴ�.";
            //                continue;
            //            }
            //            //���Ծ��� ������ ���� ���ϵ��� (BackColor = Black)
            //            else if (((System.Windows.Forms.Label)control).BackColor == Color.Black)
            //            {
            //                string lblname = ((System.Windows.Forms.Label)control).Name;

            //                //��
            //                if (lblname.Contains("Island"))
            //                {
            //                    ((System.Windows.Forms.Label)control).Image = Properties.Resources.���ε�v2;
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
            //                    ((System.Windows.Forms.Label)control).Image = Properties.Resources.���Ͻ�2;
            //                    ((System.Windows.Forms.Label)control).BackColor = Color.Black;
            //                    ((System.Windows.Forms.Label)control).Text = null;
            //                }

            //                continue;
            //            }

            //            //4�׷����� ������
            //            //�׷� A
            //            else if (((System.Windows.Forms.Label)control).Text.Contains("A"))
            //            {
            //                //�� ����
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((System.Windows.Forms.Label)control).BackColor = randomColor;
            //                ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((System.Windows.Forms.Label)control).ForeColor = Color.Black;

            //                //�� �׸񸶴� �ؽ�Ʈ ����
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((System.Windows.Forms.Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }
            //            if (((System.Windows.Forms.Label)control).Text.Equals("Ȳ�� ����"))
            //            {
            //                ((System.Windows.Forms.Label)control).BackColor = Color.Yellow;
            //                ((System.Windows.Forms.Label)control).Image = Properties.Resources.golden_keys;
            //                ((System.Windows.Forms.Label)control).Text = null;
            //            }

            //            //�׷� B
            //            else if (((System.Windows.Forms.Label)control).Text.Contains("B"))
            //            {
            //                //�� ����
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((System.Windows.Forms.Label)control).BackColor = randomColor;
            //                ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((System.Windows.Forms.Label)control).ForeColor = Color.Black;

            //                //�� �׸񸶴� �ؽ�Ʈ ����
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((System.Windows.Forms.Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }
            //            if (((System.Windows.Forms.Label)control).Text.Equals("Ȳ�� ����"))
            //            {
            //                ((System.Windows.Forms.Label)control).BackColor = Color.Yellow;
            //                ((System.Windows.Forms.Label)control).Image = Properties.Resources.golden_keys;
            //                ((System.Windows.Forms.Label)control).Text = null;
            //            }

            //            //�׷� C
            //            else if (((System.Windows.Forms.Label)control).Text.Contains("C"))
            //            {
            //                //�� ����
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((System.Windows.Forms.Label)control).BackColor = randomColor;
            //                ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((System.Windows.Forms.Label)control).ForeColor = Color.Black;

            //                //�� �׸񸶴� �ؽ�Ʈ ����
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((System.Windows.Forms.Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }
            //            if (((System.Windows.Forms.Label)control).Text.Equals("Ȳ�� ����"))
            //            {
            //                ((System.Windows.Forms.Label)control).BackColor = Color.Yellow;
            //                ((System.Windows.Forms.Label)control).Image = Properties.Resources.golden_keys;
            //                ((System.Windows.Forms.Label)control).Text = null;
            //            }

            //            //�׷� D
            //            else if (((System.Windows.Forms.Label)control).Text.Contains("D"))
            //            {
            //                //�� ����
            //                Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //                ((System.Windows.Forms.Label)control).BackColor = randomColor;
            //                ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
            //                ((System.Windows.Forms.Label)control).ForeColor = Color.Black;

            //                //�� �׸񸶴� �ؽ�Ʈ ����
            //                for (int i = stack; i < rdcate_.Length;)
            //                {
            //                    ((System.Windows.Forms.Label)control).Text = rdcate_[i].ToString();
            //                    stack++;
            //                    break;
            //                }
            //            }

            //            if (((System.Windows.Forms.Label)control).Text.Equals("Ȳ�� ����"))
            //            {
            //                ((System.Windows.Forms.Label)control).BackColor = Color.Yellow;
            //                ((System.Windows.Forms.Label)control).Image = Properties.Resources.golden_keys;
            //                ((System.Windows.Forms.Label)control).Text = null;
            //            }
            //        }

            //        //�ƴ� �׸���� ��ó�� �����ֵ���
            //        //    else if (((System.Windows.Forms.Label)control).Text != "")
            //        //    {
            //        //        //�� ����
            //        //        Color randomColor = Color.FromArgb(rd.Next(100, 256), rd.Next(100, 256), rd.Next(64, 256));

            //        //        ((System.Windows.Forms.Label)control).BackColor = randomColor;
            //        //        ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
            //        //        ((System.Windows.Forms.Label)control).ForeColor = Color.Black;

            //        //        //�� �׸񸶴� �ؽ�Ʈ ����
            //        //        for (int i = stack; i < rdcate_.Length;)
            //        //        {
            //        //            ((System.Windows.Forms.Label)control).Text = rdcate_[i].ToString();
            //        //            stack++;
            //        //            break;
            //        //        }
            //        //    }

            //        //    if (((System.Windows.Forms.Label)control).Text.Equals("Ȳ�� ����"))
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

        //����
        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("������ �����Ͻðڽ��ϱ�?", "Ȯ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (Result == DialogResult.OK)
            {
                Environment.Exit(0);
            }
        }

        //�� ����
        private void btnReset_Click(object sender, EventArgs e)
        {

            DialogResult Result = MessageBox.Show("������ ���� �����ðڽ��ϱ�?", "Ȯ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (Result == DialogResult.OK)
            {
                Application.Restart();
                Environment.Exit(0);
            }
        }

        //�ɼ�
        private void buttonSetup_Click(object sender, EventArgs e)
        {
            Popup popup = new Popup();
            popup.ShowDialog();
        }

        //��Ʈ ����
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("�� ���α׷����� �����ý��丮�� ������\r�����ý��丮 ��ü�� ����Ǿ� �ֽ��ϴ�.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //��ũ����
        private void btnScreenshot_Click(object sender, EventArgs e)
        {

            MessageBox.Show("�Ϸ絿�� �����µ� �������� ���Ƴ����ϴ�.\r������ ����ȭ �ǰ���?.", "Ȯ��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;

            //DialogResult Result = MessageBox.Show("���� ���� ���� �Ͻðڽ��ϱ�? \r����ȭ�鿡 ����˴ϴ�.", "���� Ȯ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //if (Result == DialogResult.OK)
            //{
            //    //���� ��ġ ���� (����ȭ��)
            //    string localpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //    string filename = "\\�Ƕ���.png";
            //    string _path = localpath + filename;


            //    //�׽�Ʈ
            //    string Hello = string.Empty;


            //    //���� ���� �ʿ�
            //    Capture ImgCapture = new Capture(0,0,100,100);
            //    ImgCapture.SetPath(_path);
            //    ImgCapture.CaptureImage();

            //    MessageBox.Show("����ȭ�鿡 ����Ǿ����ϴ�.", "Ȯ��", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    return;
            //}
        }

        #endregion

        #region :: ETC Event ::
        //ũ�� ���� �̺�Ʈ
        private void MainBoard_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(1920, 1080);
        }
        #endregion
    }
}