
namespace Doklado.Integration.Configuration
{
    public sealed class DokladoOptions
    {
        public const string SectionName = "Doklado";

        public string BaseUrl { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
    }
}
