using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using vkProject.ViewModels;

namespace vkProject.Views;

public partial class AddDocView : ReactiveUserControl<AddDocViewModel>
{
    public AddDocView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);    }
}