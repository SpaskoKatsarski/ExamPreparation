using System.Text;

namespace Drones
{
    public class Drone
    {
        public Drone(string name, string brand, int range)
        {
            this.name = name;
            this.brand = brand;
            this.range = range;
            this.available = true;
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string brand;

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        private int range;

        public int Range
        {
            get { return range; }
            set { range = value; }
        }

        private bool available;

        public bool Available
        {
            get { return available; }
            set { available = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drone: {this.name}");
            sb.AppendLine($"Manufactured by: {this.brand}");
            sb.AppendLine($"Range: {this.range} kilometers");

            return sb.ToString().Trim();
        }
    }
}
