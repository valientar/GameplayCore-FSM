namespace Valientar.Gameplay.Core.FSM
{
    public interface IState<T>
    {
        public void Init(T owner, StateMachine<T> fsm);
        public void OnEnter();
        public void OnExit();
        public void OnTick();
    }
}
