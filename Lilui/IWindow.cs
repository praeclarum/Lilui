namespace Lilui;

public interface IWindow : IPlatformObject
{
    string Title { get; set; }

    void Show();
}
