namespace WW.Patterns
{
    public class StateContextBase
    {
        public IState CurrentState { get; set; }

        private readonly StateControllerBase controller;

        public StateContextBase(StateControllerBase controller)
        {
            this.controller = controller;
        }

        public void Transition()
        {
            CurrentState.SetState(controller);
        }

        public void Transition(IState state)
        {
            CurrentState = state;
            CurrentState.SetState(controller);
        }
    }
}