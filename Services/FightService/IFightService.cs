using dotnet_rpg.Dto.Fight;

namespace dotnet_rpg.Services.FightService
{
    public interface IFightService
    {
        Task<ServiceResponse<AttackResultDto>> WeaponAttack(WeaponAttackDto request);
        Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto request);
        Task<ServiceResponse<FightResultsDto>> Fight(FightRequestDto request);
        Task<ServiceResponse<List<HighScoreDto>>> GetHighScores();

    }
}