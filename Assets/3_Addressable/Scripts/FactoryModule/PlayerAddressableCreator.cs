using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace _3_Addressable.Scripts.FactoryModule
{
    public class PlayerAddressableCreator : MonoBehaviour
    {
        [SerializeField] private string _name;
        [SerializeField] private Transform _spawnTransform;

        private async Task Start()
        {
            var handle = Addressables.LoadAssetAsync<GameObject>(_name);
            await handle.Task;
            Instantiate(handle.Result, _spawnTransform.position, _spawnTransform.rotation);
            Addressables.Release(handle);
        }
    }
}