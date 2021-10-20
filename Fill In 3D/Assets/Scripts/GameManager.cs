using System.Collections;
using UnityEngine;

namespace Epsilon.FillIn3D
{
    /// <summary>
    /// singleton class that manages all of the UI part
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        public static GameManager Instance { get { return instance; } }

        #region Serialized fields
        [SerializeField] private GameObject levelCompletePanel;
        [SerializeField] private GameObject pausePanel;
        #endregion

        public static bool gameIsPaused;

        private void Awake()
        {
            instance = this;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameIsPaused = !gameIsPaused;
                PauseGame();
            }
        }

        //loads level win panel
        public void LoadLevelWinPanel()
        {
            levelCompletePanel.SetActive(true);
        }

        //pause game
        void PauseGame()
        {
            if (gameIsPaused)
            {
                Time.timeScale = 0f;
                pausePanel.SetActive(true);
            }

            Time.timeScale = Mathf.Approximately(Time.timeScale, 0.0f) ? 1.0f : 0.0f;
        }

    }
}