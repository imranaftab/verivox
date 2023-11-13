namespace verivox.Models
{
    public class ProductATariff : TariffBase
    {
        public ProductATariff(string name, byte type, double baseCost, double additionalKwhCost) : base(name, type, baseCost, additionalKwhCost)
        {
        }

        public override double CalculateAnnualCosts(double consumption)
        {
            return (BaseCost * 12) + (consumption * AdditionalKwhCost / 100.0);
        }
    }
}
