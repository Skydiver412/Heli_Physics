using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_HeliTail_Rotor : MonoBehaviour, IP_IHeliRotor
    {

        #region Variables
        [Header("Tail Rotor Properties")]
        public float rotationSpeedModifier = 1.5f;
        public Transform lRotor;
        public Transform rRotor;
        public float maxPitch = 45f;
        #endregion

        #region

        // Start is called before the first frame update
        void Start()
        {

        }
        #endregion

        #region Interface Methods
        public void UpdateRotor(float dps, IP_Input_Controller input)
        {
            transform.Rotate(Vector3.right, dps * rotationSpeedModifier);

            // Pitch the blades up and down
            if (lRotor && rRotor)
            {
                lRotor.localRotation = Quaternion.Euler(0f, input.PedalInput * maxPitch,  0f);
                rRotor.localRotation = Quaternion.Euler(0f, -input.PedalInput * maxPitch,  0f);
            }
        }
        #endregion

    }
}