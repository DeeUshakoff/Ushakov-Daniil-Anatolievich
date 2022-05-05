using System.Reflection;
using DeeULib;
using Programming.Homework.hw_25._04._2022;

namespace Programming.ControlWork;

public class ReflectionTask
{
    /* 
     * 
     * 
     * 
     * 
     * 
     * Создайте рефлексией классы-подписчики и класс-источник,
     * 
   
     */
    public ReflectionTask()
    {
        var ex = new BirthdayTimer();
        
        Type EventType = typeof(BirthdayTimer);

        // var reflectionMethod = EventType.GetMethod("StaticMethod");
        // reflectionMethod.Invoke(ex, parameters: null);
        //
        // var Property = EventType.GetProperty("Property");
        // Property.GetValue(ex).Print();
        // Property.SetValue(ex, 123);
        // Property.GetValue(ex).Print();
        //
        // var privateField = EventType.GetField("Field", BindingFlags.Instance | BindingFlags.NonPublic);
        // privateField.GetValue(ex);
        //
        //
        //
        // EventType.GetMethod("Start").Invoke(ex, parameters: null);
    }
    
}