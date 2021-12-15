using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW.Patterns.Examples
{
    public class TestStates : MonoBehaviour
    {
        private BikeController bikeController;

        // Start is called before the first frame update
        void Start()
        {
            bikeController = FindObjectOfType<BikeController>();
            if (bikeController == null)
                Debug.LogError("No Bike Controller in scene");
        }

        private void OnGUI()
        {
            GUI.skin.button.fontSize = 32;

            if (GUILayout.Button("Start Bike", GUILayout.Width(250), GUILayout.Height(100)))
                bikeController.StartBike();
            if (GUILayout.Button("Shift Left", GUILayout.Width(250), GUILayout.Height(100)))
                bikeController.Turn(Direction.Left);
            if (GUILayout.Button("Shift Right", GUILayout.Width(250), GUILayout.Height(100)))
                bikeController.Turn(Direction.Right);
            if (GUILayout.Button("Stop Bike", GUILayout.Width(250), GUILayout.Height(100)))
                bikeController.StopBike();
        }
    }
}