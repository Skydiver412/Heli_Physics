using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace IndiePixel
{
    public class IP_Basic_HeliCamera : IP_Base_HeliCamera, IP_IHeli_Camera
    {

        #region
        [Header("Basic Camera Properties")]
        public float height = 2f;
        public float distance = 2f;
        public float smoothSpeed = 0.35f;
        #endregion

        #region
        private void Start()
        {
            updateEvent.AddListener(UpdateCamera);
        }

        private void OnDisable()
        {
            updateEvent.RemoveListener(UpdateCamera);
        }
        #endregion


        #region Interface Methods
        public void UpdateCamera()
        {
            // Wanted position
            wantedPos = rb.position + (targetFlatFwd * distance) + (Vector3.up * height);

            // Position the camera
            transform.position = Vector3.SmoothDamp(transform.position, wantedPos, ref refVelocity, smoothSpeed);
            transform.LookAt(lookAtTarget);
        }
        #endregion

    }
}