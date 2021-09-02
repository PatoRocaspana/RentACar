using System;

namespace RentACar
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create Cars objects
            var car1 = new Car(Brand.Chevrolet, "Corsa", 5, "White", Transmission.Manual);
            var car2 = new Car(Brand.Fiat, "Punto", 3, "Red", Transmission.Manual);
            var car3 = new Car(Brand.Renault, "Clio", 5, "Green", Transmission.Manual);
            var car4 = new Car(Brand.Volkswagen, "Vento", 4, "Silver", Transmission.Automatic);

            //Create CarCRUD object
            var carCrud = new CarCRUD();

            //Create Cars in json
            carCrud.Create(car1);
            carCrud.Create(car2);
            carCrud.Create(car3);
            carCrud.Create(car4);

            //Get Car from json
            var getResponse = carCrud.Get(4);
            var getMessage = (getResponse != null) ? $"Here is the {getResponse.Brand} {getResponse.Model} color {getResponse.Color} for you!" : "Sorry, we dont have that car!";
            Console.WriteLine(getMessage);

            //Update Car from json
            var carToUpdate = new Car(1, Brand.Chevrolet, "Camaro", 2, "Yellow", Transmission.Automatic);
            var updateResponse = carCrud.Update(carToUpdate);
            var updateMessage = (updateResponse != null) ? $"Car updated to {updateResponse.Brand} {updateResponse.Model}!" : "Sorry, we dont have that car!";
            Console.WriteLine(updateMessage);

            //Delete Car from json
            carCrud.Delete(7);
        }
    }
}
