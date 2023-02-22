using System.ComponentModel;
using System.Runtime.InteropServices;

using WindowsApi;

namespace Lilui.Platforms.Windows;

public class MainThread : IMainThread
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void Run()
    {
        GetMessage(out var msg, IntPtr.Zero, 0, 0);
        while (msg.message != WM.QUIT) {
            TranslateMessage(ref msg);
            DispatchMessage(ref msg);
            GetMessage(out msg, IntPtr.Zero, 0, 0);
        }
    }

    void PumpMessagesWithIdle()
    {
        PeekMessage(out var msg, IntPtr.Zero, 0, 0, PM.PM_NOREMOVE);
        while (msg.message != WM.QUIT) {
            var bGotMsg = PeekMessage(out msg, IntPtr.Zero, 0, 0, PM.PM_REMOVE);
            if (bGotMsg) {
                TranslateMessage(ref msg);
                DispatchMessage(ref msg);
            }
            else {
                // Do idle work here
            }
        }
    }

    [DllImport("user32.dll")]
    static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool TranslateMessage([In] ref MSG lpMsg);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin,
       uint wMsgFilterMax);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool PeekMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin,
       uint wMsgFilterMax, PM wRemoveMsg);
}
