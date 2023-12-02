using System.Text.RegularExpressions;

class day2
{
    static void Main(string[] args)
    {
        Console.WriteLine(Part1());
        Console.WriteLine(Part2());
    }

    private static int Part1()
    {
        string[] lines = File.ReadAllLines("../../../input.txt");
        int sum = 0;

        foreach (string l in lines)
        {
            string[] sets = l.Split(";");
            string gameID = sets[0].Split(":")[0].Split(" ")[1];
            sets[0] = sets[0].Split(": ")[1];
            bool valid = true;

            foreach (string s in sets)
            {
                string[] blocks = s.Split(",");

                foreach (string b in blocks)
                {
                    if (b.Contains("blue"))
                    {
                        if (Int32.Parse(parseNumbers(b)) > 14)
                            valid = false;
                    }
                    else if (b.Contains("red"))
                    {
                        if(Int32.Parse(parseNumbers(b)) > 12)
                            valid = false;
                    }
                    else if(b.Contains("green"))
                    {
                        if(Int32.Parse(parseNumbers(b)) > 13)
                            valid = false;
                    }
                }
            }

            if (valid)
                sum += Int32.Parse(gameID);
        }
        
        return sum;
    }

    private static int Part2()
    {
        string[] lines = File.ReadAllLines("../../../input.txt");
        int sum = 0;

        foreach (string l in lines)
        {
            string[] sets = l.Split(";");
            sets[0] = sets[0].Split(": ")[1];
            Dictionary<string, int> maxValues = new Dictionary<string, int>()
            {
                {"blue", 0},
                {"red", 0},
                {"green", 0}
            };

            foreach (string s in sets)
            {
                string[] blocks = s.Split(",");

                foreach (string b in blocks)
                {
                    if (b.Contains("blue"))
                    {
                        maxValues["blue"] = Math.Max(maxValues["blue"], Int32.Parse(parseNumbers(b)));
                    }
                    else if (b.Contains("red"))
                    {
                        maxValues["red"] = Math.Max(maxValues["red"], Int32.Parse(parseNumbers(b)));
                    }
                    else if(b.Contains("green"))
                    {
                        maxValues["green"] = Math.Max(maxValues["green"], Int32.Parse(parseNumbers(b)));
                    }
                }
            }

            sum += maxValues["blue"] * maxValues["red"] * maxValues["green"];
        }
        
        return sum;
    }
    
    private static string parseNumbers(string s)
    {
        string numbers = "";
        
        for (int i = 0; i < s.Length; i++)
        {
            if (Char.IsDigit(s[i]))
                numbers += s[i];
        }

        return numbers;
    }
}