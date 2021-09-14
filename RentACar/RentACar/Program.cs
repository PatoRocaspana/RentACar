using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RentACar.Options;
using RentACar.Repositories;
using RentACar.Test;

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
                    var carRepository = new CarRepository(storageOptions);
                    CarRepositoryTest.TestAll(carRepository);

                    System.Console.WriteLine("\nClientCRUD:");
                    var clientRepository = new ClientRepository(storageOptions);
                    ClientRepositoryTest.TestAll(clientRepository);

                    System.Console.WriteLine("\nRentalCRUD:");
                    var rentalRepository = new RentalRepository(storageOptions);
                    RentalRepositoryTest.TestAll(rentalRepository);
                });
    }
}
