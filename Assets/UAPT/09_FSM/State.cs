using UnityEngine;

public class State
{
    protected int _animationHash;
    protected Entity _owner;
    protected StateMachine _stateMachine;
    protected bool _triggerCall;
    public State(Entity owner, StateMachine stateMachine, string animationBoolName)
    {
        _owner = owner;
        _stateMachine = stateMachine;
        _animationHash = Animator.StringToHash(animationBoolName);
    }

    public virtual void Enter()
    {
        _owner.AnimatorCompo.SetBool(_animationHash, true);
        _triggerCall = false;
    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {
        _owner.AnimatorCompo.SetBool(_animationHash, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        _triggerCall = true;
    }
}
