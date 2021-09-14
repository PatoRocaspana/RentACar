using RentACar.Helpers;
using RentACar.Intefaces;
using RentACar.Models.Base;
using System.Collections.Generic;
using System.Linq;

namespace RentACar.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        private List<T> _objs;

        private readonly string _jsonFile;

        public Repository(string config)
        {
            _jsonFile = config;
            _objs = CrudHelper<T>.CheckFileAndGetList(_jsonFile);
        }

        public virtual T Create(T obj)
        {
            obj.Id = CrudHelper<T>.GetNewId(_objs);
            _objs.Add(obj);

            CrudHelper<T>.SaveListToFile(_objs, _jsonFile);

            return obj;
        }

        public virtual T Update(T obj)
        {
            var existing = Get(obj.Id);

            if (existing is null)
                return null;

            UpdateObject(existing, obj);

            CrudHelper<T>.SaveListToFile(_objs, _jsonFile);

            return existing;
        }

        protected abstract void UpdateObject(T existing, T newValues);

        public virtual T Get(int id)
        {
            var obj = _objs.FirstOrDefault(e => e.Id == id);
            return obj;
        }

        public virtual void Delete(int id)
        {
            _objs.Remove(_objs.FirstOrDefault(obj => obj.Id == id));
            CrudHelper<T>.SaveListToFile(_objs, _jsonFile);
        }

        public virtual List<T> GetAll()
        {
            return _objs;
        }
    }
}
