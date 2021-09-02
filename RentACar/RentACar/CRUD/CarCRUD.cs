using System.IO;
using RentACar.Utilities;
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
            var cars = (File.Exists(_jsonFile)) ? CrudHelper.DeserializeJsonToList(_jsonFile) : new List<Car>();

            car.Id = CrudHelper.GetNewId(cars);
            cars.Add(car);

            CrudHelper.SerializeListToJson(cars, _jsonFile);

            return car;
        }

        public Car Get(int id)
        {
            if (!File.Exists(_jsonFile)) return null;

            var cars = CrudHelper.DeserializeJsonToList(_jsonFile);

            var car = cars.Where(e => e.Id == id).FirstOrDefault();

            return car ?? null;
        }

        public Car Update(Car car)
        {
            if (!File.Exists(_jsonFile)) return null;

            var cars = CrudHelper.DeserializeJsonToList(_jsonFile);

            if (!cars.Any(e => e.Id == car.Id)) return null;

            var carUpdated = CrudHelper.UpdateCarInListById(cars, car);
            CrudHelper.SerializeListToJson(cars, _jsonFile);

            return carUpdated;
        }

        public void Delete(int id)
        {
            var cars = CrudHelper.DeserializeJsonToList(_jsonFile);
            cars.Remove(cars.FirstOrDefault(car => car.Id == id));
            CrudHelper.SerializeListToJson(cars, _jsonFile);
        }
    }
}
