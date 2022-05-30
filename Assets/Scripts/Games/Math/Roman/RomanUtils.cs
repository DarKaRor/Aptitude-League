using System.Collections.Generic;
using System.Text;

public class RomanUtils
{
    public static Dictionary<char, int> romanNumbersDictionary = new()
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };

    public static Dictionary<int, string> numberRomanDictionary = new Dictionary<int, string>
    {
        { 1000, "M" },
        { 900, "CM" },
        { 500, "D" },
        { 400, "CD" },
        { 100, "C" },
        { 90, "XC" },
        { 50, "L" },
        { 40, "XL" },
        { 10, "X" },
        { 9, "IX" },
        { 5, "V" },
        { 4, "IV" },
        { 1, "I" },
    };


    public static string RomanToInt(string s)
    {
        int sum = 0;
        for (int i = 0; i < s.Length; i++)
        {
            char currentRomanChar = s[i];
            romanNumbersDictionary.TryGetValue(currentRomanChar, out int num);
            if (i + 1 < s.Length && romanNumbersDictionary[s[i + 1]] > romanNumbersDictionary[currentRomanChar])
            {
                sum -= num;
            }
            else sum += num;
        }
        return sum.ToString();
    }


    public static string IntToRoman(string n)
    {
        if (!int.TryParse(n, out int s)) return "";
        int number = System.Convert.ToInt32(n);
        var roman = new StringBuilder();

        foreach (var item in numberRomanDictionary)
        {
            while (number >= item.Key)
            {
                roman.Append(item.Value);
                number -= item.Key;
            }
        }

        return roman.ToString();
    }
}
