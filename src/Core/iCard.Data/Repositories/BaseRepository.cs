using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using iCard.Data.Contexts;
using iCard.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace iCard.Data.Repositories
{
    public class BaseRepository<T> where T : BaseEntity
    {
        public DbContext context;
        public DbSet<T> items;

        public BaseRepository()
        {
            context = new ICardContext();
            items = context.Set<T>();
        }

        public T GetById(int id)
        {
            return items
                .Where(i => i.Id == id)
                .FirstOrDefault();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            return items
                .Where(filter)
                .FirstOrDefault();
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null, int page = 1, int pageSize = int.MaxValue)
        {
            IQueryable<T> query = items;

            if (filter != null)
                query = query.Where(filter);

            return query
                .OrderBy(i => i.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public void Save(T item)
        {
            if (item.Id > 0)
            {
                context.Entry(item).State = EntityState.Modified;

            }
            else
                items.Add(item);

            context.SaveChanges();
        }

        public void SaveItem(T item)
        {
            items.Add(item);
            context.SaveChanges();
        }

        public void Delete(T item)
        {
            context.Entry(item).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}