namespace PasswordGeneratorCICD.Presentation.Blazor.Services.Interfaces
{
    public interface IMapper<TSource, TDest>
    {
        TDest Map(TSource source);
    }
}
