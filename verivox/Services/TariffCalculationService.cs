using Newtonsoft.Json;
using verivox.Comparers;
using verivox.Converters;
using verivox.Interfaces;
using verivox.Models;

namespace verivox.Services
{
    public class TariffCalculationService : ITariffCalculationService
    {
        private readonly ITariffProvider _tariffProvider;

        public TariffCalculationService(ITariffProvider tariffProvider)
        {
            this._tariffProvider = tariffProvider;
        }

        public List<CalculationResult> GetCalculationResults(int consumption)
        {
            var serTariff = _tariffProvider.GetTariffs();
            if (string.IsNullOrWhiteSpace(serTariff))
            {
                throw new InvalidOperationException("No tariffs found");
            }

            List<TariffBase>? tariffs = JsonConvert.DeserializeObject<List<TariffBase>>(serTariff, new TarifConverter());
            tariffs.Sort(new TariffComparer(consumption));

            return tariffs.Select(tariff => new CalculationResult { 
                TariffName = tariff.Name, 
                AnnualCosts = tariff.CalculateAnnualCosts(consumption) 
            }).ToList();
        }
    }
}