using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum Reasons
    {
        [Description("Internal Tech2Home")]
        InternalTech2Home = 83,

        [Description("B: Urgent, Action Today")]
        BUrgentActionToday = 86,

        [Description("E: Standard, Please follow-up required")]
        EStandardPleaseFollowupRequired = 89
    }
}