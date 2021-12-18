
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
        public void Task_4(string directoryPath)
        {
            File.WriteAllText(@$"{directoryPath}\task_4(1).txt", DateTime.Now.ToString());
            File.WriteAllText(@$"{directoryPath}\task_4(2).txt", DateTime.Now.ToString());
            File.WriteAllText(@$"{directoryPath}\task_4(3).txt", DateTime.Now.ToString());
        }
        /// <summary>
        /// Returns date and time of the newest file in directory
        /// </summary>
        public void Task_4_1(string directoryPath)
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
    public struct Match : IComparable
    {
        public string TeamName;
        public DateTime DateOfGame;

        private int scoresCount = 0;
        public int ScoresCount
        {
            get
            {
                return scoresCount;
            }
            set
            {
                if (value >= 0)
                {
                    scoresCount = value;
                    return;
                }
            }
        }

        public Match(string teamName, DateTime dateOfGame, int scoresCount)
        {
            TeamName = teamName;
            DateOfGame = dateOfGame;
            ScoresCount = scoresCount;
        }
        public static Match[] ReadMatches(string path)
        {
            string[] FileText = File.ReadAllLines(path);
            Match[] result = { };

            foreach (var el in FileText)
            {
                string[] line = el.Split(' ');

                if (line.Length != 3) continue;

                string[] tmpTimeString = line[1].Split('.');

                var DateOfGame = new DateTime(tmpTimeString[0].ToInt(),
                    tmpTimeString[1].ToInt(), tmpTimeString[2].ToInt(),
                    tmpTimeString[3].ToInt(), tmpTimeString[4].ToInt(), tmpTimeString[5].ToInt());
                result = result.Add(new Match(line[0], DateOfGame, line[2].ToInt()));
            }

            Array.Sort(result);

            return result;
        }
        public static void LeaderInPeriod(Match[] matches, DateTime start, DateTime end)
        {

            string leader_name = "";
            int leader_scores = -1;

            Dictionary<string, int> match_dict = new Dictionary<string, int>();

            
            foreach (var match in matches)
            {
                if(match.DateOfGame >= start && match.DateOfGame <= end)
                {
                    if (match_dict.ContainsKey(match.TeamName))
                        match_dict[match.TeamName] += match.ScoresCount;
                    else
                        match_dict.Add(match.TeamName, match.ScoresCount);
                }
            }
            
            
            
            foreach (var el in match_dict)
            {

                if (el.Value > leader_scores)
                {
                    leader_name = el.Key;
                    leader_scores = el.Value;
                }
            }

            DeeU.Print($"Leader from {start.ToShortDateString()} to {end.ToShortDateString()} is {leader_name} with {leader_scores} scores");
        }
        public void Print()
        {
            DeeU.Print($"{TeamName} {DateOfGame} {ScoresCount}");
        }
        
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var other = (Match)obj;

            if (obj != null)
            {
                if (this.ScoresCount > other.ScoresCount)
                    return -1;
                else if (this.ScoresCount < other.ScoresCount)
                    return 1;
                else
                    return 0;
            }
            else
                throw new Exception("Unnable to compare objects");
        }
    }


    
    public static class HW_12_Ext
    {
        public static Match[] Add(this Match[] source_array, Match add)
        {
            Match[] result = new Match[source_array.Length + 1]; // Creating array with needing length

            source_array.CopyTo(result, 0); // Copy source array to the new array
            result[result.Length-1] = add; // Copy add array or nums to the new array

            return result;
        }
        public static void Print(this Match[] source_array)
        {
            foreach (var el in source_array)
                el.Print();
        }
        public static void Print(this List<Exam> source)
        {
            foreach (var el in source)
                el.Print();
        }
    }
    public struct Exam : IComparable
    {
        public string TeacherName;

        public DateTime DateOfExam;
        
        
        
        public Exam(string teacherName, DateTime dateOfExam)
        {
            TeacherName = teacherName; DateOfExam = dateOfExam; 
        }

        public static Exam AddDay(Exam exam)
        {
            return new Exam(exam.TeacherName, exam.DateOfExam.AddDays(1));
        }

        public static List<Exam> ReadData(string path)
        {
            string[] FileText = File.ReadAllLines(path);
            List<Exam> result = new List<Exam>();

            foreach (var el in FileText)
            {
                string[] line = el.Split(' ');

                if (line.Length != 2) continue;

                string[] tmpTimeString = line[1].Split('.');

                var DateOfGame = new DateTime(tmpTimeString[0].ToInt(),
                    tmpTimeString[1].ToInt(), tmpTimeString[2].ToInt(),
                    tmpTimeString[3].ToInt(), tmpTimeString[4].ToInt(), 0);
                result.Add(new Exam(line[0], DateOfGame));
            }

            result.Sort();

            return result;
        }

        public static List<Exam> SortedExams(List<Exam> exams)
        {
            exams.Sort();

            List<Exam> sortedExams = new List<Exam>();
            List<string> dates = new List<string>();

            for (int i = 0; i < exams.Count; i++)
            {
                if (dates.Contains(exams[i].DateOfExam.ToShortDateString()))
                {
                    while (dates.Contains(exams[i].DateOfExam.ToShortDateString()))
                        exams[i] = Exam.AddDay(exams[i]);

                    sortedExams.Add(exams[i]);
                    dates.Add(exams[i].DateOfExam.ToShortDateString());
                }
                else
                {
                    dates.Add(exams[i].DateOfExam.ToShortDateString());
                    sortedExams.Add(exams[i]);
                }
            }
            return sortedExams;
            
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var other = (Exam)obj;

            var a = DateOnly.FromDateTime(DateOfExam);
            var b = DateOnly.FromDateTime(other.DateOfExam);
            if (obj != null)
            {
                if (a > b)
                    return 1;
                else if (a < b)
                    return -1;
                else
                    return 0;
            }
            else
                throw new Exception("Unnable to compare objects");
        }

        public void Print()
        {
            DeeU.Print($"{TeacherName} {DateOfExam.ToLongDateString()} {DateOfExam.ToShortTimeString()}");
        }
        
    }
}