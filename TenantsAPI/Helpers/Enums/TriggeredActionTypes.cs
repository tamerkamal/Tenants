using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum TriggeredActionTypes
    {
        [Description("Email")]
        Email = 1,

        [Description("Issue")]
        Issue = 2,

        [Description("Job")]
        Job = 3,

        [Description("SingleItem")]
        SingleItem = 4,

        [Description("MultipleItems")]
        MultipleItems = 5
    }
}