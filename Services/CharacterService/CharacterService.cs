namespace dotnet_rpg.Services.CharacterService
{
  public class CharacterService : ICharacterService
  {

    public CharacterService(IMapper mapper)
    {
      _mapper = mapper;
    }

    private static List<Character> characters = new List<Character>{
            new Character(),
            new Character{ Id = 1, Name = "Sam"}
        };

    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      var character = _mapper.Map<Character>(newCharacter);
      character.Id = characters.Max(x => x.Id) + 1;
      characters.Add(character);
      serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
    {
      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
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
        var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

        if (character is null)
        {
          throw new Exception($"Character with id:{updatedCharacter.Id} was not found");
        }

        _mapper.Map(updatedCharacter, character);

        serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

      }
      catch (Exception ex)
      {

        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }

      return serviceResponse;

    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
    {
      var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      try
      {
        var character = characters.FirstOrDefault(c => c.Id == id);

        if (character is null)
        {
          throw new Exception($"Character with id:{id} was not found");
        }

        characters.Remove(character);

        serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

      }
      catch (Exception ex)
      {

        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }

      return serviceResponse;
    }

    private readonly IMapper _mapper;
  }
}