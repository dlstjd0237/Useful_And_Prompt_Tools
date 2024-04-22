using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStateMachine))]
public class Player : Entity
{
    public PlayerStateMachine StateMachine { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        StateMachine = new PlayerStateMachine();

        foreach (PlayerStateEnum stateEnum in Enum.GetValues(typeof(PlayerStateEnum)))
        {
            string typeName = stateEnum.ToString();
            try
            {
                Type t = Type.GetType($"Player{typeName}State");
                PlayerState state = Activator.CreateInstance(t, this, StateMachine, typeName) as PlayerState;

                StateMachine.AddState(stateEnum, state);
            }
            catch (Exception ex)
            {
                Debug.LogError($"{typeName} is loading error!");
                Debug.LogError(ex);
            }
        }
    }
    private void Start()
    {
        StateMachine.Initialize(PlayerStateEnum.Idle, this);
    }
}
