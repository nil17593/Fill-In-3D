using System.Collections;
using UnityEngine;

namespace Epsilon.FillIn3D
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        public static GameManager Instance { get { return instance; } }

        [SerializeField] private GameObject levelCompletePanel;

        private void Awake()
        {
            instance = this;
        }
        public void LoadLevelWinPanel()
        {
            levelCompletePanel.SetActive(true);
        }
        
    }
}