using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ilfortunedinumeronematerial.ViewModels;
using ilfortunedinumeronematerial.Views;
using System.ComponentModel;
using Optris.Icons.Avalonia;
using Optris.Icons.Avalonia.MaterialDesign;

namespace ilfortunedinumeronematerial;

public partial class App : Application
{

    public static int Millisecondi { get; private set; }
    public static int Tentativi {get; private set; }
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        IconProvider.Current.Register<MaterialDesignIconProvider>();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            Millisecondi = 1000;
            Tentativi = 10;
            desktop.MainWindow = new MainWindow();
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            Millisecondi = 900;
            Tentativi = 4;
            singleViewPlatform.MainView = new MainView();
        }

        base.OnFrameworkInitializationCompleted();
    }
}
