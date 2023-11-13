namespace verivox.Models
{
    public abstract class TariffBase
    {
        public string Name { get; private set; }
        public byte Type { get; private set; }
        public double BaseCost { get; private set; }
        public double AdditionalKwhCost { get; private set; }

        public TariffBase(string name, byte type, double baseCost, double additionalKwhCost)
        {
            this.AdditionalKwhCost = additionalKwhCost;
            this.BaseCost = baseCost;
            this.Name = name;
            this.Type = type;
        }

        public abstract double CalculateAnnualCosts(double consumption);

    }
}
