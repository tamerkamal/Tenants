using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum JobSources
    {
        [Description("Harvey Norman (AUS) AV")]
        HarveyNorman = 1,
        [Description("AUSTAR")]
        AUSTAR = 8,
        [Description("JB Hi-Fi")]
        JBHIFI = 13,
        [Description("iiNet")]
        iiNet = 84,
        [Description("JB Hi-Fi Insurance")]
        JBHIFIINSURANCE = 117,
    }
}