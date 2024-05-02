using System;
using _1_ScriptableObject.Scripts.ItemModule;
using UnityEngine;

namespace _1_ScriptableObject.Scripts.InventoryModule
{
    public class Inventory : MonoBehaviour
    {
        public event Action<Item> RemoveItemEvent;
        
        [SerializeField] private DescriptionPanel _descriptionPanel;
        [SerializeField] private InventorySlot[] _inventorySlots;

        private void Start()
        {
            for (int i = 0; i < _inventorySlots.Length; i++)
            {
                _inventorySlots[i].ClickEvent += OnInventorySlotClick;
                _inventorySlots[i].RemoveEvent += OnRemoveItem;
            }
        }

        public bool AddItem(Item item)
        {
            for (int i = 0; i < _inventorySlots.Length; i++)
            {
                if (_inventorySlots[i].AddItem(item))
                {
                    return true;
                }
            }

            return false;
        }

        private void OnRemoveItem(Item item)
        {
            RemoveItemEvent?.Invoke(item);
        }

        private void OnInventorySlotClick(Item item)
        {
            _descriptionPanel.ActivateAndUpdateDescription(item);
        }
    }
}