using UnityEngine;

namespace _1_ScriptableObject.Scripts.ItemModule
{
    public class Item : MonoBehaviour
    {
        private string _name;
        private string _description;
        
        public Sprite Icon { get; private set; }

        public void Initialize(string name, string description, Sprite icon)
        {
            _name = name;
            _description = description;
            Icon = icon;
        }

        public string GetFullDescription()
        {
            return $"Name: {_name}\n" +
                   $"Description: {_description}";
        }
    }
}