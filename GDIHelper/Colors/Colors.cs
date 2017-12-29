using System.Drawing;

namespace GDIHelper.Colors
{
    public static class Colors
    {
        /// <summary>
        /// The Method to Translate the specified color structure to an HTML string color representation..
        /// </summary>
        /// <param name="color">The Color to convert to hex color string.</param>
        /// <returns>The string that represents the HTML color.</returns>
        public static string ToHTML(this Color color)
        {
            return ColorTranslator.ToHtml(color);
        }

        /// <summary>
        /// The Method to convert color to brush.
        /// </summary>
        /// <param name="color">The Color to convert to brush.</param>
        /// <returns>The Brush from the given color.</returns>
        public static SolidBrush ToBrush(this Color color)
        {
            return new SolidBrush(color);
        }

        /// <summary>
        /// The Method to convert color to pen.
        /// </summary>
        /// <param name="color">The Color to convert to brush.</param>
        /// <param name="size">The Color to convert to brush.</param>
        /// <returns>The Brush from the given color.</returns>
        public static Pen ToPen(this Color color, float size = 1)
        {
            return new Pen(color, size);
        }

        /// <summary>
        /// The Method to convert the given color to RGB string like (rgb(255, 255, 255).
        /// </summary>
        /// <param name="color">The Color tho get the RGB string from it.</param>
        /// <returns>The RGB string of the given color.</returns>
        public static string ToRGBString(this Color color)
        {
            return $"rgb({color.R}, {color.G}, {color.B})";
        }

        /// <summary>
        /// The Method to convert the given color to RGBA string like (rgba(255, 255, 255, 0).
        /// </summary>
        /// <param name="color">The Color tho get the RGBA string from it.</param>
        /// <returns>The RGBA string of the given color.</returns>
        public static string ToRGBAString(this Color color)
        {
            return $"rgb({color.R}, {color.G}, {color.B}, {color.A})";
        }

        /// <summary>
        /// The Method to convert the given color to ARGB string like (rgb(0, 255, 255, 255).
        /// </summary>
        /// <param name="color">The Color tho get the RGBA string from it.</param>
        /// <returns>The ARGB string of the given color.</returns>
        public static string ToARGBString(this Color color)
        {
            return $"rgb({color.A}, {color.R}, {color.G}, {color.B})";
        }

        /// <summary>
        /// The Method to mix multiplie colors.
        /// </summary>
        /// <param name="colors">The Array of colors.</param>
        /// <returns>The color combined from multiplie colors.</returns>
        public static Color MixColors(this Color[] colors)
        {
            var r = default(int);
            var g = default(int);
            var b = default(int);
            foreach (var c in colors)
            {
                r += c.R;
                g += c.B;
                b += c.B;
            }
            return Color.FromArgb(r / colors.Length, g / colors.Length, b / colors.Length);
        }
    }
}