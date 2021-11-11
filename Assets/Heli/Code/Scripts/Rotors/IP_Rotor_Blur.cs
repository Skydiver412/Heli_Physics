using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_Rotor_Blur : MonoBehaviour, IP_IHeliRotor
    {

        #region Variables
        [Header("Rotor Blur Properties")]
        public float maxDps = 1000f;
        public List<GameObject> blades = new List<GameObject>();
        public GameObject blurGeo;

        public List<Texture2D> blurTextures = new List<Texture2D>();
        public Material blurMat;
        #endregion
        
        #region Interface Methods
        public void UpdateRotor(float dps, IP_Input_Controller input)
        {
            //Debug.Log("Blurring main rotor");
            float normalizedDPS = Mathf.InverseLerp(0f, maxDps, dps);
            int blurTexID = Mathf.FloorToInt(normalizedDPS * blurTextures.Count - 1);
            blurTexID = Mathf.Clamp(blurTexID, 0, blurTextures.Count - 1);
            //Debug.Log(blurTexID);

            // check to see if we have blur textures and a blur material
            if (blurMat && blurTextures.Count > 0)
            {
                blurMat.SetTexture("_MainTex", blurTextures[blurTexID]);
            }

            if(blurTexID > 2 && blades.Count > 0)
            {
                HandleGeoBladeViz(false);
            }
            else
            {
                HandleGeoBladeViz(true);
            }
        }
        #endregion

        void HandleGeoBladeViz(bool viz)
        {
            foreach (var blade in blades)
            {
                blade.SetActive(viz);
            }
        }

    }
}