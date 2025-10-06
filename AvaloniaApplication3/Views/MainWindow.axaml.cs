using Avalonia.Controls;
using Avalonia.Input;
using AvaloniaApplication3.ViewModels;


namespace AvaloniaApplication3
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
      
        }
       

        private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            
            (DataContext as MainViewModel)?.SideMenuResizeCommand.Execute(null);
        }
    }
}