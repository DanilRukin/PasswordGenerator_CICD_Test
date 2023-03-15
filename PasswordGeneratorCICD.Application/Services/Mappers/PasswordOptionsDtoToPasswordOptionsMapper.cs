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
    internal class PasswordOptionsDtoToPasswordOptionsMapper : IMapper<PasswordOptionsDto, PasswordOptions>
    {
        public PasswordOptions Map(PasswordOptionsDto source)
        {
            var options = PasswordOptions.Defaults();
            foreach (var item in source.SpecialSymbols)
            {
                options.AddSpecialSymbol(item);
            }
            options.SetCountOfCharacters(source.CountOfCharacters);
            options.SetCountOfNumbers(source.CountOfNumbers);
            options.SetLowerCase(source.LowerCaseOnly);
            options.SetUpperCase(source.UpperCaseOnly);
            options.ClearSpecialSymbols();          
            options.SetLength(source.Length);
            return options;
        }
    }
}
