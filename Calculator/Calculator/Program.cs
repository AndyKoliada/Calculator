using GuessNumber;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
            using (var serviceProvider = SetupDI())
            {
                serviceProvider.GetService<App>().Run();
            }
        }

        private static ServiceProvider SetupDI()
        {
            var services = new ServiceCollection();

            services.AddTransient<IAnimation, TrainAnimation>();
            services.AddTransient<IGame, Game>();

            services.AddTransient<App>();

            return services.BuildServiceProvider();
        }
    }
}
