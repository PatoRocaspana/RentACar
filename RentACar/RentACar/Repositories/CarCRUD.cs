using RentACar.Models;
using RentACar.Options;

namespace RentACar.Repositories
{
    public class CarCRUD : Repository<Car>, ICarCRUD
    {
        private readonly string _jsonFile;
        public CarCRUD(FilePathsStorage config) : base(config.Car)
        {
            _jsonFile = config.Client;
        }

        protected override void UpdateObject(Car existingObject, Car newObject)
        {
            existingObject.Brand = newObject.Brand;
            existingObject.Color = newObject.Color;
            existingObject.DoorsQuantity = newObject.DoorsQuantity;
            existingObject.Model = newObject.Model;
            existingObject.Transmission = newObject.Transmission;
        }
    }
}
