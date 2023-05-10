using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceK101.Helpers;

namespace testing
{
    public class SeoUrlTest
    {
        [Test]
        public void UpperCase_Seo_Url_Tests()
        {
            var text = "Salam osiasıda      ladas sa -dasöə";
            var result = "salam-osiasida-ladas-sa-dasoe";

            var methodResult = SeoUrlHelper.SeoUrl(text);
            Assert.AreEqual(result, methodResult);
        }

        [Test]
        public void Seo_Url_White_space_Tests()
        {
            var text = "Salam osiasıda    ladas sa  -dasöə";
            var result = "salam-osiasida-ladas-sa-dasoe";

            var methodResult = SeoUrlHelper.SeoUrl(text);
            Assert.AreEqual(result, methodResult);
        }

        [Test]
        public void Seo_Url_Character_Tests()
        {
            var text = "Salam osiasıda?   ladas. sa  -dasöə";
            var result = "salam-osiasida-ladas-sa-dasoe";

            var methodResult = SeoUrlHelper.SeoUrl(text);
            Assert.AreEqual(result, methodResult);
        }

    }
}