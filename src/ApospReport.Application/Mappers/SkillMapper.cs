using System.Collections.Generic;
using System.Linq;
using ApospReport.Contract;
using ApospReport.Domain.Models;

namespace ApospReport.Application.Mappers
{
    internal interface ISkillMapper
    {
        Skill MapFromReport(SkillDto skill);
    }

    internal class SkillMapper : ISkillMapper
    {

        public Skill MapFromReport(SkillDto skill)
        {
            return new()
            {
                BaseLevel = skill.BaseLevel,
                CurrentLevel = skill.CurrentLevel
            };
        }
    }
}
