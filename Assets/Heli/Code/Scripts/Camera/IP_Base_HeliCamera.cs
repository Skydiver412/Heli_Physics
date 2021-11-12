using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IndiePixel
{
    public class IP_Base_HeliCamera : MonoBehaviour
    {
        #region
        [Header("Base Camera Properties")]
        public Rigidbody rb;
        public Transform lookAtTarget;

        protected Vector3 wantedPos;
        protected Vector3 refVelocity;
        protected UnityEvent updateEvent = new UnityEvent();
        protected Vector3 targetFlatFwd;
        #endregion

        #region
        // Start is called before the first frame update
        void Start()
        {

        }

        void FixedUpdate()
        {
            if (rb)
            {
                Vector3 targetFlatFwd = rb.transform.forward;
                targetFlatFwd.y = 0f;
                targetFlatFwd = targetFlatFwd.normalized;

                updateEvent.Invoke();
            }
        }
        #endregion

        #region
        #endregion

    }
}