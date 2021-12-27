


using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum MessageFolders
    {
        [Description("Inbox")]
        Inbox,
        [Description("Sent Items")]
        SentItems,
        [Description("Deleted")]
        Deleted,
        [Description("Drafts")]
        Drafts
    }
}
