//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.IO;
//using System.Threading.Tasks;

namespace lessons
{
    public class PasswordManager
    {
        //
        /// <summary>
        /// Local password. Using for send them from console to PasswordData class
        /// </summary>
#pragma warning disable CS8618 // свойство "password", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        string password { get; set; }
#pragma warning restore CS8618 // свойство "password", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        /// <summary>
        /// Local username. Using for send them from console to PasswordData class
        /// </summary>
#pragma warning disable CS8618 // свойство "username", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        string username { get; set; }
#pragma warning restore CS8618 // свойство "username", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        /// <summary>
        /// Local servicename. Using for send them from console to PasswordData class
        /// </summary>
#pragma warning disable CS8618 // свойство "servicename", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        string servicename { get; set; }
#pragma warning restore CS8618 // свойство "servicename", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        /// <summary>
        /// Directory of the file. Then it will be connected with file_name to create full path
        /// </summary>
#pragma warning disable CS8618 // свойство "directory_path", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        string directory_path { get; set; }
#pragma warning restore CS8618 // свойство "directory_path", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        /// <summary>
        /// File name
        /// </summary>
#pragma warning disable CS8618 // поле "file_name", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        string file_name;
#pragma warning restore CS8618 // поле "file_name", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        /// <summary>
        /// Path of the file. Using for send them from console to PasswordData class
        /// </summary>
#pragma warning disable CS8618 // поле "filepath", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        string filepath;
#pragma warning restore CS8618 // поле "filepath", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
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
            DeeU.Print("Chose what to do: \n Create - Create/Change file \n Open - display Password data \n Create Lib - create local Password lib in RAM");
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
            string input = Console.ReadLine();
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.

            bool is_ready = false;
            while (!is_ready)
            {
                
                if (input == "Create" || input == "Open" || input == "Create Lib")
                    is_ready = true;
                else
                {
                    Console.Clear();
                    DeeU.Print("Chose what to do: \n Create - Create/Change file \n Open - display Password data \n Create Lib - create local Password lib in RAM");
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                    input = Console.ReadLine();
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
                    
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

                DeeU.Print(">Password lib creation\n", "green");


                Console.Write("Enter Passwords count: ");
                int count = DeeU.ReadInt();
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
#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
            directory_path = Console.ReadLine();
#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.



            while (true)
            {

                if (Directory.Exists(directory_path))
                    break;

                Console.Clear();
                DeeU.Print("Path not found", "red");
                Console.Write("Enter the name of the file: ");
#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
                directory_path = Console.ReadLine();
#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
            }


            Console.Clear();
            DeeU.Print($"> {directory_path}", "green");

            Console.Write("Enter the File name: ");


#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
            file_name = Console.ReadLine();
#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
            filepath = Path.Combine(directory_path, file_name + ".txt");

            if(is_open)
            {
                while (true)
                {

                    if (File.Exists(filepath))
                        break;

                    Console.Clear();
                    DeeU.Print("File not found", "red");
                    Console.Write("Enter the File name: ");

#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
                    file_name = Console.ReadLine();
#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
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
#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
            servicename = Console.ReadLine();
#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.

            Console.Write("Enter the Username: ");
#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
            username = Console.ReadLine();
#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.

            Console.Write("Enter the Password: ");
#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
            password = Console.ReadLine();
#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.

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
#pragma warning disable CS8618 // поле "filePath", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        public PasswordData(string password, string username, string servicename)
#pragma warning restore CS8618 // поле "filePath", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        {

            Password = CheckInput(password); Username = CheckInput(username); ServiceName = CheckInput(servicename);
            
        }
#pragma warning disable CS8618 // поле "Password", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
#pragma warning disable CS8618 // поле "filePath", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
#pragma warning disable CS8618 // поле "ServiceName", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
#pragma warning disable CS8618 // поле "Username", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        public PasswordData(string path, bool is_lib = false)
#pragma warning restore CS8618 // поле "Username", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
#pragma warning restore CS8618 // поле "ServiceName", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
#pragma warning restore CS8618 // поле "filePath", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
#pragma warning restore CS8618 // поле "Password", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        {
            if (!File.Exists(path))
            {
                DeeU.Print("File not found");
                return;
            }
            else
            {
                if (!is_lib)
                {


                    string[] FileText = File.ReadAllLines(path);
                    if (FileText[0] != "PassMnger") { DeeU.Print("Wrong data type"); return; }

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
            
            DeeU.Print($"Succesfully created new Password data in\n{filePath}", "green");
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
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
            FileStream fileStream = null;
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.

#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL, для параметра "stream" в "StreamWriter.StreamWriter(Stream stream)".
            StreamWriter output = new StreamWriter(fileStream);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL, для параметра "stream" в "StreamWriter.StreamWriter(Stream stream)".

            output.Write($"{Key}\n{Password}\n{Username}\n{ServiceName}");
            output.Close();
        }

        /// <summary>
        /// Print Password data
        /// </summary>
        public void PrintData()
        {
            DeeU.Print($"> {filePath}", "green");
            DeeU.Print($"From {ServiceName}\nPassword: {Password} \nUsername: {Username}");
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
