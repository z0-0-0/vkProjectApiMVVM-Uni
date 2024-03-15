using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using vkProject.ViewModels;

namespace vkProject.Views;

public partial class AndroidMainView : ReactiveUserControl<MainViewModel>
{
    public AndroidMainView()
    {
        InitializeComponent();
    }
}