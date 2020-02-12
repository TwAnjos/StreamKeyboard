using System;
using Native;
using System.Diagnostics;

//Windows functions
public static class Windows
{
    private static IntPtr CurrentHandle = IntPtr.Zero;

    public static IntPtr GetCurrentHandle() 
    {
        if (CurrentHandle == IntPtr.Zero)
            CurrentHandle = Process.GetCurrentProcess().Handle;

        return CurrentHandle;
    }

    public static void Mute()
    {
        WindowsImports.SendMessageW(GetCurrentHandle(), WindowsImports.WM_APPCOMMAND, GetCurrentHandle(),
            (IntPtr)WindowsImports.APPCOMMAND_VOLUME_MUTE);
    }
    public static void VolDown()
    {
        WindowsImports.SendMessageW(GetCurrentHandle(), WindowsImports.WM_APPCOMMAND, GetCurrentHandle(),
            (IntPtr)WindowsImports.APPCOMMAND_VOLUME_DOWN);
    }

    public static void VolUp()
    {
        WindowsImports.SendMessageW(GetCurrentHandle(), WindowsImports.WM_APPCOMMAND, GetCurrentHandle(),
            (IntPtr)WindowsImports.APPCOMMAND_VOLUME_UP);
    }
}