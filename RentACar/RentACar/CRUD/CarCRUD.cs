using RentACar.Helpers;
using System.Collections.Generic;
using System.Linq;
using RentACar.CRUD;

namespace RentACar
{
    public class CarCRUD : ICarCRUD
    {
        private readonly string _jsonFile = @"..\..\..\Data\Cars.json";

        public Car Create(Car car)
        {
            var cars = CrudHelper.GetListFromFile(_jsonFile);

            car.Id = CrudHelper.GetNewId(cars);
            cars.Add(car);

            CrudHelper.SerializeListToJson(cars, _jsonFile);

            return car;
        }

        public Car Get(int id)
        {
            var cars = CrudHelper.GetListFromFile(_jsonFile);

            var car = cars.FirstOrDefault(e => e.Id == id);

            return car;
        }

        public Car Update(Car car)
        {
            var cars = CrudHelper.GetListFromFile(_jsonFile);
            var carUpdated = UpdateCarInListById(cars, car);

            if (carUpdated is not null) CrudHelper.SerializeListToJson(cars, _jsonFile);

            return carUpdated;
        }

        public void Delete(int id)
        {
            var cars = CrudHelper.GetListFromFile(_jsonFile);
            cars.Remove(cars.FirstOrDefault(car => car.Id == id));
            CrudHelper.SerializeListToJson(cars, _jsonFile);
        }

        private static Car UpdateCarInListById(List<Car> cars, Car car)
        {
            var carUpdated = cars.FirstOrDefault(e => e.Id == car.Id);

            if (carUpdated is not null)
            {
                carUpdated.Brand = car.Brand;
                carUpdated.Color = car.Color;
                carUpdated.DoorsQuantity = car.DoorsQuantity;
                carUpdated.Model = car.Model;
                carUpdated.Transmission = car.Transmission;
            }

            return carUpdated;
        }
    }
}
