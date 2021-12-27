using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum GridColumnTypes
    {
        [Description("text")]
        Text,

        [Description("boolean")]
        Boolean,

        [Description("date")]
        Date,

        [Description("time")]
        Time,

        [Description("numeric")]
        Numeric
    }
}
