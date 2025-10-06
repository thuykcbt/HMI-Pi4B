using System;
using AvaloniaApplication3.Data;
using AvaloniaApplication3.ViewModels;

namespace AvaloniaApplication3.Factories;

public class PageFactory
{
    private readonly Func<ApplicationPageNames,PageViewModel> pageFactory;
    public PageFactory(Func<ApplicationPageNames,PageViewModel> factory)
    {
        pageFactory =  factory;
    }
    public PageViewModel GetPageViewModel(ApplicationPageNames pageName)=>pageFactory.Invoke(pageName);
}