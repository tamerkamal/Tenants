using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum FormFieldDataTypes
    {
        [Description("Yes/No")]
        YesNo,

        [Description("Yes/No/NA")]
        YesNoNa,

        [Description("Label")]
        Label,

        [Description("Photo")]
        Photo,

        [Description("Longitude")]
        Longitude,

        [Description("Latitude")]
        Latitude,

        [Description("Coordinates")]
        Coordinates,

        [Description("Date")]
        Date,

        [Description("Number")]
        Number
    }
}