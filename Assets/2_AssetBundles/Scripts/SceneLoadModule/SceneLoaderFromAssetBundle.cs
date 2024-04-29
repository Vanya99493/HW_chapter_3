using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _2_AssetBundles.Scripts.SceneLoadModule
{
    public class SceneLoaderFromAssetBundle : MonoBehaviour
    {   
        [SerializeField] private string _sceneAssetBundlePath;
        [SerializeField] private string _resourcesAssetBundlePath;
        [SerializeField] private string _sceneName;

        public void LoadScene()
        {
            StartCoroutine(LoadSceneFromAssetBundle());
        }

        private IEnumerator LoadSceneFromAssetBundle()
        {
            AssetBundle sceneAssetBundle = AssetBundle.LoadFromFile(_sceneAssetBundlePath);
            AssetBundle globalAssetBundle = AssetBundle.LoadFromFile(_resourcesAssetBundlePath);

            if (sceneAssetBundle != null)
            {
                AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Single);

                while (!asyncOperation.isDone)
                {
                    yield return null;
                }

                sceneAssetBundle.Unload(false);
                globalAssetBundle.Unload(false);
            }
            else
            {
                Debug.LogError("Failed to load Asset Bundle: " + _sceneAssetBundlePath);
            }
        }
    }
}