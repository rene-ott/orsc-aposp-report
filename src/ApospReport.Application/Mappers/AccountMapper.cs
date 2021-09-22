using ApospReport.Contract;
using ApospReport.Domain.Models;

namespace ApospReport.Application.Mappers
{
    internal interface IAccountMapper
    {
        Account MapFromReport(AccountDto accountDto);
    }

    internal class AccountMapper : IAccountMapper
    {
        private readonly ISkillMapper skillMapper;

        public AccountMapper(ISkillMapper skillMapper)
        {
            this.skillMapper = skillMapper;
        }

        public Account MapFromReport(AccountDto accountDto)
        {
            return new Account
            {
                Username = accountDto.Username,
                Agility = skillMapper.MapFromReport(accountDto.Agility),
                Attack = skillMapper.MapFromReport(accountDto.Agility),
                Fishing = skillMapper.MapFromReport(accountDto.Fishing),
                Defense = skillMapper.MapFromReport(accountDto.Defense),
                Strength = skillMapper.MapFromReport(accountDto.Strength),
                Hits = skillMapper.MapFromReport(accountDto.Hits),
                Ranged = skillMapper.MapFromReport(accountDto.Ranged),
                Prayer = skillMapper.MapFromReport(accountDto.Prayer),
                Magic = skillMapper.MapFromReport(accountDto.Magic),
                Cooking = skillMapper.MapFromReport(accountDto.Cooking),
                Woodcut = skillMapper.MapFromReport(accountDto.Woodcut),
                Fletching = skillMapper.MapFromReport(accountDto.Fletching),
                Firemaking = skillMapper.MapFromReport(accountDto.Firemaking),
                Crafting = skillMapper.MapFromReport(accountDto.Crafting),
                Smithing = skillMapper.MapFromReport(accountDto.Smithing),
                Mining = skillMapper.MapFromReport(accountDto.Mining),
                Herblaw = skillMapper.MapFromReport(accountDto.Herblaw),
                Thieving = skillMapper.MapFromReport(accountDto.Thieving)
            };
        }
    }
}
