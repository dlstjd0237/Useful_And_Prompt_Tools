using UnityEngine;

public abstract class PlayerState 
{
    protected PlayerStateMachine _stateMachine;
    protected Player _player;

    protected int _animBoolHash;
    protected bool _triggerCall;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        _player = player;
        _stateMachine = stateMachine;
        _animBoolHash = Animator.StringToHash(animBoolName);

    }

    //상태를 진입했을 때 실행할 함수
    public virtual void Enter()
    {
        _player.AnimatorCompo.SetBool(_animBoolHash, true);
        _triggerCall = false; //애니메이션이 다 끝났을때 실행될 불리언 값
    }

    //상태를 나갈때 실행할 함수
    public virtual void Exit()
    {
        _player.AnimatorCompo.SetBool(_animBoolHash, false);
    }

    public virtual void UpdateState()
    {

    }

    public virtual void AnimationFinishTrigger()
    {
        _triggerCall = true;
    }
}
