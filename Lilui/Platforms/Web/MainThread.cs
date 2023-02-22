using System.ComponentModel;

namespace Lilui.Platforms.Web;

public class MainThread : IMainThread
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void Run()
    {
    }
}
