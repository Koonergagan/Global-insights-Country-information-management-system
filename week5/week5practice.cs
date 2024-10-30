using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5
{
    internal class week5practice
    {
        static void Main(string[] args)
        {
            //Example19();
            // Example20();
            Example21();
        }
        static void Example19()
        {
            Console.WriteLine("enter a sentence");
            string sentence = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(sentence))
            {
                string[] words = sentence.Split(" ");
                var result = from word in words
                             let eachword = word.Trim().ToLower()
                             orderby eachword
                             select eachword;
                if (result.Any())
                {

                    foreach (var item in result.Distinct())
                    {
                        Console.WriteLine(item);
                    }

                }
                else
                {
                    Console.WriteLine("no result");
                }
            }
            else
            {
                Console.WriteLine("No input provided");
            }
        }

        static void Example20()
        {
            List<char> randomLetters = new List<char>();
            for (int i = 0; i<30; i++)
            {
                Random random = new Random();
                randomLetters.Add((char)(random.Next('a','z'+1)));
            }
            var result = from letter in randomLetters
                         orderby letter ascending
                         select letter;
            foreach (var item in result)
            {
                Console.Write(  item+" ");
            }
            Console.WriteLine("next part:");
            var result2 = from letter in randomLetters
                         orderby letter descending
                         select letter;
            foreach (var item in result2.Distinct())
            {
                Console.Write(item+" ");
            }

        }
        static void Example21()
        {
            string[] words = {"hello", "wonderful", "LINQ", "beautiful","world"};
            var result = from word in words
                         where word.Length<=5
                         select word;
            foreach ( var item in result)
            {
                Console.Write(item+" ");
            }
        }
           

    }
}
