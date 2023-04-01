using System.Text;
using System;
namespace EKZ_UWS.GoCode;
using static Program;

public class GoCodeClass
{
    public void RunGo(string line)
    {
        

        //log(ConsoleColor.Yellow, "Application.Start");

        count = count + 1;
        //log(ConsoleColor.Magenta, "LINE FOUND: CONTENT: " + line);
        if (line.StartsWith("#"))
        {
        }

        if (line.StartsWith(""))
        {
        }

        if (line.StartsWith("clear"))
        {
            Console.Clear();
        }

        if (line.StartsWith("sleep") && badif == false)
        {
            String howlong = line.Split("=")[1];
            int potato = Convert.ToInt32(howlong);
            sleep(potato);
        }

        if (line.StartsWith("input") && badif == false)
        {
            if (line == "input=")
            {
                textcolour(ConsoleColor.Blue);
                theysaid = Console.ReadLine();
            }
            else
            {
                String addon = line.Replace("input=", "");
                write(addon);
                textcolour(ConsoleColor.Blue);
                theysaid = Console.ReadLine();
            }
        }

        if (line.StartsWith("stop") && badif == false)
        {
            if (line == "stop=")
            {
                textcolour(ConsoleColor.Blue);
                log(ConsoleColor.Green, "Press any key to continue...");
                Console.ReadKey();
                Console.WriteLine();
            }
            else
            {
                String addon = line.Replace("stop=", "");
                textcolour(ConsoleColor.DarkRed);
                write(addon);
                textcolour(ConsoleColor.Blue);
                Console.ReadKey();
                Console.WriteLine();
            }
        }

        if (line.StartsWith("endmsg") && badif == false)
        {
            endmessage = line.Replace("endmsg=", "");
        }

        if (line.StartsWith("regprog") && badif == false)
        {
            if (hasbeenregistered)
            {
                log(ConsoleColor.Red,
                    "Attempted second register. Application may be attempting to reregister as another application!!!");
                
            }

            fuckingprogramname = line.Replace("regprog=", "");
            hasbeenregistered = true;
            if (!Directory.Exists(@"C:\content\prf\"))
            {
                Directory.CreateDirectory(@"C:\content\prf\");
                if (!Directory.Exists(@"C:\content\prf\" + fuckingprogramname + @"\"))
                {
                    Directory.CreateDirectory(@"C:\content\prf\" + fuckingprogramname + @"\");
                }
            }
            else if (!Directory.Exists(@"C:\content\prf\" + fuckingprogramname + @"\"))
            {
                Directory.CreateDirectory(@"C:\content\prf\" + fuckingprogramname + @"\");
            }
        }

        if (line.StartsWith("string") && badif == false)
        {
            string whythehellnotwork = line.Replace(@"string ", "");
            string varName = whythehellnotwork.Split(@" = ")[0];
            string varContentsFake = whythehellnotwork.Split(@" = ")[1];
            string varContentsReal = null;
            if (varContentsFake == "%s")
            {
                varContentsReal = Console.ReadLine();

                if (Strings.ContainsKey(varName))
                {
                    Strings.Remove(varName);
                }

                print(varName + varContentsReal);
                Strings.Add(varName, varContentsReal);
            }
            else
            {
                varContentsReal = varContentsFake;

                if (Strings.ContainsKey(varName))
                {
                    Strings.Remove(varName);
                }

                print(varName + varContentsReal);
                Strings.Add(varName, varContentsReal);
            }
        }

        if (line.StartsWith("int") && badif == false)
        {
            int intCont = 0;
            string whythehellnotwork = line.Replace(@"int ", "");
            string varName = whythehellnotwork.Split(@" = ")[0];
            string varContents = whythehellnotwork.Split(@" = ")[1];
            try
            {
                intCont = int.Parse(varContents);
            }
            catch
            {
                Console.WriteLine(@"Integer: int " + varName + " is formatted incorrectly.");
            }

            string trueCont = intCont.ToString();

            if (Integers.ContainsKey(varName))
            {
                Integers.Remove(varName);
            }


            Strings.Add(varName, trueCont);
        }

        if (line.StartsWith(@"print=") && badif == false)
        {
            string assSplitter = line.Replace(@"print=", "");
            // we like splitting ass round here
            if (assSplitter.Contains("\""))
            {
                string thighs = assSplitter.Replace("\"", "");
                Console.WriteLine(thighs);
            }
            else if (Strings.TryGetValue(assSplitter, out string what))
            {
                try
                {
                    Console.WriteLine(what);
                }
                catch
                {
                    Console.WriteLine("owen is gay");
                }
            }
            else if (Integers.TryGetValue(assSplitter, out int whatint))
            {
                try
                {
                    Console.WriteLine(what);
                }
                catch
                {
                    Console.WriteLine("owen is gay");
                }
            }
        }

        if (line.StartsWith("if") && badif == false)
        {
            string removeIf = line.Substring(3);
            string intorstring = null;
            if (removeIf.Contains("=="))
            {
                string equals2split1 = removeIf.Split(@" == ")[0];
                string equals2split2 = removeIf.Split(@" == ")[1];
                // this line was used for debugging // log(ConsoleColor.White, equals2split1 + "" + equals2split2);

                if (Strings.TryGetValue(equals2split1, out string strval))
                {
                    if (intorstring == null)
                    {
                        intorstring = "string";
                        print("string type");
                    }

                    if (intorstring == "int")
                    {
                    }
                    else if (intorstring == "string")
                    {
                        string1 = strval;
                        print(string1);
                    }
                }
                else if (Integers.TryGetValue(equals2split2, out int intval))
                {
                    if (intorstring == null)
                    {
                        intorstring = "int";
                    }

                    if (intorstring == "string")
                    {
                    }
                    else if (intorstring == "int")
                    {
                        int1 = intval;
                    }
                }

                if (Strings.TryGetValue(equals2split2, out string strval2))
                {
                    if (intorstring == null)
                    {
                        intorstring = "string";
                        print("string type");
                    }

                    if (intorstring == "int")
                    {
                    }
                    else if (intorstring == "string")
                    {
                        string2 = strval2;
                        print(string2);
                    }
                }
                else if (Integers.TryGetValue(equals2split2, out int intval2))
                {
                    if (intorstring == null)
                    {
                        intorstring = "int";
                    }

                    if (intorstring == "string")
                    {
                    }
                    else if (intorstring == "int")
                    {
                        int2 = intval2;
                    }
                }
                
                print(intorstring);
                if (intorstring == "string")
                {
                    if (string1 != string2)
                    {
                        badif = true;
                    }
                }
                else if (intorstring == "int")
                {
                    if (int1 != int2)
                    {
                        badif = true;
                    }
                }
            }

            if (removeIf.Contains("!="))
            {
                string equals2split1 = removeIf.Split(@" != ")[0];
                string equals2split2 = removeIf.Split(@" != ")[1];
                string intorstring2 = null;
                //string string1 = null;
                //string string2 = null;
                //int int1 = 0;
                //int int2 = 0;
                // this line was used for debugging //    log(ConsoleColor.White, equals2split1 + "" + equals2split2);

                if (Strings.TryGetValue(equals2split1, out string strval))
                {
                    if (intorstring2 == null)
                    {
                        intorstring2 = "string";
                    }

                    if (intorstring2 == "int")
                    {
                    }
                    else if (intorstring2 == "string")
                    {
                        string1 = strval;
                    }
                }
                else if (Integers.TryGetValue(equals2split2, out int intval))
                {
                    if (intorstring2 == null)
                    {
                        intorstring2 = "int";
                    }

                    if (intorstring2 == "string")
                    {
                    }
                    else if (intorstring2 == "int")
                    {
                        int1 = intval;
                    }
                }

                if (Strings.TryGetValue(equals2split2, out string strval2))
                {
                    if (intorstring2 == null)
                    {
                        intorstring2 = "string";
                    }

                    if (intorstring2 == "int")
                    {
                    }
                    else if (intorstring2 == "string")
                    {
                        string2 = strval2;
                    }
                }
                else if (Integers.TryGetValue(equals2split2, out int intval2))
                {
                    if (intorstring2 == null)
                    {
                        intorstring2 = "int";
                    }

                    if (intorstring2 == "string")
                    {
                    }
                    else if (intorstring2 == "int")
                    {
                        int2 = intval2;
                    }
                }

                if (intorstring2 == "string")
                {
                    if (string1 == string2)
                    {
                        badif = true;
                    }
                }
                else if (intorstring2 == "int")
                {
                    if (int1 == int2)
                    {
                        badif = true;
                    }
                }
            }
        }

        if (line.StartsWith(@"save=") && badif == false)
        {
            string whatvartosave = line.Substring(5);
            if (Strings.TryGetValue(whatvartosave, out string strval))
            {
                if (Directory.Exists(@"C:\content\prf\"))
                {
                    if (!File.Exists(@"C:\content\prf\" + fuckingprogramname + @"\" + whatvartosave +
                                     @".txt"))
                    {
                        File.Create(@"C:\content\prf\" + fuckingprogramname + @"\" + whatvartosave +
                                    @".txt");
                        TextWriter tw = new StreamWriter(@"C:\content\prf\" + fuckingprogramname +
                                                         @"\" + whatvartosave + @".txt");
                        tw.WriteLine(strval);
                        tw.Write(@"type=string");
                        tw.Close();
                    }
                    else if (File.Exists(@"C:\content\prf\" + fuckingprogramname + @"\" +
                                         whatvartosave + @".txt"))
                    {
                        TextWriter tw = new StreamWriter(@"C:\content\prf\" + fuckingprogramname +
                                                         @"\" + whatvartosave + @".txt");
                        tw.WriteLine(strval);
                        tw.Write(@"type=string");
                        tw.Close();
                    }
                }
                else if (!Directory.Exists(@"C:\content\prf\"))
                {
                    Directory.CreateDirectory(@"C:\content\prf\");
                    if (!File.Exists(@"C:\content\prf\" + fuckingprogramname + @"\" + whatvartosave +
                                     @".txt"))
                    {
                        File.Create(@"C:\content\prf\" + fuckingprogramname + @"\" + whatvartosave +
                                    @".txt");
                        TextWriter tw = new StreamWriter(@"C:\content\prf\" + fuckingprogramname +
                                                         @"\" + whatvartosave + @".txt");
                        tw.WriteLine(strval);
                        tw.Write(@"type=string");
                        tw.Close();
                    }
                    else if (File.Exists(@"C:\content\prf\" + fuckingprogramname + @"\" +
                                         whatvartosave + @".txt"))
                    {
                        TextWriter tw = new StreamWriter(@"C:\content\prf\" + fuckingprogramname +
                                                         @"\" + whatvartosave + @".txt");
                        tw.WriteLine(strval);
                        tw.Write(@"type=string");
                        tw.Close();
                    }
                }
            }
            else if (Integers.TryGetValue(whatvartosave, out int intval))
            {
                if (Directory.Exists(@"C:\content\prf\"))
                {
                    if (!File.Exists(@"C:\content\prf\" + fuckingprogramname + @"\" + whatvartosave +
                                     @".txt"))
                    {
                        File.Create(@"C:\content\prf\" + fuckingprogramname + @"\" + whatvartosave +
                                    @".txt");
                        TextWriter tw = new StreamWriter(@"C:\content\prf\" + fuckingprogramname +
                                                         @"\" + whatvartosave + @".txt");
                        tw.WriteLine(intval);
                        tw.Write(@"type=int");
                        tw.Close();
                    }
                    else if (File.Exists(@"C:\content\prf\" + fuckingprogramname + @"\" +
                                         whatvartosave + @".txt"))
                    {
                        TextWriter tw = new StreamWriter(@"C:\content\prf\" + fuckingprogramname +
                                                         @"\" + whatvartosave + @".txt");
                        tw.WriteLine(intval);
                        tw.Write(@"type=int");
                        tw.Close();
                    }
                }
                else if (!Directory.Exists(@"C:\content\prf\"))
                {
                    Directory.CreateDirectory(@"C:\content\prf\");
                    if (!File.Exists(@"C:\content\prf\" + fuckingprogramname + @"\" + whatvartosave +
                                     @".txt"))
                    {
                        File.Create(@"C:\content\prf\" + fuckingprogramname + @"\" + whatvartosave +
                                    @".txt");
                        TextWriter tw = new StreamWriter(@"C:\content\prf\" + fuckingprogramname +
                                                         @"\" + whatvartosave + @".txt");
                        tw.WriteLine(intval);
                        tw.Write(@"type=int");
                        tw.Close();
                    }
                    else if (File.Exists(@"C:\content\prf\" + fuckingprogramname + @"\" +
                                         whatvartosave + @".txt"))
                    {
                        TextWriter tw = new StreamWriter(@"C:\content\prf\" + fuckingprogramname +
                                                         @"\" + whatvartosave + @".txt");
                        tw.WriteLine(intval);
                        tw.Write(@"type=int");
                        tw.Close();
                    }
                }
            }
        }

        if (line.StartsWith(@"load=") && badif == false)
        {
            int intCont = 0;
            string whatvartoload = line.Substring(5);
            string ass = null;
            string assType = null;
            if (Strings.TryGetValue(whatvartoload, out string strval))
            {
                if (File.Exists(
                        @"C:\content\prf\" + fuckingprogramname + @"\" + whatvartoload + @".txt"))
                {
                    using (StreamReader streamReader = new StreamReader(
                               @"C:\content\prf\" + fuckingprogramname + @"\" + whatvartoload + @".txt",
                               Encoding.UTF8))
                    {
                        ass = File.ReadLines(@"C:\content\prf\" + fuckingprogramname + @"\" +
                                             whatvartoload + @".txt").Skip(0).Take(1).First();
                        assType = File
                            .ReadLines(@"C:\content\prf\" + fuckingprogramname + @"\" + whatvartoload +
                                       @".txt").Skip(1).Take(1).First();
                        string assSplitter2 = assType.Split('=')[1];
                        if (assSplitter2 == "string")
                        {
                            if (Strings.ContainsKey(whatvartoload))
                            {
                                Strings.Remove(whatvartoload);
                            }

                            Strings.Add(whatvartoload, ass);
                        }

                        if (assSplitter2 == "int")
                        {
                            try
                            {
                                intCont = int.Parse(ass);
                            }
                            catch
                            {
                                Console.WriteLine(@"Load: int " + whatvartoload +
                                                  " is formatted incorrectly.");
                            }

                            string trueCont = intCont.ToString();

                            if (Integers.ContainsKey(whatvartoload))
                            {
                                Integers.Remove(whatvartoload);
                            }

                            Integers.Add(whatvartoload, intCont);
                        }
                    }
                }
            }
        }

        if (line.StartsWith("frontcolor=") && badif == false)
        {
            string ass = line.Substring(11);
            if (ass == "white")
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (ass == "blue")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (ass == "green")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (ass == "yellow")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (ass == "black")
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else if (ass == "cyan")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
            }
            else if (ass == "gray")
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else if (ass == "magenta")
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else if (ass == "red")
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (ass == "darkblue")
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
            }
            else if (ass == "darkcyan")
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            else if (ass == "darkgray")
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            else if (ass == "darkgreen")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (ass == "darkmageneta")
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
            }
            else if (ass == "darkred")
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else if (ass == "darkyellow")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
        }

        if (line.StartsWith("backcolor=") && badif == false)
        {
            string ass = line.Substring(10);
            if (ass == "white")
            {
                Console.BackgroundColor = ConsoleColor.White;
            }
            else if (ass == "blue")
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            else if (ass == "green")
            {
                Console.BackgroundColor = ConsoleColor.Green;
            }
            else if (ass == "yellow")
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
            }
            else if (ass == "black")
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (ass == "cyan")
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
            }
            else if (ass == "gray")
            {
                Console.BackgroundColor = ConsoleColor.Gray;
            }
            else if (ass == "magenta")
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
            }
            else if (ass == "red")
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else if (ass == "darkblue")
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            }
            else if (ass == "darkcyan")
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
            }
            else if (ass == "darkgray")
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
            }
            else if (ass == "darkgreen")
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
            }
            else if (ass == "darkmageneta")
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
            }
            else if (ass == "darkred")
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }
            else if (ass == "darkyellow")
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
            }
        }
    }
}