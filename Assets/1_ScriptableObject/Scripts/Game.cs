using _1_ScriptableObject.Scripts.ScriptableObjects;
using UnityEngine;

namespace _1_ScriptableObject.Scripts
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private ItemsContainerSO _itemsContainerSO;
        
        public static ItemsContainerSO ItemsContainerSO;

        private void Awake()
        {
            ItemsContainerSO = _itemsContainerSO;
        }
    }
}