namespace RentACar
{
    public class Car
    {
        public int Id { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public int DoorsQuantity { get; set; }
        public string Color { get; set; }
        public Transmission Transmission { get; set; }

        //Constructors to "test" CarCRUD in Program.cs
        public Car()
        {

        }
        public Car(Brand brand, string model, int doorsQuantity, string color, Transmission transmission)
        {
            Brand = brand;
            Model = model;
            DoorsQuantity = doorsQuantity;
            Color = color;
            Transmission = transmission;
        }
        public Car(int id, Brand brand, string model, int doorsQuantity, string color, Transmission transmission)
        {
            Id = id;
            Brand = brand;
            Model = model;
            DoorsQuantity = doorsQuantity;
            Color = color;
            Transmission = transmission;
        }
    }
}
