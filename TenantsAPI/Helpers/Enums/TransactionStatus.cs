using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum TransactionStatus
    {
        [Description("*close*")]
        Close,

        [Description("closed")]
        Closed,

        [Description("fclosed")]
        FClosed,

        [Description("start*")]
        Start,

        [Description("started")]
        Started,
    }
}