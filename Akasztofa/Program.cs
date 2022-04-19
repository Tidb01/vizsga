using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Random;
using System.Data.SqlClient; // ez kell hogy csatlakozzon az adatbázishoz
using System.Data;
using System.ComponentModel;

namespace Akasztofa
{
    namespace ConnectingToSQLServer
    {

        

        class Program
        {
            private static object console;

            private static void printHangman(int wrong)

            {
                if (wrong == 0)
                {
                    Console.WriteLine("\n+---+");
                    Console.WriteLine("+   |+");
                    Console.WriteLine("+   |+");
                    Console.WriteLine("+   |+");
                    Console.WriteLine("+ ====+");
                }
                else if (wrong == 1)
                {
                    Console.WriteLine("+---+");
                    Console.WriteLine("+o  | +");
                    Console.WriteLine("+|  |+");
                    Console.WriteLine("+   |+");
                    Console.WriteLine("+ ====+");


                }
                else if (wrong == 2)
                {
                    Console.WriteLine("+  ---+");
                    Console.WriteLine("+  o  | +");
                    Console.WriteLine("+ /|  |+");
                    Console.WriteLine("+     |+");
                    Console.WriteLine("+ ====+");


                }
                else if (wrong == 3)
                {
                    Console.WriteLine("+  ---+");
                    Console.WriteLine("+  o  | +");
                    Console.WriteLine("+ /|\\|+");
                    Console.WriteLine("+     |+");
                    Console.WriteLine("+ ====+");


                }
                else if (wrong == 4)
                {
                    Console.WriteLine("+  ---+");
                    Console.WriteLine("+  o  | +");
                    Console.WriteLine("+ /|\\|+");
                    Console.WriteLine("+ /   |+");
                    Console.WriteLine("+ ====+");


                }
                else if (wrong == 5)
                {
                    Console.WriteLine("+  ---+");
                    Console.WriteLine("+  o  | +");
                    Console.WriteLine("+ /|\\|+");
                    Console.WriteLine("+ / \\|+");
                    Console.WriteLine("+ ====+");


                }

            }

            private static int printWord(List<char> guessedLetter, String randomWord)

            {

                int counter = 0;
                int rightletters = 0;
                foreach (char c in randomWord)
                {
                    if (guessedLetter.Contains(c))
                    {
                        Console.Write(c + "");
                        rightletters++;
                    }
                    else
                    {
                        Console.Write(" ");

                    }
                    counter++;

                }
                return rightletters;
            }

            private static void printLine(string randomWord)
            {
                Console.Write("\r");
                foreach (char c in randomWord)
                {
                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                    Console.Write("\u0305 ");

                }
            }

            static void Main(string[] args)


            {
                Console.WriteLine("Getting Connection");

                var datasource = @"ezaz.database.windows.net";// ide kéne a szervered
                var database = "EZAZ"; // Adatbázis neve
                var username = "Zsombor"; // felhasználó a servernek a connectionhez
                var password = "Zsozso0620"; //jelszó

                string ConnectionString = @"Data Source=ezaz.database.windows.net;Initial Catalog=EZAZ;User ID=Zsombor;Password=Zsozso0620;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


                SqlConnection conn = new SqlConnection(ConnectionString);


                try
                {
                    Console.WriteLine("Openning Connection ...");

                    //open connection
                    conn.Open();

                    Console.WriteLine("Connection successful!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }


                const string connectionString = "Data Source = ezaz.database.windows.net; Initial Catalog = EZAZ; User ID = Zsombor; Password = Zsozso0620; Connect Timeout = 30; Encrypt = True; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
                DataTable table = new DataTable("words");

                using (var connect = new SqlConnection(connectionString))
                {
                    Console.WriteLine("Sikeres csatlakozás.");

                    string command = "SELECT word FROM words";

                    using (var cmd = new SqlCommand(command, connect))
                    {
                        Console.WriteLine("A parancs sikeresen létre lett hozva");

                        SqlDataAdapter adapt = new SqlDataAdapter(cmd);

                        connect.Open();
                        Console.WriteLine("connection opened successfuly");
                        adapt.Fill(table);
                        connect.Close();
                        Console.WriteLine("connection closed successfuly");
                    }


                    
                }
                Console.Read();



                Console.WriteLine("Üdvözlégy idegen");
                Console.WriteLine("---------------------------------------------");

                Random random = new Random();
                List<String> szotar = new List<String> { "hello" };
                int index = random.Next(szotar.Count);
                String randomW = szotar[index];

                foreach (char c in randomW)
                {
                    Console.Write(" _ ");

                }
                int guessed = randomW.Length;
                int wrong = 0;
                List<char> current = new List<char>();
                int currentright = 0;

                while (wrong != 5 && currentright != guessed)
                {
                    Console.Write("\nTippelt betük: ");
                    foreach (char letter in current)
                    {
                        Console.Write(letter + " ");

                    }
                    Console.Write("\nTippelj egy betüt: ");
                    char letterguessed = Console.ReadLine()[0];

                    if (current.Contains(letterguessed))
                    {
                        Console.Write("\r\nEz már volt!");
                        printHangman(wrong);
                        currentright = printWord(current, randomW);
                        printLine(randomW);

                    }
                    else
                    {
                        bool right = false;
                        for (int i = 0; i < randomW.Length; i++) { if (letterguessed == randomW[i]) { right = true; } }

                        if (right)
                        {
                            printHangman(wrong);
                            current.Add(letterguessed);
                            currentright = printWord(current, randomW);
                            Console.Write("\r\n");
                            printLine(randomW);
                        }
                        else
                        {
                            wrong++;
                            current.Add(letterguessed);
                            printHangman(wrong);
                            currentright = printWord(current, randomW);
                            Console.Write("\r\n");
                            printLine(randomW);
                        }
                    }
                }
                Console.WriteLine("\r\nVége a játéknak!");
            }

        }

    }
}
