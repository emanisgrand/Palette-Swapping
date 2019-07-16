# Palette-Swapping
### Palette swapping utility. Optimized for performance. Created for learning.

## Installation & Set-Up
The [Palette_Swap Unity Package](https://github.com/emanisgrand/Palette-Swapping/tree/master/Builds) should have everything you need to get started including example images, and all necessary files. Just download the package and import it into your Unity project.


## Want to Contribute?
<table>
  <tr>
    <td>
       Reach out to me if you have any questions and feel free to use the examples here for your own palette swap tool. 
      This project is openly available for anyone to use or clone and contribute to. If there's anything you think you can add to it, please do.   
</td>
 </tr>
</table>

My current TODOs:
- Further optimize draw calls

## Image Import Settings
- in the `Default` section it's best to have `Compression` set to `None`.  
- Under `Advanced`, make sure `Read/Write Enabled` is checked. ☑ 

## Next Step
When you right click a valid texture (such as a sprite sheet) > Click `Create` > and select `Color Palette`.
![img](https://github.com/emanisgrand/Palette-Swapping/blob/master/README/Create%20a%20new%20scriptable%20obj.gif)

## How It Works
The `Color Paltte` is a custom Asset Utilitiy which samples unique colors from the selected texture. The image is scanned from top-left to the bottom-right point kind of like a typewriter. This is why the images used in the example scene have all of its colors in the top-left part of the image. This is not required in order for the palette swapper to work, but is a great way to optimize the image scan. The fewer the colors in your spritesheet, the easier it will be to maintain, but ultimately it's up to you. As long as you include an offset on your spritesheets, those colors will never be rendered. 

| Photoshop            |  Sprite Editor |
:-------------------------:|:-------------------------:
![](https://github.com/emanisgrand/Palette-Swapping/blob/master/README/zombie-samples.PNG)  |  ![](https://github.com/emanisgrand/Palette-Swapping/blob/master/README/Zombie-sample%20from%20sprite%20editor.PNG)



Once it's created, you can then place your new palette on any sprite containing the `Palette Swapper` script component.  

![img](https://github.com/emanisgrand/Palette-Swapping/blob/master/README/palette-swap-script.PNG)


Once you have a new palette, simply use the color picker in the `New Color` column to replace the original colors, and apply the new palette to your Sprite. Don't worry about mixing it up too much, as you can always click the big Revert button to go back to the original colors. 🚧


![](https://github.com/emanisgrand/Palette-Swapping/blob/master/README/palette-util.PNG)

No need to reanimate a ready-to-play sprite. 

![](https://github.com/emanisgrand/Palette-Swapping/blob/master/README/image_2.gif)
