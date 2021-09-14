using RentACar.Models;
using RentACar.Repositories;
using System;

namespace RentACar.Test
{
    public static class CarCRUDTest
    {
        static public void TestAll(CarCRUD carCrud)
        {
            //Create Cars objects
            var car1 = new Car { Brand = Brand.Chevrolet, Model = "Corsa", DoorsQuantity = 5, Color = "White", Transmission = Transmission.Manual };
            var car2 = new Car { Brand = Brand.Fiat, Model = "Punto", DoorsQuantity = 3, Color = "Red", Transmission = Transmission.Manual };
            var car3 = new Car { Brand = Brand.Renault, Model = "Clio", DoorsQuantity = 5, Color = "Green", Transmission = Transmission.Manual };
            var car4 = new Car { Brand = Brand.Volkswagen, Model = "Vento", DoorsQuantity = 4, Color = "Silver", Transmission = Transmission.Automatic };

            //Create Cars in json
            carCrud.Create(car1);
            carCrud.Create(car2);
            carCrud.Create(car3);
            carCrud.Create(car4);

            //Get Car from json
            var getResponse = carCrud.Get(3);
            var getMessage = (getResponse != null) ? $"Here is the {getResponse.Brand} {getResponse.Model} color {getResponse.Color} for you!" : "Sorry, we dont have that car!";
            Console.WriteLine(getMessage);

            //Update Car from json
            var carToUpdate = new Car { Id = 4, Brand = Brand.Chevrolet, Model = "Camaro", DoorsQuantity = 2, Color = "Yellow", Transmission = Transmission.Automatic };
            var updateResponse = carCrud.Update(carToUpdate);
            var updateMessage = (updateResponse != null) ? $"Car updated to {updateResponse.Brand} {updateResponse.Model}!" : "Sorry, we dont have that car!";
            Console.WriteLine(updateMessage);

            //Delete Car from json
            carCrud.Delete(7);
        }
    }
}
