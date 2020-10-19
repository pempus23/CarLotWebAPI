using AutoLotDAL.Models.Base;

namespace AutoLotDAL.Repos
{
    public interface IExtendRepository<T> : IRepo<T>, IDelete<T> where T : EntityBase { }
}
