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
                decorationsSquare = DeeUseless.CheckLessZero(value);
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
                availableSockets_Count = DeeUseless.CheckLessZero(value);
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
                height = DeeUseless.CheckLessZero(value);
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
                decorationSquare = DeeUseless.CheckLessZero(value);
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
                modesCount = DeeUseless.CheckLessZero(value);
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
                colorsCount = DeeUseless.CheckLessZero(value);
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
                weight = DeeUseless.CheckLessZero(value);
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
                    TreeToys = DeeUseless.Add(TreeToys, input);
                    TreeToys = DeeUseless.Sort(TreeToys);
                }
                else if (!input.isSocketRequired)
                {
                    availableTreeSquare -= input.DecorationSquare;
                    TreeToys = DeeUseless.Add(TreeToys, input);
                    TreeToys = DeeUseless.Sort(TreeToys);
                }
                    
            }

            //ClearNulls();
        }
        public void DecorateTree(Garland input)
        {
            if (availableTreeSquare - input.DecorationSquare >= 0) 
            {
                if (input.isSocketRequired && (availableTreeSockets - 1 >= 0)) //If enough space and socket need
                {
                    availableTreeSquare -= input.DecorationSquare;
                    availableTreeSockets--;
                    TreeGarlands = DeeUseless.Add(TreeGarlands, input);
                }
                else if (!input.isSocketRequired) // If enough space and socket doesn't need
                {
                    availableTreeSquare -= input.DecorationSquare;
                    TreeGarlands = DeeUseless.Add(TreeGarlands, input);
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
                            availableTreeSquare += (temp_square - input.DecorationSquare);
                            availableTreeSockets += (temp_sockets - 1);
                            foreach (var el in temp_toys)
                            {
                                TreeToys = new Toy[0];
                                if (el != null)
                                    if (el.isExist)
                                        TreeToys = DeeUseless.Add(temp_toys, el);
                            }
                            TreeToys = temp_toys;
                            TreeGarlands = DeeUseless.Add(TreeGarlands, input);
                            
                            break;
                        }

                        temp_square += TreeToys[i].DecorationSquare;
                        temp_sockets++;
                        
                        
                        temp_toys[i] = TreeToys[i];

                        temp_toys[i].isExist = false;
                        
                        
                    }


                }


            }
            ClearNulls();

            
            availableTreeSockets = ChristmasTree.AvailableSockets_Count;
            availableTreeSquare = ChristmasTree.DecorationsSquare;

            foreach(var el in TreeGarlands)
                if(el.isSocketRequired)
                    availableTreeSockets--;
            foreach (var el in TreeToys)
                if (el.isSocketRequired)
                    availableTreeSockets--;

            foreach (var el in TreeGarlands)
            {

                availableTreeSquare -= el.DecorationSquare;

            }
                
            foreach (var el in TreeToys)
            {
                availableTreeSquare -= el.DecorationSquare;
            }
                

        }
        public void DecorateShowcase(Toy input)
        {
            if (availableShowcaseSquare - input.DecorationSquare >= 0)
            {
                if (input.isSocketRequired && (availableShowcaseSockets - 1 >= 0))
                {
                    availableShowcaseSquare -= input.DecorationSquare;
                    availableShowcaseSockets--;
                    ShowcaseToys = DeeUseless.Add(ShowcaseToys, input);
                    ShowcaseToys = DeeUseless.Sort(ShowcaseToys);
                }
                else if (!input.isSocketRequired)
                {
                    availableShowcaseSquare -= input.DecorationSquare;
                    ShowcaseToys = DeeUseless.Add(ShowcaseToys, input);
                    ShowcaseToys = DeeUseless.Sort(ShowcaseToys);
                }

            }
            //ClearNulls();
        }
        public void DecorateShowcase(Garland input)
        {
            if (availableShowcaseSquare - input.DecorationSquare >= 0)
            {
                if (input.isSocketRequired && (availableShowcaseSockets - 1 >= 0)) //If enough space and socket need
                {
                    availableShowcaseSquare -= input.DecorationSquare;
                    availableShowcaseSockets--;
                    ShowcaseGarlands = DeeUseless.Add(ShowcaseGarlands, input);
                }
                else if (!input.isSocketRequired) // If enough space and socket doesn't need
                {
                    availableShowcaseSquare -= input.DecorationSquare;
                    ShowcaseGarlands = DeeUseless.Add(ShowcaseGarlands, input);
                }

            }
            else
            {

                double temp_square = 0; int temp_sockets = 0;
                Toy[] temp_toys = new Toy[0];
                if (Showcase != null)
                {

                    temp_toys = new Toy[ShowcaseToys.Length];



                    for (int i = 0; i < ShowcaseToys.Length; i++)
                    {
                        if ((availableShowcaseSquare + temp_square - input.DecorationSquare >= 0) && (availableShowcaseSockets + temp_sockets - 1 >= 0))
                        {
                            availableShowcaseSquare += (temp_square - input.DecorationSquare);
                            availableShowcaseSockets += (temp_sockets - 1);
                            foreach (var el in temp_toys)
                            {
                                ShowcaseToys = new Toy[0];
                                if (el != null)
                                    if (el.isExist)
                                        ShowcaseToys = DeeUseless.Add(temp_toys, el);
                            }
                            ShowcaseToys = temp_toys;
                            ShowcaseGarlands = DeeUseless.Add(ShowcaseGarlands, input);

                            break;
                        }

                        temp_square += ShowcaseToys[i].DecorationSquare;
                        temp_sockets++;


                        temp_toys[i] = ShowcaseToys[i];

                        temp_toys[i].isExist = false;


                    }


                }


            }
            ClearNulls();


            availableShowcaseSockets = Showcase.AvailableSockets_Count;
            availableShowcaseSquare = Showcase.DecorationsSquare;

            foreach (var el in ShowcaseGarlands)
                if (el.isSocketRequired)
                    availableShowcaseSockets--;
            foreach (var el in ShowcaseToys)
                if (el.isSocketRequired)
                    availableShowcaseSockets--;

            foreach (var el in ShowcaseGarlands)
            {

                availableShowcaseSquare -= el.DecorationSquare;

            }

            foreach (var el in ShowcaseToys)
            {
                availableShowcaseSquare -= el.DecorationSquare;
            }


        }
        public void Print()
        {
            if (TreeGarlands != null)
            {

                foreach (var el in TreeGarlands)
                {
                    
                    DeeUseless.Print($"Garland, square {el.DecorationSquare}, need socket? {el.isSocketRequired}, mode's count {el.ModesCount}, color's count {el.ColorsCount}");
                }
            }
            if (TreeToys != null)
            {
                foreach (var el in TreeToys)
                {
                    
                        DeeUseless.Print($"Toy, square {el.DecorationSquare}, need socket? {el.isSocketRequired}");

                }
            }

            if(availableTreeSockets > 0)
                DeeUseless.Print($"Available tree sockets: {availableTreeSockets}", "green");
            else
                DeeUseless.Print("Available tree sockets: 0", "red");

            if (availableTreeSquare > 0)
                DeeUseless.Print($"Available tree square: {availableTreeSquare}", "green");
            else
                DeeUseless.Print("Available tree square: 0", "red");




            if (ShowcaseGarlands != null)
            {

                foreach (var el in ShowcaseGarlands)
                {

                    DeeUseless.Print($"Garland, square {el.DecorationSquare}, need socket? {el.isSocketRequired}, mode's count {el.ModesCount}, color's count {el.ColorsCount}");
                }
            }
            if (ShowcaseToys != null)
            {
                foreach (var el in ShowcaseToys)
                {

                    DeeUseless.Print($"Toy, square {el.DecorationSquare}, need socket? {el.isSocketRequired}");

                }
            }

            if (availableShowcaseSockets > 0)
                DeeUseless.Print($"Available Showcase sockets: {availableShowcaseSockets}", "green");
            else
                DeeUseless.Print("Available Showcase sockets: 0", "red");

            if (availableShowcaseSquare > 0)
                DeeUseless.Print($"Available Showcase square: {availableShowcaseSquare}", "green");
            else
                DeeUseless.Print("Available Showcase square: 0", "red");
        }

        void ClearNulls()
        {
            var temp_tree_toys = new Toy[0];
            var temp_showcase_toys = new Toy[0];

            var temp_tree_garlands = new Garland[0] ;
            var temp_showcase_garlands = new Garland[0] ;

            //if (TreeToys != null && ShowcaseToys != null && TreeGarlands != null && ShowcaseGarlands != null)
            if(TreeToys != null)
            {
                foreach (var el in TreeToys)
                {
                    if (el != null)
                        temp_tree_toys = DeeUseless.Add(temp_tree_toys, el);
                }
            }
            
            if ( ShowcaseToys != null)
            {
                foreach (var el in ShowcaseToys)
                {
                    if (el != null)
                        temp_showcase_toys = DeeUseless.Add(temp_showcase_toys, el);
                }
            }
            if(TreeGarlands != null)
            {
                foreach (var el in TreeGarlands)
                {
                    
                    if (el != null)
                        temp_tree_garlands = DeeUseless.Add(temp_tree_garlands, el);

                }
            }
            
            if(ShowcaseGarlands != null)
            {
                foreach (var el in ShowcaseGarlands)
                {
                    if (el != null)
                        temp_showcase_garlands = DeeUseless.Add(temp_showcase_garlands, el);
                }
            }
            
            TreeToys = temp_tree_toys;
            TreeGarlands = temp_tree_garlands;

            ShowcaseToys = temp_showcase_toys;
            ShowcaseGarlands = temp_showcase_garlands;

        }
    }
}
