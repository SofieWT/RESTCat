using Microsoft.AspNetCore.Mvc;
using RESTCat.Interfaces;
using RESTCat.Models;
using System.Drawing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RESTCat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private ICatRepository _catRepository;

        public CatController(ICatRepository catRepository)
        {
            _catRepository = catRepository;
        }

        // GET: api/<CatController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<Cat>> Get([FromQuery] string? name = null, [FromQuery] string? breed = null, [FromQuery] string? color = null, [FromQuery] string? sortOrder = null)
        {

            var cats = _catRepository.GetCats(name, breed, color, sortOrder);
            if (cats !=null)
            {
                return Ok(cats);
            }
            else
            {
               return NotFound("No cats found matching the specified criteria.");
            }
        }

        // GET api/<CatController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Cat> Get(int id)
        {
            var cat = _catRepository.GetCatById(id);
            if (cat == null)
            {
                return NotFound("Cat not found.");
            }
            return Ok(cat);
        }

        // POST api/<CatController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cat> Post([FromBody] Cat cat)
        {
            if (cat == null)
            {
                return BadRequest("Invalid cat data.");
            }
                
            var createdCat = _catRepository.AddCat(cat);
            return CreatedAtAction(nameof(Get), new { id = createdCat.Id }, createdCat);
        }

        // PUT api/<CatController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Cat> Put(int id, [FromBody] Cat data)
        {
            var cat = _catRepository.UpdateCat(id, data);
            if (cat == null)
            {
                return NotFound("Cat not found.");
            }
            return Ok(cat);

        }

        // DELETE api/<CatController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Cat> Delete(int id)
        {
            var deletedCat = _catRepository.DeleteCat(id);
            if(deletedCat == null)
            {
                return NotFound("Cat not found.");
            }
            else
            {
                return Ok("Cat deleted successfully.");
            }

        }
    }
}
