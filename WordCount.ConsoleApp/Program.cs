using System;
using Autofac;
using WordCount.Main;
using WordCount.Main.Interfaces;

namespace WordCount.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = CreateContainerBuilder();

            using (var container = containerBuilder.Build())
            {
                var controller = container.Resolve<IController>();
                Console.WriteLine("Counting words...");
                var startAt = DateTime.Now;
                controller.Execute();
                var stopAt = DateTime.Now;
                Console.WriteLine("Input data processed in {0} secs", new TimeSpan(stopAt.Ticks - startAt.Ticks).TotalSeconds);
                Console.WriteLine();
                Console.WriteLine("Distinct words and count:");
                Console.WriteLine(controller.Report());
                Console.ReadLine();
            }
        }

        private static ContainerBuilder CreateContainerBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<MainAutofacModule>();

            return builder;
        }
    }
}
