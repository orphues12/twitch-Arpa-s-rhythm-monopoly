using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RhythmMonopoly
{
    public partial class Popup : Form
    {
        #region :: 전역변수 ::

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



        //하위 더미데이터 불러오는 곳
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

        bool Randomize = Properties.Settings.Default.Randomize;
        bool GoldenFix = Properties.Settings.Default.GoldenFix;


        //저장 여부
        bool SaveChecked = false;
        bool SaveChecked2 = false;
        bool StartCheck = true;

        //목차
        int TopIndex = -1;
        int botIndex = 0;

        //Combobox 숫자관련
        int TopNum = Properties.Settings.Default.TopNum;
        int BotNum = Properties.Settings.Default.BottomNum;
        

        #endregion

        public Popup()
        {
            InitializeComponent();

            //크기 고정

            //컨트롤박스 제거
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            //크기 관련
            this.MinimumSize = new Size(399,325);
            this.MaximumSize = new Size(399, 325);


            //폰트설정
            Font font1 = new Font(FontManager.fontFamilys[0], 16, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            Font font2 = new Font(FontManager.fontFamilys[0], 40, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            Font font3 = new Font(FontManager.fontFamilys[0], 24, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));

            ChkRandom.Font = font1;
            ChkRandom.Checked = Randomize;

            //모든 컨트롤 점검
            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                //라벨 확인
                if (control is System.Windows.Forms.Label)
                {
                    //라벨 이름으로 원하는 항목의 폰트 설정 변경
                    string lblname = ((System.Windows.Forms.Label)control).Name;
                    //일반 라벨
                    ((System.Windows.Forms.Label)control).Font = font1;
                    //패널 라벨
                    if (lblname.Contains("Panel"))
                    {
                        ((System.Windows.Forms.Label)control).Font = font2;
                    }
                    //타이틀 라벨
                    else if (lblname.Contains("Title"))
                    {
                        ((System.Windows.Forms.Label)control).Font = font3;
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

                    cmbCategoryBottom.Items.Add("하위1 - " + dummycontent1_1);
                    cmbCategoryBottom.Items.Add("하위2 - " + dummycontent1_2);
                    cmbCategoryBottom.Items.Add("하위3 - " + dummycontent1_3);

                    cmbCategoryBottom.SelectedIndex = 0;
                }
                else if (cmbCategoryTop.Text.Contains("하-2"))
                {
                    txtCategoryTop.Text = BotCategory02;
                    txtCategoryTop.Enabled = true;

                    cmbCategoryBottom.Enabled = true;
                    txtCategoryBottom.Enabled = true;

                    cmbCategoryBottom.Items.Clear();

                    cmbCategoryBottom.Items.Add("하위1 - " + dummycontent2_1);
                    cmbCategoryBottom.Items.Add("하위2 - " + dummycontent2_2);
                    cmbCategoryBottom.Items.Add("하위3 - " + dummycontent2_3);
                    cmbCategoryBottom.Items.Add("하위4 - " + dummycontent2_4);

                    cmbCategoryBottom.SelectedIndex = 0;
                }
                else if (cmbCategoryTop.Text.Contains("하-3"))
                {
                    txtCategoryTop.Text = BotCategory03;
                    txtCategoryTop.Enabled = true;

                    cmbCategoryBottom.Enabled = true;
                    txtCategoryBottom.Enabled = true;

                    cmbCategoryBottom.Items.Clear();

                    cmbCategoryBottom.Items.Add("하위1 - " + dummycontent3_1);
                    cmbCategoryBottom.Items.Add("하위2 - " + dummycontent3_2);
                    cmbCategoryBottom.Items.Add("하위3 - " + dummycontent3_3);
                    cmbCategoryBottom.Items.Add("하위4 - " + dummycontent3_4);
                    cmbCategoryBottom.Items.Add("하위5 - " + dummycontent3_5);

                    cmbCategoryBottom.SelectedIndex = 0;
                }
                else if (cmbCategoryTop.Text.Contains("하-4"))
                {
                    txtCategoryTop.Text = BotCategory04;
                    txtCategoryTop.Enabled = true;

                    cmbCategoryBottom.Enabled = true;
                    txtCategoryBottom.Enabled = true;

                    cmbCategoryBottom.Items.Clear();

                    cmbCategoryBottom.Items.Add("하위1 - " + dummycontent4_1);
                    cmbCategoryBottom.Items.Add("하위2 - " + dummycontent4_2);
                    cmbCategoryBottom.Items.Add("하위3 - " + dummycontent4_3);
                    cmbCategoryBottom.Items.Add("하위4 - " + dummycontent4_4);
                    cmbCategoryBottom.Items.Add("하위5 - " + dummycontent4_5);

                    cmbCategoryBottom.SelectedIndex = 0;
                }
                else if (cmbCategoryTop.Text.Contains("하-5"))
                {
                    txtCategoryTop.Text = BotCategory05;
                    txtCategoryTop.Enabled = true;

                    cmbCategoryBottom.Enabled = true;
                    txtCategoryBottom.Enabled = true;

                    cmbCategoryBottom.Items.Clear();

                    cmbCategoryBottom.Items.Add("하위1 - " + dummycontent5_1);
                    cmbCategoryBottom.Items.Add("하위2 - " + dummycontent5_2);
                    cmbCategoryBottom.Items.Add("하위3 - " + dummycontent5_3);
                    cmbCategoryBottom.Items.Add("하위4 - " + dummycontent5_4);
                    cmbCategoryBottom.Items.Add("하위5 - " + dummycontent5_5);

                    cmbCategoryBottom.SelectedIndex = 0;
                }
                else if (cmbCategoryTop.Text.Contains("하-6"))
                {
                    txtCategoryTop.Text = BotCategory06;
                    txtCategoryTop.Enabled = true;

                    cmbCategoryBottom.Enabled = true;
                    txtCategoryBottom.Enabled = true;

                    cmbCategoryBottom.Items.Clear();

                    cmbCategoryBottom.Items.Add("하위1 - " + dummycontent6_1);
                    cmbCategoryBottom.Items.Add("하위2 - " + dummycontent6_2);
                    cmbCategoryBottom.Items.Add("하위3 - " + dummycontent6_3);

                    cmbCategoryBottom.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                if (ex.Source != null)
                    Console.WriteLine("IOException source: {0}", ex.Source);
                throw;
            }
        }

        private void cmbCategorybottom_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //하위 콤보박스 정리
                txtCategoryBottom.Clear();

                //상위+하위 항목 선택시 그것에 대한 설정
                if (cmbCategoryTop.Text.Contains("하-1"))
                {
                    if (cmbCategoryBottom.Text.Contains("하위1"))
                    {
                        txtCategoryBottom.Text = dummycontent1_1;
                    }
                    else if (cmbCategoryBottom.Text.Contains("하위2"))
                    {
                        txtCategoryBottom.Text = dummycontent1_2;
                    }
                    else if (cmbCategoryBottom.Text.Contains("하위3"))
                    {
                        txtCategoryBottom.Text = dummycontent1_3;
                    }
                }
                else if (cmbCategoryTop.Text.Contains("하-2"))
                {
                    if (cmbCategoryBottom.Text.Contains("하위1"))
                    {
                        txtCategoryBottom.Text = dummycontent2_1;
                    }
                    else if (cmbCategoryBottom.Text.Contains("하위2"))
                    {
                        txtCategoryBottom.Text = dummycontent2_2;
                    }
                    else if (cmbCategoryBottom.Text.Contains("하위3"))
                    {
                        txtCategoryBottom.Text = dummycontent2_3;
                    }
                    else if (cmbCategoryBottom.Text.Contains("하위4"))
                    {
                        txtCategoryBottom.Text = dummycontent2_4;
                    }
                }
                else if (cmbCategoryTop.Text.Contains("하-3"))
                {
                    if (cmbCategoryBottom.Text.Contains("하위1"))
                    {
                        txtCategoryBottom.Text = dummycontent3_1;
                    }
                    else if (cmbCategoryBottom.Text.Contains("하위2"))
                    {
                        txtCategoryBottom.Text = dummycontent3_2;
                    }
                    else if (cmbCategoryBottom.Text.Contains("하위3"))
                    {
                        txtCategoryBottom.Text = dummycontent3_3;
                    }
                    else if (cmbCategoryBottom.Text.Contains("하위4"))
                    {
                        txtCategoryBottom.Text = dummycontent3_4;
                    }
                    else if (cmbCategoryBottom.Text.Contains("하위5"))
                    {
                        txtCategoryBottom.Text = dummycontent3_5;
                    }
                }
                else if (cmbCategoryTop.Text.Contains("하-4"))
                {
                    if (cmbCategoryBottom.Text.Contains("하위1"))
                    {
                        txtCategoryBottom.Text = dummycontent4_1;
                    }
                    else if (cmbCategoryBottom.Text.Contains("하위2"))
                    {
                        txtCategoryBottom.Text = dummycontent4_2;
                    }
                    else if (cmbCategoryBottom.Text.Contains("하위3"))
                    {
                        txtCategoryBottom.Text = dummycontent4_3;
                    }
                    else if (cmbCategoryBottom.Text.Contains("하위4"))
                    {
                        txtCategoryBottom.Text = dummycontent4_4;
                    }
                    else if (cmbCategoryBottom.Text.Contains("하위5"))
                    {
                        txtCategoryBottom.Text = dummycontent4_5;
                    }
                }
                else if (cmbCategoryTop.Text.Contains("하-5"))
                {
                    if (cmbCategoryBottom.Text.Contains("하위1"))
                    {
                        txtCategoryBottom.Text = dummycontent5_1;
                    }
                    else if (cmbCategoryBottom.Text.Contains("하위2"))
                    {
                        txtCategoryBottom.Text = dummycontent5_2;
                    }
                    else if (cmbCategoryBottom.Text.Contains("하위3"))
                    {
                        txtCategoryBottom.Text = dummycontent5_3;
                    }
                    else if (cmbCategoryBottom.Text.Contains("하위4"))
                    {
                        txtCategoryBottom.Text = dummycontent5_4;
                    }
                    else if (cmbCategoryBottom.Text.Contains("하위5"))
                    {
                        txtCategoryBottom.Text = dummycontent5_5;
                    }
                }
                else if (cmbCategoryTop.Text.Contains("하-6"))
                {
                    if (cmbCategoryBottom.Text.Contains("하위1"))
                    {
                        txtCategoryBottom.Text = dummycontent6_1;
                    }
                    else if (cmbCategoryBottom.Text.Contains("하위2"))
                    {
                        txtCategoryBottom.Text = dummycontent6_2;
                    }
                    else if (cmbCategoryBottom.Text.Contains("하위3"))
                    {
                        txtCategoryBottom.Text = dummycontent6_3;
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

                /* 저장 방식 */
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

                    #region :: 목차 데이터 찾는 코드 ::
                    //상위
                    if (_TempCateTop.Contains("(상-"))
                    {
                        //값 찾아서 목차용 변수에 값 대입
                        for (int i = 1; i < TopNum+1; i++)
                        {
                            if (_TempCateTop.Contains(String.Format("(상-{0})",i.ToString())))
                            {
                                TopCatadata = String.Format("TopCategory0{0}",i.ToString());
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
                                TopCatadata = String.Format("BotCategory0{0}", i.ToString());

                                //하위 배열 담기
                                string[] BotArray = BotarrayCheck(i);
                                for (int j = 1; j < 6; j++)
                                {
                                    if (_TempCateBot.Contains(String.Format("하위{0}", j.ToString())))
                                    {
                                        string TempBot = BotArray[j - 1];
                                        BotCatadata = TempBot;
                                        break;
                                    }
                                }
                                break;
                            }
                            
                        }
                    }

                    #endregion

                    //데이터 저장
                    Properties.Settings.Default[TopCatadata] = _TempCateChangeTop;

                    if (BotCatadata != string.Empty)
                    {
                        Properties.Settings.Default[BotCatadata] = _TempCateChangeBot;
                    }
                    
                    Properties.Settings.Default.Save();

                    TopIndex = cmbCategoryTop.SelectedIndex;
                    botIndex = cmbCategoryBottom.SelectedIndex;

                    CataSaveText();

                    MessageBox.Show("저장이 완료되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SaveChecked = true;
                    addCombobox();

                }
            }
            catch (Exception ex)
            {
                if (ex.Source != null)
                    Console.WriteLine("IOException source: {0}", ex.Source);
                throw;
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

                if (cmbCategoryBottom.Text.Contains("하위1"))
                {
                    dummycontent1_1 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Contains("하위2"))
                {
                    dummycontent1_2 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Contains("하위3"))
                {
                    dummycontent1_3 = txtCategoryBottom.Text;
                }
            }
            else if (cmbCategoryTop.Text.Contains("하-2"))
            {
                BotCategory02 = txtCategoryTop.Text;

                if (cmbCategoryBottom.Text.Contains("하위1"))
                {
                    dummycontent2_1 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Contains("하위2"))
                {
                    dummycontent2_2 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Contains("하위3"))
                {
                    dummycontent2_3 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Contains("하위4"))
                {
                    dummycontent2_4 = txtCategoryBottom.Text;
                }
            }
            else if (cmbCategoryTop.Text.Contains("하-3"))
            {
                BotCategory03 = txtCategoryTop.Text;

                if (cmbCategoryBottom.Text.Contains("하위1"))
                {
                    dummycontent3_1 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Contains("하위2"))
                {
                    dummycontent3_2 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Contains("하위3"))
                {
                    dummycontent3_3 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Contains("하위4"))
                {
                    dummycontent3_4 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Contains("하위5"))
                {
                    dummycontent3_5 = txtCategoryBottom.Text;
                }
            }
            //임시 5/5/3
            else if (cmbCategoryTop.Text.Contains("하-4"))
            {
                BotCategory04 = txtCategoryTop.Text;

                if (cmbCategoryBottom.Text.Contains("하위1"))
                {
                    dummycontent4_1 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Contains("하위2"))
                {
                    dummycontent4_2 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Contains("하위3"))
                {
                    dummycontent4_3 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Contains("하위4"))
                {
                    dummycontent4_4 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Contains("하위5"))
                {
                    dummycontent4_5 = txtCategoryBottom.Text;
                }
            }
            else if (cmbCategoryTop.Text.Contains("하-5"))
            {
                BotCategory05 = txtCategoryTop.Text;

                if (cmbCategoryBottom.Text.Contains("하위1"))
                {
                    dummycontent5_1 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Contains("하위2"))
                {
                    dummycontent5_2 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Contains("하위3"))
                {
                    dummycontent5_3 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Contains("하위4"))
                {
                    dummycontent5_4 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Contains("하위5"))
                {
                    dummycontent5_5 = txtCategoryBottom.Text;
                }
            }
            else if (cmbCategoryTop.Text.Contains("하-6"))
            {
                BotCategory06 = txtCategoryTop.Text;

                if (cmbCategoryBottom.Text.Contains("하위1"))
                {
                    dummycontent6_1 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Contains("하위2"))
                {
                    dummycontent6_2 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Contains("하위3"))
                {
                    dummycontent6_3 = txtCategoryBottom.Text;
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

            //상위 항목 추가
            for (int i = 1; i < TopNum + 1; i++)
            {
                cmbCategoryTop.Items.Add(String.Format("(상-{0}) - " + TopList[i-1], i.ToString()));
            }
            //하위 항목 추가
            for (int i = 1; i < BotNum + 1; i++)
            {
                cmbCategoryTop.Items.Add(String.Format("(하-{0}) - " + BotList[i - 1], i.ToString()));
            }

            cmbCategoryTop.SelectedIndex = TopIndex;

            #region :: 보지마 :: 
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

                cmbCategoryBottom.Items.Add("하위1 - " + dummycontent1_1);
                cmbCategoryBottom.Items.Add("하위2 - " + dummycontent1_2);
                cmbCategoryBottom.Items.Add("하위3 - " + dummycontent1_3);

                cmbCategoryBottom.SelectedIndex = 0;
            }
            else if (cmbCategoryTop.Text.Contains("하-2"))
            {
                txtCategoryTop.Text = BotCategory02;
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                cmbCategoryBottom.Items.Add("하위1 - " + dummycontent2_1);
                cmbCategoryBottom.Items.Add("하위2 - " + dummycontent2_2);
                cmbCategoryBottom.Items.Add("하위3 - " + dummycontent2_3);
                cmbCategoryBottom.Items.Add("하위4 - " + dummycontent2_4);

                cmbCategoryBottom.SelectedIndex = 0;
            }
            else if (cmbCategoryTop.Text.Contains("하-3"))
            {
                txtCategoryTop.Text = BotCategory03;
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                cmbCategoryBottom.Items.Add("하위1 - " + dummycontent3_1);
                cmbCategoryBottom.Items.Add("하위2 - " + dummycontent3_2);
                cmbCategoryBottom.Items.Add("하위3 - " + dummycontent3_3);
                cmbCategoryBottom.Items.Add("하위4 - " + dummycontent3_4);
                cmbCategoryBottom.Items.Add("하위5 - " + dummycontent3_5);

                cmbCategoryBottom.SelectedIndex = 0;
            }
            else if (cmbCategoryTop.Text.Contains("하-4"))
            {
                txtCategoryTop.Text = BotCategory04;
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                cmbCategoryBottom.Items.Add("하위1 - " + dummycontent4_1);
                cmbCategoryBottom.Items.Add("하위2 - " + dummycontent4_2);
                cmbCategoryBottom.Items.Add("하위3 - " + dummycontent4_3);
                cmbCategoryBottom.Items.Add("하위4 - " + dummycontent4_4);
                cmbCategoryBottom.Items.Add("하위5 - " + dummycontent4_5);

                cmbCategoryBottom.SelectedIndex = 0;
            }
            else if (cmbCategoryTop.Text.Contains("하-5"))
            {
                txtCategoryTop.Text = BotCategory05;
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                cmbCategoryBottom.Items.Add("하위1 - " + dummycontent5_1);
                cmbCategoryBottom.Items.Add("하위2 - " + dummycontent5_2);
                cmbCategoryBottom.Items.Add("하위3 - " + dummycontent5_3);
                cmbCategoryBottom.Items.Add("하위4 - " + dummycontent5_4);
                cmbCategoryBottom.Items.Add("하위5 - " + dummycontent5_5);

                cmbCategoryBottom.SelectedIndex = 0;
            }
            else if (cmbCategoryTop.Text.Contains("하-6"))
            {
                txtCategoryTop.Text = BotCategory06;
                txtCategoryTop.Enabled = true;

                cmbCategoryBottom.Enabled = true;
                txtCategoryBottom.Enabled = true;

                cmbCategoryBottom.Items.Clear();

                cmbCategoryBottom.Items.Add("하위1 - " + dummycontent6_1);
                cmbCategoryBottom.Items.Add("하위2 - " + dummycontent6_2);
                cmbCategoryBottom.Items.Add("하위3 - " + dummycontent6_3);

                cmbCategoryBottom.SelectedIndex = 0;
            }
            #endregion

            if (!StartCheck)
            {
                cmbCategoryBottom.SelectedIndex = botIndex;
            }

            StartCheck = false;

            #region :: 백업 ::
            ////하위 항목만 저장했을때 안바뀌도록
            //if (cmbCategoryTop.Items.Contains(txtCategoryTop.Text) && txtCategoryTop.Text != "")
            //{
            //}
            //cmbCategoryTop.Items.Clear();
            //cmbCategoryBottom.Items.Clear();

            //txtCategoryBottom.Text = "";
            //txtCategoryTop.Text = "";

            //cmbCategoryTop.Items.Add("(상-1) - " + TopCategory01);  //TopCategory01

            //cmbCategoryTop.Items.Add("(하-1) - " + BotCategory01); //BotCategory01
            //cmbCategoryTop.Items.Add("(하-2) - " + BotCategory02); //BotCategory02
            //cmbCategoryTop.Items.Add("(하-3) - " + BotCategory03); //BotCategory03
            //cmbCategoryTop.Items.Add("(하-4) - " + BotCategory04); //dummycontent4_
            //cmbCategoryTop.Items.Add("(하-5) - " + BotCategory05); //feelscontent
            //cmbCategoryTop.Items.Add("(하-6) - " + BotCategory06); //BotCategory03

            //cmbCategoryTop.SelectedIndex = TopIndex;

            //#region :: 보지마 :: 
            //if (cmbCategoryTop.Text.Contains("상-1"))
            //{
            //    txtCategoryTop.Text = TopCategory01;
            //    txtCategoryTop.Enabled = true;
            //    cmbCategoryBottom.Enabled = false;
            //    txtCategoryBottom.Enabled = false;
            //    cmbCategoryBottom.Items.Clear();
            //    txtCategoryBottom.Text = "";
            //}
            //else if (cmbCategoryTop.Text.Contains("상-2"))
            //{
            //    txtCategoryTop.Text = TopCategory02;
            //    txtCategoryTop.Enabled = true;
            //    cmbCategoryBottom.Enabled = false;
            //    txtCategoryBottom.Enabled = false;
            //    cmbCategoryBottom.Items.Clear();
            //    txtCategoryBottom.Text = "";
            //}
            //else if (cmbCategoryTop.Text.Contains("상-3"))
            //{
            //    txtCategoryTop.Text = TopCategory03;
            //    txtCategoryTop.Enabled = true;
            //    cmbCategoryBottom.Enabled = false;
            //    txtCategoryBottom.Enabled = false;
            //    cmbCategoryBottom.Items.Clear();
            //    txtCategoryBottom.Text = "";
            //}
            //else if (cmbCategoryTop.Text.Contains("상-4"))
            //{
            //    txtCategoryTop.Text = TopCategory04;
            //    txtCategoryTop.Enabled = true;
            //    cmbCategoryBottom.Enabled = false;
            //    txtCategoryBottom.Enabled = false;
            //    cmbCategoryBottom.Items.Clear();
            //    txtCategoryBottom.Text = "";
            //}
            //else if (cmbCategoryTop.Text.Contains("상-5"))
            //{
            //    txtCategoryTop.Text = TopCategory05;
            //    txtCategoryTop.Enabled = true;
            //    cmbCategoryBottom.Enabled = false;
            //    txtCategoryBottom.Enabled = false;
            //    cmbCategoryBottom.Items.Clear();
            //    txtCategoryBottom.Text = "";
            //}
            //else if (cmbCategoryTop.Text.Contains("상-6"))
            //{
            //    txtCategoryTop.Text = TopCategory06;
            //    txtCategoryTop.Enabled = true;

            //    cmbCategoryBottom.Enabled = false;
            //    txtCategoryBottom.Enabled = false;
            //    cmbCategoryBottom.Items.Clear();
            //    txtCategoryBottom.Text = "";
            //}
            //else if (cmbCategoryTop.Text.Contains("하-1"))
            //{
            //    txtCategoryTop.Text = BotCategory01;
            //    txtCategoryTop.Enabled = true;
            //    cmbCategoryBottom.Enabled = true;
            //    txtCategoryBottom.Enabled = true;

            //    cmbCategoryBottom.Items.Clear();

            //    cmbCategoryBottom.Items.Add("하위1 - " + dummycontent1_1);
            //    cmbCategoryBottom.Items.Add("하위2 - " + dummycontent1_2);
            //    cmbCategoryBottom.Items.Add("하위3 - " + dummycontent1_3);

            //    cmbCategoryBottom.SelectedIndex = 0;
            //}
            //else if (cmbCategoryTop.Text.Contains("하-2"))
            //{
            //    txtCategoryTop.Text = BotCategory02;
            //    txtCategoryTop.Enabled = true;

            //    cmbCategoryBottom.Enabled = true;
            //    txtCategoryBottom.Enabled = true;

            //    cmbCategoryBottom.Items.Clear();

            //    cmbCategoryBottom.Items.Add("하위1 - " + dummycontent2_1);
            //    cmbCategoryBottom.Items.Add("하위2 - " + dummycontent2_2);
            //    cmbCategoryBottom.Items.Add("하위3 - " + dummycontent2_3);
            //    cmbCategoryBottom.Items.Add("하위4 - " + dummycontent2_4);

            //    cmbCategoryBottom.SelectedIndex = 0;
            //}
            //else if (cmbCategoryTop.Text.Contains("하-3"))
            //{
            //    txtCategoryTop.Text = BotCategory03;
            //    txtCategoryTop.Enabled = true;

            //    cmbCategoryBottom.Enabled = true;
            //    txtCategoryBottom.Enabled = true;

            //    cmbCategoryBottom.Items.Clear();

            //    cmbCategoryBottom.Items.Add("하위1 - " + dummycontent3_1);
            //    cmbCategoryBottom.Items.Add("하위2 - " + dummycontent3_2);
            //    cmbCategoryBottom.Items.Add("하위3 - " + dummycontent3_3);
            //    cmbCategoryBottom.Items.Add("하위4 - " + dummycontent3_4);
            //    cmbCategoryBottom.Items.Add("하위5 - " + dummycontent3_5);

            //    cmbCategoryBottom.SelectedIndex = 0;
            //}
            //else if (cmbCategoryTop.Text.Contains("하-4"))
            //{
            //    txtCategoryTop.Text = BotCategory04;
            //    txtCategoryTop.Enabled = true;

            //    cmbCategoryBottom.Enabled = true;
            //    txtCategoryBottom.Enabled = true;

            //    cmbCategoryBottom.Items.Clear();

            //    cmbCategoryBottom.Items.Add("하위1 - " + dummycontent4_1);
            //    cmbCategoryBottom.Items.Add("하위2 - " + dummycontent4_2);
            //    cmbCategoryBottom.Items.Add("하위3 - " + dummycontent4_3);
            //    cmbCategoryBottom.Items.Add("하위4 - " + dummycontent4_4);
            //    cmbCategoryBottom.Items.Add("하위5 - " + dummycontent4_5);

            //    cmbCategoryBottom.SelectedIndex = 0;
            //}
            //else if (cmbCategoryTop.Text.Contains("하-5"))
            //{
            //    txtCategoryTop.Text = BotCategory05;
            //    txtCategoryTop.Enabled = true;

            //    cmbCategoryBottom.Enabled = true;
            //    txtCategoryBottom.Enabled = true;

            //    cmbCategoryBottom.Items.Clear();

            //    cmbCategoryBottom.Items.Add("하위1 - " + dummycontent5_1);
            //    cmbCategoryBottom.Items.Add("하위2 - " + dummycontent5_2);
            //    cmbCategoryBottom.Items.Add("하위3 - " + dummycontent5_3);
            //    cmbCategoryBottom.Items.Add("하위4 - " + dummycontent5_4);
            //    cmbCategoryBottom.Items.Add("하위5 - " + dummycontent5_5);

            //    cmbCategoryBottom.SelectedIndex = 0;
            //}
            //else if (cmbCategoryTop.Text.Contains("하-6"))
            //{
            //    txtCategoryTop.Text = BotCategory06;
            //    txtCategoryTop.Enabled = true;

            //    cmbCategoryBottom.Enabled = true;
            //    txtCategoryBottom.Enabled = true;

            //    cmbCategoryBottom.Items.Clear();

            //    cmbCategoryBottom.Items.Add("하위1 - " + dummycontent6_1);
            //    cmbCategoryBottom.Items.Add("하위2 - " + dummycontent6_2);
            //    cmbCategoryBottom.Items.Add("하위3 - " + dummycontent6_3);

            //    cmbCategoryBottom.SelectedIndex = 0;
            //}
            //#endregion

            //if (!StartCheck)
            //{
            //    cmbCategoryBottom.SelectedIndex = botIndex;
            //}

            //StartCheck = false;
            #endregion
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

        string[] BotarrayCheck (int a)
        {
            string[] TempBot1 = new string[5];

            switch (a)
            {
                case 1:
                    TempBot1.SetValue("dummycontent1_1", 0);
                    TempBot1.SetValue("dummycontent1_2", 1);
                    TempBot1.SetValue("dummycontent1_3", 2); 
                    break;
                case 2:
                    TempBot1.SetValue("dummycontent2_1", 0);
                    TempBot1.SetValue("dummycontent2_2", 1);
                    TempBot1.SetValue("dummycontent2_3", 2);
                    TempBot1.SetValue("dummycontent2_4", 3);
                    break;
                case 3:
                    TempBot1.SetValue("dummycontent3_1", 0);
                    TempBot1.SetValue("dummycontent3_2", 1);
                    TempBot1.SetValue("dummycontent3_3", 2);
                    TempBot1.SetValue("dummycontent3_4", 3);
                    TempBot1.SetValue("dummycontent3_5", 4);
                    break;
                case 4:
                    TempBot1.SetValue("dummycontent4_1", 0);
                    TempBot1.SetValue("dummycontent4_2", 1);
                    TempBot1.SetValue("dummycontent4_3", 2);
                    TempBot1.SetValue("dummycontent4_4", 3);
                    TempBot1.SetValue("dummycontent4_5", 4);
                    break;
                case 5:
                    TempBot1.SetValue("dummycontent5_1", 0);
                    TempBot1.SetValue("dummycontent5_2", 1);
                    TempBot1.SetValue("dummycontent5_3", 2);
                    TempBot1.SetValue("dummycontent5_4", 3);
                    TempBot1.SetValue("dummycontent5_5", 4);
                    break;
                case 6:
                    TempBot1.SetValue("dummycontent6_1", 0);
                    TempBot1.SetValue("dummycontent6_2", 1);
                    TempBot1.SetValue("dummycontent6_3", 2);
                    break;

            }
            return TempBot1;
        }

        #endregion

        #region :: 미사용 ::
        #region ::: 기존 항목 설정 이벤트 모음 :::

        #region :: Combobox Event ::
        private void cmbCategoryTop2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbCategoryTop2.Text.ToString() == "BGA")
            {
                cmbCategoryBottom2.Enabled = true;
                txtCategoryBottom2.Enabled = true;
                cmbCategoryBottom2.Items.Clear();
                txtCategoryBottom2.Text = "";

                cmbCategoryBottom2.Items.Add("하위 항목 1");
                cmbCategoryBottom2.Items.Add("하위 항목 2");
                cmbCategoryBottom2.Items.Add("하위 항목 3");
                cmbCategoryBottom2.Items.Add("하위 항목 4");
                cmbCategoryBottom2.Items.Add("하위 항목 5");

                cmbCategoryBottom2.SelectedIndex = 0;
            }
            else if (cmbCategoryTop2.Text.ToString() == "느낌")
            {
                cmbCategoryBottom2.Enabled = true;
                txtCategoryBottom2.Enabled = true;
                cmbCategoryBottom2.Items.Clear();
                txtCategoryBottom2.Text = "";

                cmbCategoryBottom2.Items.Add("하위 항목 1");
                cmbCategoryBottom2.Items.Add("하위 항목 2");
                cmbCategoryBottom2.Items.Add("하위 항목 3");
                cmbCategoryBottom2.Items.Add("하위 항목 4");
                cmbCategoryBottom2.Items.Add("하위 항목 5");


                cmbCategoryBottom2.SelectedIndex = 0;
            }
            else if (cmbCategoryTop2.Text.ToString() == "보컬 언어")
            {
                cmbCategoryBottom2.Enabled = true;
                txtCategoryBottom2.Enabled = true;
                cmbCategoryBottom2.Items.Clear();
                txtCategoryBottom2.Text = "";

                cmbCategoryBottom2.Items.Add("하위 항목 1");
                cmbCategoryBottom2.Items.Add("하위 항목 2");
                cmbCategoryBottom2.Items.Add("하위 항목 3");

                cmbCategoryBottom2.SelectedIndex = 0;
            }
        }

        private void cmbCategorybottom2_SelectedValueChanged(object sender, EventArgs e)
        {
            txtCategoryBottom2.Clear();

            if (cmbCategoryTop2.Text.ToString() == "BGA")
            {
                if (cmbCategoryBottom2.Text.ToString() == "하위 항목 1")
                {
                    txtCategoryBottom2.Text = dummycontent4_1;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 2")
                {
                    txtCategoryBottom2.Text = dummycontent4_2;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 3")
                {
                    txtCategoryBottom2.Text = dummycontent4_3;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 4")
                {
                    txtCategoryBottom2.Text = dummycontent4_4;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 5")
                {
                    txtCategoryBottom2.Text = dummycontent4_5;
                }
            }
            else if (cmbCategoryTop2.Text.ToString() == "느낌")
            {

                if (cmbCategoryBottom2.Text.ToString() == "하위 항목 1")
                {
                    txtCategoryBottom2.Text = dummycontent5_1;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 2")
                {
                    txtCategoryBottom2.Text = dummycontent5_2;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 3")
                {
                    txtCategoryBottom2.Text = dummycontent5_3;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 4")
                {
                    txtCategoryBottom2.Text = dummycontent5_4;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 5")
                {
                    txtCategoryBottom2.Text = dummycontent5_5;
                }
            }
            else if (cmbCategoryTop2.Text.ToString() == "보컬 언어")
            {

                if (cmbCategoryBottom2.Text.ToString() == "하위 항목 1")
                {
                    txtCategoryBottom2.Text = dummycontent6_1;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 2")
                {
                    txtCategoryBottom2.Text = dummycontent6_2;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 3")
                {
                    txtCategoryBottom2.Text = dummycontent6_3;
                }
            }
        }
        #endregion

        #region :: button Event ::

        private void Savebutton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategoryTop2.SelectedItem == null)
                {
                    MessageBox.Show("항목을 선택하여 주십시오.", "저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (txtCategoryBottom2.Text == "")
                {
                    MessageBox.Show("하위 항목을 입력하여 주십시오.", "저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                /* 저장 방식 */
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
                    string _TempCateTop = cmbCategoryTop2.Text;
                    //아랫라인
                    string _TempCateBot = cmbCategoryBottom2.Text;
                    string _TempCateChangeBot = txtCategoryBottom2.Text;

                    //목차용 변수 지정 및 초기화
                    string BotCatadata = string.Empty;

                    #region :: 목차 데이터 찾는 코드 ::

                    if (_TempCateTop == "BGA")
                    {

                        if (_TempCateBot == "하위 항목 1")
                        {
                            BotCatadata = "dummycontent4_1";
                        }
                        else if (_TempCateBot == "하위 항목 2")
                        {
                            BotCatadata = "dummycontent4_2";
                        }
                        else if (_TempCateBot == "하위 항목 3")
                        {
                            BotCatadata = "dummycontent4_3";
                        }
                        else if (_TempCateBot == "하위 항목 4")
                        {
                            BotCatadata = "dummycontent4_4";
                        }
                        else if (_TempCateBot == "하위 항목 5")
                        {
                            BotCatadata = "dummycontent4_5";
                        }
                    }
                    else if (_TempCateTop == "느낌")
                    {

                        if (_TempCateBot == "하위 항목 1")
                        {
                            BotCatadata = "dummycontent5_1";
                        }
                        else if (_TempCateBot == "하위 항목 2")
                        {
                            BotCatadata = "dummycontent5_2";
                        }
                        else if (_TempCateBot == "하위 항목 3")
                        {
                            BotCatadata = "dummycontent5_3";
                        }
                        else if (_TempCateBot == "하위 항목 4")
                        {
                            BotCatadata = "dummycontent5_4";
                        }
                        else if (_TempCateBot == "하위 항목 5")
                        {
                            BotCatadata = "dummycontent5_5";
                        }
                    }
                    else if (_TempCateTop == "보컬 언어")
                    {
                        if (_TempCateBot == "하위 항목 1")
                        {
                            BotCatadata = "dummycontent6_1";
                        }
                        else if (_TempCateBot == "하위 항목 2")
                        {
                            BotCatadata = "dummycontent6_2";
                        }
                        else if (_TempCateBot == "하위 항목 3")
                        {
                            BotCatadata = "dummycontent6_3";
                        }
                    }
                    #endregion

                    //데이터 저장
                    if (BotCatadata == string.Empty)
                    {
                        MessageBox.Show("하위 항목은 공백이 될 수 없습니다.", "저장 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Properties.Settings.Default[BotCatadata] = _TempCateChangeBot;
                    CataSaveText2();

                    MessageBox.Show("저장이 완료되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SaveChecked = true;

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

        #region :: ETC Event ::
        //엔터 키 이벤트
        private void Enter_KeyDown2(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Savebutton2_Click(sender, e);
            }
        }


        private void CataSaveText2()
        {
            if (cmbCategoryTop2.Text.Contains("BGA"))
            {
                if (cmbCategoryBottom2.Text.Contains("하위 항목 1"))
                {
                    dummycontent4_1 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Contains("하위 항목 2"))
                {
                    dummycontent4_2 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Contains("하위 항목 3"))
                {
                    dummycontent4_3 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Contains("하위 항목 4"))
                {
                    dummycontent4_4 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Contains("하위 항목 5"))
                {
                    dummycontent4_5 = txtCategoryBottom2.Text;
                }
            }
            else if (cmbCategoryTop2.Text.Contains("느낌"))
            {
                if (cmbCategoryBottom2.Text.Contains("하위 항목 1"))
                {
                    dummycontent5_1 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Contains("하위 항목 2"))
                {
                    dummycontent5_2 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Contains("하위 항목 3"))
                {
                    dummycontent5_3 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Contains("하위 항목 4"))
                {
                    dummycontent5_4 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Contains("하위 항목 5"))
                {
                    dummycontent5_5 = txtCategoryBottom2.Text;
                }
            }

            else if (cmbCategoryTop2.Text.Contains("보컬 언어"))
            {
                if (cmbCategoryBottom2.Text.Contains("하위 항목 1"))
                {
                    dummycontent6_1 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Contains("하위 항목 2"))
                {
                    dummycontent6_2 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Contains("하위 항목 3"))
                {
                    dummycontent6_3 = txtCategoryBottom2.Text;
                }
            }
        }
        #endregion

        #endregion
        #endregion
    }
}
