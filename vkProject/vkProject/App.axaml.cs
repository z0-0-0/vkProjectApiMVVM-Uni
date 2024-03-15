using System.Reflection;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using Splat;
using vkProject.ViewModels;
using vkProject.Views;

namespace vkProject;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetExecutingAssembly());

        Locator.CurrentMutable.RegisterLazySingleton(() => new ViewLocator(), typeof(IViewLocator));
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
        {
            Locator.CurrentMutable.RegisterConstant<IScreen>(new MainViewModel());
            desktopLifetime.MainWindow = new MainView { DataContext = Locator.Current.GetService<IScreen>() };
            desktopLifetime.MainWindow.Show();
        }

        if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewApplicationLifetime)
        {
            Locator.CurrentMutable.RegisterConstant<IScreen>(new AndroidMainViewModel());
            singleViewApplicationLifetime.MainView =
                new AndroidMainView() { DataContext = Locator.Current.GetService<IScreen>() };
        }

        base.OnFrameworkInitializationCompleted();
    }
}