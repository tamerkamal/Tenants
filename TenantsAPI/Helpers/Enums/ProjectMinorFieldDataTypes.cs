
using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum ProjectMinorFieldDataTypes
    {
        [Description("Text")]
        Text = 0,
        [Description("Number")]
        Number = 1,
        [Description("List")]
        List = 2,
        [Description("Header")]
        Header = 3
    }
}
