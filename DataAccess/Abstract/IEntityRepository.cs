using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T:class, IEntity,new()
    {   
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        //ayrı ayrı getirmeye gerek kalmayacak, filter=null. filtre vermeyebilirsin, verilmezse null olur.
        //p=>p.CategoryId=2 gibi filtreler yazmamızı sağlar.

        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}