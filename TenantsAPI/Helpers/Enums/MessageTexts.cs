using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum MessageTexts
    {
        [Description("Success")]
        Success,

        [Description("Sent Items")]
        SentItems,

        [Description("Files with invalid Extensions were not uploaded:")]
        InvalidExtensionMessage,

        [Description("Data on this page has been modified before Saving your changes," +
                     "page will be reloaded with updated values from database," +
                     "please redo your changes if you still want them to be applied")]
        ConcurrencyExceptionMessage
    }
}
