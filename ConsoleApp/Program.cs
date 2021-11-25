using System;
using System.IO;
using System.Linq;
namespace ConsoleApp
{
    class Program
    {
        public static string name;
        public static int ID;
        public static string Class;
        public static string Section;
        static void Main(string[] args)
        {
            Console.WriteLine("Rainbow school storing system");
            for(int i = 0; i < 99; )
            {
                Console.WriteLine("Enter 1 - to update / add teacher data and create file if it does not exist");
                Console.WriteLine("Enter 2 - to view teachers file data");
                Console.WriteLine("Enter 3 - to close the program");
                i = Convert.ToInt32(Console.ReadLine());
                if(i < 2 && i > 0)
                {
                    string dir = Directory.GetCurrentDirectory();
                    string filename = "data.txt";
                    Console.WriteLine("Add data or update by entring ID:");
                    ID = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("Class: ");
                    Class = Console.ReadLine();
                    Console.WriteLine("Section: ");
                    Section = Console.ReadLine();
                    if (File.Exists(filename))
                    {
                        string[] check = File.ReadAllLines(filename);
                        if (check.Contains("ID: " + ID))
                        {
                            for(int j = 0; j < check.Length; j++)
                            {
                                if(check[j].Contains("ID: " + ID))
                                {
                                    check[j + 1] = "Name: " + name;
                                    check[j + 2] = "Class: " + Class;
                                    check[j + 3] = "Section: " + Section;
                                    using (StreamWriter sw = File.CreateText(filename))
                                    {
                                        foreach(string line in check)
                                        {
                                            sw.WriteLine(line);
                                        }
                                    }
                                    Console.WriteLine("Date has been updated");
                                }
                            }
                        }
                        else
                        {
                            using (StreamWriter sw = File.AppendText(filename))
                            {
                                sw.WriteLine("ID: " + ID);
                                sw.WriteLine("Name: " + name);
                                sw.WriteLine("Class: " + Class);
                                sw.WriteLine("Section: " + Section);
                                sw.WriteLine("----------------------");
                            }
                            Console.WriteLine("Data has been Added");
                        }
                    }
                    else
                    {
                        File.CreateText(filename);
                        Console.WriteLine("storing file created");
                    }

                }
                if(i > 1 && i < 3)
                {
                    string filelocation = "data.txt";
                    if (File.Exists(filelocation))
                    {
                        string[] lines = File.ReadAllLines(filelocation);
                        foreach(string s in lines)
                        {
                            Console.WriteLine(s);
                        }
                    }
                    else
                    {
                        Console.WriteLine("storing file does not exist");
                    }
                }
                if(i >= 3)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
