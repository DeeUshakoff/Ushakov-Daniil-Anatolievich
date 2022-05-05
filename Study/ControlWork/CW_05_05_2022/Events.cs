using DeeULib;

namespace Programming.ControlWork;

public class OnBirthdayEventArgs : EventArgs {}
   

    public class BirthdayTimer
    {
        private int Property { get; set; }
        public int Field = 10;
        
        private double current_time = 72;

        public event EventHandler<OnBirthdayEventArgs> OnCakeReady;
        public event EventHandler<OnBirthdayEventArgs> OnBallsReady;
        public event EventHandler<OnBirthdayEventArgs> OnBirthdayHappens;

        public BirthdayTimer(){}

        public void Start()
        {
            while (current_time > 0)
            {
                current_time--;
                $"{current_time}h until Birthday".Print();

                if (current_time == 20)
                    OnBallsReady(this, new OnBirthdayEventArgs());
                if (current_time == 5)
                    OnCakeReady(this, new OnBirthdayEventArgs());
            }

            OnBirthdayHappens(this, new OnBirthdayEventArgs());
        }

        public static void StaticMethod() => "Static method works".Print();
    }

    public class Birthday
    {
        private readonly string name;
        public Birthday(string name)
        {
            this.name = name;

            var bt = new BirthdayTimer();
            
            bt.OnBirthdayHappens += Congrats;
            bt.OnBallsReady += BallsReady;
            bt.OnCakeReady += CakeReady;
            
            bt.Start();
        }
        void BallsReady(object? sender, OnBirthdayEventArgs e) => $"Dad hung balloons!".Print();
        void CakeReady(object? sender, OnBirthdayEventArgs e) => $"Mom baked a cake!".Print();
        void Congrats(object? sender, OnBirthdayEventArgs e) => $"Happy Birthday, {name}!!!".Print();
    }