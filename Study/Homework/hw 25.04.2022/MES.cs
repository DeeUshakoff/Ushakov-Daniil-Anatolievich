using DeeULib;
namespace Programming.Homework.hw_25._04._2022;

public class MES
{
    public readonly string Name;
    public MES(string name) => Name = name;
    public void HandleEmergency(object? sender, OnEmergencyEventArgs onEmergencyEventArgs) => $"The MES \"{Name}\" went to the accident".Print();
}