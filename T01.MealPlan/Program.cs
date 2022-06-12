using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //pasta soup salad steak pasta steak pasta
            const int SaladCalories = 350;
            const int SoupCalories = 490;
            const int PastaCalories = 680;
            const int SteakCalories = 790;

            string[] foodInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int[] caloriesInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<string> food = new Queue<string>(foodInfo);
            Stack<int> calories = new Stack<int>(caloriesInfo);

            int pastDays = 0;
            int mealsEaten = 0;

            string meal = food.Peek();
            int caloriesForTheDay = calories.Peek();
            int mealCalories = 0;

            if (meal == "salad")
            {
                mealCalories = SaladCalories;
            }
            else if (meal == "soup")
            {
                mealCalories = SoupCalories;
            }
            else if (meal == "pasta")
            {
                mealCalories = PastaCalories;
            }
            else if (meal == "steak")
            {
                mealCalories = SteakCalories;
            }

            while (true)
            {
                if (caloriesForTheDay < mealCalories)
                {
                    mealCalories -= caloriesForTheDay;
                    caloriesForTheDay = 0;
                }
                else 
                {
                    caloriesForTheDay -= mealCalories;
                    calories.Pop();
                    calories.Push(caloriesForTheDay);
                    food.Dequeue();
                    mealsEaten++;

                    if (!food.Any())
                    {
                        break;
                    }

                    meal = food.Peek();

                    if (meal == "salad")
                    {
                        mealCalories = SaladCalories;
                    }
                    else if (meal == "soup")
                    {
                        mealCalories = SoupCalories;
                    }
                    else if (meal == "pasta")
                    {
                        mealCalories = PastaCalories;
                    }
                    else if (meal == "steak")
                    {
                        mealCalories = SteakCalories;
                    }
                }

                if (caloriesForTheDay == 0)
                {
                    pastDays++;
                    calories.Pop();

                    if (!calories.Any())
                    {
                        break;
                    }

                    caloriesForTheDay = calories.Peek();
                }
            }

            if (food.Any())
            {
                Console.WriteLine($"John ate enough, he had {++mealsEaten} meals.");
                food.Dequeue();
                Console.WriteLine($"Meals left: {string.Join(", ", food)}.");
            }
            else
            {
                Console.WriteLine($"John had {mealsEaten} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
        }
    }
}
