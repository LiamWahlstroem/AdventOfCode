using System.Diagnostics;

class day1 
{
    static void Main(string[] args)
    {
        Console.WriteLine(Part1().ToString());
        Console.WriteLine(Part2());
    }

    private static int Part1()
    {
        string[] lines = File.ReadAllLines("../../../input.txt");
        int sum = 0;

        foreach (string l in lines)
        {
            List<Char> digits = new List<Char>();
            
            for (int i = 0; i < l.Length; i++)
            {
                if (Char.IsDigit(l[i]))
                    digits.Add(l[i]);
            }

            sum += Int32.Parse(digits[0].ToString() + digits.Last());
        }

        return sum;
    }

    private static int Part2()
    {
        string[] searchValues = {"1", "2", "3", "4", "5", "6", "7", "8", "9", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
        string[] lines = File.ReadAllLines("../../../input.txt");
        int sum = 0;

        foreach (string l in lines)
        {
            Dictionary<int, int> numbersInString = new Dictionary<int, int>();
            int startIndex = 0;

            for (int i = 0; i < searchValues.Count(); i++)
            {
                int index = l.IndexOf(searchValues[i], startIndex);

                if (index != -1)
                {
                    string foundValue = searchValues[i];

                    if (i > 8)
                    {
                        switch (foundValue)
                        {
                            case "one":
                                foundValue = "1";
                                break;
                            case "two":
                                foundValue = "2";
                                break;
                            case "three":
                                foundValue = "3";
                                break;
                            case "four":
                                foundValue = "4";
                                break;
                            case "five":
                                foundValue = "5";
                                break;
                            case "six":
                                foundValue = "6";
                                break;
                            case "seven":
                                foundValue = "7";
                                break;
                            case "eight":
                                foundValue = "8";
                                break;
                            case "nine":
                                foundValue = "9";
                                break;
                        }
                    }

                    startIndex = index + 1;
                    numbersInString.Add(index, Int32.Parse(foundValue));
                    i--;
                }
                else
                    startIndex = 0;
            }

            sum += Int32.Parse(numbersInString[numbersInString.Keys.Min()].ToString() + numbersInString[numbersInString.Keys.Max()]);
        }

        return sum;
    }
}