
# Palette-Swapping
### Basic palette swapping script. Optimized for performance. Created for learning.

<table>
  <tr>
    <td>
      ## Want to Contribute? 
    Reach out to me if you have any questions and feel free to use the examples here for your own palette swap tool.
    This project is openly available for anyone to use or clone and contribute to. If there's anything you think you can add to it, please do.   
</td>
 </tr>
</table>
My current TODOs:
- Optimize Draw Calls

## Image Import Settings
- in the `Default` section it's best to have `Compression` set to `None`.  
- Under `Advanced`, make sure `Read/Write Enabled` is checked. ☑ 

## Next Step
When you right click a valid texture (such as a sprite sheet) > Click `Create` > and select `Color Palette`.
![img](https://github.com/emanisgrand/Palette-Swapping/blob/master/README/Create%20a%20new%20scriptable%20obj.gif)

## How It Works
The `Color Paltte` is a custom Asset Utilitiy which samples unique colors from the selected texture, scanning it from the upper-left-most point and working its way to the right, then down. Kind of like a typewriter. In the example scene, the image file isolates every last color in the sprite in order to optimize the scan.


It scans the entire image for unique colors, and outputs a color palette object...


which you can then place on any sprite containing the `Palette Swapper` script.  
![img](https://github.com/emanisgrand/Palette-Swapping/blob/master/README/palette-swap-script.PNG)

The fewer amount of colors your spritesheet has, the easier it will be, but it's all up to you.

Once you have a new palette, simply use the color picker in the `New Color` column to replace the original colors, and apply the new palette to your gameobject. 

No need to reanimate a ready-to-play sprite. 



