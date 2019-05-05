using Me.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Me.DataAccess.Abstract
{
    public interface IBaseRepository<T> where T : IEntity
    {
        int Add(T item);
        int Remove(int id);
        int Update(T item);
        T FindByID(int id);
        IEnumerable<T> FindAll();
    }
}
