
namespace CmdApi.services.characterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{Id = 1 , Name = "Sam"},
        };

        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
 
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
             var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        try
            {
            var character  = characters.FirstOrDefault(c => c.Id == id);

            if(character == null) throw new Exception($"character with id {id} is not found");

            characters.Remove(character);


            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
             }
        catch (Exception ex)
            {
                serviceResponse.Successful = false;
                serviceResponse.Message = ex.Message;
            }
             return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterBYId(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
        try
            {
            var character  = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

            if(character == null) throw new Exception($"character with id {updatedCharacter.Id} is not found");

            _mapper.Map<Character>(updatedCharacter);

            character.Name = updatedCharacter.Name;
            character.Intelligence = updatedCharacter.Intelligence;
            character.Defense = updatedCharacter.Defense;
            character.Strength = updatedCharacter.Strength;
            character.HitPoints = updatedCharacter.HitPoints;
            character.Class = updatedCharacter.Class;

            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
             }
        catch (Exception ex)
            {
                serviceResponse.Successful = false;
                serviceResponse.Message = ex.Message;
            }
             return serviceResponse;
        }
    }
}