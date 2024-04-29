using _1_ScriptableObject.Scripts.CharacterModule;
using UnityEngine;

namespace CharacterModule
{
    public class CharacterRotator : MonoBehaviour
    {
        [SerializeField] private GameObject _head;
        [SerializeField] private float _rotationSpeed;

        private Vector3 _currentRotation;
        private CharacterInventory _characterInventory;

        private void Start()
        {
            _characterInventory = GetComponent<CharacterInventory>();
        }

        private void Update()
        {
            if (_characterInventory != null && _characterInventory.IsActiveInventory)
            {
                return;
            }
            
            _currentRotation.x += Input.GetAxis("Mouse X");
            _currentRotation.y += Input.GetAxis("Mouse Y");
            _currentRotation.y = Mathf.Clamp(_currentRotation.y, -60f, 60f);
        }

        private void LateUpdate()
        {
            transform.localRotation = Quaternion.Euler(0, _currentRotation.x * _rotationSpeed * Time.fixedDeltaTime, 0);
            _head.transform.localRotation = Quaternion.Euler(-_currentRotation.y * _rotationSpeed * Time.fixedDeltaTime, 0, 0);
        }
    }
}