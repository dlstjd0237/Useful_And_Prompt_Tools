using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State _currentState;
    public State CurrentState => _currentState;
    private Entity _owner;

    void Start()
    {
        _owner = GetComponent<Entity>();
        _currentState = new PlayerIdleState(_owner, this, "Idle");
        _currentState.Enter();
    }

    void Update()
    {
        _currentState.Update();
    }

    public void ChangeState(State newState)
    {
        _currentState.Exit();

        _currentState = newState;
        _currentState.Enter();
    }
}
