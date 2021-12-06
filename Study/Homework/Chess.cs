

namespace Study
{
    public class Chess
    {
       
        public char[,] GameDesk = new char[8, 8];
        public char[,] DisplayDesk = new char[18, 18];


        public void Play()
        {
            //System.Console.OutputEncoding = System.Text.Encoding.UTF8; // Uncomment if using new terminal 
            
            Console.Clear();

            DeeUseless.Print("Press Enter to start game", "green");
            bool is_started = false;
            while (!is_started)
            {

                var input = Console.ReadKey();

                if (input.Key == ConsoleKey.Escape)
                    break;
                else if (input.Key == ConsoleKey.Enter)
                {

                    is_started = true;

                    Console.WindowWidth = 40;
                    Console.WindowHeight = 20;

                    FillGameDesk();
                    PrintDesk();

                    bool is_finished = false;
                    while(!is_finished)
                    {
                        
                        MoveSelection();
                        
                        //PrintDesk();
                        is_selected = false;
                    }

                }
                else
                {
                    Console.Clear();
                    DeeUseless.Print("Press Enter to start game", "green");
                }
            }



            //PrintG();
        }



        void FillGameDesk()
        {

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    GameDesk[1, i] = '♟';
                    GameDesk[6, i] = '♙';
                }

            }

            GameDesk[0, 0] = '♜'; GameDesk[7, 0] = '♖'; GameDesk[0, 7] = '♜'; GameDesk[7, 7] = '♖';
            GameDesk[7, 6] = '♘'; GameDesk[0, 6] = '♞'; GameDesk[7, 1] = '♘'; GameDesk[0, 1] = '♞';
            GameDesk[7, 2] = '♗'; GameDesk[0, 2] = '♝'; GameDesk[7, 5] = '♗'; GameDesk[0, 5] = '♝';
            GameDesk[7, 4] = '♕'; GameDesk[0, 4] = '♛';
            GameDesk[7, 3] = '♔'; GameDesk[0, 3] = '♚';


        }
        void PrintDesk()
        {
            DeeUseless.Print(DisplayDesk[5,5]);

            FillDisplayDesk();
            for (int i = 0; i <= 17; i++)
            {
                
                for (int j = 0; j <= 17; j++)
                {
                    if (DisplayDesk[i, j] == '*')
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;
                        
                    }
                    else if (DisplayDesk[i, j] == '!')
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (DisplayDesk[i, j] == '=')
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (DisplayDesk[i, j] == '+')
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (DisplayDesk[i, j] != '\u0000') //'\ u0000' s.IndexOf(DisplayDesk[i, j]) != -1
                    {
                        Console.Write(DisplayDesk[i, j]);
                        //Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                    
                }
                Console.Write("\n");
            }
        }
        void PrintG()
        {
            FillDisplayDesk();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(GameDesk[i, j]);
                    Console.Write(" ");
                }
                Console.Write("\n");
            }
        }

        public void FillDisplayDesk()
        {
            
            Console.Clear();
            string letters = "ABCDEFGH";
            int index = 0;
            int row = 0;
            int col = 0;

            /// <summary>
            /// Step 1, convert GameDesk data to player display and add a borders 
            /// </summary>
            
            for (int i = 2; i <= 17; i += 2)
            {
                // Fill characters in DisplayDesk
                for (int j = 2; j <= 17; j += 2)
                {

                    DisplayDesk[i, j] = GameDesk[row, col];

                    col++;
                    if (col == 8)
                        col = 0;
                }

                if (row == 8)
                    row = 0;
                row++;

                // Fill letters in DisplayDesk 
                DisplayDesk[0, i] = letters[index];
                if (index + 1 < letters.Length)
                    index++;
                // Fill numbers in DisplayDesk 
                DisplayDesk[i, 0] = index.ToString()[0];

            }

            /// <summary>
            /// Step 2, add UI selection element
            /// </summary>
            //for (int i = 2; i <= 17; i += 2)
            //{
            //    
            //    for (int j = 2; j <= 17; j += 2)
            //    {
            //        
            //    }
            //}


            

            /*
            DisplayDesk[7,12] = '!'; // No way to go
            DisplayDesk[9,12] = '!';

            DisplayDesk[7,9] = '='; // May to go
            DisplayDesk[9,9] = '=';

            
            */
            DisplayDesk[16, 0] = '8';
        }



        public bool is_selected = false;
        public int X = 2; public int X_selected = 2;
        public int Y = 1; public int Y_selected = 1;
        
        public void MoveCharacter(int x_old, int y_old, int x_new, int y_new)
        {
            GameDesk[x_new, y_new] = GameDesk[x_old, y_old];
            GameDesk[x_old, y_old] = ' '; 
        }

        public void MoveSelection()
        {
            bool ready = false;

            while (!is_selected)
            {
            
                var input = Console.ReadKey();

                if (input.Key == ConsoleKey.LeftArrow)
                {
                    if (X - 2 >= 2)
                        X -= 2;
                }
                else if (input.Key == ConsoleKey.RightArrow)
                {
                    if (X + 2 <= 17)
                        X += 2;
                }
                else if (input.Key == ConsoleKey.UpArrow)
                {
                    if (Y - 2 >= 0)
                        Y -= 2;
                }
                else if (input.Key == ConsoleKey.DownArrow)
                {
                    if (Y + 2 <= 16)
                        Y += 2;
                }
                else if (input.Key == ConsoleKey.Enter)
                {
                    MoveCharacter(1, 2, 5, 3);
                    CleanPrev(true);
                    X_selected = X;
                    Y_selected = Y;
                    is_selected = true;
                   
                }
                
                void CleanPrev(bool clean_selected = false)
                { 
                    for(int i = 0; i <= 17; i++)
                    {
                        for(int j = 0; j <= 17; j++)
                        {
                            if(DisplayDesk[i,j] == '*')
                                DisplayDesk[i,j] = '\u0000';
                            if(DisplayDesk[i,j] == '=' && ready)
                                DisplayDesk[i,j] = '\u0000';
                            if(DisplayDesk[i,j] == '=' && clean_selected == true)
                                DisplayDesk[i,j] = '\u0000';
                            
                        }
                    }
                }

                CleanPrev();


                if(DisplayDesk[Y, X] != '=' && DisplayDesk[Y+2, X] != '=')
                    {DisplayDesk[Y, X] = '*'; DisplayDesk[Y+2, X] = '*';}
                else if (DisplayDesk[Y, X] != '=' && DisplayDesk[Y+2, X] == '=')
                    {DisplayDesk[Y, X] = '*'; DisplayDesk[Y+2, X] = '=';}
                else if (DisplayDesk[Y, X] == '=' && DisplayDesk[Y+2, X] != '=')
                    {DisplayDesk[Y, X] = '='; DisplayDesk[Y+2, X] = '*';}
                if (is_selected)
                    {DisplayDesk[Y_selected, X_selected] = '=';
                    DisplayDesk[Y_selected+2, X_selected] = '=';
                ready = true;}
                PrintDesk();
                
            }
            

        }

    }

     class UISelection
     {
        public bool is_selected = false;
        public int X = 2;
        public int Y = 1;
        
        

        public void MoveSelection()
        {
            while (!is_selected)
            {
            
                var input = Console.ReadKey();

                if (input.Key == ConsoleKey.LeftArrow)
                {
                    if (X - 2 >= 3)
                        X -= 2;
                }
                else if (input.Key == ConsoleKey.RightArrow)
                {
                    if (X + 2 <= 16)
                        X += 2;
                }
                else if (input.Key == ConsoleKey.UpArrow)
                {
                    if (Y + 2 >= 0)
                        Y += 2;
                }
                else if (input.Key == ConsoleKey.DownArrow)
                {
                    if (Y + 2 <= 17)
                        Y += 2;
                }
                else if (input.Key == ConsoleKey.Enter)

                {
                    is_selected = true;

                }
                    

            }
            
            

        }
        
            

     }
}
