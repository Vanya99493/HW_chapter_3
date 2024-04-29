using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _2_AssetBundles.Scripts.UIModule
{
    public class SelectLevelPanel : MonoBehaviour
    {
        [SerializeField] private Button _selectLevel1Button;
        [SerializeField] private Button _selectLevel2Button;

        private void Start()
        {
            _selectLevel1Button.onClick.AddListener(OnSelectLevel1);
            _selectLevel2Button.onClick.AddListener(OnSelectLevel2);
        }

        private void OnSelectLevel1()
        {
            SceneManager.LoadScene("Scene1");
        }

        private void OnSelectLevel2()
        {
            SceneManager.LoadScene("Scene2");
        }
    }
}