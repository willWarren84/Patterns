using System.Linq;
using UnityEngine;

namespace WW.Patterns.Examples
{
    public class BikeController : StateControllerBase
    {
        public float maxSpeed = 2.0f;
        public float railDistance = 2.0f;
        public float CurrentSpeed { get; set; }
        public Direction CurrentRailMoveDirection { get; private set; }
        
        private IState startState, stopState, turnState;

        public void StartBike()
        {
            stateContext.Transition(startState);
        }

        public void StopBike()
        {
            stateContext.Transition(stopState);
        }

        public void Turn(Direction direction)
        {
            CurrentRailMoveDirection = direction;
            stateContext.Transition(turnState);
            StartBike();
        }

        protected override void SetStates()
        {
            startState = gameObject.AddComponent<BikeStartState>();
            stopState = gameObject.AddComponent<BikeStopState>();
            turnState = gameObject.AddComponent<BikeRailMoveState>();

            stateContext.Transition(stopState);
        }       
    }

    public enum Direction
    {
        Left = -1,
        Right = 1
    }
}
