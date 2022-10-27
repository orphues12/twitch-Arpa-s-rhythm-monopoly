using System.Security.Cryptography.X509Certificates;

namespace RhythmMonopoly
{
    public partial class ColorControl : Form
    {
        public string ChangedColor
        {
            get { return this.ChangedColor; }
            set { this.ChangedColor = value; }
        }

        public ColorControl()
        {
            InitializeComponent();
            
            #region :: 변수 불러오기 ::
            //뒷배경 코드
            string BackCurrentColor = Properties.Settings.Default.BackCurrentColor;
            #endregion

            //크기 관련
            this.MinimumSize = new Size(300, 200);
            this.MaximumSize = new Size(300, 200);

            //TextBox 초기값 넣기
            string[] CurrentColorData = BackCurrentColor.Split(',');

            SpinR.Value = int.Parse(CurrentColorData[0]);
            SpinG.Value = int.Parse(CurrentColorData[1]);
            SpinB.Value = int.Parse(CurrentColorData[2]);

            //컨트롤을 검사
            foreach (System.Windows.Forms.Control control in this.Controls)
            {
                //라벨 확인
                if (control is System.Windows.Forms.Label)
                {
                    string lblname = ((System.Windows.Forms.Label)control).Name;
                    if (lblname.Contains("Current") || lblname.Contains("Change"))
                    {
                        ((System.Windows.Forms.Label)control).BackColor = System.Drawing.ColorTranslator.FromHtml(BackCurrentColor);
                    }
                }
            }
        }
        #region :: Button Event ::

        private void button1_Click(object sender, EventArgs e)
        {
            string _R = SpinR.Value.ToString();
            string _G = SpinG.Value.ToString();
            string _B = SpinB.Value.ToString();

            DialogResult Result = MessageBox.Show("정말로 색을 저장하시겠습니까?", "저장 확인", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (Result == DialogResult.OK)
            {
                string ChangedColor = _R + "," + _G + "," + _B;
                //저장
                Properties.Settings.Default.BackCurrentColor = ChangedColor;
                Properties.Settings.Default.Save();

                MessageBox.Show("저장이 완료되었습니다.", "저장 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                lblCurrentColor.BackColor = System.Drawing.ColorTranslator.FromHtml(ChangedColor);
            }
        }
        #endregion

        #region :: ETC Event ::

        //변경 색 바뀌는 이벤트
        private void _Leave(object sender, EventArgs e)
        {
            string _R = SpinR.Value.ToString();
            string _G = SpinG.Value.ToString();
            string _B = SpinB.Value.ToString();

            string ChangedColor = _R + "," + _G + "," + _B;

            lblChangeColor.BackColor = System.Drawing.ColorTranslator.FromHtml(ChangedColor);

            if (SpinR.Text == "")
            {
                SpinR.Value = 0;
            }
            else if (SpinG.Text == "")
            {
                SpinG.Value = 0;
            }
            else if (SpinB.Text == "")
            {
                SpinB.Value = 0;
            }
        }
        //폼 클릭으로 색 바뀌는 이벤트
        private void ColorControl_Click(object sender, EventArgs e)
        {
            _Leave(sender, e);
        }
        #endregion

        private void _ValueChanged(object sender, EventArgs e)
        {
            string _R = SpinR.Value.ToString();
            string _G = SpinG.Value.ToString();
            string _B = SpinB.Value.ToString();

            string ChangedColor = _R + "," + _G + "," + _B;

            lblChangeColor.BackColor = System.Drawing.ColorTranslator.FromHtml(ChangedColor);

        }

    }
}
