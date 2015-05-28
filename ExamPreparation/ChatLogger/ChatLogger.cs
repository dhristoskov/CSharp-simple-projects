using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatLogger
{
    class Program
    {
        static List<Tuple<string, DateTime>> messeges = new List<Tuple<string, DateTime>>();
        static void Main(string[] args)
        {
            DateTime currentDateTime = DateTime.Parse(Console.ReadLine());

            string msg = Console.ReadLine();
            while (msg != "END")
            {
                string[] data = msg.Split('/').Select(s => s.Trim()).ToArray();
                messeges.Add(new Tuple<string, DateTime>(data[0], DateTime.Parse(data[1])));
                msg = Console.ReadLine();
            }


            foreach (var messege in messeges.OrderBy(s => s.Item2))
            {
                Console.WriteLine("<div>" + messege.Item1 + "</div>");
            }
            var lastmessege = messeges.OrderByDescending(s => s.Item2).Select(s => s.Item2).First();
            TimeSpan result = currentDateTime - lastmessege;

            Console.Write("<p>Last active: <time>");
            if (result < TimeSpan.FromMinutes(1))
            {
                Console.Write("a few moments ago");
            }
            else if (result < TimeSpan.FromHours(1))
            {
                Console.Write("{0} minute(s) ago", result.Minutes);
            }
            else if (result < TimeSpan.FromHours(24) && lastmessege.Day == currentDateTime.Day)
            {
                Console.Write("{0} hour(s) ago", result.Hours);
            }
            else if (currentDateTime.Day - 1 == lastmessege.Day)
            {
                Console.Write("yesterday");
            }
            else
            {
                Console.Write(lastmessege.ToString("dd-MM-yyyy"));
            }
            Console.Write("</time></p>");
        }
    }
}
