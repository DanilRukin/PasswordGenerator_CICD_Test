using PasswordGeneratorCICD.Application.Dtos;
using PasswordGeneratorCICD.Application.Services.Interfaces;
using PasswordGeneratorCICD.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeneratorCICD.Application.Services.Mappers
{
    internal class PasswordOptionsToPasswordOptionsDtoMapper : IMapper<PasswordOptions, PasswordOptionsDto>
    {
        public PasswordOptionsDto Map(PasswordOptions source)
        {
            PasswordOptionsDto options = new()
            {
                CountOfCharacters = source.CountOfCharacters,
                CountOfNumbers = source.CountOfNumbers,
                Length = source.Length,
                LowerCaseOnly = source.LowerCaseOnly,
                SpecialSymbols = source.SpecialSymbols.ToList(),
                UpperCaseOnly = source.UpperCaseOnly
            };
            return options;
        }
    }
}
