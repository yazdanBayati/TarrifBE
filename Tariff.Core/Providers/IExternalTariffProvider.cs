using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tariff.Core.Domains;

namespace Tariff.Core.Providers
{
    public interface IExternalTariffProvider
    {
        Task<IEnumerable<TariffModel>> GetTariffs();
    }
}
