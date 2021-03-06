using RentACar.Models;
using RentACar.Repositories;
using System;

namespace RentACar.Test
{
    public static class ClientRepositoryTest
    {
        static public void TestAll(ClientRepository clientRepository)
        {
            //Create Clients objects
            var client1 = new Client
            {
                Dni = "12345678",
                Name = "Marcos",
                LastName = "Mundstock",
                PhoneNumber = "0123456789",
                Address = "Av San Martin 123",
                City = "Carlos Paz",
                Province = "Cordoba",
                PostalCode = "5001"
            };

            var client2 = new Client
            {
                Dni = "87654321",
                Name = "Guillermo",
                LastName = "Vilas",
                PhoneNumber = "987654321",
                Address = "Av Belgrano 987",
                City = "La Punta",
                Province = "San Luis",
                PostalCode = "4009"
            };

            var client3 = new Client
            {
                Dni = "6222111",
                Name = "Jorge",
                LastName = "Maronna",
                PhoneNumber = "1134112345",
                Address = "Cochabamba 1087",
                City = "Santo Tome",
                Province = "Santa Fe",
                PostalCode = "2001"
            };

            //Create Clients in json
            clientRepository.Create(client1);
            clientRepository.Create(client2);
            clientRepository.Create(client3);

            //Get Client from json
            var getResult = clientRepository.Get(1);
            var getMessage = (getResult != null) ? $"GET>> Here is the Client with Id {getResult.Id} whose name is {getResult.Name} {getResult.LastName}. Last Update {getResult.LastUpdate} !" : "GET>> Sorry, that client doesn´t exist in our db!";
            Console.WriteLine(getMessage);

            //Update Client from json
            var clientToUpdate = new Client
            {
                Dni = "6222111",
                Name = "Daniel",
                LastName = "Rabinovich",
                PhoneNumber = "456789123",
                Address = "Italia 17",
                City = "Rosario",
                Province = "Santa Fe",
                PostalCode = "2000"
            };

            var updateResult = clientRepository.Update(clientToUpdate, 1);
            var updateMessage = (updateResult is not null) ? $"UPDATE>> Client Id {updateResult.Id} {updateResult.Name} {updateResult.LastName} was updated! Now his/her adress is {updateResult.Address}!" : "UPDATE>> Sorry, that client doesn´t exist in our db or already exist a client with same Dni!";
            Console.WriteLine(updateMessage);

            //Delete Client from json
            clientRepository.Delete(7);

            foreach (var element in clientRepository.GetAll())
            {
                Console.WriteLine($"The client {element.Name} {element.LastName} has Id {element.Id}. Last update: {element.LastUpdate}");
            }
        }
    }
}
