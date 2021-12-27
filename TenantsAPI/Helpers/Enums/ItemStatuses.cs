using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum ItemStatuses
    {
        [Description("Removed")]
        Removed,

        [Description("Deleted")]
        Deleted,

        [Description("Archived")]
        Archived,

        [Description("BulkDeleted")]
        BulkDeleted,

        [Description("Float")]
        Float,
    }
}
