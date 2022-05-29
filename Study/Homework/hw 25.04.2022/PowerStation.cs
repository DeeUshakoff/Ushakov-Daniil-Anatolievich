using System.Timers;
using DeeULib;

namespace Programming.Homework.hw_25._04._2022;
public class PowerStation
{
    private System.Timers.Timer TickTimer;

    private double temperature = 0;
    private readonly double heatingSpeed;
    private readonly double criticalTemperature;

    public event EventHandler<OnEmergencyEventArgs> OnEmergencyEvent;
    public PowerStation(double criticalTemperature, double heatingSpeed)
    {
        if (criticalTemperature < temperature)
            throw new Exception("Critical temperature can't be less than current temperature");
        this.criticalTemperature = criticalTemperature;
        this.heatingSpeed = heatingSpeed;
    }
    
    public void Start()
    {
        this.Print();
        TickTimer = new System.Timers.Timer(3000);
        
        TickTimer.Elapsed += OnTimedEvent;
        
        // TickTimer.Start();
        // Console.ReadLine();
        // TickTimer.Stop();
    }

    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        temperature += heatingSpeed;
        if(temperature >= criticalTemperature)
            Emergency();
        this.Print();
    }

    private void Emergency()
    {
        if (OnEmergencyEvent == null) return;
        
        OnEmergencyEvent(this, new OnEmergencyEventArgs());
        temperature = 0;

    }

    public override string ToString() => $"Current temperature: {temperature} / {criticalTemperature}";
}