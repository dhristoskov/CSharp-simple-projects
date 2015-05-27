using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PINValidation
{
    class PINValidation
    {
        static bool CheckIfCorrect(string egn, string gender)
        {
            if (egn.Length == 10 && (gender == "male" && egn[8] % 2 == 0)
                || (gender == "female" && egn[8] % 2 != 0) && IsDigit(egn))
            {
                if (CheckDate(egn) && IsCheckSumCorrect(egn))
                {
                    return true;
                }
            }
            return false;
        }
        static bool IsDigit(string egn)
        {
            foreach (var ch in egn)
            {
                if (!Char.IsDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }
        static bool CheckDate(string egn)
        {           
            int year = int.Parse(egn.Substring(0, 2));
            int month = int.Parse(egn.Substring(2, 2));
            int day = int.Parse(egn.Substring(4, 2));
            if (month > 20 && month <= 32)
            {
                month -= 20;
                year = 1800 + year;
            }
            else if (month > 40 && month <= 52)
            {
                month -= 40;
                year = 2000 + year;
            }
            else
            {
                year = 1900 + year;
            }
            DateTime datetime = new DateTime();
            if (DateTime.TryParse(String.Format("{0}/{1}/{2}", year, month, day), out datetime))
            {
                return true;
            }
            return false;
        }
        static bool IsCheckSumCorrect(string eng)
        {
            int[] nums = eng.Select(x => int.Parse(x.ToString())).ToArray();
            int checkSum = (nums[0] * 2 + nums[1] * 4 + nums[2] * 8 + nums[3] * 5 + nums[4] * 10 + nums[5] * 9
                + nums[6] * 7 + nums[7] * 3 + nums[8] * 6) % 11;
            if (checkSum == 10)
            {
                checkSum = 0;
            }

            if (checkSum == nums[9])
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            string fullName = Console.ReadLine();
            string gender = Console.ReadLine();
            string personEGN = Console.ReadLine();

            if (CheckIfCorrect(personEGN, gender))
            {
                Console.WriteLine("{{\"name\":\"{0}\",\"gender\":\"{1}\",\"pin\":\"{2}\"}}", fullName, gender, personEGN);
            }
            else
            {
                Console.WriteLine("<h2>Incorrect data</h2>");
            }
        }
    }
}
