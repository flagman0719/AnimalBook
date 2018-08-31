using UnityEngine;
using UnityEditor;

public class ExportAssetBundles : MonoBehaviour {

    [MenuItem("Assets/Build AssetBundle")]
    static void ExportResource()
    {
        // Bring up save panel.
        string path = EditorUtility.SaveFilePanel("Save Bundle", "", "AssetBundle", "unity3d");

        if (path.Length != 0)
        {
            // Build the resource file from the active selection.
            Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);

            foreach (object asset in selection)
            {
                string assetPath = AssetDatabase.GetAssetPath((UnityEngine.Object)asset);
                if (asset is Texture2D)
                {
                    // Force reimport thru TextureProcessor.
                    AssetDatabase.ImportAsset(assetPath);
                }
            }
            BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, BuildAssetBundleOptions.CollectDependencies | BuildAssetBundleOptions.CollectDependencies, BuildTarget.Android);
            Selection.objects = selection;
        }
    }
}
