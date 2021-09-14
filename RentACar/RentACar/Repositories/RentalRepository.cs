using RentACar.Models;
using RentACar.Options;

namespace RentACar.Repositories
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        public RentalRepository(FilePathsStorageOptions storageConfig) : base(storageConfig.Rental) { }

        protected override void UpdateEntity(Rental existingEntity, Rental newEntity)
        {
            existingEntity.RentalDate = newEntity.RentalDate;
            existingEntity.ReturnDate = newEntity.ReturnDate;
            existingEntity.Car = newEntity.Car;
            existingEntity.Client = newEntity.Client;
        }
    }
}
