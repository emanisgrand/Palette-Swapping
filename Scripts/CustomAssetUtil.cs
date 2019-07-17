using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CustomAssetUtil {
    #if UNITY_EDITOR
    public static T CreateAsset<T>(string path) where T:ScriptableObject {
    T asset = null;

    // Create an instance of the scritable object.
    asset = ScriptableObject.CreateInstance<T>();
    
    // Generate a unique path name to avoid overwriting when multiple versions get saved
    var newPath = AssetDatabase.GenerateUniqueAssetPath(path);
    AssetDatabase.CreateAsset (asset, newPath);
    AssetDatabase.SaveAssets();

    return asset;  // so we can use it in other parts of our code    
    }
    #endif
}
