using DeeULib;

namespace Study
{
    public interface IPlayer
    {
        public void Play();
        
    }
    public class FootboolPlayer : IPlayer
    {
        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if(value < 0)
                    age = 0;
                else
                    age = value;
            }
        }

        /// <summary>
        /// Name of the musician
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Create footbal player
        /// </summary>
        /// <param name="name">Name of the player</param>
        /// <param name="age">Age of the player</param>
        public FootboolPlayer(string name, int age)
        {
            Age = age;
            Name = name;
        }
        /// <summary>
        /// Start playing by Player
        /// </summary>
        public void Play()
        {
            if (Age >= 18)
                DeeU.Print($"{Name}, {Age} year's old is playing footbal", ConsoleColor.Blue);
            else
                DeeU.Print("Player is so little to play that perfect game", ConsoleColor.Red);
        }
    }
    public class Musician : IPlayer
    {
        /// <summary>
        /// Name of the musician
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Start playing by Player
        /// </summary>
        public void Play()
        {
            
            DeeU.Print($"{Name} is playing on {Instrument}", ConsoleColor.Magenta);
        }

        /// <summary>
        /// Instrument of the musician
        /// </summary>
        public MusicalInstrument Instrument;
        /// <summary>
        /// Create musician
        /// </summary>
        /// <param name="name">Name of the musician</param>
        /// <param name="instrument">Instrument of musician to play</param>
        public Musician(string name, MusicalInstrument instrument)
        {
            Name = name;
            Instrument = instrument;
        }
    }

    public enum MusicalInstrument
    {
        Piano,
        Pipe,
        Guitar,
        Harp
    }
}
