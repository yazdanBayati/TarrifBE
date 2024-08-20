using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tariff.ApplicationService.Dtos;

namespace Tariff.ApplicationService.TariffComparison
{
    public interface ITariffComparisonService
    {
        Task<ItemDataResponse<IEnumerable<TariffDto>>> CompareTariffs(int consumption);
    }
}
