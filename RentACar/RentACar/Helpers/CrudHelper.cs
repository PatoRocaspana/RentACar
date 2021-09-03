using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RentACar.Utilities
{
    static public class CrudHelper
    {
        public static Car UpdateCarInListById(List<Car> cars, Car car)
        {
            var carUpdated = cars.FirstOrDefault(e => e.Id == car.Id);

            carUpdated.Brand = car.Brand;
            carUpdated.Color = car.Color;
            carUpdated.DoorsQuantity = car.DoorsQuantity;
            carUpdated.Model = car.Model;
            carUpdated.Transmission = car.Transmission;

            return carUpdated;
        }
        public static int GetNewId(List<Car> cars)
        {
            if (cars.Count > 0)
                return cars.Select(x => x.Id).OrderByDescending(x => x).FirstOrDefault() + 1;
            else
                return 1;
        }
        public static List<Car> DeserializeJsonToList(string jsonFile)
        {
            using (var streamReader = File.OpenText(jsonFile))
            {
                var jsonContent = streamReader.ReadToEnd();
                List<Car> deserializedJson = JsonSerializer.Deserialize<List<Car>>(jsonContent);
                return deserializedJson;
            }
        }
        public static void SerializeListToJson(List<Car> cars, string jsonFile)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };

            using (var streamWriter = File.CreateText(jsonFile))
            {
                var listToString = JsonSerializer.Serialize(cars, options);
                streamWriter.Write(listToString);
            }
        }
    }
}
