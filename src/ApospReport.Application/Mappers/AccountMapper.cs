using ApospReport.Contract;
using ApospReport.Domain.Models;

namespace ApospReport.Application.Mappers
{
    internal interface IAccountMapper
    {
        Account MapFromDto(AccountReportDto accountReportDto);
    }

    internal class AccountMapper : IAccountMapper
    {
        private readonly ISkillMapper skillMapper;

        public AccountMapper(ISkillMapper skillMapper)
        {
            this.skillMapper = skillMapper;
        }

        public Account MapFromDto(AccountReportDto accountReportDto)
        {
            return new()
            {
                Username = accountReportDto.Username,
                Agility = skillMapper.MapFromDto(accountReportDto.Agility),
                Attack = skillMapper.MapFromDto(accountReportDto.Agility),
                Fishing = skillMapper.MapFromDto(accountReportDto.Fishing),
                Defense = skillMapper.MapFromDto(accountReportDto.Defense),
                Strength = skillMapper.MapFromDto(accountReportDto.Strength),
                Hits = skillMapper.MapFromDto(accountReportDto.Hits),
                Ranged = skillMapper.MapFromDto(accountReportDto.Ranged),
                Prayer = skillMapper.MapFromDto(accountReportDto.Prayer),
                Magic = skillMapper.MapFromDto(accountReportDto.Magic),
                Cooking = skillMapper.MapFromDto(accountReportDto.Cooking),
                Woodcut = skillMapper.MapFromDto(accountReportDto.Woodcut),
                Fletching = skillMapper.MapFromDto(accountReportDto.Fletching),
                Firemaking = skillMapper.MapFromDto(accountReportDto.Firemaking),
                Crafting = skillMapper.MapFromDto(accountReportDto.Crafting),
                Smithing = skillMapper.MapFromDto(accountReportDto.Smithing),
                Mining = skillMapper.MapFromDto(accountReportDto.Mining),
                Herblaw = skillMapper.MapFromDto(accountReportDto.Herblaw),
                Thieving = skillMapper.MapFromDto(accountReportDto.Thieving)
            };
        }
    }
}
