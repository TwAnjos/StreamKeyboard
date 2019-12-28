using System;
using System.Runtime.InteropServices;

namespace Native 
{
    public static class WindowsImports 
    {
        public const byte VK_VOLUME_MUTE = 0xAD;
        public const byte VK_VOLUME_DOWN = 0xAE;
        private const byte VK_VOLUME_UP = 0xAF;
        public const UInt32 KEYEVENTF_EXTENDEDKEY = 0x0001;
        public const UInt32 KEYEVENTF_KEYUP = 0x0002;

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, UInt32 dwFlags, UInt32 dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern Byte MapVirtualKey(UInt32 uCode, UInt32 uMapType);

        [DllImport("user32.dll")]
        public static extern short GetKeyState(int key);
    }
}