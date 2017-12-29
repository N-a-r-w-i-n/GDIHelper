using GDIHelper.Areas;
using GDIHelper.Strings;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace GDIHelper.Drawing
{
    public static class Drawings
    {
        /// <summary>
        /// The Method to draw the image from encoded base64 string.
        /// </summary>
        /// <param name="g">The Graphics to draw the image.</param>
        /// <param name="base64Image">The Encoded base64 image.</param>
        /// <param name="rect">The Rectangle area for the image.</param>
        public static void DrawImageFromBase64(this Graphics g, string base64Image, Rectangle rect)
        {
            Image image;
            using (var ms = new System.IO.MemoryStream(Convert.FromBase64String(base64Image)))
            {
                image = Image.FromStream(ms);
            }
            g.DrawImage(image, rect);
            image.Dispose();
        }

        /// <summary>
        /// The Method to draw the image with custom color.
        /// </summary>
        /// <param name="g"> The Graphic to draw the image.</param>
        /// <param name="r"> The Rectangle area of image.</param>
        /// <param name="base64Image"> The Encoded base64 image that the custom color applies on it.</param>
        /// <param name="c">The Color that be applied to the image.</param>
        /// <remarks></remarks>
        public static void DrawColoredImage(this Graphics g, Rectangle r, string base64Image, Color c)
        {
            var im = base64Image.ToImage();
            float[][] ptsArray = {
                new[] {Convert.ToSingle(c.R / 255.0), 0f, 0f, 0f, 0f},
                new[] {0f, Convert.ToSingle(c.G / 255.0), 0f, 0f, 0f},
                new[] {0f, 0f, Convert.ToSingle(c.B / 255.0), 0f, 0f},
                new[] {0f, 0f, 0f, Convert.ToSingle(c.A / 255.0), 0f},
                new[]
                {
                    Convert.ToSingle( c.R/255.0),
                    Convert.ToSingle( c.G/255.0),
                    Convert.ToSingle( c.B/255.0), 0f,
                    Convert.ToSingle( c.A/255.0)
                }
            };
            var imgAttribs = new ImageAttributes();
            imgAttribs.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Default);
            g.DrawImage(im, r, 0, 0, im.Width, im.Height, GraphicsUnit.Pixel, imgAttribs);
        }

        /// <summary>
        /// The Method to draw the image with custom color.
        /// </summary>
        /// <param name="g"> The Graphic to draw the image.</param>
        /// <param name="r"> The Rectangle area of image.</param>
        /// <param name="image"> The image that the custom color applies on it.</param>
        /// <param name="c">The Color that be applied to the image.</param>
        /// <remarks></remarks>
        public static void DrawColoredImage(this Graphics g, Rectangle r, Image image, Color c)
        {
            float[][] ptsArray = {
                new[] {Convert.ToSingle(c.R / 255.0), 0f, 0f, 0f, 0f},
                new[] {0f, Convert.ToSingle(c.G / 255.0), 0f, 0f, 0f},
                new[] {0f, 0f, Convert.ToSingle(c.B / 255.0), 0f, 0f},
                new[] {0f, 0f, 0f, Convert.ToSingle(c.A / 255.0), 0f},
                new[]
                {
                    Convert.ToSingle( c.R/255.0),
                    Convert.ToSingle( c.G/255.0),
                    Convert.ToSingle( c.B/255.0), 0f,
                    Convert.ToSingle( c.A/255.0)
                }
            };
            var imgAttribs = new ImageAttributes();
            imgAttribs.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Default);
            g.DrawImage(image, r, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, imgAttribs);
            image.Dispose();
        }

        /// <summary>
        /// The Method to draw image with custom transparency.
        /// </summary>
        /// <param name="g">The Graphic to draw the image.</param>
        /// <param name="alpha">The Transparency for the image which is starts from 0 and ends with 1.</param>
        /// <param name="image">The image to draw which also the custom transparency applies on it.</param>
        /// <param name="rect">The Rectangle area of image.</param>
        public static void DrawTransparentImage(this Graphics g, float alpha, Image image, Rectangle rect)
        {
            var colorMatrix = new ColorMatrix { Matrix33 = alpha };
            var imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(colorMatrix);
            g.DrawImage(image, new Rectangle(rect.X, rect.Y, image.Width, image.Height), rect.X, rect.Y, image.Width, image.Height, GraphicsUnit.Pixel, imageAttributes);
            imageAttributes.Dispose();
        }

        /// <summary>
        /// The Method to draw the rectangle alongside the border.
        /// </summary>
        /// <param name="g">The Graphic to draw the rectangle.</param>
        /// <param name="rect">The Rectangle area.</param>
        /// <param name="bodyColor">The Body color of the rectangle.</param>
        /// <param name="strokeColor">The Border color of the rectangle.</param>
        /// <param name="strokeThickness">The Border thickness.</param>
        public static void DrawStrokedRectangle(this Graphics g, Rectangle rect, Color bodyColor, Color strokeColor, int strokeThickness = 1)
        {
            using (var bodyBrush = new SolidBrush(bodyColor))
            {
                var x = strokeThickness == 1 ? 0 : strokeThickness;
                var y = strokeThickness == 1 ? 0 : strokeThickness;
                var h = strokeThickness == 1 ? 1 : strokeThickness + 1;
                var w = strokeThickness == 1 ? 1 : strokeThickness + 1;
                var newRect = new Rectangle(rect.X + x, rect.Y + y, rect.Width - w, rect.Height - h);
                using (var strokePen = new Pen(strokeColor, strokeThickness))
                {
                    g.FillRectangle(bodyBrush, newRect);
                    g.DrawRectangle(strokePen, newRect);
                }
            }
        }

        /// <summary>
        /// The Method to draw the circle alongside the border.
        /// </summary>
        /// <param name="g">The Graphic to draw the Circle.</param>
        /// <param name="rect">The Circle area.</param>
        /// <param name="bodyColor">The Body color of the circle.</param>
        /// <param name="strokeColor">The Border color of the circle.</param>
        /// <param name="strokeThickness">The Border thickness.</param>
        public static void DrawStrokedEllipse(this Graphics g, Rectangle rect, Color bodyColor, Color strokeColor, int strokeThickness = 1)
        {
            using (var bodyBrush = new SolidBrush(bodyColor))
            {
                var x = strokeThickness == 1 ? 0 : strokeThickness;
                var y = strokeThickness == 1 ? 0 : strokeThickness;
                var h = strokeThickness == 1 ? 1 : strokeThickness + 1;
                var w = strokeThickness == 1 ? 1 : strokeThickness + 1;
                var newRect = new Rectangle(rect.X + x, rect.Y + y, rect.Width - w, rect.Height - h);
                using (var strokePen = new Pen(strokeColor, strokeThickness))
                {
                    g.FillEllipse(bodyBrush, newRect);
                    g.DrawEllipse(strokePen, newRect);
                }
            }
        }

        /// <summary>
        /// The Method to draw the rectangle alongside the border.
        /// </summary>
        /// <param name="g">The Graphic to draw the rectangle.</param>
        /// <param name="rect">The Rectangle area.</param>
        /// <param name="bodyColor">The Body color of the rectangle.</param>
        /// <param name="strokeColor">The Border color of the rectangle.</param>
        /// <param name="strokeThickness">The Border thickness.</param>
        /// <param name="curve">The Rounding border radius.</param>
        /// <param name="topLeft">Wether the top left of rectangle be round or not.</param>
        /// <param name="topRight">Wether the top right of rectangle be round or not.</param>
        /// <param name="bottomLeft">Wether the bottom left of rectangle be round or not.</param>
        /// <param name="bottomRight">Wether the bottom right of rectangle be round or not.</param>
        public static void DrawRoundedRectangleWithStroke(this Graphics g, Rectangle rect, Color bodyColor, Color strokeColor, int strokeThickness = 1, int curve = 1, bool topLeft = true, bool topRight = true,
            bool bottomLeft = true, bool bottomRight = true)
        {
            using (var bodyBrush = new SolidBrush(bodyColor))
            {
                var x = strokeThickness == 1 ? 0 : strokeThickness;
                var y = strokeThickness == 1 ? 0 : strokeThickness;
                var h = strokeThickness == 1 ? 1 : strokeThickness + 1;
                var w = strokeThickness == 1 ? 1 : strokeThickness + 1;
                var newRect = new Rectangle(rect.X + x, rect.Y + y, rect.Width - w, rect.Height - h).RoundRec(curve, topLeft, topRight, bottomLeft, bottomRight);
                using (var strokePen = new Pen(strokeColor, strokeThickness))
                {
                    g.FillPath(bodyBrush, newRect);
                    g.DrawPath(strokePen, newRect);
                }
            }
        }
    }
}