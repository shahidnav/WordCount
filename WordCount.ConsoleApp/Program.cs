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
                controller.Execute();
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
