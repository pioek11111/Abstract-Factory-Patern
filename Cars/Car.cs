using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars.Interfaces;

namespace Cars
{
	public class Car
	{
		private readonly IEngine engine;
		private readonly IInterior interior;
		private readonly IBody body;

		public Car(IEngine engine, IInterior interior, IBody body)
		{
			if (engine == null || interior == null || body == null)
				throw new ArgumentException("Car part should not be null.");

			this.engine = engine;
			this.body = body;
			this.interior = interior;
		}

		public void ShowOff()
		{
			Console.WriteLine(body.GetDescription()+" powered by "+engine.GetDescription()+" with "+interior.GetDescription());
		}
	}
    public abstract class Factory
    {
        public abstract Car getCar(float c, EngineType et, List<string> list, BodyType t, Color color);
    }
    public class CarOneFactory : Factory
    {      
        public override Car getCar(float c, EngineType et, List<string> list, BodyType t, Color color)
        {
            Car car  = new Car(new SportEngine(c, et), new FamilyCarInterior(list), new FancyBody(t, color));
            return car;
        }
    }
    public class CarTwoFactory : Factory
    {
        public override Car getCar(float c, EngineType et, List<string> list, BodyType t, Color color)
        {
            Car car = new Car(new EfficientEngine(c, et), new StandardInterior(list), new FamilyBody(t, color));
            return car;
        }

    }
    public class CarThreeFactory : Factory
    {
        public override Car getCar(float c, EngineType et, List<string> list, BodyType t, Color color)
        {
            Car car = new Car(new FamilyEngine(c, et), new PremiumInterior(list), new SportBody(t, color));
            return car;
        }

    }
    public class SportEngine : IEngine
    {
        public float Capacity { get; }
        public EngineType Type { get; }
        public SportEngine(float c, EngineType et)
        {
            if(c>=2) Capacity = 2;
            Type = et == EngineType.Lpg ? EngineType.Petrol : et;
        }

        public string GetDescription()
        {
            return "Sport Engine  Capacity: " + Capacity.ToString() + " Type: " + Type.ToString();
        }
    }

    public class EfficientEngine : IEngine
    {
        public float Capacity { get; }
        public EngineType Type { get; }
        public EfficientEngine(float c, EngineType et)
        {
            Capacity = c<=3? c : 3;
            Type = et;
        }

        public string GetDescription()
        {
            return "Spart Engine" + Capacity.ToString() + " Type: " + Type.ToString(); 
        }
    }

    public class FamilyEngine : IEngine
    {
        public float Capacity { get; }
        public EngineType Type { get; }
        public FamilyEngine(float c, EngineType et)
        {
            Capacity = c <= (float)2.5 ? c : (float)2.5;
            Type = et == EngineType.Diesel ? EngineType.Petrol : et;
        }

        public string GetDescription()
        {
            return "Spart Engine" + Capacity.ToString() + " Type: " + Type.ToString(); 
        }
    }

    public class FamilyCarInterior : IInterior
    {
        List<string> features;
        public FamilyCarInterior(List<string> list)
        {
            features = new List<string>();
            foreach(var v in list)
            {
                if (v != "alufelgi"  && v != "DVD")
                    features.Add(v);
            }
        }
        public IEnumerable<string> Features
        {
            get
            {
                foreach (var v in features)
                    yield return v;
            }
        }

        public string GetDescription()
        {
            string s = null;
            foreach (var v in features)
                s += v.ToString() + " ";
            return "Family Car Interior " + s;
        }
    } //(v != "alufelgi" && v != "skórzane fotele" && v != "ABS" && v != "ASR" && v != "DVD" && v != "Immobilizer")

    public class StandardInterior : IInterior
    {
        List<string> features;
        public StandardInterior(List<string> list)
        {
            features = new List<string>();
            foreach (var v in list)
            {
                if (v != "Immobilizer" )
                    features.Add(v);
            }
        }
        public IEnumerable<string> Features
        {
            get
            {
                foreach (var v in features)
                    yield return v;
            }
        }

        public string GetDescription()
        {
            string s = null;
            foreach (var v in features)
                s += v.ToString() + " ";
            return "Family Car Interior " + s;
        }
    }

    public class PremiumInterior : IInterior
    {
        List<string> features;
        public PremiumInterior(List<string> list)
        {
            features = new List<string>();
            foreach (var v in list)
            {
                if (v != "DVD")
                    features.Add(v);
            }
        }
        public IEnumerable<string> Features
        {
            get
            {
                foreach (var v in features)
                    yield return v;
            }
        }

        public string GetDescription()
        {
            string s = null;
            foreach (var v in features)
                s += v.ToString() + " ";
            return "Family Car Interior " + s;
        }
    }
    public class FancyBody : IBody
    {
        public FancyBody(BodyType t, Color c)
        {
            Type = t == BodyType.Combi? BodyType.Coupe : t;
            if (c == Cars.Interfaces.Color.White || c == Cars.Interfaces.Color.Black)
                Color = Cars.Interfaces.Color.Blue.ToString();
            else
                Color = c.ToString();

        }
        public string Color { get; }

        public BodyType Type { get; }

        public string GetDescription()
        {
            return "Fancy Body Color: " + Color.ToString() + " Type: " + Type.ToString();
        }
    }
    public class FamilyBody : IBody
    {
        public FamilyBody(BodyType t, Color c)
        {
            Type = t == BodyType.Cabriolet ? BodyType.Sedan : t;
            if (c != Cars.Interfaces.Color.White || c != Cars.Interfaces.Color.Black)
                Color = Cars.Interfaces.Color.Black.ToString();
            else
                Color = c.ToString();
        }
        public string Color { get; }

        public BodyType Type { get; }

        public string GetDescription()
        {
            return "Fancy Body " + Color.ToString() + " Type: " + Type.ToString();
        }
    }
    public class SportBody : IBody
    {
        public SportBody(BodyType t, Color c)
        {
            Type = t == BodyType.Combi ? BodyType.Cabriolet : t;
            if (c == Cars.Interfaces.Color.NeonPink)
                Color = Cars.Interfaces.Color.Rouge.ToString();
            else
                Color = c.ToString();
        }
        public string Color { get; }

        public BodyType Type { get; }

        public string GetDescription()
        {
            return "Fancy Body " + Color.ToString() + " Type: " + Type.ToString();
        }
    }
}
