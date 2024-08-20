using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tariff.ApplicationService.Dtos;
using Tariff.Core.Domains.TariffCalculators;
using Tariff.Core.Providers;

namespace Tariff.ApplicationService.TariffComparison
{
    public class TariffComparisonService : ITariffComparisonService
    {
        private readonly IExternalTariffProvider _tariffProvider;
        private readonly CalculatorFactory _calculatorFactory;

        public TariffComparisonService(IExternalTariffProvider tariffProvider)
        {
            _tariffProvider = tariffProvider;
            _calculatorFactory = new CalculatorFactory();
        }

        public async Task<ItemDataResponse<IEnumerable<TariffDto>>> CompareTariffs(int consumption)
        {
            try
            {
                var tariffs = await _tariffProvider.GetTariffs();

                var result = tariffs.Select(tariff =>
                {
                    var calculator = _calculatorFactory.CreateCalculator(tariff);
                    var annualCost = calculator.CalculateAnnualCost(consumption);

                    return new TariffDto
                    {
                        Name = tariff.Name,
                        AnnualCost = annualCost
                    };
                });

                return new ItemDataResponse<IEnumerable<TariffDto>>
                {
                    Success = true,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                // Log the exception 

                return new ItemDataResponse<IEnumerable<TariffDto>>
                {
                    Success = false,
                    Error = "InternalServerError",
                    ErrorCode = 500,
                    ErrorMessage = ex.Message,
                    Data = null
                };
            }
        }
    }
}
