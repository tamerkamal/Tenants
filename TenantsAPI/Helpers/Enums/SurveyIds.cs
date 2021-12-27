using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum SurveyIds
    {
        [Description("SurveyQuestion")]  //Global for all PIC Tabs
        SurveyQuestion = 6,

        [Description("AddressConfirmedId")]
        AddressConfirmedId = 23,

        TimeSlotConfirmed = 24,

        [Description("ScopeConfirmedId")]
        ScopeConfirmedId = 26,

        AmountOutstanding = 27,

        GoodsAtHome = 28,

        [Description("AntennaScope")]
        AntennaScope = 28,

        [Description("SpeakerMountingScope")]
        SpeakerMountingScope = 29,

        [Description("NewOutletNeeded")]
        NewOutletNeeded = 38,

        [Description("RoofAccessGiven")]
        RoofAccessGiven = 43,

        [Description("PowerPointInLocationAndComments")]
        PowerPointInLocationAndComments = 44
    }
}
