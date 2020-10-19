using System;
using System.Collections.Generic;

namespace AutoLotDAL.Repos
{
public interface IRepo<T> : IDisposable
    {
    int Add(T entity);
    int AddRange(IList<T> entities);
    int Save(T entity);
    T GetOne(int? id);
    List<T> GetAll();
    List<T> ExecuteQuery(string sql);
    List<T> ExecuteQuery(string sql, object[] sqlParametersObjects);
}
}
