using UnityEngine;

namespace WW.Patterns.Examples
{
    public class BikeStartState : BaseBikeState
    {
        public override void SetState(StateControllerBase newController)
        {
            base.SetState(newController);

            controller.CurrentSpeed = controller.maxSpeed;
        }

        private void Update()
        {
            if (!controller) return;

            if(controller.CurrentSpeed > 0)
            {                
                controller.transform.Translate(Vector3.forward * (controller.CurrentSpeed * Time.deltaTime));                 
            }
        }
    }
}