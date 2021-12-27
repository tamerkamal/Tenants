using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum TransactionTypes
    {
        [Description("WHTF")]
        WHTF,

        [Description("Stock Transfer")]
        StockTransfer,

        [Description("RTF")]
        RTF,

        [Description("TF")]
        TF,

        [Description("FLOC")]
        FLOC,

        [Description("F")]
        F,

        [Description("RT")]
        RT,

        [Description("RC")]
        RC,

        [Description("RS")]
        RS,

        [Description("WTIF")]
        WTIF,

        [Description("RM")]
        RM,

        [Description("IN")]
        IN
    }
}