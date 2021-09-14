using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RentACar.Options;
using RentACar.Repositories;
using RentACar.Test;
using RentACar.Tests;

namespace RentACar
{
    class Program
    {
        static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, configuration) =>
                {
                    configuration.Sources.Clear();

                    configuration
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                    IConfigurationRoot configurationRoot = configuration.Build();

                    var storageOptions = new FilePathsStorage();
                    configurationRoot.GetSection(nameof(FilePathsStorage))
                                     .Bind(storageOptions);

                    System.Console.WriteLine("\nCarCRUD:");
                    var carCrud = new CarCRUD(storageOptions);
                    CarCRUDTest.TestAll(carCrud);

                    System.Console.WriteLine("\nClientCRUD:");
                    var clientCrud = new ClientCRUD(storageOptions);
                    ClientCRUDTest.TestAll(clientCrud);

                    System.Console.WriteLine("\nRentalCRUD:");
                    var rentalCrud = new RentalCRUD(storageOptions);
                    RentalCRUDTest.TestAll(rentalCrud);
                });
    }
}
