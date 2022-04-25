using DeeULib;

namespace Programming.Homework.hw_25._04._2022;

public class FireDepartment
{
    public readonly string Name;
    public FireDepartment(string name) => Name = name;
    public void HandleEmergency(object? sender, OnEmergencyEventArgs onEmergencyEventArgs) => $"The fire department \"{Name}\" went to the accident".Print();
}