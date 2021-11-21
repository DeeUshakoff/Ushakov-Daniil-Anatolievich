
namespace lessons
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
        /// Maximum rental period in months
        /// </summary>
        protected int MaxRentTime
        {
            set
            {
                maxRentTime = CheckInputInt(value);
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
            DeeU.Print(Cost);
            DeeU.Print(MinRentTime, MaxRentTime);
            DeeU.Print(isPrepaidRequired);
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
            DeeU.Print(RoomType);
            DeeU.Print(NutritionType);

        }

    }
    public class Triangle
    {
        private double side_A;
        public double Side_A;


        private double side_B;
        public double Side_B;


        private double side_C;
        public double Side_C;


        /// <summary>
        /// Angle between sides A and B
        /// </summary>
        public double Angle_AB;

        /// <summary>
        /// Angle between sides A and C
        /// </summary>
        public double Angle_AC;

        /// <summary>
        /// Angle between sides B and C
        /// </summary>
        public double Angle_BC;

        /// <summary>
        /// Create Triangle using 2 sides and angle between them
        /// </summary>
        /// <param name="angle">Angle between side_A and side_B</param>
        /// 
        public Triangle(double side_A, double side_B, double angle)
        {
            Side_A = side_A;
            Side_B = side_B;
            Angle_AB = DeeU.Angle3.CheckAngle(angle);

            Side_C = Math.Sqrt(Side_A * Side_A + Side_B * Side_B - 2 * Side_A * Side_B * Math.Cos(Angle_AB * Math.PI / 180));
            DeeU.Print(Side_C);
        }


    }




}
