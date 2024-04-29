using _1_ScriptableObject.Scripts.InventoryModule;
using _1_ScriptableObject.Scripts.ScriptableObjects;
using UnityEngine;

namespace _1_ScriptableObject.Scripts
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private InventorySO _inventorySO;
        [SerializeField] private Inventory _inventory;

        private void Start()
        {
            _inventory.Initialize(_inventorySO);
        }
    }
}