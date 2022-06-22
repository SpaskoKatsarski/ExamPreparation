using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> swordsInfo = new Dictionary<string, int>
            {
                { "Gladius", 70 },
                { "Shamshir", 80 },
                { "Katana", 90 },
                { "Sabre", 110 },
                { "Broadsword", 150 }
            };

            Dictionary<string, int> forgedSwordsWithCount = new Dictionary<string, int>
            {
                { "Gladius", 0 },
                { "Shamshir", 0 },
                { "Katana", 0 },
                { "Sabre", 0 },
                { "Broadsword", 0 }
            };

            Queue<int> steel = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int forgedSwords = 0;

            while (steel.Count > 0 && carbon.Count > 0)
            {
                int currSteel = steel.Dequeue();
                int currCarbon = carbon.Pop();

                if (swordsInfo.Any(s => s.Value == currSteel + currCarbon))
                {
                    string sword = swordsInfo.First(s => s.Value == currSteel + currCarbon).Key;
                    forgedSwordsWithCount[sword]++;
                    forgedSwords++;
                }
                else
                {
                    carbon.Push(currCarbon + 5);
                }
            }

            if (forgedSwords > 0)
            {
                Console.WriteLine($"You have forged {forgedSwords} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }

            if (steel.Count == 0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }

            if (carbon.Count == 0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }

            foreach (var sword in forgedSwordsWithCount.OrderBy(s => s.Key))
            {
                if (sword.Value > 0)
                {
                    Console.WriteLine($"{sword.Key}: {sword.Value}");
                }
            }
        }
    }
}
