using System.Net;
using System.Text;

namespace ControlWork_19_11_2022;

public enum ServerStatus
{
    Start,
    Stop
};

public class HttpServer : IDisposable
{
    public ServerStatus Status = ServerStatus.Stop;
    private readonly ServerSetting _serverSetting = new ServerSetting();
    private readonly HttpListener _listener;

    public HttpServer()
    {
        _listener = new HttpListener();
        _listener.Prefixes.Add($"http://localhost:" + _serverSetting.Port + "/");
    }

    public void Start()
    {
        _listener.Start();
        Status = ServerStatus.Start;
        Receive();
    }

    public void Stop()
    {
        _listener.Stop();
        Status = ServerStatus.Stop;
    }

    private void Receive()
    {
        _listener.BeginGetContext(new AsyncCallback(ListenerCallback), _listener);
    }

    private void ListenerCallback(IAsyncResult result)
    {
        if (!_listener.IsListening) return;
        var _httpContext = _listener.EndGetContext(result);
        var request = _httpContext.Request;
        var response = _httpContext.Response;
        var buffer = Array.Empty<byte>();
        string st;
        
        if (Directory.Exists(_serverSetting.Path))
        {
            buffer = FileManager.getFile(_httpContext.Request.RawUrl.Replace("%20", " "), _serverSetting);

            buffer = Encoding.UTF8.GetBytes(Replacer.Replace(Encoding.UTF8.GetString(buffer)));

            if (buffer == null)
            {
                response.Headers.Set("Content-Type", "text/plain");
                response.StatusCode = (int)HttpStatusCode.NotFound;
                var err = "404 - not found";
                buffer = Encoding.UTF8.GetBytes(err);
            }
        }
        else
        {
            var err = $"Directory " + _serverSetting.Path + " not found";
            buffer = Encoding.UTF8.GetBytes(err);
        }

        var output = response.OutputStream;
        output.Write(buffer, 0, buffer.Length);
        output.Close();
        Receive();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}