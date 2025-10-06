using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaApplication3.Data;
using AvaloniaApplication3.Factories;
using AvaloniaApplication3.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace AvaloniaApplication3
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
         
        }
    

        public override void OnFrameworkInitializationCompleted()
        {
            var collection = new ServiceCollection();
            collection.AddSingleton<MainViewModel>();
            collection.AddSingleton<HomePageViewModel>();
            collection.AddSingleton<ProcessPageViewModel>();
            collection.AddSingleton<ActionPageViewModel>();
            collection.AddSingleton<MacrosPageViewModel>();
            collection.AddSingleton<ReporterPageViewModel>();
            collection.AddSingleton<HistoryPageViewModel>();
            collection.AddSingleton<SettingPageViewModel>();
            
            collection.AddSingleton<Func<ApplicationPageNames,PageViewModel>>(x => name=> name switch
            {
                ApplicationPageNames.Home=>x.GetRequiredService<HomePageViewModel>(),
                ApplicationPageNames.Process=>x.GetRequiredService<ProcessPageViewModel>(),
                ApplicationPageNames.Marcos=>x.GetRequiredService<MacrosPageViewModel>(),
                ApplicationPageNames.Action=>x.GetRequiredService<ActionPageViewModel>(),
                ApplicationPageNames.Reporter=>x.GetRequiredService<ReporterPageViewModel>(),
                ApplicationPageNames.History=>x.GetRequiredService<HistoryPageViewModel>(),
                ApplicationPageNames.Setting=>x.GetRequiredService<SettingPageViewModel>(),
                _=> throw new InvalidOperationException(),  
                
            });
            collection.AddSingleton<PageFactory>();
            var service = collection.BuildServiceProvider();
       
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow()
                {
                     DataContext = service.GetRequiredService<MainViewModel>()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }   
    }
}