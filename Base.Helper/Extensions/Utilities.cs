using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Helpers.Extensions
{
    public static class Utilities
    {
        public static string ItemCategoryName(int? value)
        {
            if (value == 1)
                return "Audio Visual";
            if (value == 2)
                return "Whitegoods (WA Only)";
            if (value == 3)
                return "Whitegoods (QLD, NSW, ACT, VIC, SA)";
            else
                return "";
        }
    }
}
