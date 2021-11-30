using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    public abstract class ChristmasPlace
    {
        private double decorationsSquare;
        public double DecorationsSquare
        {
            get
            {
                return decorationsSquare;
            }
            set
            {
                decorationsSquare = DeeU.CheckLessZero(value);
            }
        }
        private int availableSockets_Count;
        public int AvailableSockets_Count
        {
            get
            {
                return availableSockets_Count;
            }
            set
            {
                availableSockets_Count = DeeU.CheckLessZero(value);
            }
        }

        public ChristmasPlace(double decorationsSquare, int availableSockets_Count)
        {
           DecorationsSquare = decorationsSquare;
           AvailableSockets_Count = availableSockets_Count;
        }

    }

    public class ChristmasTree : ChristmasPlace
    {
        private int height;
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = DeeU.CheckLessZero(value);
            }
        }
        public ChristmasTree(double decorationSquare, int availableSockets_Count, int height) : base(decorationSquare, availableSockets_Count)
        {
            Height = height;
        }

    }
    public class Showcase : ChristmasPlace
    {
        public Showcase(double decorationSquare, int availableSockets_Count) : base(decorationSquare, availableSockets_Count)
        {

        }
    }




    public abstract class Decoration
    {
        private double decorationSquare;
        /// <summary>
        /// Square of the decoration
        /// </summary>
        public double DecorationSquare
        {
            get
            {
                return decorationSquare;
            }
            set
            {
                decorationSquare = DeeU.CheckLessZero(value);
            }
        }
        public bool isSocketRequired;

        public Decoration(double decorationSquare, bool SocketRequired)
        {
            DecorationSquare = decorationSquare;
            isSocketRequired = SocketRequired;
        }
    }

    public class Garland : Decoration
    {
        private int modesCount, colorsCount;
        public int ModesCount
        {
            get
            {
                return modesCount;
            }
            set
            {
                modesCount = DeeU.CheckLessZero(value);
                if (modesCount == 0)
                    modesCount = 1;
            }
        }
        public int ColorsCount
        {
            get
            {
                return colorsCount;
            }
            set
            {
                colorsCount = DeeU.CheckLessZero(value);
                if (colorsCount == 0)
                    colorsCount = 1;
            }
        }

        public Garland(double decorationSquare, bool SocketRequired, int modesCount, int colorsCount) : base(decorationSquare, SocketRequired)
        {
            ModesCount = modesCount;
            ColorsCount = colorsCount;
        }
    }

    public class Toy : Decoration
    {
        public bool isExist = true;
        private double weight;
        /// <summary>
        /// Weight of the Toy
        /// </summary>
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = DeeU.CheckLessZero(value);
            }
        }
        private int fragility;

        /// <summary>
        /// Fragility of the Toy. 0 <= value <= 100. Fragility = 0, if not in range
        /// </summary>
        public int Fragility
        {
            get
            {
                return fragility;
            }
            set
            {
                if (value < 0 || value > 100)
                    fragility = 0;
                else
                    fragility = value;
            }
        }
        public Toy(double decorationSquare, bool SocketRequired, double weight, int fragility) : base(decorationSquare, SocketRequired)
        {
            Weight = weight;
            Fragility = fragility;
        }

        
    }

    public class ChristmasManager
    {
        public double availableTreeSquare;
        public double availableShowcaseSquare;

        public int availableTreeSockets;
        public int availableShowcaseSockets;

        public ChristmasTree ChristmasTree;
        public Showcase Showcase;

        Toy[] TreeToys;
        Toy[] ShowcaseToys;

        Garland[] TreeGarlands;
        Garland[] ShowcaseGarlands;

        public ChristmasManager(ChristmasTree christmasTree, Showcase showcase)
        {
            
            ChristmasTree = christmasTree;
            Showcase = showcase;

            availableTreeSquare = ChristmasTree.DecorationsSquare;
            availableShowcaseSquare = Showcase.DecorationsSquare;

            availableTreeSockets = ChristmasTree.AvailableSockets_Count;
            availableShowcaseSockets = Showcase.AvailableSockets_Count;

        }

        public void DecorateTree(Toy input)
        {
            if (availableTreeSquare - input.DecorationSquare >= 0)
            {
                if (input.isSocketRequired && (availableTreeSockets - 1 >= 0))
                { 
                    availableTreeSquare -= input.DecorationSquare;
                    availableTreeSockets--;
                    TreeToys = DeeU.Add(TreeToys, input);
                    TreeToys = DeeU.Sort(TreeToys);
                }
                else if (!input.isSocketRequired)
                {
                    availableTreeSquare -= input.DecorationSquare;
                    TreeToys = DeeU.Add(TreeToys, input);
                    TreeToys = DeeU.Sort(TreeToys);
                }
                    
            }

            
        }
        public void DecorateTree(Garland input)
        {
            if (availableTreeSquare - input.DecorationSquare >= 0) 
            {
                if (input.isSocketRequired && (availableTreeSockets - 1 >= 0)) //If enough space and socket need
                {
                    availableTreeSquare -= input.DecorationSquare;
                    availableTreeSockets--;
                    TreeGarlands = DeeU.Add(TreeGarlands, input);
                }
                else if (!input.isSocketRequired) // If enough space and socket doesn't need
                {
                    availableTreeSquare -= input.DecorationSquare;
                    TreeGarlands = DeeU.Add(TreeGarlands, input);
                }

            }
            else
            {

                double temp_square = 0; int temp_sockets = 0;
                Toy[] temp_toys = new Toy[0];
                if (TreeToys != null)
                {
                    
                    temp_toys = new Toy[TreeToys.Length];
                    


                    for (int i = 0; i < TreeToys.Length; i++)
                    {
                        if ((availableTreeSquare + temp_square - input.DecorationSquare >= 0) && (availableTreeSockets + temp_sockets - 1 >= 0))
                        {
                            DeeU.Print("eeeee");
                            availableTreeSquare += (temp_square - input.DecorationSquare);
                            availableTreeSockets += (temp_sockets - 1);
                            foreach (var el in temp_toys)
                            {
                                TreeToys = new Toy[0];
                                if (el != null)
                                    if (el.isExist)
                                        TreeToys = DeeU.Add(temp_toys, el);
                            }
                            TreeToys = temp_toys;
                            TreeGarlands = DeeU.Add(TreeGarlands, input);
                            
                            break;
                        }

                        temp_square += TreeToys[i].DecorationSquare;
                        temp_sockets++;
                        
                        if (TreeToys[i] == null)
                        {
                            temp_toys[i] = new Toy(1,false,1,1);
                            TreeToys[i] = new Toy(1,false,1,1);
                            temp_toys[i].isExist = false;
                        }
                        
                        
                    }


                }


            }

        }
        public void DecorateShowcase(Toy input)
        {
            if (availableShowcaseSquare - input.DecorationSquare >= 0)
            {
                if (input.isSocketRequired && (availableShowcaseSockets - 1 >= 0))
                    { availableShowcaseSquare -= input.DecorationSquare; availableShowcaseSockets--; }
                else if (!input.isSocketRequired)
                    availableShowcaseSquare -= input.DecorationSquare;
            }
        }

        public void Print()
        {
            if (TreeGarlands != null)
            {
                foreach (var el in TreeGarlands)
                {
                    DeeU.Print($"Garland, square {el.DecorationSquare}, need socket? {el.isSocketRequired}, mode's count {el.ModesCount}, color's count {el.ColorsCount}");
                }
            }
            if (TreeToys != null)
            {
                foreach (var el in TreeToys)
                {
                    DeeU.Print($"Toy, square {el.DecorationSquare}, need socket? {el.isSocketRequired}");
                    //DeeU.Print(el.DecorationSquare);

                }
            }

            if(availableTreeSockets > 0)
                DeeU.Print($"Available tree sockets: {availableTreeSockets}", "green");
            else
                DeeU.Print("Available tree sockets: 0", "red");

            if (availableTreeSquare > 0)
                DeeU.Print($"Available tree square: {availableTreeSquare}", "green");
            else
                DeeU.Print("Available tree square: 0", "red");
        }
    }
}
