using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum DwellingTypes
    {
        [Description("Unit")]
        Unit,
        [Description("House")]
        House,
        [Description("TownHouse")]
        TownHouse,
        [Description("Other")]
        Other
    }
}
