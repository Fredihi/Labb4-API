using API_Models;
using Labb4_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb4_API.Services
{
    public class UserRepository : ILabb4<User>
    {
        private AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<InterestLink> Add(string newlink, int userid, int interestid)
        {
            var result = await _appDbContext.UserInterests
                .FirstOrDefaultAsync(p => p.UserID == userid && p.InterestID == interestid);
            if (result == null)
            {
                return null;
            }
            var link = new InterestLink()
            {
                Link = newlink,
                UserInterest = result
            };

            await _appDbContext.InterestLinks.AddAsync(link);
            await _appDbContext.SaveChangesAsync();
            return link;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _appDbContext.Users.ToListAsync();
        }

        public async Task<User> GetSingle(int id)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
