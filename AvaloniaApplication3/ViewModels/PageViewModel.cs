using AvaloniaApplication3.Data;
using AvaloniaApplication3.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication3.ViewModels;

public partial class PageViewModel : ViewModelBase
{
    [ObservableProperty]
    private ApplicationPageNames _pageName;
}