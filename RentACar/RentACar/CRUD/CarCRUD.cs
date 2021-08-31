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

        private List<Car> DeserializeJsonToList(string jsonFile)
        {
            string existingJsonToString = File.ReadAllText(jsonFile);
            List<Car> deserializedJson = JsonSerializer.Deserialize<List<Car>>(existingJsonToString);

            return deserializedJson;
        }

        private void SerializeListToJson(List<Car> cars)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };

            string listToString = JsonSerializer.Serialize(cars, options);
            File.WriteAllText(_jsonFile, listToString);
        }

        public Car Create(Car car)
        {
            var cars = new List<Car>();

            if (File.Exists(_jsonFile))
            {
                cars = DeserializeJsonToList(_jsonFile);

                car.Id = cars.Last().Id + 1;
                cars.Add(car);
            }
            else
            {
                car.Id = 0;
                cars.Add(car);
            }

            SerializeListToJson(cars);

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
