namespace ControlWork_19_11_2022;

public class FileManager
{
    public static byte[] getFile(string rawUrl, ServerSetting _serverSetting) 
    {
        byte[] buffer = null;
        var filePath = _serverSetting.Path + rawUrl;
            
        if (Directory.Exists(filePath))
        {
                
            filePath = filePath + "page.html";

            if (File.Exists(filePath))
            {
                //Console.WriteLine(filePath);
                buffer = File.ReadAllBytes(filePath);
            }

        }
        else if (File.Exists(filePath))
            buffer = File.ReadAllBytes(filePath);
        return buffer; 
    }
}