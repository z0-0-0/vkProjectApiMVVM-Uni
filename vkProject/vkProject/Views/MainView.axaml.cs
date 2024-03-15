using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using vkProject.ViewModels;

namespace vkProject.Views;

public partial class MainView : ReactiveWindow<MainViewModel>
{
    public MainView()
    {
        InitializeComponent();
        ViewModel = new MainViewModel();
        this.WhenActivated(disposables => { });
    }
}