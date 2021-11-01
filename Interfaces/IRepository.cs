using System.Collections.Generic;
namespace cadastro_series
{
    public interface IRepository<T>
    {
         List <T> list();

         T ReturnById(int id);

         void Insert(T entity);

         void Delete(int id);

         void Update(int id, T entity);

         int NextId();
    }
}