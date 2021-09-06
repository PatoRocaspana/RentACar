using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RentACar.Helpers
{
    static public class CrudHelper
    {
        public static List<Car> GetListFromFile(string json)
        {
            var carList = (!File.Exists(json)) ? new List<Car>() : DeserializeJsonToList(json);
            return carList;
        }

        public static int GetNewId(List<Car> cars)
        {
            if (cars.Count > 0)
                return cars.Max(e => e.Id) + 1;
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
