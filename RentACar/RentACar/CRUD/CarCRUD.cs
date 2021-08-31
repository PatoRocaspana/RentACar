using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;


namespace RentACar
{
    public class CarCRUD
    {
        private readonly string _jsonFile = @"..\..\..\CRUD\Cars.json";

        public Car Create(Car car)
        {
            var cars = new List<Car>();

            if (File.Exists(_jsonFile))
            {
                var existingJsonToString = File.ReadAllText(_jsonFile);
                cars = JsonSerializer.Deserialize<List<Car>>(existingJsonToString);

                car.Id = cars.Last().Id + 1;
                cars.Add(car);
            }
            else
            {
                car.Id = 0;
                cars.Add(car);
            }

            var options = new JsonSerializerOptions { WriteIndented = true };

            var listToString = JsonSerializer.Serialize(cars, options);
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
