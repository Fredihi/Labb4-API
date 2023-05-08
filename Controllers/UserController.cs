using API_Models;
using Labb4_API.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Labb4_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ILabb4<User> _labbApi;

        public UserController(ILabb4<User> labbApi)
        {
            _labbApi = labbApi;
        }

        [HttpGet("/GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _labbApi.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve data from Database");
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetSingle(int id)
        {
            try
            {
                var result = await _labbApi.GetSingle(id);
                if (result == null)
                {
                    return BadRequest($"Error users with ID:{id} could not be found");
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Could not retrieve data from Database");
            }
        }
        [HttpPost("/AddLink")]
        public async Task<IActionResult> AddLink(string newlink, int userid, int interestid)
        {
            try
            {
                var result = _labbApi.Add(newlink, userid, interestid);
                return Ok(await result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
