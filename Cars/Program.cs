using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("<-----------------First factory----------->");
            Factory c = new CarOneFactory();
            BuildCar(c);
            Console.WriteLine("<-----------------Second factory----------->");
            c = new CarTwoFactory();
            BuildCar(c);
            Console.WriteLine("<-----------------Third factory----------->");
            c = new CarThreeFactory();
            BuildCar(c);
        }

        public static void BuildCar(Factory i)
        {
            List<string> list = new List<string>();
            list.Add("ABS");// "alufelgi" && v != "skórzane fotele" && v != "ABS" && v != "ASR" && v != "DVD" && v != "Immobilizer")
            list.Add("alufelgi");
            list.Add("skórzane fotele");
            list.Add("ASR");
            list.Add("DVD");
            list.Add("Immobilizer");
            Car c;
            c = i.getCar((float)1.8, Interfaces.EngineType.Lpg, list, Interfaces.BodyType.Cabriolet, Interfaces.Color.NeonPink);
            c.ShowOff();
            
        }
	}
}
