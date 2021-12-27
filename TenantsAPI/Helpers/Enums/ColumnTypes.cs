using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum ColumnTypes
    {
        [Description("text")]
        Text,

        [Description("numeric")]
        Numeric,

        [Description("boolean")]
        Boolean,

        [Description("date")]
        Date
    }
}