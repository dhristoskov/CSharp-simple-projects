using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class OMyGirl
{
    public static void Main()
    {
        string key = Console.ReadLine();
        string input = Console.ReadLine();

        StringBuilder sb = new StringBuilder();

        while (input != "END")
        {
            sb.Append(input);
            input = Console.ReadLine();
        }

        string text = sb.ToString();

        sb = new StringBuilder();

        if (!char.IsLetterOrDigit(key[0]))
        {
            sb.Append("\\" + key[0]);
        }
        else
        {
            sb.Append(key[0]);
        }

        for (int i = 1; i < key.Length - 1; i++)
        {
            if (char.IsDigit(key[i]))
            {
                sb.Append(@"[0-9]*");
            }
            else if (char.IsLower(key[i]))
            {
                sb.Append(@"[a-z]*");
            }
            else if (char.IsUpper(key[i]))
            {
                sb.Append(@"[A-Z]*");
            }
            else if (key[i] == '+'
                || key[i] == '*'
                || key[i] == '?'
                || key[i] == '['
                || key[i] == ']'
                || key[i] == '('
                || key[i] == ')')
            {
                sb.Append("\\" + key[i]);
            }
            else
            {
                sb.Append(key[i]);
            }
        }

        if (!char.IsLetterOrDigit(key[key.Length - 1]))
        {
            sb.Append("\\" + key[key.Length - 1]);
        }
        else
        {
            sb.Append(key[key.Length - 1]);
        }

        string pattern = sb + "(.{2,6}?)" + sb;

        Regex regex = new Regex(pattern);

        var matches = regex.Matches(text).Cast<Match>().Select(match => match.Groups[1].Value);

        Console.WriteLine(string.Join(string.Empty, matches));
    }
}