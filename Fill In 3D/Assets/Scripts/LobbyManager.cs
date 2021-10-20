using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Epsilon.FillIn3D
{
    public class LobbyManager : MonoBehaviour
    {
        #region Serialized fields
        [SerializeField] private Button playButton;
        [SerializeField] private string gameScene;
        #endregion

        void Start()
        {
            playButton.onClick.AddListener(LoadGameScene);
        }

        //loads game scene on button click
        private void LoadGameScene()
        {
            SceneManager.LoadScene(gameScene);
        }
    
    }
}