using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace GDIHelper
{
    public class Methods
    {
        /// <summary>
        /// Converts the byte array of font to font, e.g a font stored from resources.
        /// </summary>
        /// <param name="fontbyte">The Font stored in resources.</param>
        /// <param name="size">The Desired size for the font</param>
        /// <param name="fontStyle">The Desired size for the font</param>
        /// <returns>The Font stored from resources with desired size.</returns>
        public Font GetFont(byte[] fontbyte, float size, FontStyle fontStyle = FontStyle.Regular)
        {
            var fnt = fontbyte;
            var buffer = Marshal.AllocCoTaskMem(fnt.Length);
            Marshal.Copy(fnt, 0, buffer, fnt.Length);
            using (var privateFontCollection = new PrivateFontCollection())
            {
                privateFontCollection.AddMemoryFont(buffer, fnt.Length);
                return new Font(privateFontCollection.Families[0].Name, size, fontStyle);
            }
        }

        /// <summary>
        /// Get The Font from file, e.g The Fonts that located in widnows fonts directory.
        /// </summary>
        /// <param name="fontPath">The path for the font file.</param>
        /// <param name="size">The Desired size for the font</param>
        /// <param name="fontStyle">The Desired size for the font</param>
        /// <returns>The Font stored from resources with desired size.</returns>
        public Font GetFont(string fontPath, float size, FontStyle fontStyle = FontStyle.Regular)
        {
            var fnt = System.IO.File.ReadAllBytes(fontPath);
            var buffer = Marshal.AllocCoTaskMem(fnt.Length);
            Marshal.Copy(fnt, 0, buffer, fnt.Length);
            using (var privateFontCollection = new PrivateFontCollection())
            {
                privateFontCollection.AddMemoryFont(buffer, fnt.Length);
                return new Font(privateFontCollection.Families[0].Name, size, fontStyle);
            }
        }

        /// <summary>
        /// The Method to set Alignments horizontally and vertically.
        /// </summary>
        /// <param name="horizontalAlignment">The Alignment information on vertical plane.</param>
        /// <param name="verticalAlignment">The Alignment information on horizontal plane.</param>
        /// <returns>The StringFormat based on given alignments.</returns>
        public StringFormat SetAlignment(StringAlignment horizontalAlignment = StringAlignment.Center,
            StringAlignment verticalAlignment = StringAlignment.Center)
        {
            return new StringFormat { Alignment = horizontalAlignment, LineAlignment = verticalAlignment };
        }

        /// <summary>
        /// The Method to make the glow brush to specified GraphicsPath.
        /// </summary>
        /// <param name="centerColor">The Center color of path gradient.</param>
        /// <param name="surroundColor">The Array of colors correspond to the points in the path in this method.</param>
        /// <param name="point">The Focus point for the gradient falloff.</param>
        /// <param name="gp">The GraphicsPath that defines the path filled by this PathGradientBrush.</param>
        /// <param name="wrapMode">The Wrap mode for this PathGradientBrush.</param>
        /// <returns>The GlowBrush based on given details.</returns>
        public Brush GlowBrush(Color centerColor, Color[] surroundColor, PointF point, GraphicsPath gp, WrapMode wrapMode = WrapMode.Clamp)
        {
            return new PathGradientBrush(gp) { CenterColor = centerColor, SurroundColors = surroundColor, FocusScales = point, WrapMode = wrapMode };
        }

        /// <summary>
        /// The Method to make the glow brush to specified points.
        /// </summary>
        /// <param name="centerColor">The Center color of path gradient.</param>
        /// <param name="surroundColor">The Array of colors correspond to the points in the path in this method.</param>
        /// <param name="point">The Focus points for the gradient falloff.</param>
        /// <param name="wrapMode">The Wrap mode for this PathGradientBrush.</param>
        /// <returns>The GlowBrush based on given details.</returns>
        public Brush GlowBrush(Color centerColor, Color[] surroundColor, PointF[] point, WrapMode wrapMode = WrapMode.Clamp)
        {
            return new PathGradientBrush(point) { CenterColor = centerColor, SurroundColors = surroundColor, WrapMode = wrapMode };
        }
    }
}