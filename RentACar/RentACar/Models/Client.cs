﻿using RentACar.Models.Base;
using System;

namespace RentACar.Models
{
    public class Client : Entity
    {
        public string Dni { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
