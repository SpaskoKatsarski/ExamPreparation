using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<Animal> Animals { get; private set; }

        public string AddAnimal(Animal animal)
        {
            if (animal.Species == null || animal.Species == " ")
            {
                return "Invalid animal species.";
            }
            else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            else if (Animals.Count == Capacity)
            {
                return "The zoo is full.";
            }

            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int count = Animals.Count(a => a.Species == species);
            Animals.RemoveAll(a => a.Species == species);
            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return Animals.Where(a => a.Diet == diet).ToList();
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.First(a => a.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = Animals.Count(a => a.Length >= minimumLength && a.Length <= maximumLength);
            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
