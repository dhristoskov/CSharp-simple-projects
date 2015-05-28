using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleeRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int jumpcount = int.Parse(Console.ReadLine());
            int fieldSize = int.Parse(Console.ReadLine());
            List<Flee> fleesList = new List<Flee>();
            for (int i = 0; i < 4; i++)
            {
                string[] flee = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                fleesList.Add(new Flee() { JumpForce = int.Parse(flee[1]), Name = flee[0], Position = 0 });
            }

            StringBuilder field = new StringBuilder();
            field.Append('#', fieldSize);
            field.Append(Environment.NewLine);
            field.Append('#', fieldSize);
            Console.WriteLine(field);
            int index = 1;
            bool haveWinner = false;
            while (jumpcount > 0)
            {
                foreach (var flee in fleesList)
                {
                    flee.Position = flee.JumpForce + flee.Position;
                    if (flee.Position >= fieldSize - 1)
                    {
                        flee.Position = fieldSize - 1;
                        haveWinner = true;
                        break;
                    }
                }
                jumpcount--;
                index++;
            }

            foreach (var flee in fleesList)
            {
                char[] line = new string('.', fieldSize).ToCharArray();
                line[flee.Position] = char.ToUpper(flee.Name[0]);
                Console.WriteLine(line);
            }
            Console.WriteLine(field);

            if (haveWinner)
            {
                Console.WriteLine("Winner:{0}", (from flee in fleesList
                                                 orderby flee.Position descending
                                                 select flee.Name).First());
            }
            else
            {
                Console.WriteLine("Winner:{0}", fleesList.Last().Name);
            }

        }
    }

    class Flee
    {
        public string Name;
        public int JumpForce;
        public int Position;
    }
}
