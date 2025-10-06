using AvaloniaApplication3.Data;
using AvaloniaApplication3.ViewModels;

namespace AvaloniaApplication3.ViewModels;

public partial class MacrosPageViewModel:PageViewModel
{
    public string Test { get; set; } = "Home";
    public MacrosPageViewModel()
    {
        PageName = ApplicationPageNames.Marcos;
    }
}