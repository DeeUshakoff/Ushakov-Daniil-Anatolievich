
using DeeULib;
namespace Study
{
    public class Classwork_14
    {
        public static void PrintValues()
        {
            foreach(var exam in System.Enum.GetValues(typeof(Exams)))
                DeeU.Print(exam.ToString(), ConsoleColor.DarkBlue);
        }
        public static string GetName(Type enumerator, int value)
            => System.Enum.GetName(enumerator, value);
        public static int GetValue(string find, Type sourceEnum)
            => (int)System.Enum.Parse(sourceEnum, find);
        public static bool IsContains(object find, Type sourceEnum)
            => System.Enum.IsDefined(sourceEnum, find);
    }
    public enum Exams
    {
        Algem,
        MathematAnalysis,
        Discret,
        Programming
    }
}
