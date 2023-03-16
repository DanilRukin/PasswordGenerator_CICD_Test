using MediatR;
using PasswordGeneratorCICD.Presentation.Blazor.Dtos;
using PasswordGeneratorCICD.SharedKernel.Results;
using System.Net.Http.Json;

namespace PasswordGeneratorCICD.Presentation.Blazor.Infrastructure.PasswordGenerator.Commands
{
    public class GeneratePasswordCommandHandler : IRequestHandler<GeneratePasswordCommand, Result<string>>
    {
        private HttpClient _client;

        public GeneratePasswordCommandHandler(IHttpClientFactory factory)
        {
            _ = factory == null ? throw new ArgumentNullException(nameof(factory)) : _client = factory.CreateClient();
        }

        public async Task<Result<string>> Handle(GeneratePasswordCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var resonse = await _client.PostAsJsonAsync(ApiHelper.Post.CreatePassword(), request.Options, cancellationToken);
                if (!resonse.IsSuccessStatusCode)
                    return Result<string>.Error(resonse.Content.ReadFromJsonAsync<IEnumerable<string>>().Result.ToArray());
                var password = await resonse
                    .Content
                    .ReadAsStringAsync(cancellationToken);
                return Result.Success(password);
            }
            catch(Exception e)
            {
                List<string> errors = new List<string>();
                while (e != null)
                {
                    errors.Add(e.Message);
                    e = e.InnerException;
                }
                return Result<string>.Error(errors.ToArray());
            }
        }
    }
}
