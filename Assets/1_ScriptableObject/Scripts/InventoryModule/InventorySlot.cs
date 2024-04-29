using System;
using _1_ScriptableObject.Scripts.ItemModule;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _1_ScriptableObject.Scripts.InventoryModule
{
    public class InventorySlot : MonoBehaviour, IPointerDownHandler
    {
        public event Action<Item> ClickEvent;
        public event Action<Item> RemoveEvent;

        [SerializeField] private InventoryItem _inventoryItem;

        public Item Item { get; private set; }

        private void Start()
        {
            _inventoryItem.ClickEvent += () => OnPointerDown(null);
        }

        public bool AddItem(Item item)
        {
            if (Item == null)
            {
                Item = item;
                _inventoryItem.Add(item.Icon, OnRemoveButtonClick);
                return true;
            }

            return false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            ClickEvent?.Invoke(Item);
        }

        private void OnRemoveButtonClick()
        {
            RemoveEvent?.Invoke(Item);
            Item = null;
            _inventoryItem.Remove();
        }
    }
}