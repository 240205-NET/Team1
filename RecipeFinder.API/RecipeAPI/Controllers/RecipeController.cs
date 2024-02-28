
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeFinder.DTO;
using RecipeFinder.Logic.Model;

namespace Recipe.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeRepository _repo;
        private readonly ILogger<RecipeRepository> _logger;

        public RecipeController(RecipeRepository repo, ILogger<RecipeRepository> logger)
        {
            _repo= repo;
            _logger = logger;
        }

        // GET: api/<UserController>/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var user = await _repo.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

    }
}
