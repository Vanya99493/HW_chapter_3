using UnityEngine;

namespace _2_AssetBundles.Scripts.FactoryModule
{
    public class PlayerCreator : MonoBehaviour
    {
        [SerializeField] private string _name;
        [SerializeField] private string _assetBundlePath;
        [SerializeField] private Transform _spawnTransform;

        private void Start()
        {
            AssetBundle assetBundle = AssetBundle.LoadFromFile(_assetBundlePath);
            
            if (assetBundle != null)
            {
                GameObject characterPrefab = assetBundle.LoadAsset<GameObject>(_name);
                Instantiate(characterPrefab, _spawnTransform.position, _spawnTransform.rotation);
                assetBundle.Unload(false);
            }
            else
            {
                Debug.LogError("Failed to load Asset Bundle: " + _assetBundlePath);
            }
        }
    }
}