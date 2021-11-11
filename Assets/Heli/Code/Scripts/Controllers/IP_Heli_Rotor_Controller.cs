using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace IndiePixel
{
    public class IP_Heli_Rotor_Controller : MonoBehaviour
    {
        #region
        public float maxDps = 3000f;
        private List<IP_IHeliRotor> rotors;
        #endregion


        #region
        private void Start()
        {
            rotors = GetComponentsInChildren<IP_IHeliRotor>().ToList<IP_IHeliRotor>();
        }
        #endregion

        #region Custom

        public void UpdateRotors(IP_Input_Controller input, float currentRPMs)
        {
            //Debug.Log("Updating Rotor Controller");
            // Degrees per sec calculation
            float dps = ((currentRPMs * 360f) / 60f);
            dps = Mathf.Clamp(dps, 0f, maxDps);

            // Update our rotors
            if(rotors.Count > 0)
            {
                foreach (var rotor in rotors)
                {
                    rotor.UpdateRotor(dps, input);
                }
            }
        }
        #endregion


        
    }
}
