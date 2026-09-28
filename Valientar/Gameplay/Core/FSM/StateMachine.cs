namespace Valientar.Gameplay.Core.FSM
{
    public sealed class StateMachine<T>
    {
        public IState<T> CurrentState { get; private set; }
        public readonly Blackboard Blackboard;
        private readonly T _owner;


        public StateMachine(T owner, IState<T> startingState)
        {
            if (startingState == null)
                return;

            Blackboard = new();
            CurrentState = null;
            _owner = owner;

            SetState(startingState);
        }


        public void TransitionTo(IState<T> newState)
        {
            if (newState == null || CurrentState == newState)
                return;

            CurrentState?.OnExit();
            SetState(newState);
        }

        private void SetState(IState<T> state)
        {
            state.Init(_owner, this);
            CurrentState = state;
            CurrentState.OnEnter();
        }

        public void OnTick() => CurrentState?.OnTick();
    }
}