using System.Collections.Generic;
using UnityEngine;

namespace _1_ScriptableObject.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/Inventory", order = 1)]
    public class InventorySO : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] private int _inventorySize;
        
        public List<ItemSO> Items;

        public void OnBeforeSerialize() {}
 
        public void OnAfterDeserialize()
        {
            if (Items.Count > _inventorySize)
            {
                List<ItemSO> newList = new List<ItemSO>();

                int i = 0;
                foreach (var item in Items)
                {
                    if (i >= _inventorySize)
                    {
                        break;
                    }
                    newList.Add(item);
                    i++;
                }
                Items = newList;
            }
        }
    }
}