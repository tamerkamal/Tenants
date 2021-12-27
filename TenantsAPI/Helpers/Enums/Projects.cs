using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum Projects
    {
        [Description("Consumer Direct Audio Visual")]
        Cdav = 5,

        [Description("Insulation")]
        Insul = 9,

        [Description("HISP")]
        Hisp = 12,

        [Description("OPT-NBN")]
        Optnbn = 14,

        [Description("Consumer Direct IT")]
        Cdit = 17,

        [Description("Optus ULL")]
        Optull = 18,

        [Description("Silcar NBN")]
        SILNBN = 19,

        [Description("NBN Direct")]
        Nbn = 22,

        [Description("ISGM CARP")]
        ISGMCARP = 25,

        [Description("TATA")]
        Tcs = 33,

        [Description("Lend Lease")]
        Lnl = 35,

        [Description("TPG")]
        Tpg = 36,

        [Description("Fulton Hogan")]
        Fh = 39,

        [Description("Fulton Hogan HFC")]
        Fhh = 45,

        [Description("Downer")]
        Dow = 47,

        [Description("Downer MIMA")]
        Dowm = 50,

        [Description("Visionstream")]
        Vs = 52,

        [Description("NBN HFC")]
        Nbnhfc = 54,

        [Description("Communications Direct")]
        Cdcom = 58,

        [Description("NETSOL")]
        NETSOL = 63,

        [Description("NBN FTTC")]//need to get the description 
        Nbnfttc = 64,
         
    }
}