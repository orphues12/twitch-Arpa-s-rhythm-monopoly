using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RhythmMonopoly
{
    public class GetLocalPoint
    {
        // 안씀 씨발
        private int _X;
        private int _Y;

        public GetLocalPoint()
        {
            this._X = 0;
            this._Y = 0;
        }

        //public void Set_X(int X)
        //{
        //    this._X = X;
        //}
        //public void Set_Y(int Y)
        //{
        //    this._Y = Y;
        //}
        //public int Get_X()
        //{
        //    return this._X;
        //}
        //public int Get_Y()
        //{
        //    return this._Y;
        //}

        public int X_Event
        {
            get { return this._X; }
            set { this._X = value; }
        }

        public int Y_Event
        {
            get { return this._Y; }
            set { this._Y = value; }
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        internal struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public ShowWindowCommands showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;

        }

        internal enum ShowWindowCommands : int
        {
            Hide = 0,
            Normal = 1,
            Minimized = 2,
            Maximized = 3,
        }

        internal enum WNDSTATE : int
        {
            SW_HIDE = 0,
            SW_SHOWNORMAL = 1,
            SW_NORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_MAXIMIZE = 3,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOW = 5,
            SW_MINIMIZE = 6,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_RESTORE = 9,
            SW_SHOWDEFAULT = 10,
            SW_MAX = 10
        }

        private static WINDOWPLACEMENT GetPlacement(IntPtr hwnd)
        {
            WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
            placement.length = Marshal.SizeOf(placement);
            GetWindowPlacement(hwnd, ref placement);
            return placement;
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);



        // Windows 의 Position 을 가져옴.

        void GetWindowPos(IntPtr hwnd, ref int ptrPhwnd, ref int ptrNhwnd, ref Point ptPoint, ref Size szSize, ref WNDSTATE intShowCmd)
        {
            WINDOWPLACEMENT wInf = new WINDOWPLACEMENT();
            wInf.length = System.Runtime.InteropServices.Marshal.SizeOf(wInf);
            GetWindowPlacement(hwnd, ref wInf);
            szSize = new Size(wInf.rcNormalPosition.Right - (wInf.rcNormalPosition.Left * 2),
                wInf.rcNormalPosition.Bottom - (wInf.rcNormalPosition.Top * 2));
            ptPoint = new Point(wInf.rcNormalPosition.Left, wInf.rcNormalPosition.Top);
        }
        public Point getLocationPoint()
        {
            Process me = Process.GetCurrentProcess(); // 현재 실행중인 Program 의 Process 를 가져온다.                       
            IntPtr hwnd = (IntPtr)me.MainWindowHandle; // me.ID 는 자신의 PID, me.MainWindowHandle 은 Spy++ 에서 확인할 수 있는 핸들 값이다.
            int ptrPhwnd = 0, ptrNhwnd = 0;
            Point ptPoint = new Point();
            Size szSize = new Size();
            WNDSTATE intShowCmd = 0;

            GetWindowPos(hwnd, ref ptrPhwnd, ref ptrNhwnd, ref ptPoint, ref szSize, ref intShowCmd);

            _X = ptPoint.X;
            _Y = ptPoint.Y;

            return ptPoint;
        }

    }
}
