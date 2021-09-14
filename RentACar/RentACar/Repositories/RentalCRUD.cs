using RentACar.Models;
using RentACar.Options;

namespace RentACar.Repositories
{
    public class RentalCRUD : Repository<Rental>, IRentalCRUD
    {
        private readonly string _jsonFile;
        public RentalCRUD(FilePathsStorage config) : base(config.Rental)
        {
            _jsonFile = config.Rental;
        }

        protected override void UpdateObject(Rental existingObject, Rental newObject)
        {
            existingObject.RentalDate = newObject.RentalDate;
            existingObject.ReturnDate = newObject.ReturnDate;
            existingObject.Car = newObject.Car;
            existingObject.Client = newObject.Client;
        }
    }
}
