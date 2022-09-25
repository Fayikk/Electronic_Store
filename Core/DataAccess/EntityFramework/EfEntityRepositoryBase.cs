using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
    where TEntity : class, IEntity , new()
    where TContext : DbContext , new() 
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //eklenecek değişkeni bir geçici değişkene atayalım.
                var addedEntity = context.Entry(entity);
                //Durum belirtme işlemi bu  ne olacak.
                addedEntity.State = EntityState.Added;
                //Kaydetme işlemini gerçekleştiriyoruz.
                context.SaveChanges();

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //eklenecek değişkeni bir geçici değişkene atayalım.
                var deletedEntity = context.Entry(entity);
                //Durum belirtme işlemi bu  ne olacak.
                deletedEntity.State = EntityState.Deleted;
                //Kaydetme işlemini gerçekleştiriyoruz.
                context.SaveChanges();

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            //burada filre null değer döndürebilir dolayısıyla koşul ifadeleri eklememiz gerekecektir.
            using (TContext context = new TContext())
            {
                return filter == null?
                    context.Set<TEntity>().ToList():
                    context.Set<TEntity>().Where(filter).ToList();
            }
               
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                //eklenecek değişkeni bir geçici değişkene atayalım.
                var updatedEntity = context.Entry(entity);
                //Durum belirtme işlemi bu  ne olacak.
                updatedEntity.State = EntityState.Modified ;
                //Kaydetme işlemini gerçekleştiriyoruz.
                context.SaveChanges();

            }
        }
    }
}
