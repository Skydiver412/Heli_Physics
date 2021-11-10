using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    [RequireComponent(typeof(IP_Input_Controller))]
    
    public class IP_Heli_Controller : IP_BaseRB_Controller
    {

        #region Variables
        [Header("Heli Properties")]
        public List<IP_Heli_Engine> engines = new List<IP_Heli_Engine>();

        [Header("Heli Rotors")]
        public IP_Heli_Rotor_Controller rototCtrl;

        private IP_Input_Controller input;
        #endregion

        #region
        protected override void HandlePhysics()
        {
            input = GetComponent<IP_Input_Controller>();
            if (input)
            {
                HandleEngines();
                HandleRotors();
                HandleCharacteristics();
            }
        }

        #endregion

        #region Helicopter Controls Methods

        protected virtual void HandleEngines()
        {
            for(int i = 0; i < engines.Count; i++)
            {
                engines[i].UpdateEngine(input.StickyThrottle);
                float finalPower = engines[i].CurrentHP;
                //Debug.Log(finalPower);
            }
        }

        protected virtual void HandleRotors()
        {
            if(rototCtrl && engines.Count > 0)
            {
                rototCtrl.UpdateRotors(input, engines[0].CurrentRPM);
            }
        }


        protected virtual void HandleCharacteristics()
        {

        }
        #endregion
    }
}