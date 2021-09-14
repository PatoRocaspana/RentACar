using RentACar.Models;
using RentACar.Repositories;
using System;

namespace RentACar.Test
{
    public static class CarRepositoryTest
    {
        static public void TestAll(CarRepository carRepository)
        {
            //Create Cars objects
            var car1 = new Car { Brand = Brand.Chevrolet, Model = "Corsa", DoorsQuantity = 5, Color = "White", Transmission = Transmission.Manual };
            var car2 = new Car { Brand = Brand.Fiat, Model = "Punto", DoorsQuantity = 3, Color = "Red", Transmission = Transmission.Manual };
            var car3 = new Car { Brand = Brand.Renault, Model = "Clio", DoorsQuantity = 5, Color = "Green", Transmission = Transmission.Manual };
            var car4 = new Car { Brand = Brand.Volkswagen, Model = "Vento", DoorsQuantity = 4, Color = "Silver", Transmission = Transmission.Automatic };

            //Create Cars in json
            carRepository.Create(car1);
            carRepository.Create(car2);
            carRepository.Create(car3);
            carRepository.Create(car4);

            //Get Car from json
            var getResult = carRepository.Get(3);
            var getMessage = (getResult != null) ? $"Here is the {getResult.Brand} {getResult.Model} color {getResult.Color} for you!" : "Sorry, we dont have that car!";
            Console.WriteLine(getMessage);

            //Update Car from json
            var carToUpdate = new Car { Id = 4, Brand = Brand.Chevrolet, Model = "Camaro", DoorsQuantity = 2, Color = "Yellow", Transmission = Transmission.Automatic };
            var updateResult = carRepository.Update(carToUpdate);
            var updateMessage = (updateResult != null) ? $"Car updated to {updateResult.Brand} {updateResult.Model}!" : "Sorry, we dont have that car!";
            Console.WriteLine(updateMessage);

            //Delete Car from json
            carRepository.Delete(7);
        }
    }
}
