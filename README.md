# GDIHelper
A Bunch of useful GDI+ methods and extensions that can be used for many purposes.

## 

## Dependency
 .NET Framework 3.5 or higher
 
 ## 
 
## Contents

<h4 align="Left">Methods</h3>

* [GetFont](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#getfont)
* [GetFont](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#getfont-1)   
* [SetAlignment](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#setalignment)
* [GlowBrush](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#glowbrush)
* [GlowBrush](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#glowbrush-1)

<h4 align="Left">Extensions</h3>

* _**Rectangles**_
    * [RoundRec](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#roundrec)
  
* _**Colors**_
    * [ToHTML](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#tohtml)
    * [ToBrush](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#tobrush)
    * [ToPen](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#topen)
    * [ToRGBString](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#torgbstring)
    * [ToRGBAString](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#torgbastring)
    * [ToARGBString](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#toargbstring)
    * [MixColors](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#mixcolors)
    
* _**Drawings**_
    * [DrawImageFromBase64](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#drawimagefrombase64)
    * [DrawColoredImage](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#drawcoloredimage)
    * [DrawColoredImage](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#drawcoloredimage-1)
    * [DrawTransparentImage](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#drawtransparentimage)
    * [DrawStrokedRectangle](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#drawstrokedrectangle)
    * [DrawStrokedEllipse](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#drawstrokedellipse)
    * [DrawRoundedRectangleWithStroke](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#drawroundedrectanglewithstroke)
    
* _**Images**_
    * [ToBrush](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#tobrush-1)
    * [ToBrush](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#tobrush-2)
    * [ToPen](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#tobrush-2)
    * [ToBase64](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#tobase64)
    
* _**Strings**_
    * [ToImage](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#toimage)
    * [ToColor](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#tocolor)
    * [ToBrush](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#tobrush-3)
    * [ToPen](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#topen-2)
    * [ToFont](https://github.com/N-a-r-w-i-n/GDIHelper/blob/master/README.md#tofont)

##

<h1 align="Left">Methods</h1>

### GetFont

```cs
using GDIHelper;

    private readonly Methods _instance = new Methods();
    Font fontfile = _instance.GetFont("fontbytearray /* e.g : a font stored in resources */, fontsize, fontstyle);
```
### GetFont

```cs

using GDIHelper;

    private readonly Methods _instance = new Methods();
    Font fontfile = _instance.GetFont("Font path" /* e.g : C:fontfile.ttf */, fontsize, fontstyle);
    
```
### SetAlignment

```cs

using GDIHelper;

    private readonly Methods _instance = new Methods();
    StringFormat stringFormat = _instance.SetAlignment(StringAlignment.Center, StringAlignment.Near);
    
```
### GlowBrush

```cs

using GDIHelper;

    private readonly Methods _instance = new Methods();
    GraphicsPath GP = new GraphicsPath();
            GP.AddRectangle(new Rectangle(10, 10, 23, 45));
            Brush solidBrush = _instance.GlowBrush(Color.Brown, new Color[] {Color.Black, Color.DarkRed}, new PointF(5, 8), GP, WrapMode.Clamp);
    
```
### GlowBrush

```cs

using GDIHelper;

    private readonly Methods _instance = new Methods();
    GraphicsPath GP = new GraphicsPath();
            GP.AddRectangle(new Rectangle(10, 10, 23, 45));
            Brush solidBrush = _instance.GlowBrush(Color.Brown, new Color[] {Color.Black, Color.DarkRed}, new PointF[]{new PointF(12,10), new PointF(0, 2) }, WrapMode.Tile);
    
```


##

<h1 align="Left">Extensions</h1>

<h2 align="Left">Rectangles</h2>

### RoundRec

```cs
GraphicsPath GP = new Rectangle(0, 0, 10, 10).RoundRec(12, true, true, true, true);
```

<h2 align="Left">Colors</h2>

### ToHTML
```cs
string htmlColor = Color.Brown.ToHTML();
```
### ToBrush
```cs
SolidBrush solidBrush = Color.MediumBlue.ToBrush();
```
### ToPen
```cs
Pen pen = Color.Brown.ToPen();
```
### ToRGBString
```cs
string rgb = Color.Aquamarine.ToRGBString();
```
Output :
 > rgb(127, 255, 212)
 
### ToRGBAString
```cs
string rgba = Color.Aquamarine.ToRGBAString();
```
Output :
 > rgba(127, 255, 212, 255)
  
### ToARGBString
```cs
string argb = Color.Aquamarine.ToARGBString();
```
Output :
 > argb(255, 127, 255, 212)
 
### MixColors
```cs
Color color = new Color[]{Color.Black, Color.Blue}.MixColors();
```

<h2 align="Left">Colors</h2>

### DrawImageFromBase64
```cs
Graphics g = CreateGraphics();
/// DrawImageFromBase64(string base64Image, Rectangle rect)
g.DrawImageFromBase64("base64 image", new Rectangle(0, 0, 12, 12));
```
### DrawColoredImage
```cs
Graphics g = CreateGraphics();
/// DrawColoredImage(Rectangle r, string base64Image, Color c)
g.DrawColoredImage(new Rectangle(0, 0, 12, 12), "base64 image", Color.Black);
```
### DrawColoredImage
```cs
Graphics g = CreateGraphics();
Image image = Image.FromFile("image path");
// DrawColoredImage(Rectangle r, Image image, Color c)
g.DrawColoredImage(new Rectangle(0, 0, 12, 12), image, Color.Black);
```
### DrawTransparentImage
```cs
Graphics g = CreateGraphics();
Image image = Image.FromFile("image path");
// DrawTransparentImage(float alpha, Image image, Rectangle rect)
g.DrawTransparentImage(0.1f, image, new Rectangle(0, 0, 12, 12));
```
### DrawStrokedRectangle
```cs
Graphics g = CreateGraphics();
// DrawStrokedRectangle(Rectangle rect, Color bodyColor, Color strokeColor, int strokeThickness = 1)
g.DrawStrokedRectangle(new Rectangle(0, 0, 12, 12), Color.Brown, Color.Black, 2);
```
### DrawStrokedEllipse
```cs
Graphics g = CreateGraphics();
// DrawStrokedEllipse(Rectangle rect, Color bodyColor, Color strokeColor, int strokeThickness = 1)
g.DrawStrokedEllipse(new Rectangle(0, 0, 12, 12), Color.Brown, Color.Black, 2);
```
### DrawRoundedRectangleWithStroke
```cs
Graphics g = CreateGraphics();
// DrawRoundedRectangleWithStroke(Rectangle rect, Color bodyColor, Color strokeColor, int strokeThickness = 1, int curve = 1, bool topLeft = true, bool topRight = true,
            bool bottomLeft = true, bool bottomRight = true)
g.DrawRoundedRectangleWithStroke(new Rectangle(0, 0, 12, 12), Color.Brown, Color.Black, 2, 10, true, true ,true, true);
```

<h2 align="Left">Images</h2>

### ToBrush
```cs
Image image = Image.FromFile("image path");
TextureBrush pathGradientBrush = image.ToBrush();
```
### ToBrush
```cs
Image image = Image.FromFile("image path");
TextureBrush pathGradientBrush = image.ToBrush(new Rectangle(0, 0, 22, 22));
```
### ToPen
```cs
Image image = Image.FromFile("image path");
// ToPen(float width = 1, LineCap startCap = LineCap.Custom, LineCap endCap = LineCap.Custom)
Pen pen = image.ToPen(2, LineCap.Custom, LineCap.Custom);
```
### ToBase64
```cs
Image image = Image.FromFile("image path");
string base64image = image.ToBase64();
```
<h2 align="Left">Strings</h2>

### ToImage
```cs
string base64Image = "imageinbase64string";
Image image = base64Image.ToImage();
```
### ToColor
```cs
string HTML = "#fff";
// ToColor(int alpha = 255)
Color color = HTML.ToColor(80);
```
### ToBrush
```cs
string HTML = "#fff";
// ToBrush(int alpha = 255)
SolidBrush solidBrush = HTML.ToBrush(90);
```
### ToPen
```cs
string HTML = "#fff";
// ToPen(int alpha = 255, float size = 1, LineCap startCap = LineCap.Custom, LineCap endCap = LineCap.Custom)
Pen pen = HTML.ToPen(220, 4, LineCap.Custom, LineCap.Custom);
```
### ToFont
```cs
string fontName = "Arial";
// ToFont(float size, FontStyle fontStyle = FontStyle.Regular, GraphicsUnit unit = GraphicsUnit.Pixel)
Font font = fontName.ToFont(8, FontStyle.Regular, GraphicsUnit.Display);
```
