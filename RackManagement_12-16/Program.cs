using System;

namespace RackManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestsForRackManagement1();

            TestsForDictionaryProcessingClass();
            
        }

        public static void TestsForRackManagement1()
        {
            // Main Excercise
            
            // TestCase 1 -> true
            var rack1 = new ScrabbleRack("ladilmy");
            Console.WriteLine(rack1.CanMakeWord("daily"));

            // TestCase 2 -> false
            var rack2 = new ScrabbleRack("eerriin");
            Console.WriteLine(rack2.CanMakeWord("eeire"));

            // TestCase 3 -> true
            var rack3 = new ScrabbleRack("orrpgma");
            Console.WriteLine(rack3.CanMakeWord("program"));

            // TestCase 4 -> false
            var rack4 = new ScrabbleRack("orppgma");
            Console.WriteLine(rack4.CanMakeWord("program"));

            // Bonus 1

            //TestCase 1 -> true
            var bonusRack1 = new ScrabbleRack("pizza??");
            Console.WriteLine(bonusRack1.CanMakeWord("pizzazz"));

            //TestCase 2 -> false
            var bonusRack2 = new ScrabbleRack("pizza??");
            Console.WriteLine(bonusRack2.CanMakeWord("pizzazz"));

            //TestCase 3 - true
            var bonusRack3 = new ScrabbleRack("a??????");
            Console.WriteLine(bonusRack3.CanMakeWord("program"));

            //TestCase 4 - false
            var bonusRack4 = new ScrabbleRack("b??????");
            Console.WriteLine(bonusRack4.CanMakeWord("program"));

            // Bonus 2

            //TestCase 1 -> "coauthored"
            var bonusRack5 = new ScrabbleRack("dcthoyueorza");

            //TestCase 2 -> "turquois"
            var bonusRack6 = new ScrabbleRack("uruqrnytrois");

            //TestCase 3 - "greengrocery"
            var bonusRack7 = new ScrabbleRack("rryqeiaegicgeo??");

            //TestCase 4 - "subordinately"
            var bonusRack8 = new ScrabbleRack("udosjanyuiuebr??");

            // TestCase 5 -> "ovolactovegetarian"
            var bonusRack9 = new ScrabbleRack("vaakojeaietg????????");
        }

        public static void TestsForDictionaryProcessingClass()
        {
            // Check Constructor
            var list = new WordList();

            // Check alphabetical constructor
            list = new WordList("alphabetical");

            // Check length sorted constructor
            list = new WordList("length");
            for (int i = 0; i < list.Length - 2; i++)
            {
                if (list.AllWords[i].Length < list.AllWords[i+1].Length)
                {
                    Console.WriteLine("failed");
                    return;
                }
            }
        }
    }
}
