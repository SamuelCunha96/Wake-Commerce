namespace Wake.Commerce.Shared.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNull(this string? value) 
        {
            return string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value.Trim());
        }
    }
}
