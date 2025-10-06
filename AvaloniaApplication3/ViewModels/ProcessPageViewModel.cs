using AvaloniaApplication3.Data;
using AvaloniaApplication3.ViewModels;

namespace AvaloniaApplication3.ViewModels;

public partial class ProcessPageViewModel : PageViewModel
{
    public string Test { get; set; } = "ProcessPageViewModel";
    public ProcessPageViewModel()
    {
        PageName =ApplicationPageNames.Process;
    }
}