
using Microsoft.AspNetCore.Mvc;

namespace CmdApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
            
        }


        [HttpGet("GetAll")]
        public ActionResult<List<Character>> GetAllCharacters(){
            return Ok(_characterService.GetAllCharacters());
        }

        [HttpGet("GetSingleCharacter/{id}")]
        public ActionResult<Character> GetSingleCharacter(int id){
            return Ok(_characterService.GetCharacterBYId(id));
        }

        [HttpPost("CreateCharacter")]
        public ActionResult<Character> CreateCharacter(Character newCharacter)
        {
            return Ok(_characterService.AddCharacter(newCharacter));
        }
    }
}