using _1_ScriptableObject.Scripts.ItemModule;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _1_ScriptableObject.Scripts.InventoryModule
{
    public class DescriptionPanel : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _description;

        private void Start()
        {
            DeactivateDescription();
        }

        public void ActivateAndUpdateDescription(Item item)
        {
            if (item == null)
            {
                DeactivateDescription();
                return;
            }
            gameObject.SetActive(true);
            _icon.sprite = item.Icon;
            _description.text = item.GetFullDescription();
        }

        public void DeactivateDescription()
        {
            gameObject.SetActive(false);
        }
    }
}