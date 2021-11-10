using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace IndiePixel
{
    public class IP_XBoxHeli_Input : IP_KeyboardHeli_Input
    {

        #region

        #endregion

        #region Custom Methods
        protected override void HandleThrottle()
        {
            rawThrottleInput = Input.GetAxis("XboxThrottleUp") + -Input.GetAxis("XboxThrottleDown"); 
        }

        protected override void HandleCollective()
        {
            collectiveInput = Input.GetAxis("XboxCollective");
        }

        protected override void HandleCyclic()
        {
            cyclicInput.y = Input.GetAxis("XboxCyclicVertical");
            cyclicInput.x = Input.GetAxis("XboxCyclicHorizontal");
        }

        protected override void HandlePedal()
        {
            pedalInput = Input.GetAxis("XboxPedal");
        }
        #endregion
    }
}

