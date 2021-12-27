using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum ItemRecipeTypes
    {
        [Description("Mandatory")]
        Mandatory = 101,

        [Description("Optional")]
        Optional = 102,

        [Description("Items added when job is booked")]
        ItemsAddedWhenJobIsBooked = 1,

        [Description("Items for display only")]
        ItemsForDisplayOnly = 2,

        [Description("Mandatary items when job is closed")]
        MandatoryItemsWhenJobIsClosed = 3,

        [Description("Optional items when job is closed")]
        OptionalItemsWhenJobIsClosed = 4,

        [Description("Replace Regional Item")]
        ReplaceRegionalItem = 6,

        [Description("Replace Item with Another Item on Bundle")]
        ReplaceItemWithAnotherItemOnBundle = 7,

        [Description("Replace Child items")]
        ReplaceChildItems = 8,

        [Description("NBN Network Scopes on the iPad Completion Screen")]
        NbnNetworkScopesOnTheIPadCompletionScreen = 9,

        [Description("Float HVIT Item")]
        FloatHvitItem = 10,

        [Description("Proposed Material")]
        ProposedMaterial = 11
    }
}