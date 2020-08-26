using System;
using System.Threading.Tasks;
using Ibge.Domain.ConsoleApp.Controller;

namespace Ibge.Domain.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {

                Console.WriteLine("Hello World!");

                await IbgeController.ExecuteFacadeManualTest();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{e.Message}, {e.InnerException.Message}");
            }
        }
    }
}
