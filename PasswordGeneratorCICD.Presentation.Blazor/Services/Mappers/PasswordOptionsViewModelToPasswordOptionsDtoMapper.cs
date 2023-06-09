﻿using PasswordGeneratorCICD.Application.Dtos;
using PasswordGeneratorCICD.Application.Services.Interfaces;
using PasswordGeneratorCICD.Presentation.Blazor.ViewModels;

namespace PasswordGeneratorCICD.Presentation.Blazor.Services.Mappers
{
    public class PasswordOptionsViewModelToPasswordOptionsDtoMapper : IMapper<PasswordOptionsViewModel, PasswordOptionsDto>
    {
        public PasswordOptionsDto Map(PasswordOptionsViewModel source)
        {
            PasswordOptionsDto dto = new()
            {
                CountOfCharacters = source.CountOfCharacters,
                CountOfNumbers = source.CountOfNumbers,
                Length = source.Length,
                LowerCaseOnly = source.LowerCaseOnly,
                UpperCaseOnly = source.UpperCaseOnly,
                SpecialSymbols = StringToCollectionOfChars(source.SpecialSymbols),
            };
            return dto;
        }

        private List<char> StringToCollectionOfChars(string str, string delimeter = " ")
        {
            string[] chars = str.Split(delimeter, StringSplitOptions.RemoveEmptyEntries);
            List<char> result = new List<char>();
            for (int i = 0; i < chars.Length; i++)
            {
                result.Add(Convert.ToChar(chars[i]));
            }
            return result;
        }
    }
}
