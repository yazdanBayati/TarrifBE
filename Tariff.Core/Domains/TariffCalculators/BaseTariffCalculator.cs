using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tariff.Core.Domains.TariffCalculators
{
    public abstract class BaseTariffCalculator
    {
        protected int additionalKwhCost { get; }

        public BaseTariffCalculator(int additionalKwhCost)
        {
            this.additionalKwhCost = additionalKwhCost;
        }

        // Abstract method to be implemented by derived classes
        public abstract decimal CalculateAnnualCost(int consumption);


    }
}
