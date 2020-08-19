using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.AsyncAwait
{
    public class TeaMaker9000
    {
        public string MakeTea()
        {
            Console.WriteLine();
            Console.WriteLine("Making tea synchronously:");
            Console.WriteLine();

            string water = "water";
            string boiledWater = BoilWater(water);

            // These following 2 actions could be done while waiting for the water to be boiled
            Console.WriteLine("Take some cups out");
            Console.WriteLine("Put tea in cups");

            int count = 100_000_000;
            Console.WriteLine($"Counting to {count}");
            for (int i = 0; i <= count; i++)
            {
                // Show progress
                if (i % (count / 10) == 0)
                {
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine($"Pour {boiledWater} in cups");

            Console.WriteLine("Tea should be ready in a few minutes");

            return "tea";
        }

        public string BoilWater(string water)
        {
            Console.WriteLine($"Pour {water} in a kettle");
            Console.WriteLine("Start the kettle");
            Console.WriteLine($"Wait for the {water} to be boiled");

            Task.Delay(2000).Wait();

            Console.WriteLine("Kettle finished boiling");

            return "boiled " + water;
        }

        public async Task<string> MakeTeaAsync()
        {
            Console.WriteLine();
            Console.WriteLine("Making tea asynchronously:");
            Console.WriteLine();

            string water = "water";
            Task<string> boilingWater = BoilWaterAsync(water);

            // These following 2 actions could be done while waiting for the water to be boiled
            Console.WriteLine("Take some cups out");
            Console.WriteLine("Put tea in cups");

            // We can do other stuff as well, while waiting
            int count = 100_000_000;
            Console.WriteLine($"Counting to {count} while waiting");
            for (int i = 0; i <= count; i++)
            {
                // Show progress
                if (i % (count / 10) == 0)
                {
                    Console.WriteLine(i);
                }
            }

            string boiledWater = await boilingWater;

            Console.WriteLine($"Pour {boiledWater} in cups");

            Console.WriteLine("Tea should be ready in a few minutes");

            return "tea";
        }

        public async Task<string> BoilWaterAsync(string water)
        {
            Console.WriteLine($"Pour {water} in a kettle");
            Console.WriteLine("Start the kettle");
            Console.WriteLine($"Wait for the {water} to be boiled");

            await Task.Delay(500);

            Console.WriteLine("Kettle finished boiling");

            return "boiled " + water;
        }
    }
}
