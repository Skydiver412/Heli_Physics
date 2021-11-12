using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace IndiePixel
{
    public class IP_Heli_Camera_Controller : MonoBehaviour
    {
        #region Variables
        [Header("Manager Properties")]
        public int startIndex = 1;

        private List<IP_Base_HeliCamera> cameras = new List<IP_Base_HeliCamera>();
        private int camIndex = 0; 
        #endregion

        #region Built-in Methods
        // Start is called before the first frame update
        void Start()
        {
            cameras = transform.GetComponentsInChildren<IP_Base_HeliCamera>().ToList<IP_Base_HeliCamera>();
            camIndex = startIndex;
            SwitchCamera(camIndex);
        }

        #endregion

        #region Custom
        public void SwitchCamera()
        {
            //Debug.Log("Switching Cameras");
            camIndex++;
            HandleSwitch();
        }

        public void SwitchCamera(int index)
        {
            HandleSwitch();
        }

        private void HandleSwitch()
        {
            if (camIndex == cameras.Count)
            {
                camIndex = 0;
            }

            for (int i = 0; i < cameras.Count; i++)
            {
                //cameras[i].gameObject.SetActive(false);
                Camera curCam = cameras[i].GetComponent<Camera>();
                if (curCam)
                {
                    curCam.enabled = false;
                    if (i == camIndex)
                    {
                        //cameras[camIndex].gameObject.SetActive(true);
                        curCam.enabled = true;
                    }
                }
            }
        }
        #endregion

    }
}