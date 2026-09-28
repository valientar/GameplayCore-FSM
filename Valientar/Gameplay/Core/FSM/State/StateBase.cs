namespace Valientar.Gameplay.Core.FSM
{
    public abstract class StateBase<T> : IState<T>
    {
        protected T Owner { get; private set; }
        protected StateMachine<T> FSM { get; private set; }


        void IState<T>.Init(T owner, StateMachine<T> fsm)
        {
            Owner = owner;
            FSM = fsm;
        }

        public abstract void OnEnter();
        public abstract void OnExit();
        public abstract void OnTick();
    }
}