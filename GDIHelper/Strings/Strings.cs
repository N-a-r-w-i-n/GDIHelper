using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GDIHelper.Strings
{
    public static class Strings
    {
        /// <summary>
        /// The Image from encoded base64 image.
        /// </summary>
        /// <param name="base64Image">The Encoded base64 image</param>
        /// <returns>The Image from encoded base64.</returns>
        public static Image ToImage(this string base64Image)
        {
            using (var toImage = new System.IO.MemoryStream(Convert.FromBase64String(base64Image)))
            {
                return Image.FromStream(toImage);
            }
        }

        /// <summary>
        /// The Color from Hex by alpha property.
        /// </summary>
        /// <param name="alpha">Alpha.</param>
        /// <param name="htmlColor">The string representation of the Html color to translate.</param>
        /// <returns>The Color from Hex with given ammount of transparency</returns>
        public static Color ToColor(this string htmlColor, int alpha = 255)
        {
            return Color.FromArgb(alpha > 255 ? 255 : alpha, ColorTranslator.FromHtml(htmlColor));
        }

        /// <summary>
        /// Gets the brush form hex format which starts with # and the amount of transparency.
        /// </summary>
        /// <param name="htmlColor">The string representation of the Html color to translate.</param>
        /// <param name="alpha">The Alpha amount which demonstrates the transparency color start with #.</param>
        /// <returns>The Color from given hex color string.</returns>
        public static SolidBrush ToBrush(this string htmlColor, int alpha = 255)
        {
            return new SolidBrush(Color.FromArgb(alpha > 255 ? 255 : alpha, ColorTranslator.FromHtml(htmlColor)));
        }

        /// <summary>
        /// Gets the brush form hex format which starts with #.
        /// </summary>
        /// <param name="htmlColor">The string representation of the Html color to translate.</param>
        /// <param name="alpha">The Alpha amount which demonstrates the transparency color start with #.</param>
        /// <param name="size">The Size of the pen.</param>
        /// <param name="startCap">The Start Style of the pen.</param>
        /// <param name="endCap">The End Style of the pen.</param>
        /// <returns>The Color from given hex color string.</returns>
        public static Pen ToPen(this string htmlColor, int alpha = 255, float size = 1, LineCap startCap = LineCap.Custom, LineCap endCap = LineCap.Custom)
        {
            return new Pen(Color.FromArgb(alpha > 255 ? 255 : alpha, ColorTranslator.FromHtml(htmlColor)), size) { StartCap = startCap, EndCap = endCap };
        }

        /// <summary>
        /// The Method to convert font name in string to font.
        /// </summary>
        /// <param name="fontName">The Font Name.</param>
        /// <param name="size">The Size of the font.</param>
        /// <param name="fontStyle">The Font Style, default is Regular.</param>
        /// <param name="unit">The Graphic unit, default is pixel.</param>
        /// <returns></returns>
        public static Font ToFont(this string fontName, float size, FontStyle fontStyle = FontStyle.Regular, GraphicsUnit unit = GraphicsUnit.Pixel)
        {
            return new Font(fontName, size, fontStyle, unit);
        }
    }
}