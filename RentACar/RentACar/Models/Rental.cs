using RentACar.Models.Base;
using System;

namespace RentACar.Models
{
    public class Rental : Entity
    {
        public TimeSpan RentalDuration => MyMethodTime();
        public Client Client { get; set; }
        public Car Car { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }

        private TimeSpan MyMethodTime()
        {
            return ReturnDate - RentalDate;
        }
    }
}
