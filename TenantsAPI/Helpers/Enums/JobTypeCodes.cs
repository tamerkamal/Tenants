using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum JobTypeCodes
    {
        [Description("AVCW")]
        Avcw,

        //[Description("ASMNT")]
        //Asmnt,

        [Description("DNQ")]
        Dnq,
         
        [Description("ELCW")]
        Elcw,

        [Description("INST")]
        Inst,

        [Description("QT")]
        Qt,

        //[Description("SHINST")]
        //Shinst,

        [Description("G-INST")]
        Ginst,

        [Description("E-INST")]
        Einst,

        [Description("GE-INST")]
        Geinst,

        [Description("P-INST")]
        Pinst,

        [Description("WG-INST")]
        Wginst,


        // new 
        [Description("DC")]
        DC,

        [Description("IF")]
        IF,

        [Description("QCI")]
        QCI,

        [Description("B-INST")]
        BINST,

        [Description("B-IHA")]
        BIHA,

        [Description("IHA")]
        IHA,
    }
}