using BIS.Animators;
using BIS.Entities;
using BIS.Init;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityState : InitBase
{
    protected Entity _entity;

    protected AnimParamSO _stateAnimParam;
    protected bool _isTrigger;

    protected EntityRenderer _renderer;
    protected EntityAnimatorTrigger _animTrigger;

}
