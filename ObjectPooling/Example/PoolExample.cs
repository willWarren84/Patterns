using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW.Patterns.Examples
{
    public class PoolExample : MonoBehaviour
    {
        public ColouredCubePool pool;

        private void OnGUI()
        {
            GUI.skin.button.fontSize = 32;

            if (GUILayout.Button("Add", GUILayout.Width(250), GUILayout.Height(100)))
                pool.Pool.Get();
        }

        void Update()
        {
            HandleClick();
        }

        void HandleClick()
        {
            if (!Input.GetKeyDown(KeyCode.Mouse0)) return;

            var origin = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(origin, out var hit)) return;

            var cube = hit.collider.gameObject.GetComponent<PoolableColouredCube>();
            pool.Pool.Release(cube);
        }
    }
}