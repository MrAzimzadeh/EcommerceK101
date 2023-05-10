using System.Text.RegularExpressions;

namespace EcommerceK101.Helpers
{


    public static class SeoUrlHelper
    {
        public static string SeoUrl(string url)
        {
            var result = url.ToLower()
                .Replace("ə", "e")
                .Replace("ü", "u")
                .Replace("ç", "c")
                .Replace("ş", "s")
                .Replace("ö", "o")
                .Replace("ğ", "g")
                .Replace("ı", "i")
                .Replace(".", "")
                .Replace(",", "")
                .Replace(" ", "-");

            return result;
        }
    }
}
