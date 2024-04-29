using System;
using UnityEditor;
using UnityEngine;

namespace _2_AssetBundles.Scripts.Editor
{
    public class AssetBundlesBuilder
    {
        [MenuItem("Assets/Create Assets Bundles")]
        private static void BuildAllAssetBundles()
        {
            string assetBundlesDirectoryPath = $"Assets/2_AssetBundles/AssetBundles";
            try
            {
                BuildPipeline.BuildAssetBundles(
                    assetBundlesDirectoryPath,
                    BuildAssetBundleOptions.None,
                    EditorUserBuildSettings.activeBuildTarget
                ); 
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        } 
    }
}