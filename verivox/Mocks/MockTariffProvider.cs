using verivox.Interfaces;

namespace verivox.Mocks
{
    public class MockTariffProvider : ITariffProvider
    {
        public string GetTariffs()
        {
            return ProductMockGenerator.GenerateMockProductsJson();
        }
    }
}
