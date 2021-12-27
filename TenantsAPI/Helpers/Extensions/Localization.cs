using System.Globalization;

namespace TenantsAPI.Helper.Extensions
{
    public class Localization
    {
        public static void SetCulture()
        {
            const string cultureName = "en-AU";

            // Modify current thread's cultures   
            var cultureInfo = new CultureInfo(cultureName)
            {
                DateTimeFormat =
                {
                    ShortDatePattern = "dd/MM/yyyy",
                    LongTimePattern = "hh:mm tt"
                }
            };

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}