using System.ComponentModel;

namespace TenantsAPI.Helper.Enums
{
    public enum PaymentMethods
    {
        [Description("Cash")]
        Cash = 1,
        [Description("Cheque")]
        Cheque = 2,
        [Description("Credit Card")]
        CreditCard = 3,
        [Description("Money Order")]
        MoneyOrder = 4,
        [Description("Direct Debit")]
        DirectDebit = 5,
        [Description("B-Pay")]
        BPay = 6,
        [Description("Invoice")]
        Invoice = 7,
        [Description("Warranty")]
        Warranty = 8,
        [Description("CollectionAgency")]
        CollectionAgency = 9,
        [Description("Change To Store")]
        ChangeToStore = 10,
        [Description("Flexi Rent")]
        FlexiRent = 11,
        [Description("GE Money")]
        GEMoney = 12
    }
}