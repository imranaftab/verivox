using verivox.Models;

namespace verivox.Interfaces
{
    public interface ITariffCalculationService
    {
        List<CalculationResult> GetCalculationResults(int consumption);
    }
}
