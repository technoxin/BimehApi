using BimehApi.Models;

namespace BimehApi.Data;

public static class SeedData
{
    public static void SeedDatabase(AppDbContext context)
    {
        if (context.InsuranceRequests.Any())
        {
            // Database has already been seeded
            return;
        }

        var seedRequests = new List<InsuranceRequest>
        {
            new InsuranceRequest
            {
                Title = "پوشش جراحی قلب",
                Coverage = CoverageType.Surgery,
                Capital = 150000000,
                Premium = 780000,
            },
            new InsuranceRequest
            {
                Title = "پوشش بستری در بیمارستان",
                Coverage = CoverageType.Hospitalization,
                Capital = 80000000,
                Premium = 336000,
            },
            new InsuranceRequest
            {
                Title = "پوشش خارج از بیمارستان",
                Coverage = CoverageType.Outpatient,
                Capital = 50000000,
                Premium = 250000,
            },
            new InsuranceRequest
            {
                Title = "پوشش عمل جراحی چشم",
                Coverage = CoverageType.Surgery,
                Capital = 35000000,
                Premium = 182000,
            },
            new InsuranceRequest
            {
                Title = "پوشش عمل جراحی ارتوپدی",
                Coverage = CoverageType.Surgery,
                Capital = 120000000,
                Premium = 624000,
            },
            new InsuranceRequest
            {
                Title = "پوشش بستری در بخش CCU",
                Coverage = CoverageType.Hospitalization,
                Capital = 200000000,
                Premium = 840000,
            },
            new InsuranceRequest
            {
                Title = "پوشش خدمات پزشکی سرپایی",
                Coverage = CoverageType.Outpatient,
                Capital = 15000000,
                Premium = 75000,
            },
            new InsuranceRequest
            {
                Title = "پوشش جراحی کلیه",
                Coverage = CoverageType.Surgery,
                Capital = 95000000,
                Premium = 494000,
            }
        };

        context.InsuranceRequests.AddRange(seedRequests);
        context.SaveChanges();
    }
}