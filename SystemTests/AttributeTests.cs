using TestFramework.Extensions;
using Xunit;

namespace SystemTests
{
    public class AttributeTests
    {
        [Theory]
        [JsonFileData("Currencies.json", "Currencies")]
        public void VerifyCurrenciesFromJson(string currency1, string currency2, string currency3)
        {   
            var result = new[] {currency1,  currency2, currency3};
            var expected = new[] { "USD", "BTC", "AUD" };

            Assert.Equal(expected, result);
        }
    }
}
