using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum MessageTypes
    {
        [Description("StreamNET")]
        StreamNET=1,

        [Description("SMS")]
        SMS=2,

        [Description("Email")]
        Email=3,

        [Description("News")]
        News=4,

   
    }
}