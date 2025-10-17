using BimehApi.Models;

namespace BimehApi.Services;

public class InsuranceCalculatorService
{
    public decimal CalculatePremium(CoverageType coverage, long capital)
    {
        if (!IsValidCapital(coverage, capital)) 
            throw new ArgumentException("Capital amount is outside the valid range for the selected coverage type.");

        decimal rate = coverage switch
        {
            CoverageType.Surgery => 0.0052m,
            CoverageType.Hospitalization => 0.0042m,
            CoverageType.Outpatient => 0.005m,
            _ => throw new ArgumentOutOfRangeException(nameof(coverage), "Invalid coverage type")
        };

        return Math.Round(capital * rate, 2);
    }

    public bool IsValidCapital(CoverageType coverage, long capital)
    {
        return coverage switch
        {
            CoverageType.Surgery => capital >= 5000 && capital <= 500_000_000,
            CoverageType.Hospitalization => capital >= 4000 && capital <= 400_000_000,
            CoverageType.Outpatient => capital >= 2000 && capital <= 200_000_000,
            _ => false
        };
    }
}