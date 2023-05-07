using API_Models;
using Labb4_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Labb4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private IInterestApi<Interest> _interestApi;

        public InterestController(IInterestApi<Interest> interestApi)
        {
            _interestApi = interestApi;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllInterests()
        {
            try
            {
                return Ok(await _interestApi.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error trying to get data from database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSingleInterest(int id)
        {
            var result = await _interestApi.GetSingle(id);
            try
            {
                return Ok(await _interestApi.GetSingle(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error trying to get data from specific ID.");
            }
        }
    }
}
