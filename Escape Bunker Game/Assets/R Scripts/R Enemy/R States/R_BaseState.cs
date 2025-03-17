public abstract class R_BaseState
{
    public R_Enemy enemy;
    public R_StateMachine stateMachine;

    public abstract void Enter();
    public abstract void Perform();
    public abstract void Exit();

}
