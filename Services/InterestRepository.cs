using API_Models;
using Labb4_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;

namespace Labb4_API.Services
{
    public class InterestRepository : IInterestApi<Interest>
    {
        private AppDbContext _appDbContext;
        public InterestRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Interest> Add(Interest newEntity)
        {
            var result = await _appDbContext.Interests.AddAsync(newEntity);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Interest>> GetAll()
        {
            return await _appDbContext.Interests.ToListAsync();
        }

        public async Task<IEnumerable<Interest>> GetSingle(int id)
        {
            var result = from i in _appDbContext.Interests
                         join k in _appDbContext.UserInterests on i.InterestID equals k.InterestID
                         join u in _appDbContext.Users on k.UserID equals u.Id
                         where u.Id == id
                         select i;
            return await result.ToListAsync();
        }
    }
}
