using BIS.Entities;
using BIS.Init;
using System;
using UnityEngine;

namespace BIS.Animators
{
    public class EntityAnimatorTrigger : MonoBehaviour, IEntityComponentInit
    {
        public event Action OnAnimationEnd;
        public event Action OnAttackTrigger;

        protected Entity _entity;
        public void Initalize(Entity entity)
        {
            _entity = entity;
        }
        protected virtual void AnimationEnd() => OnAnimationEnd?.Invoke();
        protected virtual void AttackTrigger() => OnAttackTrigger?.Invoke();
    }
}


