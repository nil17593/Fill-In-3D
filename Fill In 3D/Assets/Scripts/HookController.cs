using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Epsilon.FillIn3D
{
    public class HookController : MonoBehaviour
    {
        #region private variables
        private float deltaX, deltaZ;
        private float l, r;
        #endregion

        #region vectors
        private Vector3 touchPos;
        private Vector3 eulerAngleVelocity;
        #endregion

        #region Components
        private Rigidbody rgbd;
        private Touch touch;
        private Ray ray;
        private RaycastHit raycastHit;
        #endregion

        #region Serialized Fields
        [SerializeField] private float speed;
        [SerializeField] private float rotateSpeed;
        #endregion

        private void Start()
        {
            rgbd = GetComponent<Rigidbody>();
            speed = 0.01f;
        }



        private void Update()
        {
            l = Input.GetAxisRaw("Horizontal");
            r = Input.GetAxisRaw("Vertical");
            Vector3 move = transform.position;
            move += transform.forward * r * speed * Time.deltaTime;
            rgbd.MovePosition(move);
        }


        private void FixedUpdate()
        {
            //Movement();
            //Rotation();
            TouchMovement();
            MouseMovement();
        }

        // horizontal movement
        private void Movement()
        {
            Vector3 input = new Vector3(l, 0, r);
            rgbd.MovePosition(transform.position + input * speed * Time.deltaTime);
        }

        //rotation of hook
        private void Rotation()
        {
            eulerAngleVelocity = new Vector3(0, rotateSpeed * l, 0);
            Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.fixedDeltaTime);
            rgbd.MoveRotation(rgbd.rotation * deltaRotation);
        }

        //touch movements
        private void TouchMovement()
        {
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
                        rgbd.MovePosition(new Vector3(touchPos.x - deltaX, touchPos.z - deltaZ));
                        break;

                    case TouchPhase.Ended:
                        rgbd.velocity = Vector3.zero;
                        break;
                }
            }
        }

        //mouse movement
        private void MouseMovement()
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, float.MaxValue, 1 << LayerMask.NameToLayer("Ground")))
            {
                this.transform.position = raycastHit.point;
            }
        }
    }
}
