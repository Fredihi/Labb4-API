using API_Models;

namespace Labb4_API.Services
{
    public interface IInterestApi<T>
    {
        Task<T> Add(Interest entity);
        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> GetSingle(int id);

    }
}
