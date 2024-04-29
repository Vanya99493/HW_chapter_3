using _1_ScriptableObject.Scripts.ItemModule;
using UnityEngine;

namespace _1_ScriptableObject.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 1)]
    public class ItemSO : ScriptableObject
    {
        public string ItemName;
        public string ItemDescription;
        public Sprite ItemIcon;
        public Item ItemPrefab;
    }
}