namespace RentACar.CRUD
{
    public interface ICarCRUD
    {
        Car Create(Car car);
        Car Get(int id);
        Car Update(Car car);
        void Delete(int id);
    }
}
