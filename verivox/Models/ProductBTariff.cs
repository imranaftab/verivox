namespace verivox.Models
{
    public class ProductBTariff : TariffBase
    {
        public int IncludedKwh { get; private set; }

        public ProductBTariff(string name, byte type, double baseCost, double additionalKwhCost, int includedKwh) : base(name, type, baseCost, additionalKwhCost)
        {
            this.IncludedKwh = includedKwh;
        }

        public override double CalculateAnnualCosts(double consumption)
        {
            double annualCosts;

            if (consumption <= IncludedKwh)
            {
                annualCosts = BaseCost;
            }
            else
            {
                annualCosts = BaseCost + ((consumption - IncludedKwh) * AdditionalKwhCost / 100.0);
            }
            
            return annualCosts;
        }
    }
}
