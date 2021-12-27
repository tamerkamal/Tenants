

using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum IncidentCategoryTypes
    {
        [Description("Location")]
        Location,

        [Description("Physical activity")]
        PhysicalActivity,

        [Description("Environmental")]
        Environmental,

        [Description("Posture")]
        Posture,
    }
}