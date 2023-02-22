using System.ComponentModel;

namespace Lilui.Platforms.Web;

public class Window : IWindow
{
    public event PropertyChangedEventHandler? PropertyChanged;

    string title = "";
    public string Title {
        get => title;
        set {
            var v = value ?? "";
            if (title == v)
                return;
            title = v;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
        }
    }
}
