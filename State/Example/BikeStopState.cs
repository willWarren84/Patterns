namespace WW.Patterns.Examples
{
    public class BikeStopState : BaseBikeState
    {        
        public override void SetState(StateControllerBase newController)
        {
            base.SetState(newController);

            controller.CurrentSpeed = 0;
        }        
    }
}