using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public interface IEntityRepository<T> where T : class,IEntity,new() 
    {
        //Gerekli CRUD operasyonlarının iskeletleri yazılacaktır.
        List<T> GetAll(Expression<Func<T, bool>> filter = null);//Filtre olmayabilir anlamına gelmektedir.
        T Get(Expression<Func<T, bool>> filter);//Filtre olmalıdır
        void Add(T entity); 
        void Update(T entity);
        void Delete(T entity);




    }
}
