using Tariff.Core.Providers;
using Tariff.Core.Domains;

namespace Tariff.Provider
{
    public class ExternalTariffProviderMock: IExternalTariffProvider
    {
        public Task<IEnumerable<TariffModel>> GetTariffs()
        {
            // Creating mock data for tariffs
            var mockTariffs = new List<TariffModel>
            {
                new TariffModel("Product A", 1, 5, 22),                       
                new TariffModel("Product B", 2, 800, 30, 4000),              
                new TariffModel("Product C", 1, 6, 18),                       
                new TariffModel("Product D", 2, 950, 35, 3500),               
                new TariffModel("Product E", 2, 7, 1000),                       
                new TariffModel("Product F", 1, 7, 25),                       
                new TariffModel("Product G", 2, 850, 40, 4500)               
            };

            return Task.FromResult<IEnumerable<TariffModel>>(mockTariffs);
        }
    }
}
