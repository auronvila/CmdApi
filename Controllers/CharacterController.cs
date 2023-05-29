using Microsoft.AspNetCore.Mvc;

namespace CmdApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{Id = 1 , Name = "Sam"},
        };

        [HttpGet("GetAll")]
        public ActionResult<List<Character>> Get(){
            return Ok(characters);
        }

        [HttpGet("GetSingleCharacter/{id}")]
        public ActionResult<Character> GetSingleCharacter(int id){
            return Ok(characters.FirstOrDefault(c => c.Id == id));
        }
    }
}