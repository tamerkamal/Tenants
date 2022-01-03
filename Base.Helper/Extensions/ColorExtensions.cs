using System.Drawing;

namespace Base.Helpers.Extensions
{
    public static class ColorExtensions
    {
        /// <summary>
        /// Converts a Color value to a string representation of the value in hexadecimal.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string ToHex(this Color color)
        {
            return ColorTranslator.ToHtml(Color.FromArgb(color.ToArgb()));
        }
    }
}