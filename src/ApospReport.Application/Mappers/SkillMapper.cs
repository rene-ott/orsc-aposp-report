using ApospReport.Contract;
using ApospReport.Domain.Models;

namespace ApospReport.Application.Mappers
{
    internal interface ISkillMapper
    {
        Skill MapFromDto(SkillDto skill);
    }

    internal class SkillMapper : ISkillMapper
    {

        public Skill MapFromDto(SkillDto skill)
        {
            return new()
            {
                BaseLevel = skill.BaseLevel,
                CurrentLevel = skill.CurrentLevel
            };
        }
    }
}
