using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum CommentType
    {
        [Description("All comments")]
        All,

        [Description("Client comment")]
        Client,

        [Description("Dispatch comment")]
        Dispatch,

        [Description("Customer comment")]
        CustomerComments,

        [Description("Tech comment")]
        Tech,

        [Description("Recon comment")]
        Recon,

        [Description("TL comment")]
        Tl,

        [Description("TSO comment")]
        Tso,

        [Description("Customer feedback")]
        CustomerFeedBack,

        [Description("Form Comment")]
        Form,

        [Description("Fulfillment Comment")]
        FulfillmentComment,

      [Description("System Comment")]
        SystemComment
    }
}
