using MvcCv.Models.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcCv.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        DbCvEntities db = new DbCvEntities();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }
        public void Add(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void Delete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }

        public T Get(int id)
        {
            return db.Set<T>().Find(id);
        }

        public void Update(T p)
        {
            db.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            //silinecek olanın id sine ulaşmak için
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}