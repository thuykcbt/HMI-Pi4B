using AvaloniaApplication3.Data;
using AvaloniaApplication3.ViewModels;

namespace AvaloniaApplication3.ViewModels;

public partial class HomePageViewModel:PageViewModel
{
    public string Test { get; set; } = "Home";
    public HomePageViewModel()
    {
        PageName = ApplicationPageNames.Home;
    }
}