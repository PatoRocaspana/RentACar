using RentACar.Models;
using RentACar.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentACar.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(FilePathsStorage storageConfig) : base(storageConfig.Client) { }

        public override Client Create(Client entity)
        {
            if (EntityList.Any(e => e.Dni == entity.Dni))
                return null;

            entity.LastUpdate = DateTime.UtcNow;

            var clientCreated = base.Create(entity);

            return clientCreated;
        }

        public override List<Client> GetAll()
        {
            var list = EntityList
                           .OrderBy(e => e.Id)
                           .ToList();
            return list;
        }

        protected override void UpdateEntity(Client existingEntity, Client newEntity)
        {
            existingEntity.Dni = newEntity.Dni;
            existingEntity.Name = newEntity.Name;
            existingEntity.LastName = newEntity.LastName;
            existingEntity.PhoneNumber = newEntity.PhoneNumber;
            existingEntity.City = newEntity.City;
            existingEntity.Address = newEntity.Address;
            existingEntity.PostalCode = newEntity.PostalCode;
            existingEntity.Province = newEntity.Province;
            existingEntity.LastUpdate = DateTime.UtcNow;
        }
    }
}
