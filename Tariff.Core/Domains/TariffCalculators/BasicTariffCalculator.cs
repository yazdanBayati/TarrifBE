using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tariff.Core.Domains.TariffCalculators
{
    public class BasicTariffCalculator: BaseTariffCalculator
    {

        private int monthlyCost { get; }
        public BasicTariffCalculator(int baseCost, int costPerKwh) : base(costPerKwh)
        {
            monthlyCost = baseCost;
        }

        public override decimal CalculateAnnualCost(int consumption)
        {
            // Base cost is monthly, so multiply by 12 for the annual base cost
            var annualBaseCost = this.monthlyCost * 12;
            var consumptionCost = consumption * this.additionalKwhCost / 100;
            return annualBaseCost + consumptionCost;
        }
    }
}
