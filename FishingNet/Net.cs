using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish = new List<Fish>();
        }

        public List<Fish> Fish { get; private set; }

        public string Material { get; set; }

        public int Capacity { get; set; }

        public int Count => Fish.Count;

        public string AddFish(Fish fish)
        {
            if (Fish.Count + 1 > Capacity)
            {
                return "Fishing net is full.";
            }

            if (string.IsNullOrEmpty(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            if (Fish.Any(f => f.Weight == weight))
            {
                Fish.Remove(Fish.First(f => f.Weight == weight));
                return true;
            }

            return false;
        }

        public Fish GetFish(string fishType)
        {
            return Fish.FirstOrDefault(f => f.FishType == fishType);
        }

        public Fish GetBiggestFish()
        {
            return Fish.OrderByDescending(f => f.Length).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {this.Material}:");

            foreach (var fish in this.Fish.OrderByDescending(f => f.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
