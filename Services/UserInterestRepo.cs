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
            var result = await _appDbContext.InterestLinks.Where(i => i.UserInterest.UserID == id).Select(u => new InterestLink
            {
                Link = u.Link
            }).ToListAsync();
            return result;
        }
    }
}
