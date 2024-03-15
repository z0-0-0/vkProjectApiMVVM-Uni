using System.Reactive;
using System.Reflection;
using ReactiveUI;
using vkProj.Models;

namespace vkProject.ViewModels;

public class AndroidMainViewModel : ViewModelBase, IScreen
{
    public RoutingState Router { get; } = new RoutingState();
    private Api _api = new Api();


    public ReactiveCommand<Unit, IRoutableViewModel> GoToLogin { get; }


    public ReactiveCommand<Unit, IRoutableViewModel> GoBack => Router.NavigateBack;


    public AndroidMainViewModel()
    {
        GoToLogin = ReactiveCommand.CreateFromObservable(
            () => Router.Navigate.Execute(new LoginViewModel(this._api, this)));
    }
}