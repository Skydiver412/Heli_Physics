using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_HeliMain_Rotor : MonoBehaviour, IP_IHeliRotor
    {

        #region
        [Header("Main Rotor Properties")]
        public Transform lRotor;
        public Transform rRotor;
        public float maxPitch = 35f;
        #endregion

        #region
        #endregion
        // Start is called before the first frame update
        void Start()
        {

        }

        #region Interface Methods
        public void UpdateRotor(float dps, IP_Input_Controller input)
        {
            //Debug.Log("Updating Main Rotor");
            transform.Rotate(Vector3.up, dps);

            // Pitch the blades up and down
            if(lRotor && rRotor)
            {
                lRotor.localRotation = Quaternion.Euler(input.CollectiveInput * maxPitch, 0f, 0f);
                rRotor.localRotation = Quaternion.Euler(-input.CollectiveInput * maxPitch, 0f, 0f);
            }
        }
        #endregion

    }
}
