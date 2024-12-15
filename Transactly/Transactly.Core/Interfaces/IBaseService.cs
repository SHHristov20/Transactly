namespace Transactly.Core.Interfaces
{
    public interface IBaseService
    {
        Task<bool> Create<T>(T entity) where T : class;
        Task<bool> Update<T>(T entity) where T : class;
        Task<bool> Delete<T>(T entity) where T : class;
        Task<T?> GetById<T>(int id) where T : class;
        Task<IEnumerable<T>> GetAll<T>() where T : class;
    }
}
