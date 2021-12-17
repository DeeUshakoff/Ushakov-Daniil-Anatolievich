
using DeeULib;

namespace Study
{
    // Task 1
    public class Vector3D : Vector2D
    {
        public double Z;
        /// <summary>
        /// Create Vector3D using X Y Z coord
        /// </summary>
        /// <param name="x">Axis X value</param>
        /// <param name="y">Axis Y value</param>
        /// <param name="z">Axis Z value</param>
        public Vector3D(double x, double y, double z) : base(x, y)
        {
            this.Z = z;

        }

        /// <summary>
        /// Add/Substract input Vector3D to this Vector3D
        /// </summary>
        /// <param name="input">what add</param>
        /// <param name="substract">if true: this - input, else: this + input</param>
        public void Add(Vector3D input, bool substract = false)
        {
            int multiplier = 1;
            if (substract) multiplier = -1;


            X += multiplier * input.X;
            Y += multiplier * input.Y;
            Z += multiplier * input.Z;
        }

        public override int GetHashCode()
        {
            double hash = (X * Y * Z) % 10;
            return hash.ToInt();
        }

        public override string ToString()
        {
            return $"{X} {Y} {Z}";
        }
        public override bool Equals(object? obj)
        {
            var compare = obj as Vector3D;

            if ((obj == null && this == null) ||
                (X == compare.X && Y == compare.Y && Z == compare.Z))
                return true;

            return false;
        }

        public new void Print()
        {
            ToString().Print();
        }
        public static Vector3D operator +(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static Vector3D operator -(Vector3D a, Vector3D b)
        {
            return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

    }


    public struct TRAIN
    {
        public string Destination;
        public DateTime DepartureTime;

        public int TrainNumber;

        public TRAIN(string destination, DateTime departureTime, int trainNumber)
        {
            Destination = destination; DepartureTime = departureTime; TrainNumber = trainNumber;
        }

        public static TRAIN[] WriteTrains()
        {
            var result = new TRAIN[8];

            for (int i = 0; i < 8; i++)
            {
                result[i] = ReadTrain();
            }
            result = Sorted(result);
            return result;
        }

        public static TRAIN ReadTrain()
        {
            string destination;
            DateTime departureTime;

            int trainNumber;

            DeeU.PrintL("Enter the destination: ");
            destination = Console.ReadLine();

            DeeU.PrintL("Enter the departure time: ");
            departureTime = DeeU.ReadTime();

            DeeU.PrintL("Enter the train number: ");
            trainNumber = DeeU.ReadInt();

            return new TRAIN(destination, departureTime, trainNumber);
        }

        public static TRAIN[] Sorted(TRAIN[] input)
        {
            TRAIN temp;
            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i].TrainNumber > input[j].TrainNumber)
                    {
                        temp = input[i];
                        input[i] = input[j];
                        input[j] = temp;
                    }
                }
            }

            return input;
        }

        public static void PrintTrainByNumber(TRAIN[] input)
        {
            DeeU.Print("Enter the train number: ");
            int trainNumber = DeeU.ReadInt();

            int count = 0;

            Console.Clear();

            foreach (var train in input)
            {
                if (train.TrainNumber == trainNumber)
                {
                    count++;
                    if (count == 1)
                        DeeU.Print($"Trains with number {trainNumber}:", ConsoleColor.Green);
                    Console.WriteLine($"Arrives to {train.Destination} at {train.DepartureTime}");
                }
            }
            if (count == 0)
                DeeU.Print($"No trains with number: {trainNumber}", ConsoleColor.Red);
        }

        public void Print()
        {
            DeeU.Print(TrainNumber);
            DeeU.Print(Destination);
            Console.WriteLine(DepartureTime);

        }
    }
    public struct Aeroflot
    {
        public string Destination;
        public string PlaneType;

        public int FlightNumber;

        public Aeroflot(string destination, string planeType, int flightNumber)
        {
            Destination = destination; PlaneType = planeType; FlightNumber = flightNumber;
        }

        public static Aeroflot[] WritePlanes()
        {
            var result = new Aeroflot[7];

            for (int i = 0; i < 7; i++)
            {
                result[i] = ReadPlane();
            }
            result = Sorted(result);
            return result;
        }

        public static Aeroflot ReadPlane()
        {
            string destination;
            string planeType;

            int flightNumber;

            DeeU.PrintL("Enter the flight destination: ");
            destination = Console.ReadLine();

            DeeU.PrintL("Enter the plane type: ");
            planeType = Console.ReadLine();

            DeeU.PrintL("Enter the flight number: ");
            flightNumber = DeeU.ReadInt();

            return new Aeroflot(destination, planeType, flightNumber);
        }

        public static Aeroflot[] Sorted(Aeroflot[] input)
        {
            Aeroflot temp;
            for (int i = 0; i < input.Length - 1; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i].FlightNumber > input[j].FlightNumber)
                    {
                        temp = input[i];
                        input[i] = input[j];
                        input[j] = temp;
                    }
                }
            }

            return input;
        }

        public static void PrintPlanesByDestination(Aeroflot[] input)
        {
            DeeU.Print("Enter the flight destination: ");
            string destination = Console.ReadLine();

            int count = 0;

            Console.Clear();

            foreach (var plane in input)
            {
                if (plane.Destination.ToLower() == destination.ToLower())
                {
                    count++;
                    if (count == 1)
                        DeeU.Print($"Flights to {destination}:", ConsoleColor.Green);
                    DeeU.Print($"{plane.PlaneType} №{plane.FlightNumber}");

                }
            }
            if (count == 0)
                DeeU.Print($"No flights to {destination}", ConsoleColor.Red);
        }

        public void Print()
        {
            DeeU.Print(Destination);
            DeeU.Print(PlaneType);
            DeeU.Print(FlightNumber);
        }
    }

    public class HW_12
    {
        /// <summary>
        /// Creates file with current time in directory
        /// </summary>
        public static void Task_4(string directoryPath)
        {
            File.WriteAllText(@$"{directoryPath}\task_4(1).txt", DateTime.Now.ToString());
            File.WriteAllText(@$"{directoryPath}\task_4(2).txt", DateTime.Now.ToString());
            File.WriteAllText(@$"{directoryPath}\task_4(3).txt", DateTime.Now.ToString());
        }
        /// <summary>
        /// Returns date and time of the newest file in directory
        /// </summary>
        public static void Task_4_1(string directoryPath)
        {

            string[] files = Directory.GetFiles(directoryPath);
            string newestFile = files[0];

            foreach (var path in files)
            {
                if (File.GetLastWriteTime(path) > File.GetLastWriteTime(newestFile))
                    newestFile = path;
            }

            files.Print();

            DeeU.Print($"{newestFile}\n{File.GetLastWriteTime(newestFile)}", ConsoleColor.Green);
        }
    }
}