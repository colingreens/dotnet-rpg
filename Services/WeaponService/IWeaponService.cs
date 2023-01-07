using dotnet_rpg.Dto.Weapon;

namespace dotnet_rpg.Services.CharacterService.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}