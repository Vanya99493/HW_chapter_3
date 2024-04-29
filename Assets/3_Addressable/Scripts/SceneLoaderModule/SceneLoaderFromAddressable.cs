using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _3_Addressable.Scripts.SceneLoaderModule
{
    public class SceneLoaderFromAddressable : MonoBehaviour
    {
        [SerializeField] private string _sceneName;

        public void LoadScene()
        {
            Addressables.LoadSceneAsync(_sceneName);
        }
    }
}