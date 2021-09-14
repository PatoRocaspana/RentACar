using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RentACar.Helpers
{
    static public class CrudHelper
    {
        /// <summary>
        /// Takes a file and deserialize it to a List<Car>.
        /// In the case that file does not exist, it returns a new empty List<Car>. CheckFileAndGetList
        /// </summary>
        public static List<Car> CheckFileAndGetList(string filePath)
        {
            var carList = (!File.Exists(filePath)) ? new List<Car>() : GetListFromFile(filePath);
            return carList;
        }

        public static int GetNewId(List<Car> cars)
        {
            if (cars.Count > 0)
                return cars.Max(e => e.Id) + 1;
            else
                return 1;
        }

        public static List<Car> GetListFromFile(string filePath)
        {
            using (var streamReader = File.OpenText(filePath))
            {
                var jsonContent = streamReader.ReadToEnd();
                List<Car> deserializedJson = JsonSerializer.Deserialize<List<Car>>(jsonContent);
                return deserializedJson;
            }
        }

        public static void SaveListToFile(List<Car> cars, string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };

            using (var streamWriter = File.CreateText(filePath))
            {
                var listToString = JsonSerializer.Serialize(cars, options);
                streamWriter.Write(listToString);
            }
        }
    }
}
