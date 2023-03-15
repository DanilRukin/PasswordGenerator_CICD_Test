using MediatR;
using PasswordGeneratorCICD.Application.Dtos;
using PasswordGeneratorCICD.Application.Services.Interfaces;
using PasswordGeneratorCICD.Domain;
using PasswordGeneratorCICD.SharedKernel.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGeneratorCICD.Application.PasswordGenerator.Commands
{
    public class CreatePasswordCommandHandler : IRequestHandler<CreatePasswordCommand, Result<string>>
    {
        private IMapper<PasswordOptionsDto, PasswordOptions> _mapper;

        public CreatePasswordCommandHandler(IMapper<PasswordOptionsDto, PasswordOptions> mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Task<Result<string>> Handle(CreatePasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                PasswordOptions options = _mapper.Map(request.Options);
                Domain.PasswordGenerator generator = new Domain.PasswordGenerator();
                string result = generator.Generate(options);
                return Task.FromResult(Result.Success(result));
            }
            catch(Exception e)
            {
                List<string> errors = new List<string>();

                while (e != null)
                {
                    errors.Add(e.Message);
                    e = e.InnerException;
                }
                return Task.FromResult(Result<string>.Error(errors.ToArray()));
            }
        }
    }
}
