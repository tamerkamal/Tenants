using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum DynamicFieldValidatorTypes
    {
        [Description("required")]
        Required,

        [Description("pattern")]
        Pattern
    }
}