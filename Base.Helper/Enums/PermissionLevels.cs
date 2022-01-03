using System.ComponentModel;

namespace Base.Helpers.Enums
{
    public enum PermissionLevels
    {
        [Description("Not Set")]
        NotSet = 0,

        [Description("Not Visible")]
        NotVisible = 1,

        [Description("Read Only")]
        ReadOnly = 2,

        [Description("Read / Write")]
        ReadWrite = 3
    }
}