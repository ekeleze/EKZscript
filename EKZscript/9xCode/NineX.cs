namespace EKZ_UWS._9xCode;
using static Program;
using System;

public class NineX
{
    public void RunNine(string line)
    {
        bool SysLib = true, ConsoleLib = true, TimeLib = true;
        int i;

        if (line.StartsWith(";"))
        {
        }

        if (line == "test")
        {
            print("YES");
        }

        if (line.StartsWith("import"))
        {
            if (line.Contains("System"))
            {
                SysLib = true;
            }

            if (line.Contains("Console"))
            {
                ConsoleLib = true;
            }

            if (line.Contains("Time"))
            {
                TimeLib = true;
            }
        }

        if (line.StartsWith("Boolean"))
        {
            string keyass = line.Split(" = ")[0];
            string otherkeyass = line.Split(" = ")[1];
            string key = keyass.Substring(8);

            if (Booleans.ContainsKey(key))
            {
                Booleans.Remove(key);
            }

            Booleans.Add(key, Convert.ToBoolean(otherkeyass));
        }

        if (line.StartsWith("Integer"))
        {
            string keyass = line.Split(" = ")[0];
            print(keyass);
            string otherkeyass = line.Split(" = ")[1];
            print(otherkeyass);
            string key = keyass.Substring(8);
            print(key);

            if (Integers.ContainsKey(key))
            {
                Integers.Remove(key);
            }

            if (otherkeyass.StartsWith("Seconds"))
            {
                Integers.Add(key, DateTime.Now.Second);
            }
            else if (otherkeyass.StartsWith("Minutes"))
            {
                Integers.Add(key, DateTime.Now.Minute);
            }
            else if (otherkeyass.StartsWith("Hours"))
            {
                Integers.Add(key, DateTime.Now.Hour);
            }
            else if (otherkeyass.StartsWith("0x"))
            {
                line.Remove(0, 2);
                Integers.Add(key, Convert.ToInt32(otherkeyass, 16));
            }
            else
            {
                Integers.Add(key, Convert.ToInt32(otherkeyass));
            }
        }

        if (line.StartsWith("String"))
        {
            string keyass = line.Split(" = ")[0];
            string otherkeyass = line.Split(" = ")[1];
            string halffixedkeyass = otherkeyass.Substring(1);
            string fixedkeyass = halffixedkeyass.Remove(halffixedkeyass.Length - 1);
            print (fixedkeyass);
            string key = keyass.Substring(7);
            print(key);

            if (Strings.ContainsKey(key))
            {
                Strings.Remove(key);
            }

            if (fixedkeyass.StartsWith("Read()"))
            {
                string consoleLine = Console.ReadKey(true).Key.ToString();
                Strings.Add(key, consoleLine);
            }
            else if (fixedkeyass.StartsWith("ReadLine()"))
            {
                string consoleLine = Console.ReadLine();
                Strings.Add(key, consoleLine);
            }
            else
            {
                Strings.Add(key, fixedkeyass);
            }
        }

        if (line.StartsWith("if"))
        {
            int start = line.IndexOf('(');
            int end = line.IndexOf(')') - start;

            string statement = line.Substring(start + 1, end - 1);
            string[] comparation = { };

            int endif = 0;

            for (int o = 0; o < line.Length; o++)
            {
                if (line.Substring(o, 5) == "endif")
                {
                    endif = o;
                }
            }

            if (line.Contains('='))
            {
                comparation = line.Substring(4).Split('=');

                if (Integers.TryGetValue(comparation[0].Trim(), out int intval))
                {
                    comparation[1] = comparation[1].Substring(1, comparation[1].Length - 2);
                    if (comparation[1] != intval.ToString())
                    {
                        i = endif + 1;
                    }
                }
                else if (Strings.TryGetValue(comparation[0].Trim(), out string strval))
                {
                    comparation[1] = comparation[1].Substring(comparation[1].IndexOf('"') + 1,
                        comparation[1].LastIndexOf('"') - 2);
                    if (comparation[1] != strval)
                    {
                        i = endif + 1;
                    }
                }
                else if (Booleans.TryGetValue(comparation[0].Trim(), out bool bolval))
                {
                    comparation[1] = comparation[1].Substring(1, comparation[1].Length - 2);
                    if (comparation[1] != bolval.ToString().ToLower()) // For booleans we need to make it lower
                    {
                        i = endif + 1;
                    }
                }
            }

            if (line.Contains('!'))
            {
                comparation = line.Substring(4).Split('!');

                if (Integers.TryGetValue(comparation[0].Trim(), out int intval))
                {
                    comparation[1] = comparation[1].Substring(1, comparation[1].Length - 2);
                    if (comparation[1] == intval.ToString())
                    {
                        i = endif + 1;
                    }
                }
                else if (Strings.TryGetValue(comparation[0].Trim(), out string strval))
                {
                    comparation[1] = comparation[1].Substring(comparation[1].IndexOf('"') + 1,
                        comparation[1].LastIndexOf('"') - 2);
                    if (comparation[1] == strval)
                    {
                        i = endif + 1;
                    }
                }
                else if (Booleans.TryGetValue(comparation[0].Trim(), out bool bolval))
                {
                    comparation[1] = comparation[1].Substring(1, comparation[1].Length - 2);
                    if (comparation[1] == bolval.ToString().ToLower()) // For booleans we need to make it lower
                    {
                        i = endif + 1;
                    }
                }
            }
        }

        if (ConsoleLib)
        {
            if (line.StartsWith("Write(") || line.StartsWith("Print("))
            {
                string content = line.Split('(')[1];
                int helpme = content.IndexOf(')');
                string realcontent = content.Remove(helpme);
                string[] contentSplit = realcontent.Split('+');
                
                foreach (string c in contentSplit)
                {
                    if (c.Contains('"'))
                    {
                        string cfix = c.Substring(1);
                        int helpme2 = cfix.IndexOf('"');
                        string cfixfix = cfix.Remove(helpme2);
                        Console.WriteLine(cfixfix);
                    }
                    else if (Integers.TryGetValue(c, out int intval))
                    {
                        Console.Write(intval);
                    }
                    else if (Strings.TryGetValue(c, out string strval))
                    {
                        Console.Write(strval);
                    }
                    else if (Booleans.TryGetValue(c, out bool bolval))
                    {
                        Console.Write(bolval);
                    }
                    else if (c == "Seconds")
                    {
                        Console.Write(DateTime.Now.Second);
                    }
                    else if (c == "Minutes")
                    {
                        Console.Write(DateTime.Now.Minute);
                    }
                    else if (c == "Hours")
                    {
                        Console.Write(DateTime.Now.Hour);
                    }
                }
            }
        }
    }
}
        