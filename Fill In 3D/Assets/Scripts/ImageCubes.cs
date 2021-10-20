using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Epsilon.FillIn3D
{
    /// <summary>
    /// this class handles the logic of cubes that 
    /// coverd on image after collision the cubes will 
    /// get destroyed and we can see the image behind of it
    /// </summary>
    public class ImageCubes : MonoBehaviour
    {
        #region Serialized Fields
        [SerializeField ]  int numberOfCubes;
        #endregion

        private void Start()
        {
            numberOfCubes = transform.childCount;
        }

        private void Update()
        {
            numberOfCubes = transform.childCount;
            if (numberOfCubes == 0)
            {
                GameManager.Instance.LoadLevelWinPanel();
            }
        }

    }
}