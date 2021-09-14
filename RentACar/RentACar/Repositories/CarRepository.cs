using RentACar.Models;
using RentACar.Options;

namespace RentACar.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(FilePathsStorageOptions storageConfig) : base(storageConfig.Car) { }

        protected override void UpdateEntity(Car existingEntity, Car newEntity)
        {
            existingEntity.Brand = newEntity.Brand;
            existingEntity.Color = newEntity.Color;
            existingEntity.DoorsQuantity = newEntity.DoorsQuantity;
            existingEntity.Model = newEntity.Model;
            existingEntity.Transmission = newEntity.Transmission;
        }
    }
}
