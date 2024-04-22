using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStateEnum
{
    Idle,
    Move
}

public class PlayerStateMachine
{
    public PlayerState CurrentState { get; private set; }
    public Dictionary<PlayerStateEnum, PlayerState> stateDictionary;

    private Player _player;

    public PlayerStateMachine()
    {
        stateDictionary = new Dictionary<PlayerStateEnum, PlayerState>();
    }

    public void Initialize(PlayerStateEnum startState, Player player)
    {
        _player = player;
        CurrentState = stateDictionary[startState];
        CurrentState.Enter();
    }

    public void ChangeState(PlayerStateEnum newState)
    {
        CurrentState.Exit();
        CurrentState = stateDictionary[newState];
        CurrentState.Enter();
    }

    public void AddState(PlayerStateEnum stateEnum, PlayerState state)
    {
        stateDictionary.Add(stateEnum, state);
    }
}
