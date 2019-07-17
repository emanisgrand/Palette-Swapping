using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

#if UNITY_EDITOR  //called to use unityeditor in builds
using UnityEditor;
#endif

[Serializable]
public class ColorPalette : ScriptableObject {
    // Denote the method that follows is a Menu Item that will
    //exist under the specified location. 
    #if UNITY_EDITOR
    [MenuItem("Assets/Create/Color Palette")]
   
    public static void CreateColorPalette(){

        if (Selection.activeObject is Texture2D){
            
            var selectedTexture     = Selection.activeObject as Texture2D;
            var selectionPath       = AssetDatabase.GetAssetPath(selectedTexture);

            selectionPath           = selectionPath.Replace(".png", "-color-palette.asset");

            var newPalette          = CustomAssetUtil.CreateAsset<ColorPalette>(selectionPath);

            //pass a reference to the selected texture to the source of 
            //the new palette that gets created
            newPalette.source       = selectedTexture;
            newPalette.ResetPalette();
            Debug.Log("Creating a Palette");
        } else
        {
             Debug.Log("Can't create a Palette. Select a Texture2D");
        }
    }
    #endif

    public Texture2D source;
    public List<Color> palette      = new List<Color>();
    public List<Color> newPalette   = new List<Color>();
    public Texture2D cachedTexture;

    private List<Color> BuildPalette(Texture2D texture){
    List<Color> palette             = new List<Color>();
    var colors                      = texture.GetPixels();
    // pull out each color from the colors array
    foreach (var color in colors){
            if (!palette.Contains(color)){
                //only unique colors with an alpha of 1
                if(color.a == 1){
                    palette.Add(color);
                }
            
            }
        }
            return palette;
    }
    public void ResetPalette(){
        palette     = BuildPalette(source);
        newPalette  = new List<Color>(palette);
    }

    public Color GetColor(Color color){
        
        for (var i=0; i<palette.Count; i++){
            var tmpColor = palette[i];

            if (Mathf.Approximately(color.r, tmpColor.r) &&
                Mathf.Approximately(color.g, tmpColor.g) &&
                Mathf.Approximately(color.b, tmpColor.b) &&
                Mathf.Approximately(color.a, tmpColor.a)) {
                return newPalette[i];
                }
        }
    return color;
        
}

}

#if UNITY_EDITOR
[CustomEditor(typeof(ColorPalette))]
public class ColorPaletteEditor : Editor{
//need to make an instance of the color palette we've selected.
public ColorPalette colorPalette;

private void OnEnable() { //set the color palette property
        colorPalette = target as ColorPalette;
        //whatever we've targeted is going to be the since the inspector window 
        //it's safe to recast as ... because we've chose a texture
    }
    override public void OnInspectorGUI(){
        // override is pretty essential here as when we go back to the inspector
        //we will see anything that we define below 
        GUILayout.Label("Source Texture");
        colorPalette.source 
            = EditorGUILayout.ObjectField(colorPalette.source, 
                typeof(Texture2D), false) as Texture2D;
        
        
        //we want to make two columns. Left is textures
        //right is the colors we're going to modify them to be.
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Current Color");
        GUILayout.Label("New Color");
        EditorGUILayout.EndHorizontal();

        //Go through the colors in a loop and spit them out
        for (var i=0;i<colorPalette.palette.Count;i++){
            EditorGUILayout.BeginHorizontal();
            // we don't want these colors to be editable
            EditorGUILayout.ColorField(colorPalette.palette[i]);
            // whatever change happens in the iteration will be set to the new palette.
            colorPalette.newPalette[i] = EditorGUILayout.ColorField(colorPalette.newPalette[i]);
            EditorGUILayout.EndHorizontal();
        }

        // GUILayout.Button is a boolean that checks to see if the button's been clicked
        if (GUILayout.Button("Revert Palette")){
            colorPalette.ResetPalette();
        }



        EditorUtility.SetDirty(colorPalette);
    }
}
#endif