
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
The `Color Paltte` is a custom Asset Utilitiy which samples unique colors from the selected texture. The image is scanned from top-left to the bottom-right point kind of like a typewriter. This is why the images used in the example scene have all of its colors in the top-left part of the image. 

//TODO:
[PICTURE OF ZOMBIE HERE]

This is not required in order for the palette swapper to work, but is a great way to optimize the image scan. The fewer the colors in your spritesheet, the easier it will be to maintain, but ultimately it's up to you.
As long as you include an offset on your spritesheets, 
//TODO:
[SHOW IMAGE OF SPRITE SHEET EDITOR]
those colors will never be rendered. 

Once it's created, you can then place your new palette on any sprite containing the `Palette Swapper` script component.  
![img](https://github.com/emanisgrand/Palette-Swapping/blob/master/README/palette-swap-script.PNG)



Once you have a new palette, simply use the color picker in the `New Color` column to replace the original colors, and apply the new palette to your Sprite. 

//TODO:
[IMG EXAMPLE]

No need to reanimate a ready-to-play sprite. 
