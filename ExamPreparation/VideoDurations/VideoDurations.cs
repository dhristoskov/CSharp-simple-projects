using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoDurations
{
    class VideoDurations
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int totalTime = 0;

            while (input != "End")
            {
                string[] time = input.Split(':');
                int hours = int.Parse(time[0]);
                int minute = int.Parse(time[1]);
                input = Console.ReadLine();

                totalTime = totalTime + minute + (hours * 60);
            }
            int finalHours = totalTime / 60;
            int finalMinute = totalTime % 60;
            Console.WriteLine("{0}:{1}",finalHours, finalMinute);
        }
    }
}
