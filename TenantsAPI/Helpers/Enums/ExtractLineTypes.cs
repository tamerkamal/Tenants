using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum ExtractLineTypes
    {
        [Description("Bill")]
        Bill,

        [Description("Pay")]
        Pay,

        [Description("Item")]
        Item,

        [Description("Required")]
        Required,
    }
}
