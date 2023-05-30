
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
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetAllCharacters()
        {
            return Ok( await _characterService.GetAllCharacters());
        }

        [HttpGet("GetSingleCharacter/{id}")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingleCharacter(int id)
        {
            return Ok( await _characterService.GetCharacterBYId(id));
        }

        [HttpPost("CreateCharacter")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> CreateCharacter(AddCharacterDto newCharacter)
        {
            return Ok( await _characterService.AddCharacter(newCharacter));
        }
    }
}