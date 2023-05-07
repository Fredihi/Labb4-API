using API_Models;
using Labb4_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb4_API.Services
{
    public class UserInterestRepo : IUserInterest<UserInterest>
    {
        private AppDbContext _appDbContext;

        public UserInterestRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<UserInterest> Add(UserInterest newInterest)
        {
            if (newInterest == null)
            {
                return null;
            }

            _appDbContext.UserInterests.Add(newInterest);
            await _appDbContext.SaveChangesAsync();
            return newInterest;
        }

        public async Task<IEnumerable<UserInterest>> GetAll()
        {
            return await _appDbContext.UserInterests.ToListAsync();
        }

        public async Task<IEnumerable<InterestLink>> GetLinks(int id)
        {
            var result = from i in _appDbContext.UserInterests
                         join k in _appDbContext.InterestLinks on i.InterestLinkID equals k.InterestLinkID
                         join u in _appDbContext.Users on i.UserID equals u.Id
                         where i.UserID == id
                         select k;
            return await result.ToListAsync();
        }
    }
}
