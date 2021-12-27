using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TenantsAPI.Helper.Enums
{
    public enum InvStatuses
    {
        [Description("New")]
        New,

        [Description("Removed")]
        Removed,

        [Description("Non-Float")]
        NonFloat,

        [Description("Float")]
        Float
    }
}
