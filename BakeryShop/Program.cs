using System;
using System.Collections.Generic;
using System.Linq;

namespace BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double[]> bakeryProducts = new Dictionary<string, double[]>()
            {
                { "Croissant", new double[2] { 50, 50} }, // int[0] = water %, int[1] = flour %
                { "Muffin", new double[2] { 40, 60} }, // int[0] = water %, int[1] = flour %
                { "Baguette", new double[2] { 30, 70} }, // int[0] = water %, int[1] = flour %
                { "Bagel", new double[2] { 20, 80} }  // int[0] = water %, int[1] = flour %
            };

            Queue<double> water = new Queue<double>(Console.ReadLine().Split().Select(double.Parse).ToArray());
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split().Select(double.Parse).ToArray());

            Dictionary<string, int> bakedProducts = new Dictionary<string, int>();

            while (water.Count != 0 && flour.Count != 0)
            {
                double currWater = water.Dequeue();
                double currFlour = flour.Pop();

                double waterPercantage = CalculateWaterPercantage(currWater, currFlour);
                double flourPercantage = 100 - waterPercantage;

                if (bakeryProducts.Any(p => p.Value[0] == waterPercantage && p.Value[1] == flourPercantage))
                {
                    string item = bakeryProducts.First(p => p.Value[0] == waterPercantage && p.Value[1] == flourPercantage).Key;

                    if (!bakedProducts.ContainsKey(item))
                    {
                        bakedProducts.Add(item, 0);
                    }

                    bakedProducts[item]++;
                }
                else
                {
                    double excessFlour = currFlour - currWater;
                    flour.Push(excessFlour);

                    string item = "Croissant";

                    if (!bakedProducts.ContainsKey(item))
                    {
                        bakedProducts.Add(item, 0);
                    }

                    bakedProducts[item]++;
                }
            }

            foreach (var product in bakedProducts.OrderByDescending(p => p.Value).ThenBy(p => p.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }

            if (water.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }

            if (flour.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
        }

        public static double CalculateWaterPercantage(double water, double flour)
        {
            return (water * 100) / (water + flour);
        }
    }
}

   
