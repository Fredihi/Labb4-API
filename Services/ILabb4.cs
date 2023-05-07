using API_Models;

namespace Labb4_API.Services
{
    public interface ILabb4<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetSingle(int id);

        Task<InterestLink> Add(string link, int id, int interestid);

        Task<T> Update(T entity);

    }
}
