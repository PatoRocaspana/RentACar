using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace RentACar
{
    public class CarCRUD
    {
        private readonly string _jsonFile = @"C:\repos\RentACar\RentACar\RentACar\DataBase\Cars.json";

        public Car Create(Car car)
        {
            var cars = new List<Car>();

            if (File.Exists(_jsonFile))
            {
                var existingJsonToString = File.ReadAllText(_jsonFile);
                cars = JsonSerializer.Deserialize<List<Car>>(existingJsonToString);

                car.Id = cars.Count;
                cars.Add(car);
            }
            else
            {
                car.Id = 0;
                cars.Add(car);
            }

            var listToString = JsonSerializer.Serialize(cars);
            File.WriteAllText(_jsonFile, listToString);

            return car;

        }

        public Car Get(int id)
        {
            // Code here
            return new Car();
        }

        public Car Update(Car car)
        {
            // Code here
            return new Car();
        }

        public void Delete(int id)
        {
            // Code here
        }
    }
}
