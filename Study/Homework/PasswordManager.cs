//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;
//using System.Threading.Tasks;

namespace Study
{
    public class PasswordManager
    {
        //
        /// <summary>
        /// Local password. Using for send them from console to PasswordData class
        /// </summary>

        string password { get; set; }

        /// <summary>
        /// Local username. Using for send them from console to PasswordData class
        /// </summary>

        string username { get; set; }
        /// <summary>
        /// Local servicename. Using for send them from console to PasswordData class
        /// </summary>
        string servicename { get; set; }
        /// <summary>
        /// Directory of the file. Then it will be connected with file_name to create full path
        /// </summary>
        string directory_path { get; set; }
        /// <summary>
        /// File name
        /// </summary>
        string file_name;
        /// <summary>
        /// Path of the file. Using for send them from console to PasswordData class
        /// </summary>
        string filepath;
        public void Start()
        {

            Console.Clear();
            while(true)
            {
                Select();
            }
            

        }
        /// <summary>
        /// Choice of possibilities: create/change file, open file, create Pass Lib
        /// </summary>
        void Select()
        {
            DeeUseless.Print("Chose what to do: \n Create - Create/Change file \n Open - display Password data \n Create Lib - create local Password lib in RAM");
            string input = Console.ReadLine();

            bool is_ready = false;
            while (!is_ready)
            {
                
                if (input == "Create" || input == "Open" || input == "Create Lib")
                    is_ready = true;
                else
                {
                    Console.Clear();
                    DeeUseless.Print("Chose what to do: \n Create - Create/Change file \n Open - display Password data \n Create Lib - create local Password lib in RAM");
                    input = Console.ReadLine();
                    
                }
                    
            }
                

            if (input == "Create")
            {
                SelectFile();
                EnterData();

                File.CreateText(filepath).Dispose();
                
                var PassData = new PasswordData(password, username, servicename, filepath);

                
            }
            
            else if (input == "Create Lib")
            {
                Console.Clear();

                DeeUseless.Print(">Password lib creation\n", "green");


                Console.Write("Enter Passwords count: ");
                int count = DeeUseless.ReadInt();
                PasswordData[] PassLib = new PasswordData[count];
                for (int i = 0; i < count; i++)
                {
                    Console.Write("\n");
                    EnterData();
                    PassLib[i] = new PasswordData(password, username, servicename);
                }

                foreach(PasswordData el in PassLib)
                {
                    el.PrintData();
                }
            }
            else if (input == "Open")
            {
                SelectFile(true);

                Console.Clear();
                
                var PassData = new PasswordData(filepath);
                PassData.PrintData();
            }

        }
        /// <summary>
        /// Prompt the user for the correct file path, file selection
        /// </summary>
        /// <param name="is_open"></param>
        void SelectFile(bool is_open = false)
        {
            Console.Clear();
            Console.Write("Enter the directory: ");
            directory_path = Console.ReadLine();



            while (true)
            {

                if (Directory.Exists(directory_path))
                    break;

                Console.Clear();
                DeeUseless.Print("Path not found", "red");
                Console.Write("Enter the name of the file: ");
                directory_path = Console.ReadLine();
            }


            Console.Clear();
            DeeUseless.Print($"> {directory_path}", "green");

            Console.Write("Enter the File name: ");


            file_name = Console.ReadLine();
            filepath = Path.Combine(directory_path, file_name + ".txt");

            if(is_open)
            {
                while (true)
                {

                    if (File.Exists(filepath))
                        break;

                    Console.Clear();
                    DeeUseless.Print("File not found", "red");
                    Console.Write("Enter the File name: ");

                    file_name = Console.ReadLine();
                    filepath = Path.Combine(directory_path, file_name + ".txt");
                }
            }

        }
        /// <summary>
        /// Entering data to local var's
        /// </summary>
        void EnterData()
        {
            Console.Write("Enter the Service Name: ");
            servicename = Console.ReadLine();

            Console.Write("Enter the Username: ");
            username = Console.ReadLine();

            Console.Write("Enter the Password: ");
            password = Console.ReadLine();

        }

    }
    /// <summary>
    /// Class PasswordData with methods to Read/Create new Password
    /// </summary>
    public class PasswordData
    {
        public const string Key = "PassMnger";
        public string Password;
        public string Username;
        public string ServiceName;
        public string filePath;

        public PasswordData(string password, string username, string servicename, string path)
        {

            Password = CheckInput(password); Username = CheckInput(username); ServiceName = CheckInput(servicename);
            filePath = path;
            Create();
        }
        public PasswordData(string password, string username, string servicename)
        {

            Password = CheckInput(password); Username = CheckInput(username); ServiceName = CheckInput(servicename);
            
        }
        public PasswordData(string path, bool is_lib = false)
        {
            if (!File.Exists(path))
            {
                DeeUseless.Print("File not found");
                return;
            }
            else
            {
                if (!is_lib)
                {


                    string[] FileText = File.ReadAllLines(path);
                    if (FileText[0] != "PassMnger") { DeeUseless.Print("Wrong data type"); return; }

                    else
                    {
                        Password = CheckInput(FileText[1]);
                        Username = CheckInput(FileText[2]);
                        ServiceName = CheckInput(FileText[3]);
                    }
                }
                
            }
            
            
        }

        /// <summary>
        /// Create new Password in local disk
        /// </summary>
        public void Create()
        {
            using (StreamWriter outputFile = new StreamWriter(filePath))
            {
                outputFile.Write($"{Key}\n{Password}\n{Username}\n{ServiceName}");
                outputFile.Close();
                outputFile.Dispose();
                
            }
            
            DeeUseless.Print($"Succesfully created new Password data in\n{filePath}", "green");
        }
        /// <summary>
        /// Not ready :)
        /// </summary>
        /// <param name="new_password"></param>
        /// <param name="new_username"></param>
        /// <param name="new_servicename"></param>
        public void Change(string new_password, string new_username, string new_servicename)
        {

            Password = CheckInput(new_password); Username = CheckInput(new_username); ServiceName = CheckInput(new_servicename);
            FileStream fileStream = null;

            StreamWriter output = new StreamWriter(fileStream);

            output.Write($"{Key}\n{Password}\n{Username}\n{ServiceName}");
            output.Close();
        }

        /// <summary>
        /// Print Password data
        /// </summary>
        public void PrintData()
        {
            DeeUseless.Print($"> {filePath}", "green");
            DeeUseless.Print($"From {ServiceName}\nPassword: {Password} \nUsername: {Username}");
        }

        /// <summary>
        /// Check if input string == null or empty, if true - replace input to "Wrong data"
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string CheckInput(string input)
        {
            if (string.IsNullOrEmpty(input))
                input = "Wrong data";
            return input;
        }

    }
}
