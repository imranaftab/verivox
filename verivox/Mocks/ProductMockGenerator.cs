using Newtonsoft.Json;
using System.Xml.Linq;
using verivox.Models;

namespace verivox.Mocks
{
    public class ProductMockGenerator
    {
        public static string GenerateMockProductsJson()
        {
            var products = new List<MockProduct>
            {
                new MockProduct
                {
                    Name = "Product A",
                    Type = 1,
                    BaseCost =  5,
                    AdditionalKwhCost = 22,
                },

                new MockProduct
                {
                    Name = "Product B",
                    Type = 2,
                    BaseCost = 800,
                    IncludedKwh = 4000,
                    AdditionalKwhCost = 30
                }
            };

            return JsonConvert.SerializeObject(products);
        }
    }
}
