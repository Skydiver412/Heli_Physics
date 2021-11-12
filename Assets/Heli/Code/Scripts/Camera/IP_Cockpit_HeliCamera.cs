using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_Cockpit_HeliCamera : IP_Base_HeliCamera, IP_IHeli_Camera
    {

        #region
        [Header("Cockpit Camera Properties")]
        public Transform cockpitPosition;
        public Vector3 offset = Vector3.zero;
        public float fov = 70f;
        #endregion

        #region
        private void OnEnable()
        {
            updateEvent.AddListener(UpdateCamera);
        }

        private void OnDisable()
        {
            updateEvent.RemoveListener(UpdateCamera);
        }
        #endregion

        #region
        public void UpdateCamera()
        {
            if (cockpitPosition)
            {
                transform.position = cockpitPosition.position;
                transform.LookAt(lookAtTarget);
            }
            
        }
        #endregion
    }
}