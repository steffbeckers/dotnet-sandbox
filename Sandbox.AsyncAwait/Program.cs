using System;
using System.Threading.Tasks;

namespace Sandbox.AsyncAwait
{
    public class Program
    {
        static void Main()
        {
            TeaMaker9000 teaMaker = new TeaMaker9000();

            teaMaker.MakeTea();

            Task.Run(async () =>
            {
                await teaMaker.MakeTeaAsync();
            }).Wait();
        }
    }
}
