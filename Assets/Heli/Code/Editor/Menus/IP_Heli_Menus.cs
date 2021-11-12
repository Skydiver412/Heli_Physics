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
            GameObject engineGRP = new GameObject("Engine_GRP");
            SetupEngineGRP(engineGRP, curController);
            GameObject rotorGRP = new GameObject("Rotor_GRP");
            SetupRotorGRP(rotorGRP, curController);

            audioGRP.transform.SetParent(curHeli.transform);
            graphicsGRP.transform.SetParent(curHeli.transform);
            colGRP.transform.SetParent(curHeli.transform);
            engineGRP.transform.SetParent(curHeli.transform);
            rotorGRP.transform.SetParent(curHeli.transform);


            Selection.activeGameObject = curHeli;
        }

        static void SetupRotorGRP(GameObject rotorgo, IP_Heli_Controller controller)
        {
            IP_Heli_Rotor_Controller rotorController = rotorgo.AddComponent<IP_Heli_Rotor_Controller>();
            controller.rototCtrl = rotorController;

            GameObject mainGRP = new GameObject("Main_Rotor");
            mainGRP.AddComponent<IP_HeliMain_Rotor>();
            GameObject tailGRP = new GameObject("Tail_Rotor");
            tailGRP.AddComponent<IP_HeliTail_Rotor>();

            mainGRP.transform.SetParent(rotorgo.transform);
            tailGRP.transform.SetParent(rotorgo.transform);            
        }

        static void SetupEngineGRP(GameObject enginego, IP_Heli_Controller controller)
        {
            GameObject engineGRP = new GameObject("Main_Engine");
            IP_Heli_Engine engine = engineGRP.AddComponent<IP_Heli_Engine>();
            controller.engines.Add(engine);

            engineGRP.transform.SetParent(enginego.transform);
        }
    }
}