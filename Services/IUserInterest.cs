using API_Models;

namespace Labb4_API.Services
{
    public interface IUserInterest<T>
    {
        Task<T> Add(UserInterest entity);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<InterestLink>> GetLinks(int id);
    }
}
