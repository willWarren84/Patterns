using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WW.Patterns.Examples
{
    public class CubeClickedCommand : ICommand
    {
        private GameObject cube;
        private Color colour;
        public Color previousColour;

        public CubeClickedCommand(GameObject cube, Color colour)
        {
            this.cube = cube;
            this.colour = colour;
        }

        public void Execute()
        {            
            this.previousColour = cube.GetComponent<MeshRenderer>().material.color;
            cube.GetComponent<MeshRenderer>().material.color = colour;
        }

        public void Undo()
        {            
            cube.GetComponent<MeshRenderer>().material.color = previousColour;
        }
    }
}