namespace ControlWork_19_11_2022;

public static class Replacer
{
    public static string Replace(string input)
    {
        var indexFirst = input.IndexOf("@#!elephant=&.ha-ha");
        var indexLast = input.IndexOf("</header>") - 1;

        if (indexFirst == 0 || indexLast == 0)
            return "Empty header";
        
        input = input.Replace("header", "h2");
        
        for (var i = indexFirst; i <= indexLast; i++)
        {
            if (input[i] == '>')
            {
                indexFirst = i + 1;
                break;
            }
        }

        var temp_array = input.ToArray();
        for (var i = indexFirst; i <= indexLast; i++)
            temp_array[i] = Translator.GetEncoded(temp_array[i]);
        
        return string.Join("", temp_array);
    }
}