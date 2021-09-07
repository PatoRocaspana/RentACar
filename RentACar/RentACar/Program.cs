using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RentACar.Options;
using RentACar.Test;
using System;

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

                    var jsonFileStorageOptions = new JsonFileStorageOptions();
                    configurationRoot.GetSection(jsonFileStorageOptions.SectionName)
                                     .Bind(jsonFileStorageOptions);

                    var carCrud = new CarCRUD(jsonFileStorageOptions);
                    CarCRUDTest.TestAll(carCrud);

                    Console.WriteLine($"jsonFileStorageOptions.SectionName={jsonFileStorageOptions.SectionName}");
                    Console.WriteLine($"jsonFileStorageOptions.FilePath={jsonFileStorageOptions.FilePath}");
                });
    }
}
