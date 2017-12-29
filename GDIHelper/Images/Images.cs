using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace GDIHelper.Images
{
    public static class Images
    {
        /// <summary>
        /// The Method to put the image into the brush.
        /// </summary>
        /// <param name="image">The Image to out into the brush.</param>
        /// <returns>The Brush from the given image.</returns>
        public static TextureBrush ToBrush(this Image image)
        {
            return new TextureBrush(image);
        }

        /// <summary>
        /// The Method to put the image into the brush.
        /// </summary>
        /// <param name="image">The Image to put into the brush.</param>
        /// /// <param name="destinationRectangle">A Rectangle structure that represents the bounding rectangle for this texture brush.</param>
        /// <returns>The Brush from the given image.</returns>
        public static TextureBrush ToBrush(this Image image, Rectangle destinationRectangle)
        {
            return new TextureBrush(image, destinationRectangle);
        }

        /// <summary>
        /// The Method to put the image into the pen.
        /// </summary>
        /// <param name="image">The Image to put into the pen.</param>
        /// <param name="width">The Width of the pen.</param>
        /// <param name="startCap">The Start Style of the pen.</param>
        /// <param name="endCap">The End Style of the pen.</param>
        /// <returns>The pen from the given image.</returns>
        public static Pen ToPen(this Image image, float width = 1, LineCap startCap = LineCap.Custom, LineCap endCap = LineCap.Custom)
        {
            using (var toBrush = new TextureBrush(image))
            {
                return new Pen(toBrush, width) { StartCap = startCap, EndCap = endCap };
            }
        }

        /// <summary>
        /// The Method to convert the given image to base64 string.
        /// </summary>
        /// <param name="image">The Image to convert it to base64 string.</param>
        /// <returns>The Base64 string from given image.</returns>
        public static string ToBase64(this Image image)
        {
            using (var toBase64 = new MemoryStream())
            {
                image.Save(toBase64, image.RawFormat);
                image.Dispose();
                return Convert.ToBase64String(toBase64.ToArray());
            }
        }
    }
}