using System;
using System.Linq;
using System.Reflection;
using DbUp;

namespace todoMigrations
{
    class Program
    {
        static int Main(string[] args)
        {
            int output = 0;

            var connectionString =
                args.FirstOrDefault()
                ?? "Server=127.0.0.1;Database=todo;User=sa;Password=Retnuh1601;";

            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsFromFileSystem("scripts")
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                output = -1;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
#if DEBUG
                Console.ReadLine();
#endif
            }
            else 
            {
                output = 0;
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success!");
                Console.ResetColor();
            }

            return output;
        }
    }
}
