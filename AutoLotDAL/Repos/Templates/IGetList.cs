using System.Collections.Generic;

namespace AutoLotDAL.Repos.Templates
{
    public interface IGetList<T> : IRepo<T>
    {
        List<T> GetOne(int id);
    }
}
