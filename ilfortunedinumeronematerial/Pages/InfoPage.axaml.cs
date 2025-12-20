using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Platform.Storage;
using System;

namespace ilfortunedinumeronematerial.Pages;

public partial class InfoPage : UserControl
{

    private static ILauncher? launcher = null;
    private static readonly Uri HomePage = new Uri("https://github.cm/giulianospaghetti/ilfortunedinumeronematerial");
    public InfoPage()
    {
        InitializeComponent();
    }

    public void OnSito_Click(Object sender, RoutedEventArgs e)
    {
        if (launcher == null)
        {
            launcher = TopLevel.GetTopLevel(this).Launcher;
        }
        launcher.LaunchUriAsync(HomePage);
    }
}