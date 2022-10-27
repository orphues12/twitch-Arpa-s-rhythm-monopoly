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

        //�� ��ġ ����
        bool Labellocation = false;

        public MainBoard()
        {
            InitializeComponent();

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

            //�ΰ� ��ǥ
            labelLogo.Left = (this.ClientSize.Width - labelLogo.Width) / 2;
            labelLogo.Top = (this.ClientSize.Height - labelLogo.Height) / 2;

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
            string BotCategory04 = Properties.Settings.Default.BotCategory04; //���� + ����
            string BotCategory05 = Properties.Settings.Default.BotCategory05; //���� + ����
            string BotCategory06 = Properties.Settings.Default.BotCategory06; //���� + ����


            //���� ���̵�����
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


            //�׸� ���� ����
            int AlphaNum = Properties.Settings.Default.AlphaNum;
            int ConsoNum = Properties.Settings.Default.ConsoNum;
            int TopNum = Properties.Settings.Default.TopNum;
            int BotNum = Properties.Settings.Default.BottomNum;
            int GoldenNum = Properties.Settings.Default.GoldenNum;

            //��������
            bool Randomize = Properties.Settings.Default.Randomize;
            bool GoldenFix = Properties.Settings.Default.GoldenFix;

            //�޹��
            string BackCurrentColor = Properties.Settings.Default.BackCurrentColor;

            #endregion

            #region :: ���� �ؽ�Ʈ ::
            //���ĺ�
            string Alpha1_1 = "���ĺ� ";
            string Alpha1_2 = " �� ���۵Ǵ� ��";

            //���� (2) - 8
            string Conso1_1 = "������ ";
            string Conso1_2 = " �� ���۵Ǵ� ��";

            //�׸�ȸ����
            int stack = 0;
            #endregion

            #region :: ���� ���� ���� ���� ::
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

            //�߰������� �����Ǵ� ���� �����͵� ����� (3,4,5)
            string[] Dummy1_ = { dummycontent1_1, dummycontent1_2, dummycontent1_3};
            string[] Dummy2_ = { dummycontent2_1, dummycontent2_2, dummycontent2_3, dummycontent2_4};
            string[] Dummy3_ = { dummycontent3_1, dummycontent3_2, dummycontent3_3, dummycontent3_4, dummycontent3_5};
            string[] Dummy4_ = { dummycontent4_1, dummycontent4_2, dummycontent4_3, dummycontent4_4, dummycontent4_5};
            string[] Dummy5_ = { dummycontent5_1, dummycontent5_2, dummycontent5_3, dummycontent5_4, dummycontent5_5};
            string[] Dummy6_ = { dummycontent6_1, dummycontent6_2, dummycontent6_3 };

            ///�迭 ����
            //���� �Ұ���
            /// �������� ������
            string[] rdalphabet_ = alphabet_.OrderBy(x => rd.Next()).ToArray();
            string[] rdConsonant_ = consonant_.OrderBy(x => rd.Next()).ToArray();
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
            string textConso1 = rdConsonant_[0].ToString() + ", " + rdConsonant_[1].ToString() + ", " + rdConsonant_[2].ToString();
            string textConso2 = rdConsonant_[3].ToString() + ", " + rdConsonant_[4].ToString() + ", " + rdConsonant_[5].ToString();
            string textConso3 = rdConsonant_[6].ToString() + ", " + rdConsonant_[7].ToString() + ", " + rdConsonant_[8].ToString();
            string textConso4 = rdConsonant_[9].ToString() + ", " + rdConsonant_[10].ToString() + ", " + rdConsonant_[11].ToString();

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
            string CateAlpha1 = Alpha1_1 + textAlpha1 + Alpha1_2;
            string CateAlpha2 = Alpha1_1 + textAlpha2 + Alpha1_2;
            string CateAlpha3 = Alpha1_1 + textAlpha3 + Alpha1_2;
            string CateAlpha4 = Alpha1_1 + textAlpha4 + Alpha1_2;
            string CateAlpha5 = Alpha1_1 + textAlpha5 + Alpha1_2;
            string CateAlpha6 = Alpha1_1 + textAlpha6 + Alpha1_2;
            string CateAlpha7 = Alpha1_1 + textAlpha7 + Alpha1_2;
            string CateAlpha8 = Alpha1_1 + textAlpha8 + Alpha1_2;

            string[] CateAlpha = { CateAlpha1, CateAlpha2, CateAlpha3, CateAlpha4, CateAlpha5, CateAlpha6, CateAlpha7, CateAlpha8 }; 

            //���� ����
            string CateConso1 = Conso1_1 + textConso1 + Conso1_2;
            string CateConso2 = Conso1_1 + textConso2 + Conso1_2;
            string CateConso3 = Conso1_1 + textConso3 + Conso1_2;
            string CateConso4 = Conso1_1 + textConso4 + Conso1_2;

            string[] CateConso = { CateConso1, CateConso2, CateConso3, CateConso4 };

            //������
            string CateTop1 = TopCategory01;
            string CateTop2 = TopCategory02;
            string CateTop3 = TopCategory03;
            string CateTop4 = TopCategory04;
            string CateTop5 = TopCategory05;
            string CateTop6 = TopCategory06;

            string[] CateTop = { CateTop1, CateTop2, CateTop3, CateTop4, CateTop5, CateTop6 };

            //������
            string CateBot1 = textDummy1 + BotCategory01;
            string CateBot2 = textDummy2 + BotCategory02;
            string CateBot3 = textDummy3 + BotCategory03;
            string CateBot4 = textDummy4 + BotCategory04;
            string CateBot5 = textDummy5 + BotCategory05;
            string CateBot6 = textDummy6 + BotCategory06;

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

            string[] CateGolden = { CateGolden1, CateGolden2, CateGolden3, CateGolden4, CateGolden5, CateGolden6, CateGolden7, CateGolden8 };

            //���� �׸�
            string CateButton = textButton1 + " ���� �������";
            string CateGameClass = textGameclass1 + " �÷��� �������";
            string CateSeason = textSeason1 + " ���� ��";
            #endregion

            #region :: ���� �迭 ���� ::

            //�׸���� ���� Dictionary ����
            Dictionary<string, string> CateDictionary = new Dictionary<string, string>();

            //���� �׸���� Dictionary�� �߰�
            CateDictionary.Add("CateButton", CateButton);
            CateDictionary.Add("CateGameClass", CateGameClass);
            CateDictionary.Add("CateSeason", CateSeason);

            //���ĺ� �׸���� Dictionary�� �߰�
            for (int i = 1; i < AlphaNum + 1; i++)
            {
                CateDictionary.Add(String.Format("CateAlpha{0}", i.ToString()), CateAlpha[i-1]);
            }

            //���� �׸���� Dictionary�� �߰�
            for (int i = 1; i < ConsoNum + 1; i++)
            {
                CateDictionary.Add(String.Format("CateConso{0}", i.ToString()), CateConso[i - 1]);
            }

            //���� �׸���� Dictionary�� �߰�
            for (int i = 1; i < TopNum + 1; i++)
            {
                CateDictionary.Add(String.Format("CateTop{0}", i.ToString()), CateTop[i - 1]);
            }

            //���� + ���� �׸���� Dictionary�� �߰�
            for (int i = 1; i < BotNum + 1; i++)
            {
                CateDictionary.Add(String.Format("CateBot{0}", i.ToString()), CateBot[i - 1]);
            }

            //Dictionary���� Value �� ���� �� �� ����Ʈ ���� 
            var CateList = new List<string>(CateDictionary.Values);
            #endregion

            #region :: �׸� ���� ::

            //���� ����Ʈ���� ������ �迭�� ���� Array ����
            string[] rdcate_ = { };
            //Ȳ�ݿ��� ��ġ ������ ��
            if (GoldenFix)
            {
                rdcate_ = CateList.OrderBy(x => rd.Next()).ToArray();
            }


            /* Ȳ�� ���谡 ������ ��ġ + �ٸ� �׸���� �������� ��ġ */
            if (!Randomize)
            {
                //��� ��Ʈ���� �˻�
                foreach (System.Windows.Forms.Control control in this.Controls)
                {
                    //�� �˻� + Ȳ�� ���谡 �ƴ� ���
                    if (control is System.Windows.Forms.Label && ((System.Windows.Forms.Label)control).Text != "Golden")
                    {
                        //��Ʈ ���� (�Ÿ����� ���丮)
                        ((System.Windows.Forms.Label)control).Font = font1;
                        //�� �̸� �˻�
                        string lblname = ((System.Windows.Forms.Label)control).Name;
                        if (lblname.Contains("BackScreen"))
                        {
                            ((System.Windows.Forms.Label)control).BackColor = System.Drawing.ColorTranslator.FromHtml(BackCurrentColor);
                            continue;
                        }
                        //���Ծ��� ������ ���� ���ϵ��� (BackColor = Black)
                        else if (((System.Windows.Forms.Label)control).BackColor == Color.Black)
                        {

                            //���¼�
                            if (lblname.Contains("EZ2ON"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.���ε�_EZ2v2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.White;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }
                            //��Ƽ�
                            else if (lblname.Contains("DJMAX"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.���ε�_DJMAXv2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.White;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }
                            //�������
                            else if (lblname.Contains("Start"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.STARTv2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.White;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }
                            //����
                            else if (lblname.Contains("Free"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.FREEv2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.Black;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }
                            continue;
                        }
                        //�׸� �κ�
                        else if (((System.Windows.Forms.Label)control).Text != "")
                        {
                            //�� ����
                            Color randomColor = Color.FromArgb(rd.Next(64, 256), rd.Next(0, 20), rd.Next(64, 256));

                            ((System.Windows.Forms.Label)control).BackColor = randomColor;
                            ((System.Windows.Forms.Label)control).BorderStyle = BorderStyle.FixedSingle;
                            ((System.Windows.Forms.Label)control).ForeColor = Color.Black;

                            //�������� �׸� �߰�
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
            //��ü ���� üũ ��
            else if (Randomize)
            {
                //Ȳ�ݿ��� ���� ��ŭ �߰�
                for (int i = 0; i < GoldenNum; i++)
                {
                    CateList.Add("Ȳ�� ����");
                }

                //Ȳ�ݿ��� �߰� �� ���Ӱ� ������
                rdcate_ = CateList.OrderBy(x => rd.Next()).ToArray();

                //��� ��Ʈ���� �˻�
                foreach (System.Windows.Forms.Control control in this.Controls)
                {
                    //�� �˻� + Ȳ�� ���谡 �ƴ� ���
                    if (control is System.Windows.Forms.Label)
                    {
                        //��Ʈ ����
                        ((System.Windows.Forms.Label)control).Font = font1;
                        //�� �̸� �˻�
                        string lblname = ((System.Windows.Forms.Label)control).Name;
                        if (lblname.Contains("BackScreen"))
                        {
                            ((System.Windows.Forms.Label)control).BackColor = System.Drawing.ColorTranslator.FromHtml(BackCurrentColor);
                            continue;
                        }
                        //���Ծ��� ������ ���� ���ϵ��� (BackColor = Black)
                        else if (((System.Windows.Forms.Label)control).BackColor == Color.Black)
                        {

                            //���¼�
                            if (lblname.Contains("EZ2ON"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.���ε�_EZ2v2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.White;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }
                            //��Ƽ�
                            else if (lblname.Contains("DJMAX"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.���ε�_DJMAXv2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.White;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }
                            //�������
                            else if (lblname.Contains("Start"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.STARTv2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.White;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }
                            //����
                            else if (lblname.Contains("Free"))
                            {
                                ((System.Windows.Forms.Label)control).Image = Properties.Resources.FREEv2;
                                ((System.Windows.Forms.Label)control).BackColor = Color.Black;
                                ((System.Windows.Forms.Label)control).Text = null;
                            }

                            continue;
                        }
                        //�׸� �κ�
                        else if (((System.Windows.Forms.Label)control).Text != "")
                        {
                            //�� ����
                            Color randomColor = Color.FromArgb(rd.Next(64, 256), rd.Next(0, 20), rd.Next(64, 256));

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
                        //Ȳ�� ���� �� ���
                        if (((System.Windows.Forms.Label)control).Text.Equals("Ȳ�� ����"))
                        {
                            ((System.Windows.Forms.Label)control).BackColor = Color.Yellow;
                            ((System.Windows.Forms.Label)control).Image = Properties.Resources.golden_keys;
                            ((System.Windows.Forms.Label)control).Text = null;
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
            //        if (control is System.Windows.Forms.Label && ((System.Windows.Forms.Label)control).Text != "Golden")
            //        {

            //            ((System.Windows.Forms.Label)control).Font = font1;

            //            //���Ծ��� ������ ���� ���ϵ��� (BackColor = Black)
            //            if (((System.Windows.Forms.Label)control).BackColor == Color.Black)
            //            {
            //                string lblname = ((System.Windows.Forms.Label)control).Name;

            //                //��
            //                if (lblname.Contains("EZ2ON"))
            //                {
            //                    ((System.Windows.Forms.Label)control).Image = Properties.Resources.���ε�_EZ2v2;
            //                    ((System.Windows.Forms.Label)control).BackColor = Color.White;
            //                    ((System.Windows.Forms.Label)control).Text = null;
            //                }
            //                else if (lblname.Contains("DJMAX"))
            //                {
            //                    ((System.Windows.Forms.Label)control).Image = Properties.Resources.���ε�_DJMAXv2;
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

            //            //�ƴ� �׸���� ��ó�� �����ֵ���
            //            else if (((System.Windows.Forms.Label)control).Text != "")
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

            //        }
            //        //Ȳ�ݿ��� �� ���
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
            ////��ü ����
            //else if(Randomize)
            //{
            //    string[] CategoryArray = { Category1, Category2, Category3, Category4, Category5, Category6, Category7, Category8, Category9,  Category11, Category12, Category14, Category15, Category16, Category17, Category18, Category20, Category21, Category22, Category23, Category24, Category25 };
            //    rdcate_ = CategoryArray.OrderBy(x => rd.Next()).ToArray();

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

            //            //�ƴ� �׸���� ��ó�� �����ֵ���
            //            else if (((System.Windows.Forms.Label)control).Text != "")
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
            //    }
            //}
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

            DialogResult Result = MessageBox.Show("���� ���� ���� �Ͻðڽ��ϱ�? \r����ȭ�鿡 ����˴ϴ�.", "���� Ȯ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (Result == DialogResult.OK)
            {
                MessageBox.Show("Ȯ���� �����ø� 3�� �� ��ũ�� ĸ�İ� �˴ϴ�.", "���� Ȯ��", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //���� ��ġ ���� (����ȭ��)
                string localpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
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

                MessageBox.Show("����ȭ�鿡 ����Ǿ����ϴ�.", "Ȯ��", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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