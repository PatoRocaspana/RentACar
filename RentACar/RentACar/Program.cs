using System;

namespace RentACar
{
    class Program
    {
        static void Main(string[] args)
        {

            var car1 = new Car(CarsBrands.Chevrolet, "Corsa", 5, "White", Transmission.Manual);
            var car2 = new Car(CarsBrands.Volkswagen, "Passat", 4, "Black", Transmission.Automatic);

            var carCrud = new CarCRUD();

            carCrud.Create(car1);
            carCrud.Create(car2);
        }
    }
}
