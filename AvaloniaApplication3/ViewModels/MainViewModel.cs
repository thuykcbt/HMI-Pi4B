using Avalonia.Svg.Skia;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls.Shapes;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using AvaloniaApplication3.Data;
using AvaloniaApplication3.Factories;
using AvaloniaApplication3.ViewModels;
using AvaloniaApplication3.Views;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaApplication3.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
       private PageFactory _pageFactory;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SideMenuImage))]
        private bool _sideMenuExpanded = true;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HomePageIsActive))]
        [NotifyPropertyChangedFor(nameof(ProcessPageIsActive))]
        [NotifyPropertyChangedFor(nameof(ActionPageIsActive))]
        [NotifyPropertyChangedFor(nameof(MacrosPageIsActive))]
        [NotifyPropertyChangedFor(nameof(ReporterPageIsActive))]
        [NotifyPropertyChangedFor(nameof(HistoryPageIsActive))]
        [NotifyPropertyChangedFor(nameof(SettingPageIsActive))]
        private PageViewModel _currentPage;

        
        public bool HomePageIsActive=> CurrentPage.PageName==ApplicationPageNames.Home;
        public bool ProcessPageIsActive=>  CurrentPage.PageName==ApplicationPageNames.Process;
        public bool ActionPageIsActive=> CurrentPage.PageName==ApplicationPageNames.Action;
        public bool MacrosPageIsActive=>  CurrentPage.PageName==ApplicationPageNames.Marcos;
        public bool ReporterPageIsActive=>  CurrentPage.PageName==ApplicationPageNames.Reporter;
        public bool HistoryPageIsActive=>  CurrentPage.PageName==ApplicationPageNames.History;
        public bool SettingPageIsActive=>  CurrentPage.PageName==ApplicationPageNames.Setting;
      
       
        public Bitmap  SideMenuImage =>new Bitmap(AssetLoader.Open( new Uri("avares://AvaloniaApplication3/Assets/Images/Viettech.jpg")));
          
        // Design time only constructor
        public MainViewModel()
        {
            CurrentPage = new SettingPageViewModel();
        }
        public MainViewModel(PageFactory pageFactory)
        {
            _pageFactory = pageFactory;
            GotoHome();
        }
        [RelayCommand]
        private void SideMenuResize()
        {
            SideMenuExpanded = !SideMenuExpanded;
        }

        [RelayCommand]
        private void GotoHome() =>    CurrentPage =_pageFactory.GetPageViewModel(ApplicationPageNames.Home);
        
        [RelayCommand]
        private void GotoProcess() => CurrentPage =_pageFactory.GetPageViewModel(ApplicationPageNames.Process);
        
        [RelayCommand]
        private void GotoAction() =>CurrentPage =_pageFactory.GetPageViewModel(ApplicationPageNames.Action);
        [RelayCommand]
        private void GotoMacros() =>CurrentPage =_pageFactory.GetPageViewModel(ApplicationPageNames.Marcos);
        [RelayCommand]
        private void GotoReporter() =>  CurrentPage =_pageFactory.GetPageViewModel(ApplicationPageNames.Reporter);
        [RelayCommand]
        private void GotoHistory() => CurrentPage =_pageFactory.GetPageViewModel(ApplicationPageNames.History);
        [RelayCommand]
        private void GotoSetting() => CurrentPage =_pageFactory.GetPageViewModel(ApplicationPageNames.Setting);
    }
}
