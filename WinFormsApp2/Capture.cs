using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RhythmMonopoly
{
    public class Capture
    {
        private int _refX = 0;
        private int _refY = 0;
        private int _imgW = 0;
        private int _imgH = 0;

        private string Filepath = string.Empty;


        public Capture(int refX = 0, int refY = 0, int imgW = 0, int imgH = 0)
        {
            _refX = refX;
            _refY = refY;
            _imgW = imgW;
            _imgH = imgH;
            
        }

        public void SetPath(string path)
        {
            Filepath = path;
        }

        public void CaptureImage()
        {
            if (Filepath!= string.Empty)
            {
                if (_imgW == 0 || _imgH == 0) return;

                using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap((int)_imgW, (int)_imgH))
                {
                    using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(_refX, _refY, 0, 0, bitmap.Size);

                    }

                    bitmap.Save(Filepath, ImageFormat.Png);
                }
            }
        }
    }
}
