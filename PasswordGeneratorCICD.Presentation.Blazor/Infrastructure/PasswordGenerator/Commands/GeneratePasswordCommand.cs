using MediatR;
using PasswordGeneratorCICD.Presentation.Blazor.Dtos;
using PasswordGeneratorCICD.SharedKernel.Results;

namespace PasswordGeneratorCICD.Presentation.Blazor.Infrastructure.PasswordGenerator.Commands
{
    public class GeneratePasswordCommand : IRequest<Result<string>>
    {
        public PasswordOptionsDto Options { get;  }

        public GeneratePasswordCommand(PasswordOptionsDto options)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }
    }
}
