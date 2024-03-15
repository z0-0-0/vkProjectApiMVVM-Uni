using System.Reactive;
using System.Reflection;
using ReactiveUI;
using vkProj.Models;

namespace vkProject.ViewModels;

public class MainViewModel : ViewModelBase, IScreen
{
    public RoutingState Router { get; } = new();
    private Api _api = new();


    public ReactiveCommand<Unit, IRoutableViewModel> GoToLogin { get; }


    public ReactiveCommand<Unit, IRoutableViewModel> GoBack => Router.NavigateBack;


    public MainViewModel()
    {
        GoToLogin = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(new LoginViewModel(_api, this)));
    }
}