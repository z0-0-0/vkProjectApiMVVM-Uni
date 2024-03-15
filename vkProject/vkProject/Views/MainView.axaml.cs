using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using vkProject.ViewModels;

namespace vkProject.Views;
#if ANDROID
public partial class MainView : ReactiveUserControl<MainViewModel>
{
    public MainView(){
    InitializeComponent();
    ViewModel = new MainViewModel();
}
}
#else
public partial class MainView : ReactiveWindow<MainViewModel>
{
    public MainView()
    {
        InitializeComponent();
        ViewModel = new MainViewModel();
        this.WhenActivated(disposables => { });
    }
}
#endif