using Microsoft.Extensions.Logging;
using System;

namespace LoggerTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ILogger logger = new Logger.AppLogger<Program>("C://Logs/Logger.db");
            try
            {
                logger.LogInformation("Pierwsza informacja");
                throw new DivideByZeroException("Dzielenie przez zero");
            }
            catch (Exception e)
            {
                logger.LogError(e, "Informacje o errorze");
                throw;
            }

        }
    }
}
