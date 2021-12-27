using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum DataTypes
    {
        [Description("Photo")]
        Photo = 1,

        [Description("Scan")]
        Scan = 2,

        [Description("Hi-Res Photo")]
        HiResPhoto = 3,

        [Description("Yes/No")]
        YesNo = 4,

        [Description("Yes/No/NA")]
        YesNoNa = 5,
    }
}