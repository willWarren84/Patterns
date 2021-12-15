using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW.Patterns.Examples
{
    public class CommandExample : MonoBehaviour
    {
        public TimeBasedReplayCommandManager commandManager;

        void Update()
        {
            HandleClick();
        }

        void HandleClick()
        {
            if (!Input.GetKeyDown(KeyCode.Mouse0)) return;

            var origin = Camera.main.ScreenPointToRay(Input.mousePosition);     
            
            if (!Physics.Raycast(origin, out var hit)) return;

            if (!(hit.collider.name.Contains("Cube"))) return;

            var click = new CubeClickedCommand(hit.collider.gameObject, new Color(Random.value, Random.value, Random.value));
            
            commandManager.ExecuteCommand(click);
        }        

        private void OnGUI()
        {
            GUI.skin.button.fontSize = 32;

            if (GUILayout.Button(commandManager.isRecording ? "Stop Recording" : "Start Recording", GUILayout.Width(250), GUILayout.Height(100)))
            {
                if (commandManager.isRecording)
                    commandManager.StopRecording();
                else
                    commandManager.StartRecording();
            }
            
            if (commandManager.isRecording) return;
            

            if (GUILayout.Button(commandManager.isReplaying ? "Stop Replay" : "Start Replay", GUILayout.Width(250), GUILayout.Height(100)))
            {
                if (commandManager.isReplaying)
                    commandManager.StopReplaying();
                else
                    commandManager.StartReplaying();
            }            
        }
    }
}