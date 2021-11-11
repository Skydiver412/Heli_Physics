using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace IndiePixel
{
    public class IP_Heli_Rotor_Controller : MonoBehaviour
    {
        #region
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
