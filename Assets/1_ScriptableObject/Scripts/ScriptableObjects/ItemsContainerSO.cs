using _1_ScriptableObject.Scripts.CustomClasses;
using _1_ScriptableObject.Scripts.ItemModule;
using UnityEngine;

namespace _1_ScriptableObject.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemsContainer", menuName = "Inventory/Items container", order = 1)]
    public class ItemsContainerSO : ScriptableObject
    {
        public SerializableDictionary<ItemType, ItemSO> Items;

        public ItemSO this[ItemType type] => Items[type];
    }
}