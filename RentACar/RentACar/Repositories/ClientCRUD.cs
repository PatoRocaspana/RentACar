using RentACar.Models;
using RentACar.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RentACar.Repositories
{
    public class ClientCRUD : Repository<Client>, IClientCRUD
    {

        private readonly string _jsonFile;

        public ClientCRUD(FilePathsStorage config) : base(config.Client)
        {
            _jsonFile = config.Client;
        }

        public override Client Create(Client client)
        {
            var clients = base.GetAll();

            if (clients.Any(e => e.Dni == client.Dni))
                return null;

            client.LastUpdate = DateTime.UtcNow;

            var clientCreated = base.Create(client);

            return clientCreated;
        }

        public override List<Client> GetAll()
        {
            var list = base.GetAll()
                           .OrderBy(e => e.Id)
                           .ToList();
            return list;
        }

        protected override void UpdateObject(Client existingObject, Client newObject)
        {
            existingObject.Dni = newObject.Dni;
            existingObject.Name = newObject.Name;
            existingObject.LastName = newObject.LastName;
            existingObject.PhoneNumber = newObject.PhoneNumber;
            existingObject.City = newObject.City;
            existingObject.Address = newObject.Address;
            existingObject.PostalCode = newObject.PostalCode;
            existingObject.Province = newObject.Province;
            existingObject.LastUpdate = DateTime.UtcNow;
        }
    }
}
