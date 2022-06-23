using System;
using System.Collections.Generic;
using System.Linq;

namespace Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<char>> words = new Dictionary<string, List<char>>
            {
                { "pear", new List<char>() },
                { "flour", new List<char>() },
                { "pork", new List<char>() },
                { "olive", new List<char>() }
            };
            // We don't want the letters to be repeated and when the array length is full, we have found the corresponding words.
            
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split().Select(char.Parse).ToArray());
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split().Select(char.Parse).ToArray());
            List<string> foundWords = new List<string>();

            while (consonants.Count > 0)
            {
                char vowel = vowels.Dequeue();
                char consonant = consonants.Pop();

                foreach (var word in words)
                {
                    //key: word
                    //value: List with already found letters

                    if (word.Key.Contains(vowel) && !word.Value.Contains(vowel))
                    {
                        word.Value.Add(vowel);

                        //if (word.Value.Count == word.Key.Length)
                        //{
                        //    foundWords.Add(word.Key);
                        //    words.Remove(word.Key);
                        //}
                    }

                    if (word.Key.Contains(consonant) && !word.Value.Contains(consonant))
                    {
                        word.Value.Add(consonant);

                        //if (word.Value.Count == word.Key.Length)
                        //{
                        //    foundWords.Add(word.Key);
                        //    words.Remove(word.Key);
                        //}
                    }
                }

                //Returning it back to the collection:
                vowels.Enqueue(vowel);
            }

            Console.WriteLine($"Words found: {words.Count(w => w.Value.Count == w.Key.Length)}");
            //Console.WriteLine($"Words found: {foundWords.Count}");
            foreach (var word in words.Where(w => w.Value.Count == w.Key.Length))
            {
                Console.WriteLine(word.Key);
            }

            //foundWords.OrderBy(w => w.StartsWith("pe")).ThenBy(w => w.StartsWith("f")).ThenBy(w => w.StartsWith("po")).ThenBy(w => w.StartsWith("o"));

            
            //foreach (var word in foundWords)
            //{
            //    Console.WriteLine(word);
            //}
        }
    }
}
