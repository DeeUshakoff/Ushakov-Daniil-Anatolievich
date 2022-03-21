using DeeULib;

namespace Study
{
    public abstract class Machine
    {
        public string? Manufacturer { get; set; }
        public string? Name { get; set; }

        private double power;
        public double Power
        {
            get
            {
                return power;
            }
            set
            {
                if (value > 0)
                    power = value;
                else
                    throw new Exception("Power can't be less than zero");
            }
        }

        public Machine(string manufacturer, string name, double power)
        {
            Manufacturer = manufacturer;
            Name = name;
            Power = power;
        }
        public EnergeticType EnergeticType { get; set;}

    }

    public enum EnergeticType
    {
        CombustibleFuel,
        ElectricFuel
    }

    public class ConstructionMachine : Machine, ICloneable
    {
        public bool EnvironmentProtection;

        private int vibranceLevel;
        public int VibranceLevel
        {
            get
            {
                return vibranceLevel;
            }
            set
            {
                if (value >= 0 && value <= 100)
                    vibranceLevel = value;
                else
                    throw new Exception("Vibrance level must be: 0 <= value <= 100");
            }
        }

        private double weight;
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value > 0)
                    weight = value;
                else
                    throw new Exception("Weight can't be less than zero");
            }
        }


        public ConstructionMachine(string manufacturer, string name, double power, double weight, int vibranceLevel, bool environmentProtection)
            : base(manufacturer, name, power)
        {
            Weight = weight;
            VibranceLevel = vibranceLevel;
            EnvironmentProtection = environmentProtection;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void ChangeNozzle()
        {
            DeeU.Print("Nozzle was changed", ConsoleColor.Yellow);
        }

        public override int GetHashCode()
        {
            return 31 * VibranceLevel * Weight.ToInt();
        }

        public override bool Equals(object? obj)
        {
            
            var other = obj as ConstructionMachine;

            if (EnvironmentProtection == other.EnvironmentProtection &&
                VibranceLevel == other.VibranceLevel &&
                Weight == other.Weight &&
                Manufacturer == other.Manufacturer &&
                Name == other.Name &&
                EnergeticType == other.EnergeticType)
                return true;
            return false;
        }

        public override string ToString()
        {
            return $"{Manufacturer}\n{Name}\n{EnergeticType}\n" +
                $"EnvProtection is {EnvironmentProtection}\n" +
                $"Vibrance level is {VibranceLevel}\n" +
                $"Weight is {Weight}\n";
        }
    }

    public static class ConstructionMachineryExt
    {
        public static void Repair(this ConstructionMachine source, string path)
        {
            DeeU.FileWrite(path, $"\nRepair contract for machine #{source.GetHashCode()}, machine's specs:\n{source.ToString()}\nStatus: Repaired");
        }
    }

    public class Stack
    {
        public ConstructionMachine[] machines = { };

        public void Add(params ConstructionMachine[] add)
        {
            ConstructionMachine[] result = new ConstructionMachine[machines.Length + add.Length]; // Creating array with needing length

            machines.CopyTo(result, 0); // Copy source array to the new array
            add.CopyTo(result, machines.Length); // Copy add array or nums to the new array

            machines = result;
        }

        public Stack(ConstructionMachine[] machine)
        {
            this.machines = machine;
        }

        public Stack() { }

        public ConstructionMachine Read()
        {
            if (machines.Length == 0)
                throw new Exception("Stack is empty");
            var result = machines[machines.Length-1];

            ConstructionMachine[] new_machines = new ConstructionMachine[machines.Length-1];

            for (int i = 0; i < new_machines.Length; i++)
            {
                new_machines[i] = machines[i];
            }


            machines = new_machines;
            return result;
        }

        public void Print()
        {
            foreach (var machine in machines)
                DeeU.Print(machine.ToString());
        }
    }
}   
