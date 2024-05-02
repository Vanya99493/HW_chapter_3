using UnityEngine;

namespace _1_ScriptableObject.Scripts.ItemModule
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private ItemType _itemType;
        
        private ItemInfo _itemInfo;

        public string Name => _itemInfo.Name;
        public string Description => _itemInfo.Description;
        public ItemType ItemType => _itemType;
        public Sprite Icon { get; private set; }

        private void Start()
        {
            Initialize();
        }

        public string GetFullDescription()
        {
            return $"Name: {Name}\n" +
                   $"Description: {Description}";
        }

        private void Initialize()
        {
            var itemSO = Game.ItemsContainerSO[_itemType];
            _itemInfo = itemSO.ItemInfo;
            Icon = itemSO.ItemIcon;
        }
    }
}