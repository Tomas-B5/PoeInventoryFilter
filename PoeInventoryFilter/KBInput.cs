using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PoeInventoryFilter
{
    static class KBInput
    {
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        public const int CTRL_ALL = 0x11;
        public const int SHIFT_ALL = 0x10;
        public const int C_KEY = 0x43;

        public static void SendCtrlC()
        {
            keybd_event(CTRL_ALL, 0, 1 | 0, 0);
            keybd_event(C_KEY, 0x9e, 1 | 0, 0);
            keybd_event(C_KEY, 0x9e, 1 | 2, 0);
            keybd_event(CTRL_ALL, 0, 1 | 2, 0);
        }
        public static bool IsCtrlDown()
        {
            if ((GetAsyncKeyState(CTRL_ALL) & 0x8000) > 0)
                return true;

            return false;
        }

        public static bool IsShiftDown()
        {
            if ((GetAsyncKeyState(SHIFT_ALL) & 0x8000) > 0)
                return true;

            return false;
        }
    }
}
