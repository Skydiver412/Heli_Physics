using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace IndiePixel
{
    [CustomEditor(typeof(IP_Advanced_HeliCamera))]
    public class IP_AdvancedCamera_Editor : Editor
    {
        #region Variables
        IP_Advanced_HeliCamera targetCamera;
        #endregion

        #region
        private void OnEnable()
        {
            targetCamera = (IP_Advanced_HeliCamera)target;
        }

        private void OnSceneGUI()
        {
            float minDist = targetCamera.minDistance;
            float maxDist = targetCamera.maxDistance;
            Vector3 targetFwd = targetCamera.rb.transform.forward;

            Handles.color = Color.blue;
            Handles.DrawWireDisc(targetCamera.rb.position, Vector3.up, minDist);
            Handles.DrawWireDisc(targetCamera.rb.position, Vector3.up, maxDist);

            targetCamera.minDistance = Handles.ScaleSlider(targetCamera.minDistance,
                targetCamera.rb.position + (targetFwd * minDist), Vector3.forward, Quaternion.identity, 2f, 2f);
            targetCamera.maxDistance = Handles.ScaleSlider(targetCamera.maxDistance,
                targetCamera.rb.position + (targetFwd * maxDist), Vector3.forward, Quaternion.identity, 2f, 2f);

        }
        #endregion
    }
}