using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Model;
using RecipeAPI.Repository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        // Fields
        private readonly MealRepository _repo;
        private readonly ILogger<MealController> _logger;

        // Constructor
        public MealController(MealRepository repo, ILogger<MealController> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        
        // Methods
        // GET: api/<MealController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetAllMealsAsync()
        {
            IEnumerable<Meal> meals;
            try
            {
                meals = await _repo.GetAll();
            }catch (Exception e) {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
            return Ok(meals.ToList());
        }
        /*
        // GET api/<MealController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        */
        // POST api/<MealController>
        [HttpPost]
        public async Task<ActionResult> PostNewMealAsync([FromBody] Meal meal)
        {
            try
            {
                await _repo.Add(meal);
            }catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500);
            }
            return Ok();
        }
        /*
        // PUT api/<MealController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MealController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
