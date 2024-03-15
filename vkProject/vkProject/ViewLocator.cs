using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using ReactiveUI;
using Splat;
using vkProject.ViewModels;
using vkProject.Views;

namespace vkProject;

public class ViewLocator : ReactiveUI.IViewLocator
{
    public IViewFor ResolveView<T>(T viewModel, string contract = null)

    {
        if (viewModel is LoginViewModel)
            return new LoginView { ViewModel = viewModel as LoginViewModel };
        if (viewModel is MainViewModel)
            return new MainView() { ViewModel = viewModel as MainViewModel };
        if (viewModel is AddDocViewModel)
            return new AddDocView() { ViewModel = viewModel as AddDocViewModel };
        throw new Exception($"Could not find the view for view model {typeof(T).Name}.");
    }
}