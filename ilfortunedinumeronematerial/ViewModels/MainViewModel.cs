using Avalonia.Platform.Storage;
using Avalonia.Threading;
using Material.Styles.Controls;
using ReactiveUI;
using System;
using System.Data;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Threading;
using System.Windows.Input;

namespace ilfortunedinumeronematerial.ViewModels;

public class MainViewModel : ViewModelBase
{
    internal MySqlConnector.MySqlConnection conn;
    private MySqlConnector.MySqlCommand cmd;
    private MySqlConnector.MySqlDataReader reader;
    private int max = 0;
    private Random rnd;
    private int id;
    private string _cookie = string.Empty;
    private bool _continua = true;
    private String _status = string.Empty;
    public String Message
    {
        get => $"Per ottenere un doppione cliccare sul pulsante \"Ottieni un nuovo Biscotto\" per {max} volte.";
    }
    public string Cookie
    {
        get => _cookie;
        set => this.RaiseAndSetIfChanged(ref _cookie, value);
    }

    public bool Continua
    {
        get => _continua;
        set => this.RaiseAndSetIfChanged(ref _continua, value);
    }
    public string Status
    {
        get => _status; set
        {
            this.RaiseAndSetIfChanged(ref _status, value);
            SnackbarHost.Post(_status, null, DispatcherPriority.Normal);
        }
    }

    public ReactiveUI.ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> Click {get; }

    public MainViewModel()
    {
        try
        {
            connect(App.Tentativi);
            GetCookie();
	    Click=ReactiveCommand.Create(GetCookie);
        }
        catch (Exception ex)
        {
            Cookie = ex.Message;
            Continua = false;
        }
        rnd = new();
     }

    public void GetCookie()
    {
        try
        {
            id = rnd.Next(1, max);
            cmd = new($"SELECT Testo FROM Barzellette WHERE ID = {id}", conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            Cookie = reader.GetString(0);
            reader.Close();
        }
        catch (Exception ex)
        {
            try
            {
                connect(App.Tentativi);
                GetCookie();
            }
            catch (Exception ex2)
            {
                Status = ex.Message;
                Continua = false;
            }
        }
    }

    private void connect(int tentative)
    {
        try
        {
            conn = new("server=numeronesoft.ddns.net;user=guest;database=barzellette;port=3306");
            conn.Open();
            rnd = new();
            cmd = new("SELECT MAX(ID) FROM Barzellette", conn);
            reader = cmd.ExecuteReader();
            reader.Read();
            max = reader.GetInt32(0);
            reader.Close();
        } catch (Exception ex) {
            if (tentative < 1)
                throw ex;
            else
            {
                Thread.Sleep(App.Millisecondi);
                connect(tentative - 1);
            }
        }
    }
}