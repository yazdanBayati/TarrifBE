using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tariff.Core.Domains.TariffCalculators
{
    public class PackagedTariffCalculator: BaseTariffCalculator
    {
        private int includedKwh { get; }
        private int yearlyBaseCost { get; }
        public PackagedTariffCalculator(int baseCost,int includedKwh, int costPerKwh) : base(costPerKwh)
        {
            this.yearlyBaseCost = baseCost;
            this.includedKwh = includedKwh;
            
        }

        public override decimal CalculateAnnualCost(int consumption)
        {
            if (consumption <= this.includedKwh)
            {
                return this.yearlyBaseCost;
            }
            else
            {
                var excessConsumption = consumption - this.includedKwh;
                return yearlyBaseCost + (excessConsumption * this.additionalKwhCost / 100);
            }
        }
    }
}
