using API_Models;
using Labb4_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Labb4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInterestController : ControllerBase
    {
        private IUserInterest<UserInterest> _labbApi;

        public UserInterestController(IUserInterest<UserInterest> labbApi)
        {
            _labbApi = labbApi;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserInterest(UserInterestDTO newInterest)
        {
            try
            {
                var result = new UserInterest();
                result.UserID = newInterest.UserID;
                result.InterestID = newInterest.InterestID;
                result.InterestLinkID = newInterest.InterestLinkID;
                return Ok(await _labbApi.Add(result));

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("GetUsersLinks/{id:int}")]
        public async Task<IActionResult> GetAllLinks(int id)
        {
            return Ok(await _labbApi.GetLinks(id));
        }
    }
}
