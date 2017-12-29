# GDIHelper
A Bunch of useful GDI+ methods and extensions that can be used for many purposes.

## 

## Contents

<h4 align="Left">Methods</h3>

* [GetFont]()
* [GetFont]()   
* [SetAlignment]()
* [GlowBrush]()
* [GlowBrush]()

<h4 align="Left">Extensions</h3>

* _**Rectangles**_
    * [RoundRec](https://github.com/N-a-r-w-i-n/GDIHelper/new/master?readme=1#round-rectangle)
  
* _**Colors**_
    * [ToHTML]()
    * [ToBrush]()
    * [ToPen]()
    * [ToRGBString]()
    * [ToRGBAString]()
    * [ToARGBString]()
    * [MixColors]()
    
* _**Drawings**_
    * [DrawImageFromBase64]()
    * [DrawColoredImage]()
    * [DrawColoredImage]()
    * [DrawTransparentImage]()
    * [DrawStrokedRectangle]()
    * [DrawStrokedEllipse]()
    * [DrawRoundedRectangleWithStroke]()
    
* _**Images**_
    * [ToBrush]()
    * [ToBrush]()
    * [ToPen]()
    * [ToBase64]()
    
* _**Strings**_
    * [ToImage]()
    * [ToColor]()
    * [ToBrush]()
    * [ToPen]()
    * [ToFont]()

## Round Rectangle

```cs
GraphicsPath GP = new Rectangle(0, 0, 10, 10).RoundRec(12, true, true, true, true);
```
