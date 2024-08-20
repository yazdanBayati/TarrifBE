using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tariff.Core.Domains.Enums;

namespace Tariff.Core.Domains.TariffCalculators
{
    public class CalculatorFactory
    {
        public BaseTariffCalculator CreateCalculator(TariffModel tariff)
        {
            return tariff.Type switch
            {
                (int)TariffType.Basic => new BasicTariffCalculator(tariff.BaseCost, tariff.AdditionalKwhCost),
                (int)TariffType.Packaged => new PackagedTariffCalculator(tariff.BaseCost, tariff.AdditionalKwhCost, tariff.IncludedKwh ?? 0),
                _ => throw new ArgumentException("Unsupported tariff type", nameof(tariff.Type))
            };
        }
    }
}
