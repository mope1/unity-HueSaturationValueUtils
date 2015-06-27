# unity-HueSaturationValueUtils
It's two tiny helper classes for color conversion.

**Usage:**
```
using HueSaturationValueUtils;
...
//RGB->HSV
ColorHSV myHsv = myColor.toHSV();

//HSV->RGB
Color otherColor = myHsv.toRGB(); 

//this should also work i added a casting operator  
Color othercolor = myHsv; 

```

Some Demos are included. Have fun
