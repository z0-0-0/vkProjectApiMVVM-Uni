using System;
using System.Reactive;
using System.Threading.Tasks;
using System.Windows.Input;
using DynamicData.Binding;
using ReactiveUI;
using Splat;
using vkProj.Models;

namespace vkProject.ViewModels;

public class LoginViewModel : ViewModelBase, IRoutableViewModel
{
    public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
    public IScreen HostScreen { get; }


    private bool _loggedFlag = false;
    private readonly Api _api;
    private UserData _userData;
    private string _clientId;
    private ViewModelBase _contentViewModel;

    public string ClientId
    {
        get => _clientId;
        set => this.RaiseAndSetIfChanged(ref _clientId, value);
    }

    private string _userId;

    public string UserId
    {
        get => _userId;
        set => this.RaiseAndSetIfChanged(ref _userId, value);
    }

    public ReactiveCommand<Unit, IRoutableViewModel?> GoBack => HostScreen.Router.NavigateBack;

    public LoginViewModel(Api api, IScreen hostScreen = null)
    {
        HostScreen = hostScreen ?? Locator.Current.GetService<IScreen>();
        _api = api;
        var isValidClientId = this.WhenAnyValue(
            x => x.ClientId,
            y => y.UserId,
            (x, y) => !string.IsNullOrWhiteSpace(x) && x.Length == 8 && !string.IsNullOrWhiteSpace(y));
        TryLogin = ReactiveCommand.Create(_tryLoginCommand, isValidClientId);
        this.WhenValueChanged(x => x.IsLogged, false).Subscribe(_ => SwitchToDocs());
    }


    public ICommand TryLogin { get; }

    private void _tryLoginCommand()
    {
        GoToLogin();
    }

    private async void SwitchToDocs()
    {
        var file = await _api.GetUserFiles();
        var content = await _api.GetSingleFile(file.url);
        HostScreen.Router.Navigate.Execute(new AddDocViewModel(HostScreen, file, content));
    }

    public bool IsLogged
    {
        get => _loggedFlag;
        set => this.RaiseAndSetIfChanged(ref _loggedFlag, value);
    }

    public async Task GoToLogin()
    {
        _userData = await _api.GetAccessToken(_clientId);
        IsLogged = true;
    }
}