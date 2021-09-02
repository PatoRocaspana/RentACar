namespace RentACar.CRUD
{
    public interface ICarCRUD
    {
        public Car Create(Car car);
        public Car Get(int id);
        public Car Update(Car car);
        public void Delete(int id);
    }
}
