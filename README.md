# Palette-Swapping
Basic palette swapping script. Optimized for performance. Made for learning.

Reader beware: The following README is just the transcribed notes that I took while making the palette swap code. It was not written with the intention to be an actual README document. Also, some of the formatting in the code examples in the readme itself did not translate correctly when converted into the .md file that you see before you. Thank you for understanding. Please reach out to me if you have any questions and feel free to use the examples in this repo for your own palette swap tool. 

<table>
  <tr>
    <td> When you right click a valid texture > go to Create > and select `Create Palette`, the Palette Swapper samples colors from the  selected texture, scanning it from the upper-left-most point and working its way to the right, then down. Kind of like a typewriter. It scans the entire image for unique colors, and outputs a color palette object which you can place on any sprite containing the `Palette Swapper` script.  </td>
  </tr>
</table>
- It's best to disable **Compression** for any texture .
- Any texture being used in this example should have no **Compression** in order to avoid having an excess of colors in each palette. 
- it must be read/write enabled in its advanced options. 
- You really want to prepopulate any new object as much as possible. 








## Replacing Animation Texture

This is going to handle animations.

**MaterialPropertyBlock **was created here in this lesson. *See **[additional note*s](#heading=h.qk9v9wt36nqk)* below*

<table>
  <tr>
    <td>// this gets reset on every update call I think
   private void LateUpdate()-------------------------------- {
       // setting the property block to the block we
       // created at the end of the start function
       spriteRenderer.SetPropertyBlock(block);---------------}
It's important because on the next update, the animation may change and we need to give it a new reference to the cloned texture we're using.
</td>
  </tr>
</table>


## Swapping Colors on a texture

Now we're gonna need a way to remap the default color in the texture to the new color that we supply in the color palette. To do this, let's open up our Scripts folder and select our color palette script. Here, we're gonna create a new method inside of our color palette class that'll allow us to get the color that we wanna replace. Let's scroll down, and below where we reset our palette let's add a new public property. And, this public property's gonna return a color. And, let's give it the name Get Color.

<table>
  <tr>
    <td>Now, as we iterate through each of the colors we're asking the palette to get us the color and if there's a match for new color it'll return the new color instead.</td>
  </tr>
  <tr>
    <td>for (int i=0; i< colors.Length; i++){
           colors[i] = palette.GetColor(colors[i]);           }
</td>
  </tr>
</table>


At this point, due to some of the things we're referencing, we won't actually be able to compile this into a final game.

## Optimizing

16:40

## Compiler Conditions

Unity Editor is special in that you can only use it inside of the Editor itself. If you try to compile with using references to Unity Editor, it's going to throw this error.

Fixed by using 

 [_](https://docs.unity3d.com/Manual/PlatformDependentCompilation.html) #*if* UNITY_EDITOR     #*endif*     

Anywhere that the unity editor is referenced. See code for example. It’s pretty obvi.

## Optimizing the Draw Calls

![image alt text](image_1.png)

We want to resolve the problem of multiple draw calls for each instance of the same texture. And we will.

- We create a new public property to allow us to cache a texture.

- Fixed the NullReferenceException: Object reference not set to an instance of an object

PaletteSwapper.SwapColors (ColorPalette palette) (at Assets/Scripts/PaletteSwapper.cs:29)

PaletteSwapper.Start () (at Assets/Scripts/PaletteSwapper.cs:23)

 ✅ palette.cachedTexture *=* cloneTexture;

## Cleaning up artwork Colors

Open the PNG in Photoshop

Magic Wand Select - tolerance 0, AA off, not continuous

Alt+Backspace or something to magic fill from the color selected.

Save for web -> Colors -> 16bit -> Press down to see how many colors you’re at.

![image alt text](image_2.gif)

## Additional Notes

* **Platform dependent compilation** - Consists of preprocessor directives that partition scripts to compile and execute exclusively for the supported platform specified by the #define directive. In our case we used #UNITY_EDITOR.

*  **SetDirty()**** **- **Unity Editor -> **Classes -> Editor Utility -> SetDirty 

Sets the object to mark as dirty. What does this mean? Unity uses the dirty flag internally to find changed assets that must be saved to disk.

* **Material Property Block **- **Unity Engine -> **Classes. 
A block of material values to apply. Use it in situations where you want to draw multiple objects with the same material, but slightly different properties. 

* **Serializable - Other -> **Classes 
The Serializable attribute lets you embed a class with sub-properties in the inspector. 

**Currently **getting 6 batch draw calls when it should only be three. Review [Optimizing Draw calls](#heading=h.kjvlxc6g83uq)

The reason 6 batch draw calls are being made is because each new color palette creates a new version of this texture. This is fine. The idea behind optimizing the batch calls for any particular texture is to save on batch calls when the same character is being repeated. 



