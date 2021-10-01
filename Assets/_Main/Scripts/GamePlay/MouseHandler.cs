using System;
using UnityEngine;

namespace _Main.Scripts.GamePlay
{
    public class MouseHandler : MonoBehaviour
    {
        public float turnSpeed = 4.0f;
        public float moveSpeed = 2.0f;

        public float minTurnAngle = -90.0f;
        public float maxTurnAngle = 90.0f;
        private float rotX;

        private Transform _cameraTransform;
        private Transform _rickTransform;

        private void Awake()
        {
            _rickTransform = transform;
            _cameraTransform = _rickTransform.GetChild(0);
        }

        private void Update()
        {
            MouseAiming();
        }

        void MouseAiming()
        {
            // get the mouse inputs
            float y = Input.GetAxis("Mouse X") * turnSpeed;
            rotX += Input.GetAxis("Mouse Y") * turnSpeed;

            // clamp the vertical rotation
            rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);

            // rotate the camera
            _cameraTransform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
            
            //rotate rick
            _rickTransform.eulerAngles = Vector3.up * (_rickTransform.eulerAngles.y + y);
        }
    }
    
    
}