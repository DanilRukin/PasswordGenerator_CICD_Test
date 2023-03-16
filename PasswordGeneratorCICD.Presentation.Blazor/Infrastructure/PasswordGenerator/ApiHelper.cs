namespace PasswordGeneratorCICD.Presentation.Blazor.Infrastructure.PasswordGenerator
{
    public static class ApiHelper
    {
        private static string _api = "api/PasswordGenerator";
        public static class Post
        {
            public static string CreatePassword() => $"{_api}";
        }
    }
}
