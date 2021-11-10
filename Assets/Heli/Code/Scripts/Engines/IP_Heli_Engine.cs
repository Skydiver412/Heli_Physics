using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace IndiePixel
{
    public class IP_Heli_Engine : MonoBehaviour
    {
        #region Variables
        public float maxHP = 140f;
        public float maxRPM = 2700f;
        public float powerDelay = 2f;
        public AnimationCurve powerCurve = new AnimationCurve(new Keyframe(0f,0f), new Keyframe(1f,1f));
        #endregion

        #region Properties
        private float currentHP;
        public float CurrentHP
        {
            get { return currentHP; }
        }

        private float currentRPM;
        public float CurrentRPM
        {
            get { return currentRPM; }
        }
        #endregion

        #region Built-in
        // Start is called before the first frame update
        void Start()
        {

        }

        #endregion

        #region Custom
        public void UpdateEngine(float throttleInput)
        {
            // Calculate HP
            float wantedHP = powerCurve.Evaluate(throttleInput) * maxHP;
            currentHP = Mathf.Lerp(currentHP, wantedHP, Time.deltaTime * powerDelay);

            // Calculate RPMs
            float wanteRPM = throttleInput * maxRPM;
            currentRPM = Mathf.Lerp(currentRPM, wanteRPM, Time.deltaTime * powerDelay);

        }
        #endregion

    }
}