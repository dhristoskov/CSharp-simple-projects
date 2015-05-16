//http://www.reddit.com/r/dailyprogrammer/comments/1kphtf/081313_challenge_136_easy_student_management/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManag
{
    class StudentManag
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of students and number of test's scores");
            Console.WriteLine("split by single space");
            string[] date = Console.ReadLine().Split();
            int studentsNum = int.Parse(date[0]);
            int scoreDate = int.Parse(date[1]);
            List<string> names = new List<string>(studentsNum);
            List<double> sums = new List<double>();
         
            for (int a = 0; a < studentsNum; a++)
            {
                string[] studentsData = Console.ReadLine().Split();
                names.Add(studentsData[0]);
                List<double> scores = new List<double>();
                for (int b = 1; b < studentsData.Length; b++)
                {
                    scores.Add(double.Parse(studentsData[b]));
                }
                double totalPints = scores.Sum();
                sums.Add(totalPints);
            }
            int max = (int)sums.Max();
            int min = (int)sums.Min();
            double totalAvg = sums.Average();
            Console.WriteLine("Avarage {0:f2}",totalAvg);
            Console.WriteLine("Max points {0}",max);
            Console.WriteLine("Min points {0}",min);
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine("{0} {1}",names[i],(int)sums[i]);
            }
        }
    }
}
