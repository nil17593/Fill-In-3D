using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Epsilon.FillIn3D
{
    public class ImageCubes : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<FillCubes>() != null)
            {
                Destroy(this.gameObject);
                Destroy(other.gameObject);
            }
        }
    }
}