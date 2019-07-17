using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaletteSwapper : MonoBehaviour {
    public SpriteRenderer spriteRenderer;
    public ColorPalette[] palettes;

    private Texture2D texture;
    private MaterialPropertyBlock block;

    private void Awake() {
        // grab instance of the Sprite Renderer component.
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start() { 
        // If there is a palette, then start iterating through it
        // and return a  random palette 
        if (palettes.Length > 0)
            SwapColors(palettes[Random.Range(0, palettes.Length)]);
    }

    void SwapColors(ColorPalette palette){
        
        if (palette.cachedTexture == null){
            texture = spriteRenderer.sprite.texture;
            var w                   = texture.width;
            var h                   = texture.height;
            var cloneTexture        = new Texture2D(w, h);
            var colors              = texture.GetPixels();
            
            // New texture's default settings
            cloneTexture.wrapMode   = TextureWrapMode.Clamp;
            cloneTexture.filterMode = FilterMode.Point;

            // Set all the colors in the new texture to a new 
            // array called pixels.
            for (int i=0; i< colors.Length; i++){
                colors[i] = palette.GetColor(colors[i]);
            }

            cloneTexture.SetPixels(colors);
            cloneTexture.Apply();

            palette.cachedTexture = cloneTexture;
        }
        //create instance of the MatPropBlock 
        //Set the cloned texture to it/name it main tex
        block = new MaterialPropertyBlock();
        block.SetTexture("_MainTex", palette.cachedTexture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // this gets reset on every update call
    private void LateUpdate() {
        // setting the property block to the block we
        // created at the end of the start function
        spriteRenderer.SetPropertyBlock(block);
    }
}
