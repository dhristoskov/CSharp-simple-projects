using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravityCalculator
{
    class GravityCalculator
    {
        static double volume;
        static double mass;
        static double force;
        static double objectMass;

        static double CalcVolume(double r)
        {
            volume = 4 / 3 * Math.PI * Math.Pow(r, 3);
            return volume;
        }
        static double CalcMass(double d)
        {
            mass = volume * d;
            return mass;
        }
        static double CalcForce(double r)
        {
            force = 6.67e-11 * objectMass * mass / Math.Pow(r, 2);
            return force;
        }
        static void Main(string[] args)
        {
            objectMass = double.Parse(Console.ReadLine());
            int numberPlanet = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberPlanet; i++)
            {
                string[] input = Console.ReadLine().Split(',');
                string name = input[0];
                double radius = double.Parse(input[1]);
                double density = double.Parse(input[2]);

                CalcVolume(radius);
                CalcMass(density);               
                Console.WriteLine("{0} -- {1:f3}",name, CalcForce(radius));
            }
        }
    }
}
