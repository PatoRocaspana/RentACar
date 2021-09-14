using System.Collections.Generic;

namespace RentACar.Intefaces
{
    public interface IRepository<T>
    {
        T Create(T obj);
        T Get(int id);
        T Update(T obj, int id);
        void Delete(int id);
        List<T> GetAll();
    }
}
