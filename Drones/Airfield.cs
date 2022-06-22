using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield : IEnumerable<Drone>
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }

        private List<Drone> Drones { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public double LandingStrip { get; set; }

        //Functionalities:
        public int Count => this.Drones.Count;

        public object StringBulder { get; private set; }

        public string AddDrone(Drone drone)
        {
            if (this.Count == Capacity)
            {
                return "Airfield is full.";
            }

            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range <= 5 || drone.Range >= 15)
            {
                return "Invalid drone.";
            }

            this.Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            if (this.Drones.Any(d => d.Name == name))
            {
                this.Drones.Remove(this.Drones.Find(d => d.Name == name));
                return true;
            }

            return false;
        }

        public int RemoveDroneByBrand(string brand)
        {
            int count = this.Drones.Count(d => d.Brand == brand);
            this.Drones.RemoveAll(d => d.Brand == brand);

            return count;
        }

        public Drone FlyDrone(string name)
        {
            if (this.Drones.Any(d => d.Name == name))
            {
                this.Drones.Find(d => d.Name == name).Available = false;
                return Drones.Find(d => d.Name == name);
            }

            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            this.Drones.FindAll(d => d.Range >= range).ForEach(d => d.Available = false);
            return this.Drones.FindAll(d => d.Range >= range);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Drones available at {this.Name}:");

            foreach (Drone drone in this.Drones.Where(d => d.Available))
            {
                result.AppendLine(drone.ToString());
            }

            return result.ToString().Trim();
        }

        //IEnumerable interface:
        public IEnumerator<Drone> GetEnumerator()
        {
            foreach (var item in Drones)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
