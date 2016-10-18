using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Despensometro2.Models;
using System.Data.Entity;

namespace Despensometro2.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        private despensometroEntities db;
        private DbSet<T> dataMemory;

        public Repository()
        {
            db = new despensometroEntities();
            dataMemory = db.Set<T>();
        }

        public virtual IQueryable<T> ListAll()
        {
            return dataMemory;
        }

        public virtual T GetById(int id)
        {
            return dataMemory.Find(id);
        }

        public virtual void AddElement(T element)
        {
            dataMemory.Add(element);
            db.SaveChanges();
        }

        public virtual void UpdateElement(T element)
        {
            dataMemory.Attach(element);
            db.Entry(element).State = System.Data.EntityState.Modified;
            db.SaveChanges();
        }

        public virtual Boolean Delete(int id)
        {
            T element = dataMemory.Find(id);

            if (element != null)
            {
                dataMemory.Attach(element);
                dataMemory.Remove(element);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}