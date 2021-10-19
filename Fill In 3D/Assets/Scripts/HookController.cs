using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Epsilon.FillIn3D
{
    public class HookController : MonoBehaviour
    {
        private Touch touch;
        private float speed;
        private Rigidbody rb;
        private Vector3 horizontalMove;
        private Ray ray;
        private RaycastHit raycastHit;

        private float deltaX, deltaZ;
        private Vector3 touchPos;


        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            speed = 0.01f;
        }

        private void Update()
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, float.MaxValue, 1 << LayerMask.NameToLayer("Ground")))
            {
                this.transform.position = raycastHit.point;
            }
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        deltaX = touchPos.x - transform.position.x;
                        deltaZ = touchPos.z - transform.position.z;
                        break;

                    case TouchPhase.Moved:
                        rb.MovePosition(new Vector3(touchPos.x - deltaX, touchPos.z - deltaZ));
                        break;

                    case TouchPhase.Ended:
                        rb.velocity = Vector3.zero;
                        break;
                }
                //if (touch.phase == TouchPhase.Moved)
                //{
                //    transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * speed,
                //        transform.position.y, transform.position.z + touch.deltaPosition.y * speed);
                //}
            }
        }
    }
}