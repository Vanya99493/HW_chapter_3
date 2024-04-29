using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _1_ScriptableObject.Scripts.InventoryModule
{
    public class InventoryItem : MonoBehaviour, IPointerDownHandler
    {
        public event Action ClickEvent;
        
        [SerializeField] private Button _removeButton;
        [SerializeField] private Image _image;

        public void Add(Sprite icon, Action OnButtonClickHandler)
        {
            _image.sprite = icon;
            _removeButton.onClick.RemoveAllListeners();
            _removeButton.onClick.AddListener(() => OnButtonClickHandler());
            gameObject.SetActive(true);
        }

        public void Remove()
        {
            gameObject.SetActive(false);
            _removeButton.onClick.RemoveAllListeners();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            ClickEvent?.Invoke();
        }
    }
}