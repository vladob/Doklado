using Doklado.Integration.Contracts.Enums;

namespace Doklado.Integration.Extensions
{
    public static class DokladoEnumExtensions
    {
        public static string ToApiValue(this DokladoDateType type)
            => type.ToString().ToLowerInvariant();
    }
}
