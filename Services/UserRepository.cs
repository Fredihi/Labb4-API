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

        public async Task<InterestLink> Add(string newLink, int id, int interestid)
        {
            //var user = from u in _appDbContext.Users
            //           join k in _appDbContext.UserInterests on u.Id equals k.UserID
            //           join i in _appDbContext.InterestLinks on k.InterestLinkID equals i.InterestLinkID
            //           where u.Id == id
            //           select u;

            var link = new InterestLink()
            {
                Link = newLink
            };
            var userinterest = new UserInterest()
            {
                UserID = id,
                InterestID = interestid
            };

            await _appDbContext.InterestLinks.AddAsync(link);
            await _appDbContext.UserInterests.AddAsync(userinterest);
            await _appDbContext.SaveChangesAsync();
            return link;
        }
        //public async Task<InterestLink> Add(InterestLink newLink, UserInterest userinterest)
        //{
        //    if (newLink == null)
        //    {
        //        return null;
        //    }
        //    if (userinterest == null)
        //    {
        //        return null;
        //    }
        //    _appDbContext.InterestLinks.Add(newLink);
        //    _appDbContext.UserInterests.Add(userinterest);
        //    await _appDbContext.SaveChangesAsync();
        //    return newLink;
        //}

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
