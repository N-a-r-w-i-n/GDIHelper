using System.Drawing;
using System.Drawing.Drawing2D;

namespace GDIHelper.Areas
{
    public static class Rectangles
    {
        /// <summary>
        /// Turns the rectangle to the rounded rectangle.
        /// Credits : Aeonhack
        /// </summary>
        /// <param name="r">The Rectangle to fill.</param>
        /// <param name="curve">The Rounding border radius.</param>
        /// <param name="topLeft">Wether the top left of rectangle be round or not.</param>
        /// <param name="topRight">Wether the top right of rectangle be round or not.</param>
        /// <param name="bottomLeft">Wether the bottom left of rectangle be round or not.</param>
        /// <param name="bottomRight">Wether the bottom right of rectangle be round or not.</param>
        /// <returns>The Rounded rectangle based on given rectangle</returns>
        public static GraphicsPath RoundRec(this Rectangle r, int curve, bool topLeft = true, bool topRight = true,
          bool bottomLeft = true, bool bottomRight = true)
        {
            curve = curve * 2;

            var createRoundPath = new GraphicsPath(FillMode.Winding);
            if (!topLeft)
                createRoundPath.AddLine(r.X, r.Y, r.X, r.Y);
            else
                createRoundPath.AddArc(r.X, r.Y, curve, curve, 180f, 90f);
            if (!topRight)
                createRoundPath.AddLine(r.Right - r.Width, r.Y, r.Width, r.Y);
            else
                createRoundPath.AddArc(r.Right - curve, r.Y, curve, curve, 270f, 90f);
            if (!bottomRight)
                createRoundPath.AddLine(r.Right, r.Bottom, r.Right, r.Bottom);
            else
                createRoundPath.AddArc(r.Right - curve, r.Bottom - curve, curve, curve, 0f, 90f);
            if (!bottomLeft)
                createRoundPath.AddLine(r.X, r.Bottom, r.X, r.Bottom);
            else
                createRoundPath.AddArc(r.X, r.Bottom - curve, curve, curve, 90f, 90f);
            createRoundPath.CloseFigure();
            return createRoundPath;
        }
    }
}