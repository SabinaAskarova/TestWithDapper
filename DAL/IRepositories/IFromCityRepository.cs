using MyProject.Models;
using System.Collections.Generic;

namespace MyProject.DAL.IRepositories
{
    public interface IFromCityRepository<T> where T : BaseEntity
    {
        //public List<FromCity> Get();

        //public FromCity GetById(int fCityId);

        //public FromCity Add(FromCity fromCity);

        //public FromCity Update(FromCity fromCity);

        //public void Delete(int fCityId);

        void Add(T item);
        void Delete(int id);
        void Update(T item);
        T FindByID(int id);
        IEnumerable<T> FindAll();
    }
}
