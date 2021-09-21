using System.Collections.Generic;
using System.Linq;
using ApospReport.Contract;
using ApospReport.Domain.Models;

namespace ApospReport.Application.Mappers
{
    internal interface ISkillMapper
    {
        IList<Skill> MapFromReport(IList<ReportSkillDto> skills);
    }

    internal class SkillMapper : ISkillMapper
    {
        public IList<Skill> MapFromReport(IList<ReportSkillDto> skills)
        {
            return skills.Select(MapFromReport).ToList();
        }

        private static Skill MapFromReport(ReportSkillDto skill)
        {
            return new()
            {
                BaseLevel = skill.BaseLevel,
                CurrentLevel = skill.CurrentLevel
            };
        }
    }
}
