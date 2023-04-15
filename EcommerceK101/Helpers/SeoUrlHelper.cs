namespace EcommerceK101.Helpers
{
    public class SeoUrlHelper
    {
        public static string SeoUrl(string url)
        {
            var reult = url.ToLower()
                .Replace("ə", "e")
                .Replace("ü", "u")
                .Replace("ç", "c")
                .Replace("ş", "s")
                .Replace("ö", "o")
                .Replace("ğ", "g")
                .Replace(" ", "-")
                .Replace(".", "")
                .Replace("ı", "i")
                .Replace(",", "-")
                .Replace(".", "");

            return reult;
        }
    }
}
