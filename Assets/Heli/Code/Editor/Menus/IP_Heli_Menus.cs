using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace IndiePixel
{
    public class IP_Heli_Menus
    {
        [MenuItem("Vehicles/Setup New Helicopter")]
        public static void BuildNewHelicopter()
        {
            // Create a new Helicopter setup
            GameObject curHeli = new GameObject("New_Heli", typeof(IP_Heli_Controller));

            // Create COG object for new Heli
            GameObject curCOG = new GameObject("COG");
            curCOG.transform.SetParent(curHeli.transform);

            // Assign the COG to the curHeli
            IP_Heli_Controller curController = curHeli.GetComponent<IP_Heli_Controller>();
            curController.cog = curCOG.transform;

            // Create Groups
            GameObject audioGRP = new GameObject("Audio_GRP");
            GameObject graphicsGRP = new GameObject("Graphics_GRP");
            GameObject colGRP = new GameObject("Collider_GRP");

            audioGRP.transform.SetParent(curHeli.transform);
            graphicsGRP.transform.SetParent(curHeli.transform);
            colGRP.transform.SetParent(curHeli.transform);


            Selection.activeGameObject = curHeli;
        }
    }
}