using RecipeAPI.Repository;
using RecipeAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recipe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repo;
        private readonly ILogger<UserController> _logger;

        public UserController(UserRepository repo, ILogger<UserController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        // GET: api/<UserController>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            try
            {
                var user = await _repo.GetById(id);
                if (user == null)
                {
                    return NotFound(); // Return 404 Not Found if user with the specified id is not found
                }
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500); // Return 500 Internal Server Error if an exception occurs
            }
        }

        //POST
        [HttpPost]
        [Route("signup")]
        public async Task<ActionResult> AddUser([FromBody]User newUser)
        {
            try
            {
                await _repo.Add(newUser);
            }
            catch (Exception ex) 
            {
                _logger?.LogError(ex, ex.Message);
                return StatusCode(500);
            }
            Console.WriteLine($"User {newUser.Username} has been added !");
            return StatusCode(200);
        }

    }
}
