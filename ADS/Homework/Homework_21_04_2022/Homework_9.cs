namespace ADS.Homework;

public class Homework_9
{
    static double FindMax(int[] data, int start, int end)
    {
        if (data.Length == 0)
            return double.NaN;
        
        if (end - start <= 1)
            return Math.Max(data[start], data[end]);
        
        var mid = (start + end) / 2; 
        var leftMax =  FindMax(data[..mid], start, data[..mid].Length - 1);
        var rightMax = FindMax(data[mid..], 0 , data[mid..].Length - 1);
        return Math.Max(leftMax, rightMax);
    }
}