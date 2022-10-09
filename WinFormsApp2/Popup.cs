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
using System.Windows.Forms;

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


        bool SaveChecked = false;



        #endregion

        public Popup()
        {
            InitializeComponent();

            #region :: 항목 추가 설정 ::
            cmbCategoryTop.Items.Add("상위 항목 1");  //TopCategory01
            cmbCategoryTop.Items.Add("상위 항목 2");  //TopCategory02
            cmbCategoryTop.Items.Add("상위 항목 3");  //TopCategory03
            cmbCategoryTop.Items.Add("상위 항목 4");  //TopCategory04
            cmbCategoryTop.Items.Add("상위 항목 5");  //TopCategory05
            cmbCategoryTop.Items.Add("상위 항목 6");  //TopCategory06

            cmbCategoryTop.Items.Add("상위 항목 7 - 하위 항목 3개"); //BotCategory01
            cmbCategoryTop.Items.Add("상위 항목 8 - 하위 항목 4개"); //BotCategory02
            cmbCategoryTop.Items.Add("상위 항목 9 - 하위 항목 5개"); //BotCategory03


            txtCategoryTop.Enabled = false;
            cmbCategoryBottom.Enabled = false;
            txtCategoryBottom.Enabled = false;
            #endregion

            #region :: 기존 항목 설정::
            cmbCategoryTop2.Items.Add("BGA");  
            cmbCategoryTop2.Items.Add("느낌"); 
            cmbCategoryTop2.Items.Add("보컬 언어");

            cmbCategoryBottom2.Enabled = false;
            txtCategoryBottom2.Enabled = false;
            #endregion

        }

        #region ::: 항목 추가 설정 이벤트 모음 :::

        #region :: Combobox Event ::
        private void cmbCategoryTop_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCategoryTop.Text.ToString() == "상위 항목 1")
                {
                    txtCategoryTop.Text = TopCategory01;
                    txtCategoryTop.Enabled = true;
                    cmbCategoryBottom.Enabled = false;
                    txtCategoryBottom.Enabled = false;
                    cmbCategoryBottom.Items.Clear();
                    txtCategoryBottom.Text = "";
                }
                else if (cmbCategoryTop.Text.ToString() == "상위 항목 2")
                {
                    txtCategoryTop.Text = TopCategory02;
                    txtCategoryTop.Enabled = true;
                    cmbCategoryBottom.Enabled = false;
                    txtCategoryBottom.Enabled = false;
                    cmbCategoryBottom.Items.Clear();
                    txtCategoryBottom.Text = "";
                }
                else if (cmbCategoryTop.Text.ToString() == "상위 항목 3")
                {
                    txtCategoryTop.Text = TopCategory03;
                    txtCategoryTop.Enabled = true;
                    cmbCategoryBottom.Enabled = false;
                    txtCategoryBottom.Enabled = false;
                    cmbCategoryBottom.Items.Clear();
                    txtCategoryBottom.Text = "";
                }
                else if (cmbCategoryTop.Text.ToString() == "상위 항목 4")
                {
                    txtCategoryTop.Text = TopCategory04;
                    txtCategoryTop.Enabled = true;
                    cmbCategoryBottom.Enabled = false;
                    txtCategoryBottom.Enabled = false;
                    cmbCategoryBottom.Items.Clear();
                    txtCategoryBottom.Text = "";
                }
                else if (cmbCategoryTop.Text.ToString() == "상위 항목 5")
                {
                    txtCategoryTop.Text = TopCategory05;
                    txtCategoryTop.Enabled = true;
                    cmbCategoryBottom.Enabled = false;
                    txtCategoryBottom.Enabled = false;
                    cmbCategoryBottom.Items.Clear();
                    txtCategoryBottom.Text = "";
                }
                else if (cmbCategoryTop.Text.ToString() == "상위 항목 6")
                {
                    txtCategoryTop.Text = TopCategory06;
                    txtCategoryTop.Enabled = true;

                    cmbCategoryBottom.Enabled = false;
                    txtCategoryBottom.Enabled = false;
                    cmbCategoryBottom.Items.Clear();
                    txtCategoryBottom.Text = "";
                }
                else if (cmbCategoryTop.Text.ToString() == "상위 항목 7 - 하위 항목 3개")
                {
                    txtCategoryTop.Text = BotCategory01;
                    txtCategoryTop.Enabled = true;
                    cmbCategoryBottom.Enabled = true;
                    txtCategoryBottom.Enabled = true;

                    cmbCategoryBottom.Items.Clear();

                    cmbCategoryBottom.Items.Add("하위 항목 1");
                    cmbCategoryBottom.Items.Add("하위 항목 2");
                    cmbCategoryBottom.Items.Add("하위 항목 3");

                    cmbCategoryBottom.SelectedIndex = 0;
                }
                else if (cmbCategoryTop.Text.ToString() == "상위 항목 8 - 하위 항목 4개")
                {
                    txtCategoryTop.Text = BotCategory02;
                    txtCategoryTop.Enabled = true;

                    cmbCategoryBottom.Enabled = true;
                    txtCategoryBottom.Enabled = true;

                    cmbCategoryBottom.Items.Clear();

                    cmbCategoryBottom.Items.Add("하위 항목 1");
                    cmbCategoryBottom.Items.Add("하위 항목 2");
                    cmbCategoryBottom.Items.Add("하위 항목 3");
                    cmbCategoryBottom.Items.Add("하위 항목 4");

                    cmbCategoryBottom.SelectedIndex = 0;
                }
                else if (cmbCategoryTop.Text.ToString() == "상위 항목 9 - 하위 항목 5개")
                {
                    txtCategoryTop.Text = BotCategory03;
                    txtCategoryTop.Enabled = true;

                    cmbCategoryBottom.Enabled = true;
                    txtCategoryBottom.Enabled = true;

                    cmbCategoryBottom.Items.Clear();

                    cmbCategoryBottom.Items.Add("하위 항목 1");
                    cmbCategoryBottom.Items.Add("하위 항목 2");
                    cmbCategoryBottom.Items.Add("하위 항목 3");
                    cmbCategoryBottom.Items.Add("하위 항목 4");
                    cmbCategoryBottom.Items.Add("하위 항목 5");

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
                txtCategoryBottom.Clear();

                if (cmbCategoryTop.Text.ToString() == "상위 항목 7 - 하위 항목 3개")
                {
                    if (cmbCategoryBottom.Text.ToString() == "하위 항목 1")
                    {
                        txtCategoryBottom.Text = dummycontent1_1;
                    }
                    else if (cmbCategoryBottom.Text.ToString() == "하위 항목 2")
                    {
                        txtCategoryBottom.Text = dummycontent1_2;
                    }
                    else if (cmbCategoryBottom.Text.ToString() == "하위 항목 3")
                    {
                        txtCategoryBottom.Text = dummycontent1_3;
                    }
                }
                else if (cmbCategoryTop.Text.ToString() == "상위 항목 8 - 하위 항목 4개")
                {

                    if (cmbCategoryBottom.Text.ToString() == "하위 항목 1")
                    {
                        txtCategoryBottom.Text = dummycontent2_1;
                    }
                    else if (cmbCategoryBottom.Text.ToString() == "하위 항목 2")
                    {
                        txtCategoryBottom.Text = dummycontent2_2;
                    }
                    else if (cmbCategoryBottom.Text.ToString() == "하위 항목 3")
                    {
                        txtCategoryBottom.Text = dummycontent2_3;
                    }
                    else if (cmbCategoryBottom.Text.ToString() == "하위 항목 4")
                    {
                        txtCategoryBottom.Text = dummycontent2_4;
                    }
                }
                else if (cmbCategoryTop.Text.ToString() == "상위 항목 9 - 하위 항목 5개")
                {

                    if (cmbCategoryBottom.Text.ToString() == "하위 항목 1")
                    {
                        txtCategoryBottom.Text = dummycontent3_1;
                    }
                    else if (cmbCategoryBottom.Text.ToString() == "하위 항목 2")
                    {
                        txtCategoryBottom.Text = dummycontent3_2;
                    }
                    else if (cmbCategoryBottom.Text.ToString() == "하위 항목 3")
                    {
                        txtCategoryBottom.Text = dummycontent3_3;
                    }
                    else if (cmbCategoryBottom.Text.ToString() == "하위 항목 4")
                    {
                        txtCategoryBottom.Text = dummycontent3_4;
                    }
                    else if (cmbCategoryBottom.Text.ToString() == "하위 항목 5")
                    {
                        txtCategoryBottom.Text = dummycontent3_5;
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

                    if (_TempCateTop == "상위 항목 1")
                    {
                        TopCatadata = "TopCategory01";
                    }
                    else if (_TempCateTop == "상위 항목 2")
                    {
                        TopCatadata = "TopCategory02";
                    }
                    else if (_TempCateTop == "상위 항목 3")
                    {
                        TopCatadata = "TopCategory03";
                    }
                    else if (_TempCateTop == "상위 항목 4")
                    {
                        TopCatadata = "TopCategory04";
                    }
                    else if (_TempCateTop == "상위 항목 5")
                    {
                        TopCatadata = "TopCategory05";
                    }
                    else if (_TempCateTop == "상위 항목 6")
                    {
                        TopCatadata = "TopCategory06";
                    }
                    else if (_TempCateTop == "상위 항목 7 - 하위 항목 3개")
                    {
                        TopCatadata = "BotCategory01";

                        if (_TempCateBot == "하위 항목 1")
                        {
                            BotCatadata = "dummycontent1_1";
                        }
                        else if (_TempCateBot == "하위 항목 2")
                        {
                            BotCatadata = "dummycontent1_2";
                        }
                        else if (_TempCateBot == "하위 항목 3")
                        {
                            BotCatadata = "dummycontent1_3";
                        }
                    }
                    else if (_TempCateTop == "상위 항목 8 - 하위 항목 4개")
                    {
                        TopCatadata = "BotCategory02";

                        if (_TempCateBot == "하위 항목 1")
                        {
                            BotCatadata = "dummycontent1_1";
                        }
                        else if (_TempCateBot == "하위 항목 2")
                        {
                            BotCatadata = "dummycontent2_2";
                        }
                        else if (_TempCateBot == "하위 항목 3")
                        {
                            BotCatadata = "dummycontent2_3";
                        }
                        else if (_TempCateBot == "하위 항목 4")
                        {
                            BotCatadata = "dummycontent2_4";
                        }
                    }
                    else if (_TempCateTop == "상위 항목 9 - 하위 항목 5개")
                    {
                        TopCatadata = "BotCategory03";

                        if (_TempCateBot == "하위 항목 1")
                        {
                            BotCatadata = "dummycontent3_1";
                        }
                        else if (_TempCateBot == "하위 항목 2")
                        {
                            BotCatadata = "dummycontent3_2";
                        }
                        else if (_TempCateBot == "하위 항목 3")
                        {
                            BotCatadata = "dummycontent3_3";
                        }
                        else if (_TempCateBot == "하위 항목 4")
                        {
                            BotCatadata = "dummycontent3_4";
                        }
                        else if (_TempCateBot == "하위 항목 5")
                        {
                            BotCatadata = "dummycontent3_5";
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
                    CataSaveText();

                    //Properties.Settings.Default.SettingsSaving += Default_SettingsSaving;

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
        private void Enter_KeyDown1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Savebutton1_Click(sender, e);
            }
        }

        private void CataSaveText()
        {
            if (cmbCategoryTop.Text.Equals("상위 항목 1"))
            {
                TopCategory01 = txtCategoryTop.Text;
            }
            else if (cmbCategoryTop.Text.Equals("상위 항목 2"))
            {
                TopCategory02 = txtCategoryTop.Text;
            }
            else if (cmbCategoryTop.Text.Equals("상위 항목 3"))
            {
                TopCategory03 = txtCategoryTop.Text;
            }
            else if (cmbCategoryTop.Text.Equals("상위 항목 4"))
            {
                TopCategory04 = txtCategoryTop.Text;
            }
            else if (cmbCategoryTop.Text.Equals("상위 항목 5"))
            {
                TopCategory05 = txtCategoryTop.Text;
            }
            else if (cmbCategoryTop.Text.Equals("상위 항목 6"))
            {
                TopCategory06 = txtCategoryTop.Text;
            }
            else if (cmbCategoryTop.Text.Equals("상위 항목 7 - 하위 항목 3"))
            {
                 BotCategory01 = txtCategoryTop.Text;

                if (cmbCategoryBottom.Text.Equals("하위 항목 1"))
                {
                    dummycontent1_1 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Equals("하위 항목 2"))
                {
                    dummycontent1_2 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Equals("하위 항목 3"))
                {
                    dummycontent1_3 = txtCategoryBottom.Text;
                }
            }
            else if (cmbCategoryTop.Text.Equals("상위 항목 8 - 하위 항목 4"))
            {
                BotCategory02 = txtCategoryTop.Text;

                if (cmbCategoryBottom.Text.Equals("하위 항목 1"))
                {
                    dummycontent2_1 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Equals("하위 항목 2"))
                {
                    dummycontent2_2 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Equals("하위 항목 3"))
                {
                    dummycontent2_3 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Equals("하위 항목 4"))
                {
                    dummycontent2_4 = txtCategoryBottom.Text;
                }
            }
            else if (cmbCategoryTop.Text.Equals("상위 항목 9 - 하위 항목 5"))
            {
                BotCategory01 = txtCategoryTop.Text;

                if (cmbCategoryBottom.Text.Equals("하위 항목 1"))
                {
                    dummycontent3_1 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Equals("하위 항목 2"))
                {
                    dummycontent3_2 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Equals("하위 항목 3"))
                {
                    dummycontent3_3 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Equals("하위 항목 4"))
                {
                    dummycontent3_4 = txtCategoryBottom.Text;
                }
                else if (cmbCategoryBottom.Text.Equals("하위 항목 4"))
                {
                    dummycontent3_5 = txtCategoryBottom.Text;
                }
            }
        }
        #endregion

        #endregion

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
                    txtCategoryBottom2.Text = bgacontent1;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 2")
                {
                    txtCategoryBottom2.Text = bgacontent2;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 3")
                {
                    txtCategoryBottom2.Text = bgacontent3;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 4")
                {
                    txtCategoryBottom2.Text = bgacontent4;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 5")
                {
                    txtCategoryBottom2.Text = bgacontent5;
                }
            }
            else if (cmbCategoryTop2.Text.ToString() == "느낌")
            {

                if (cmbCategoryBottom2.Text.ToString() == "하위 항목 1")
                {
                    txtCategoryBottom2.Text = feelcontent1;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 2")
                {
                    txtCategoryBottom2.Text = feelcontent2;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 3")
                {
                    txtCategoryBottom2.Text = feelcontent3;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 4")
                {
                    txtCategoryBottom2.Text = feelcontent4;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 5")
                {
                    txtCategoryBottom2.Text = feelcontent5;
                }
            }
            else if (cmbCategoryTop2.Text.ToString() == "보컬 언어")
            {

                if (cmbCategoryBottom2.Text.ToString() == "하위 항목 1")
                {
                    txtCategoryBottom2.Text = languagecontent1;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 2")
                {
                    txtCategoryBottom2.Text = languagecontent2;
                }
                else if (cmbCategoryBottom2.Text.ToString() == "하위 항목 3")
                {
                    txtCategoryBottom2.Text = languagecontent3;
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
                            BotCatadata = "bgacontent1";
                        }
                        else if (_TempCateBot == "하위 항목 2")
                        {
                            BotCatadata = "bgacontent2";
                        }
                        else if (_TempCateBot == "하위 항목 3")
                        {
                            BotCatadata = "bgacontent3";
                        }
                        else if (_TempCateBot == "하위 항목 4")
                        {
                            BotCatadata = "bgacontent4";
                        }
                        else if (_TempCateBot == "하위 항목 5")
                        {
                            BotCatadata = "bgacontent5";
                        }
                    }
                    else if (_TempCateTop == "느낌")
                    {

                        if (_TempCateBot == "하위 항목 1")
                        {
                            BotCatadata = "feelcontent1";
                        }
                        else if (_TempCateBot == "하위 항목 2")
                        {
                            BotCatadata = "feelcontent2";
                        }
                        else if (_TempCateBot == "하위 항목 3")
                        {
                            BotCatadata = "feelcontent3";
                        }
                        else if (_TempCateBot == "하위 항목 4")
                        {
                            BotCatadata = "feelcontent4";
                        }
                        else if (_TempCateBot == "하위 항목 5")
                        {
                            BotCatadata = "feelcontent5";
                        }
                    }
                    else if (_TempCateTop == "보컬 언어")
                    {
                        if (_TempCateBot == "하위 항목 1")
                        {
                            BotCatadata = "languagecontent1";
                        }
                        else if (_TempCateBot == "하위 항목 2")
                        {
                            BotCatadata = "languagecontent2";
                        }
                        else if (_TempCateBot == "하위 항목 3")
                        {
                            BotCatadata = "languagecontent3";
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

                    Properties.Settings.Default.Save();
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
            if (cmbCategoryTop2.Text.Equals("BGA"))
            {
                if (cmbCategoryBottom2.Text.Equals("하위 항목 1"))
                {
                    bgacontent1 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Equals("하위 항목 2"))
                {
                    bgacontent2 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Equals("하위 항목 3"))
                {
                    bgacontent3 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Equals("하위 항목 4"))
                {
                    bgacontent4 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Equals("하위 항목 5"))
                {
                    bgacontent5 = txtCategoryBottom2.Text;
                }
            }
            else if (cmbCategoryTop2.Text.Equals("느낌"))
            {
                if (cmbCategoryBottom2.Text.Equals("하위 항목 1"))
                {
                    feelcontent1 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Equals("하위 항목 2"))
                {
                    feelcontent2 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Equals("하위 항목 3"))
                {
                    feelcontent3 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Equals("하위 항목 4"))
                {
                    feelcontent4 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Equals("하위 항목 5"))
                {
                    feelcontent5 = txtCategoryBottom2.Text;
                }
            }
            else if (cmbCategoryTop2.Text.Equals("보컬 언어"))
            {
                if (cmbCategoryBottom2.Text.Equals("하위 항목 1"))
                {
                    languagecontent1 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Equals("하위 항목 2"))
                {
                    languagecontent2 = txtCategoryBottom2.Text;
                }
                else if (cmbCategoryBottom2.Text.Equals("하위 항목 3"))
                {
                    languagecontent3 = txtCategoryBottom2.Text;
                }
            }
        }
        #endregion

        #endregion

        #region :: 창 닫기 이벤트 ::
        private void Popup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SaveChecked)
            {
                DialogResult dialogResult = MessageBox.Show("수정된 항목이 있습니다. 프로그램을 재시작 하시겠습니까?", "종료 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogResult == DialogResult.Yes)
                {
                    SaveChecked = false;
                    Application.Restart();
                    Environment.Exit(0);
                }
            }
        }
        #endregion
    }
}
