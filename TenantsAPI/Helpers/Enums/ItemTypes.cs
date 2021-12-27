using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum ItemTypes
    {
        [Description("ItemType1")]
        ItemType1 = 1,

        [Description("ItemType2")]
        ItemType2 = 2,

        [Description("Belkin/Monster Return Item")]
        BelkinMonsterReturnItem = 140,

        [Description("HN IT POS")]
        HNITPOS = 152
    }
}