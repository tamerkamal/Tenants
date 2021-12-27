using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum OrderTypes
    {
        [Description("Optus")]
        Optus = 1,

        [Description("Float Items orders")]
        FloatItemsOrders = 2,

        [Description("Tech audit for stock levels")]
        TechAuditForStockLevels = 3,

        [Description("Audits performed on site at warehouse for stock levels")]
        AuditsPerformedOnSite = 4,

        [Description("Consignment Note Orders")]
        ConsignmentNoteOrders = 5,

        [Description("Gizmo Consignment Note Orders")]
        GizmoConsignmentNoteOrders = 6,

        [Description("ISGM CARP")]
        ISGMCARP = 7
    }
}
