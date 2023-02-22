using System.Runtime.InteropServices;

using HANDLE = System.IntPtr;
using LRESULT = System.Int64;
using WPARAM = System.UInt64;
using LPARAM = System.Int64;

using WindowsApi;
using System.ComponentModel;

namespace Lilui.Platforms.Windows;

public class Window : IWindow
{
    readonly HANDLE hWnd;
    readonly WndProcDelegate wndProc;

    public event PropertyChangedEventHandler? PropertyChanged;

    public Window()
    {
        var hInstance = GetModuleHandle(null);
        wndProc = new WndProcDelegate(WndProc);
        var wndClass = WNDCLASSEX.Build();
        wndClass.hInstance = hInstance;
        wndClass.lpfnWndProc = Marshal.GetFunctionPointerForDelegate(wndProc);
        wndClass.lpszClassName = "TestWindow";
        var regR = RegisterClassEx(ref wndClass);
        if (regR == 0) {
            var err = Marshal.GetLastWin32Error();
            throw new System.Exception($"RegisterClassEx failed with error code {err}");
        }
        hWnd = CreateWindowEx(
            0,
            new IntPtr(regR),
            "Test Window",
            WS.WS_OVERLAPPEDWINDOW,
            0, 0,
            640, 480,
            IntPtr.Zero, IntPtr.Zero,
            hInstance,
            IntPtr.Zero);
        if (hWnd == IntPtr.Zero) {
            var err = Marshal.GetLastWin32Error();
            throw new System.Exception($"CreateWindow failed with error code {err}");
        }
        ShowWindow(hWnd, ShowWindowCommands.Show);
    }

    IntPtr WndProc(HANDLE hWnd, WM msg, IntPtr wParam, IntPtr lParam)
    {
        return DefWindowProc(hWnd, msg, wParam, lParam);
    }

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);

    [DllImport("user32.dll", SetLastError = true)]
    static extern IntPtr CreateWindowEx(
        uint dwExStyle,
           IntPtr lpClassName,
           string lpWindowName,
           WS dwStyle,
           int x,
           int y,
           int nWidth,
           int nHeight,
           IntPtr hWndParent,
           IntPtr hMenu,
           IntPtr hInstance,
           IntPtr lpParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    static extern IntPtr GetModuleHandle([MarshalAs(UnmanagedType.LPWStr)] string? lpModuleName);

    [DllImport("user32.dll")]
    static extern IntPtr DefWindowProc(IntPtr hWnd, WM uMsg, IntPtr wParam, IntPtr lParam);

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.U2)]
    static extern ushort RegisterClassEx([In] ref WNDCLASSEX lpwcx);

    delegate IntPtr WndProcDelegate(HANDLE hWnd, WM msg, IntPtr wParam, IntPtr lParam);
}
