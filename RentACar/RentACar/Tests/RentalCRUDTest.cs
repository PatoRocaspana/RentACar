using RentACar.Models;
using RentACar.Repositories;
using System;

namespace RentACar.Tests
{
    public static class RentalCRUDTest
    {
        static public void TestAll(RentalCRUD rentalCrud)
        {
            //Create Cars objects

            var client1 = new Client
            {
                Dni = "12345678",
                Name = "Marcos",
                LastName = "Mudstock",
                PhoneNumber = "0123456789",
                Address = "Av San Martin 123",
                City = "Carlos Paz",
                Province = "Cordoba",
                PostalCode = "5001"
            };

            var client2 = new Client
            {
                Dni = "12345678",
                Name = "Marcos",
                LastName = "Mudstock",
                PhoneNumber = "0123456789",
                Address = "Av San Martin 123",
                City = "Carlos Paz",
                Province = "Cordoba",
                PostalCode = "5001"
            };

            var car1 = new Car { Brand = Brand.Fiat, Model = "Punto", DoorsQuantity = 3, Color = "Red", Transmission = Transmission.Manual };
            var car2 = new Car { Brand = Brand.Renault, Model = "Clio", DoorsQuantity = 5, Color = "Green", Transmission = Transmission.Manual };

            var rental1 = new Rental { Car = car1, Client = client1, RentalDate = DateTime.UtcNow.AddDays(-1), ReturnDate = DateTime.UtcNow };
            var rental2 = new Rental { Car = car2, Client = client2, RentalDate = DateTime.UtcNow.AddDays(-2), ReturnDate = DateTime.UtcNow };

            //Create Cars in json
            rentalCrud.Create(rental1);
            rentalCrud.Create(rental2);

            //Get Car from json
            var getResponse = rentalCrud.Get(1);
            var getMessage = (getResponse != null) ? $"GET>> Here is the Rental Id {getResponse.Id} RentalDate: {getResponse.RentalDate:dd/MM/yyyy} ReturnDate {getResponse.ReturnDate:dd/MM/yyyy} so RentalDuration {getResponse.RentalDuration.Days} days" : "GET>> Sorry, we dont have that rent!";
            Console.WriteLine(getMessage);

            //Update Car from json
            rental1.RentalDate = DateTime.UtcNow.AddDays(-30);
            var rentalToUpdate = rental1;
            var updateResponse = rentalCrud.Update(rentalToUpdate);
            var updateMessage = (updateResponse != null) ? $"UPDATE>>  Rental Id {updateResponse.Id} RentalDate: {updateResponse.RentalDate:dd/MM/yyyy} so now RentalDuration {updateResponse.RentalDuration.Days} days" : "UPDATE>> Sorry, we dont have that car!";
            Console.WriteLine(updateMessage);

            //Delete Car from json
            rentalCrud.Delete(7);

            //GetAll rentals
            foreach (var element in rentalCrud.GetAll())
            {
                Console.WriteLine($"The rental {element.Id} from client {element.Client.Dni} RentalDate: {element.RentalDate:dd/MM/yyyy} ReturnDate {element.ReturnDate:dd/MM/yyyy} so RentalDuration {element.RentalDuration.Days} ddays \n");
            }
        }
    }
}