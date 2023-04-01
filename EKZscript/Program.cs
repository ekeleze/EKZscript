using EKZ_UWS.GoCode;
using EKZ_UWS._9xCode;
using System;

using static System.ConsoleColor;

namespace EKZ_UWS
{
    class Program
    {
        public static Dictionary<string, string> Strings = new Dictionary<string, string>() { };

        public static Dictionary<string, int> Integers = new Dictionary<string, int>() { };

        public static Dictionary<string, bool> Booleans = new Dictionary<string, bool>() { };

        public static bool isRunning = true;
        
        public static string fuckingprogramname = null;
        public static bool isif = false;
        public static bool badif = false;
        //public static string intorstring = "unsure";
        public static string string1 = null;
        public static string string2 = null;
        public static int int1 = 0;
        public static int int2 = 0;
        public static void print(string str)
        {
            Console.WriteLine(str);
        }

        public static void log(System.ConsoleColor colour, string str)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(str);
        }

        public static void write(string str)
        {
            Console.Write(str);
        }

        public static void textcolour(System.ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
        }

        public static void highlightcolour(System.ConsoleColor colour)
        {
            Console.BackgroundColor = colour;
        }

        public static void sleep(int time)
        {
            Thread.Sleep(time);
        }

        public static string Toggle = "go";
        public static string mode = "ekzscript";
        public static string theysaid = null;
        public static ConsoleKey keypressed = ConsoleKey.O;
        public static int count = 1;
        public static String endmessage = "Process has ended.";
        public static Boolean hasbeenregistered = false;


        static void Main(string[] args)
        {
            Console.WriteLine("Starting EKZscript...");
            string fileName = "";
            foreach (string arg in args)
            {
                fileName = arg;
            }

            if (isRunning)
            {
                if (fileName.Contains(".goexe") || fileName.Contains(".gexe"))
                {
                    mode = "go";
                    print("Mode: GoCode\n");
                }

                if (fileName.Contains(".9xc"))
                {
                    mode = "9x";
                    print("Mode: 9xCode\n");
                }

                if (fileName.Contains(".ekz") || fileName.Contains(".ekzscript"))
                {
                    mode = "ekzscript";
                    print("Mode: EKZscript\n");
                }

                //var content = File.ReadAllLines(fileName).Split("|");
                //var content = File.ReadAllLines("" + args);
                string[] lines = File.ReadAllLines(fileName);
                List<string> content = new List<string>();
                foreach (string line in lines)
                { 
                    string[] parts = line.Split(" | ");
                    content.AddRange(parts);
                }
                
                if (mode == "ekzscript")
                {
                    

                    foreach (string line in content)
                    {
                        if (line == "stop")
                        {
                            isRunning = false;
                        }
                        else if (line == "go" && badif == false)
                        {
                            Toggle = "go";
                        }
                        else if (line == "9x" && badif == false)
                        {
                            Toggle = "9x";
                        }
                        else if (Toggle == "go" && badif == false)
                        {
                            GoCodeClass GoCodeHandler = new GoCodeClass();
                            GoCodeHandler.RunGo(line);
                        }
                        else if (Toggle == "9x" && badif == false)
                        {
                            NineX NineXHandler = new NineX();
                            NineXHandler.RunNine(line);
                        }
                        else if (line == "break")
                        {
                            badif = false;
                            isif = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid toggle value.");
                            Console.ReadKey();
                        }
                    }
                }
                else if (mode == "go")
                {
                    foreach (string line in content)
                    {
                        GoCodeClass GoCodeHandler = new GoCodeClass();
                        GoCodeHandler.RunGo(line);
                    }
                }
                else if (mode == "9x")
                {
                    foreach (string line in content)
                    {
                        NineX NineXHandler = new NineX();
                        NineXHandler.RunNine(line);
                    }
                }
            }
            Console.ForegroundColor = White;
        }
    }
}