using System.ComponentModel;
using DeeULib;

namespace ADS.Homework.Homework_10_02_2022;

public class Homework_1
{
    
    public int[] ArrayMerge(int[][] arrays) => arrays.SelectMany(num => num).OrderBy(x => x).ToArray();

    public int[][] ReadFromFile(string path)
    {
        var file = File.ReadAllLines(path)
            .Where(x => x.IsNum())
            .Select(x => Array.ConvertAll(x.Split(" "), Convert.ToInt32))
            .ToList();
        if(file.Count < 2)
            throw new Exception("Incorrect file");
        if (file.First().Length != 1)
            throw new Exception("Incorrect file");


        return file.ToArray();
    }
}