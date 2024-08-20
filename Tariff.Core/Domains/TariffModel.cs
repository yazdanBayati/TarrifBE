

namespace Tariff.Core.Domains
{
    public class TariffModel
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public int BaseCost { get; set; }
        public int AdditionalKwhCost { get; set; }
        public int? IncludedKwh { get; set; } // Nullable for tariffs where this is not applicable

        public TariffModel(string name, int type, int baseCost, int additionalKwhCost, int? includedKwh = null)
        {
            Name = name;
            Type = type;
            BaseCost = baseCost;
            AdditionalKwhCost = additionalKwhCost;
            IncludedKwh = includedKwh;
        }
    }
}
