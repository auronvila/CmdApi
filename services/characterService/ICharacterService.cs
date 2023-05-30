using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmdApi.services.characterService
{
    public interface ICharacterService
    {
        List<Character> GetAllCharacters();
        Character GetCharacterBYId(int id);
        List<Character> AddCharacter(Character newCharacter);
    }
}