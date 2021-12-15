using UnityEngine;

namespace WW.Patterns.Examples
{
    public class BikeRailMoveState : BaseBikeState
    {
        private Vector3 railMoveDirection;        

        public override void SetState(StateControllerBase newController)
        {
            base.SetState(newController);            

            railMoveDirection.x = (float)controller.CurrentRailMoveDirection;
            if (controller.CurrentSpeed > 0)
            {                
                transform.Translate(railMoveDirection * controller.railDistance);
            }
        }
    }
}
