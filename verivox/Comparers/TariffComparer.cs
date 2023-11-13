using verivox.Models;

namespace verivox.Comparers
{
    public class TariffComparer : IComparer<TariffBase>
    {
        private readonly int _consumption;

        public TariffComparer(int consumption)
        {
            _consumption = consumption;
        }

        public int Compare(TariffBase? t1, TariffBase? t2)
        {
            if (t1 == null || t2 == null)
                throw new System.ArgumentNullException(nameof(t1));
            
            var t1Cost = t1.CalculateAnnualCosts(_consumption);
            var t2Cost = t2.CalculateAnnualCosts(_consumption);
            
            return t1Cost.CompareTo(t2Cost);
        }
    }
}
