using _1_ScriptableObject.Scripts.InventoryModule;
using _1_ScriptableObject.Scripts.ItemModule;
using UnityEngine;

namespace _1_ScriptableObject.Scripts.CharacterModule
{
    public class CharacterInventory : MonoBehaviour
    {
        private const KeyCode INVENTORY_KEY = KeyCode.I;
        private const KeyCode PICK_UP_ITEM_KEY = KeyCode.E;

        [SerializeField] private Inventory _inventory;
        [SerializeField] private Camera _headCamera;
        [SerializeField] private float _pickUpDistance;
        [SerializeField] private float _dropDistance;

        public bool IsActiveInventory { get; private set; }

        private void Start()
        {
            DeactivateInventory();
            _inventory.RemoveItemEvent += OnRemoveItem;
        }

        private void Update()
        {
            if (Input.GetKeyDown(INVENTORY_KEY))
            {
                if (IsActiveInventory)
                {
                    DeactivateInventory();
                }
                else
                {
                    ActivateInventory();
                }
            }

            if (Input.GetKeyDown(PICK_UP_ITEM_KEY))
            {
                ThrowRay();
            }
        }

        private void ActivateInventory()
        {
            IsActiveInventory = true;
            _inventory.gameObject.SetActive(true);
        }

        private void DeactivateInventory()
        {
            IsActiveInventory = false;
            _inventory.gameObject.SetActive(false);
        }

        private void ThrowRay()
        {
            Ray ray = new Ray(
                _headCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f)), 
                _headCamera.transform.forward
                );
            
            if (Physics.Raycast(ray, out RaycastHit hit, _pickUpDistance))
            {
                GameObject itemObj = hit.transform.gameObject;
                if (itemObj.TryGetComponent(out Item item))
                {
                    if (_inventory.AddItem(item))
                    {
                        itemObj.transform.SetParent(gameObject.transform);
                        itemObj.transform.position = Vector3.zero;
                        itemObj.SetActive(false);
                    }
                }
            }
        }

        private void OnRemoveItem(Item item)
        {
            item.transform.position = (transform.forward + transform.up) * _dropDistance;
            item.transform.parent = null;
            item.gameObject.SetActive(true);
        } 
    }
}