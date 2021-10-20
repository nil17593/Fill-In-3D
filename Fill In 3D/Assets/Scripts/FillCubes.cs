using System.Collections;
using UnityEngine;

namespace Epsilon.FillIn3D
{
    /// <summary>
    /// cubes fill image after colliding with the 
    /// 
    /// </summary>
    public class FillCubes : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag ("ImageCubes"))
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}