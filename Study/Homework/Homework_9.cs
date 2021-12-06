
namespace Study
{


    public class Accommodation
    {
        private int cost;
        /// <summary>
        /// Cost per month
        /// </summary>
        protected int Cost
        {
            set
            {
                cost = CheckInputInt(value);
            }
            get
            {
                return cost;
            }

        }

        private int minRentTime;
        /// <summary>
        /// Minimum rental period in months
        /// </summary>
        protected int MinRentTime
        {
            set
            {
                minRentTime = CheckInputInt(value);
            }
            get
            {
                return minRentTime;
            }

        }

        private int maxRentTime;
        /// <summary>
        /// Maximum rental period in months. If Maximum <= Minimum, Maximim = Minimum + (Minimum - Maximum) + 1
        /// </summary>
        protected int MaxRentTime
        {
            set
            {
                maxRentTime = CheckInputInt(value);
                
                if (maxRentTime <= MinRentTime)
                    maxRentTime = MinRentTime + (MinRentTime - maxRentTime) + 1;
                
            }
            get
            {
                return maxRentTime;
            }

        }

        /// <summary>
        /// Is Prepaid payment required for check-in
        /// </summary>
        protected bool isPrepaidRequired;

        /// <summary>
        /// Is Accommodation empty
        /// </summary>
        protected bool isEmpty;

        /// <summary>
        /// Populate the Accommodation
        /// </summary>
        public void Populate() { isEmpty = false; }

        /// <summary>
        /// Evict the Accommodation
        /// </summary>
        public void Evict() { isEmpty = true; }

        public void PrintCommon()
        {
            DeeUseless.Print($"Is free: {isEmpty}");
            DeeUseless.Print($"Cost: {Cost} per month");
            DeeUseless.Print($"Rental time: from {MinRentTime} month(s) to {MaxRentTime}");
            DeeUseless.Print($"Is prepaid required? {isPrepaidRequired}");
        }

        protected int CheckInputInt(int input)
        {
            if (input < 0)
                return 0;
            return input;
        }
    }

    public class Hotel : Accommodation
    {
        private string roomtype;
        string RoomType
        {
            get
            {
                return roomtype;
            }
            set
            {
                value = value.ToLower();
                if (value == "single")
                    roomtype = "Single";
                else if (value == "double")
                    roomtype = "Double";
                else if (value == "family")
                    roomtype = "Family";
                else
                    roomtype = "Unknown room type";
            }
        }
        private string nutritiontype;
        string NutritionType
        {
            get
            {
                return nutritiontype;
            }
            set
            {
                value = value.ToLower();
                if (value == "full")
                    nutritiontype = "Full";
                else if (value == "onlybreakfast")
                    nutritiontype = "Only Breakfast";
                else
                    nutritiontype = "Unknown nutrition type";
            }
        }


        private int roomNum;
        int RoomNumber
        {
            set { roomNum = CheckInputInt(value); }
            get { return roomNum; }
        }


        public Hotel(string roomType, string nutritionType, int roomNumber, int Cost, int MinRentTime, int MaxRentTime, bool isPrepaidRequired, bool isEmpty = true)

        {
            RoomType = roomType;
            NutritionType = nutritionType;
            RoomNumber = roomNumber;
            this.Cost = Cost;
            this.MinRentTime = MinRentTime;
            this.MaxRentTime = MaxRentTime;
            this.isPrepaidRequired = isPrepaidRequired;
            this.isEmpty = isEmpty;


        }

        public void Print()
        {
            PrintCommon();
            DeeUseless.Print($"Room number: {RoomNumber}");
            DeeUseless.Print($"Room type: {RoomType}");
            DeeUseless.Print($"Nutrition type: {NutritionType}");
            
            

        }

    }

    public class Rental : Accommodation
    {
        public bool isPaidInternet;

        public bool isPaidSecondKeys;

        public bool isPaidCleaning;

        public bool isFullHouse;
        


        public Rental
            (int Cost, int MinRentTime, int MaxRentTime, 
            bool isPrepaidRequired, bool IsPaidInternet, bool IsPaidSecondKeys,
            bool IsPaidCleaning, bool IsFullHouse,  bool isEmpty = true)
        {
            isFullHouse = IsFullHouse;
            isPaidCleaning = IsPaidCleaning;
            isPaidInternet = IsPaidInternet;
            isPaidSecondKeys = IsPaidSecondKeys;
            
            this.Cost = Cost;
            this.MinRentTime = MinRentTime;
            this.MaxRentTime = MaxRentTime;
            this.isPrepaidRequired = isPrepaidRequired;
            this.isEmpty = isEmpty;


        }

        public void Print()
        {
            PrintCommon();
            DeeUseless.Print($"Is paid Internet? {isPaidInternet}");
            DeeUseless.Print($"Is paid Second Keys? {isPaidSecondKeys}");
            DeeUseless.Print($"Is paid Cleaning? {isPaidCleaning}");
            DeeUseless.Print($"Is Full House? {isFullHouse}");
        }

    }


    public class Triangle
    {
        protected bool isExist;
        protected double Side_A;



        protected double Side_B;



        protected double Side_C;


        /// <summary>
        /// Angle ABC
        /// </summary>
        public double Angle_Beta;

        /// <summary>
        /// Angle CAB
        /// </summary>
        public double Angle_Alpha;

        /// <summary>
        /// Angle ACB
        /// </summary>
        public double Angle_Gamma;

        public Triangle() { }

        /// <summary>
        /// Create Triangle using 2 sides and angle between them
        /// </summary>
        /// <param name="angle">Angle between side_A and side_B</param>
        /// </summary>
        public void Create(double side_A, double side_B, DeeUseless.Angle3 angle)
        {
            Side_A = side_A;
            Side_B = side_B;
            Angle_Beta = angle.AngleValue;
            Side_C = SideC_2SidesAngle(Side_A, Side_B, Angle_Beta);

            CalcAngles();

            PrintTriangle();
        }
        public void Create(double side_A, double side_B, double side_C)
        {
            Side_A = side_A;
            Side_B = side_B;
            Side_C = side_C;

            CalcAngles();


        }
        double GetAngle(double side_1, double side_2, double side_opposite)
        {
            double angle = Math.Acos((side_1*side_1 + side_2*side_2 - side_opposite*side_opposite) / (2 * side_1*side_2)) * (180 / Math.PI);

            return angle;
        }
        
        /// <summary>
        /// Calc side C, using A and B. C = Sqrt(A^2 + B^2 - 2AB*Cos(angle between A and B))
        /// </summary>
        /// <param name="side_A"></param>
        /// <param name="side_B"></param>
        /// <param name="angle">Angle between side_A and side_B</param>
        /// <returns></returns>
        protected double SideC_2SidesAngle(double side_A, double side_B, double angle)
        {
            double side_C = Math.Sqrt(side_A * side_A + side_B * side_B - 2 * side_A * side_B * Math.Cos(angle * Math.PI / 180));
            
            return side_C;
        }
        public void CalcAngles()
        {
            Angle_Alpha = GetAngle(Side_A, Side_B, Side_C);
            Angle_Beta = GetAngle(Side_B, Side_C, Side_A);
            Angle_Gamma = GetAngle(Side_C, Side_A, Side_B);

            if (!Double.IsNaN(Angle_Alpha) && !Double.IsNaN(Angle_Beta) && !Double.IsNaN(Angle_Gamma))
                isExist = true;
            else
            {Side_A = 0; Side_B = 0; Side_C = 0; Angle_Alpha = 0; Angle_Beta = 0; Angle_Gamma = 0; }

        }

        public double GetPerimeter()
        {
            if(isExist)
                return Side_A + Side_B + Side_C;
            return 0;
        }

        public double GetSquare()
        {
            if (isExist)
                return 0.5 * Side_A*Side_B*Math.Sin(Angle_Alpha*Math.PI / 180);
            return 0;
        }
        public void PrintTriangle()
        {
            DeeUseless.Print("        A\n" +
                       "        *\n" +
                       "       *a*\n" +
                       "SideA *   * SideB\n" +
                       "     *     *\n" +
                       "    * g   b *\n" +
                       "   ***********\n" +
                       " C    SideC    B\n");
        }

        public double A()
        {
            return Side_A;
        }
        public double B()
        {
            return Side_B;
        }
        public double C()
        {
            return Side_C;
        }

        public void Print()
        {
            if (isExist == false) { DeeUseless.Print("The triangle does not exist", "red"); return; }

            DeeUseless.Print($"Alpha = {Angle_Alpha}°");
            DeeUseless.Print($"Beta = {Angle_Beta}°");
            DeeUseless.Print($"Gamma = {Angle_Gamma}°");
            DeeUseless.Print($"Side A = {Side_A}");
            DeeUseless.Print($"Side B = {Side_B}");
            DeeUseless.Print($"Side C = {Side_C}");
            DeeUseless.Print($"Permimeter = {GetPerimeter()}");
            DeeUseless.Print($"Square = {GetSquare()}");
            
        }
    }
    public class TriangleRight : Triangle
    {
        public new void Create(double a, double b, double c)
        {
        
        } // Method to hide the parrent method
        public new void Create(double side_A, double side_B, DeeUseless.Angle3 angle)
        {

        } // Method to hide the parrent method
        public TriangleRight(double Leg_A, double Leg_B)
        {
            Side_A = Leg_A;
            Side_B = Leg_B;
            Side_C = SideC_2SidesAngle(Side_A, Side_B, 90);
            
            DeeUseless.Print(Side_C);
        }
        public TriangleRight(double Leg_A, double Leg_B, double Hypothesis)
        {
            Side_A = Leg_A;
            Side_B = Leg_B;
            Side_C = Hypothesis;

            CalcAngles();

            if (Angle_Alpha != 90)
                isExist = false;
            Print();

            

            DeeUseless.Print(Side_C);
        }
    }

    public class TriangleIsoscale : Triangle
    {
        double Height;
        public void Create(double side, double side_base)
        {
            Side_A = side;
            Side_B = side;
            Side_C = side_base;
            
            CalcAngles();

            Height = Math.Sqrt(4 * Side_A * Side_A - Side_C * Side_C) * 0.5;
            Print();
        }

        public double GetSqaure()
        {
            return 0.5 * Side_C * Height;
        }
        
    }


}
