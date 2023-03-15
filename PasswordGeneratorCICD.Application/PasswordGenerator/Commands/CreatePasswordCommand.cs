using MediatR;
using PasswordGeneratorCICD.Application.Dtos;
using PasswordGeneratorCICD.SharedKernel.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeneratorCICD.Application.PasswordGenerator.Commands
{
    public class CreatePasswordCommand : IRequest<Result<string>>
    {
        public PasswordOptionsDto Options { get; }

        public CreatePasswordCommand(PasswordOptionsDto options)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }
    }
}
