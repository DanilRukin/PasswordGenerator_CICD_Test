using PasswordGeneratorCICD.Presentation.Blazor.Dtos;
using PasswordGeneratorCICD.Presentation.Blazor.Services.Interfaces;
using PasswordGeneratorCICD.Presentation.Blazor.ViewModels;
using System.Text;

namespace PasswordGeneratorCICD.Presentation.Blazor.Services.Mappers
{
    public class PasswordOptionsDtoToPasswordOptionsViewModel : IMapper<PasswordOptionsDto, PasswordOptionsViewModel>
    {
        public PasswordOptionsViewModel Map(PasswordOptionsDto source)
        {
            PasswordOptionsViewModel model = new()
            {
                CountOfCharacters = source.CountOfCharacters,
                CountOfNumbers = source.CountOfNumbers,
                Length = source.Length,
                LowerCaseOnly = source.LowerCaseOnly,
                UpperCaseOnly = source.UpperCaseOnly,
                SpecialSymbols = SymbolsCollectionToStr(source.SpecialSymbols)
            };
            return model;
        }

        private string SymbolsCollectionToStr(IList<char> collection)
        {
            StringBuilder builder = new StringBuilder(collection.Count * 2 - 1);
            foreach (char ch in collection)
            {
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
}
