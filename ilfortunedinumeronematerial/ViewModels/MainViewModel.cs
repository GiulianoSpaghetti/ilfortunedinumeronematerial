using System.Net;
using System.Reflection.PortableExecutable;
using System;
using Avalonia.Platform.Storage;
using ReactiveUI;
using System.Net.Sockets;
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
    public String Message
    {
        get => $"Per ottenere un doppione cliccare sul pulsante \"Nuovo Cookie\" per {max} volte.";
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
    public ICommand Click { get; private set; }
    public MainViewModel()
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
            Cookie = ex.Message;
            Continua = false;
        }
    }
}