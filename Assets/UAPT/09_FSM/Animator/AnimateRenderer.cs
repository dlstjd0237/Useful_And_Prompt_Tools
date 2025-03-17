using BIS.Init;
using UnityEngine;

namespace BIS.Animators
{
    public class AnimateRenderer : InitBase
    {
        private Animator _animator;

        public override bool Init()
        {
            if (base.Init() == false)
                return false;
            _animator = GetComponent<Animator>();
            return true;
        }

        public void SetParam(AnimParamSO paramSO, bool value) => _animator.SetBool(paramSO.HashValue, value);
        public void SetParam(AnimParamSO paramSO, int value) => _animator.SetInteger(paramSO.HashValue, value);
        public void SetParam(AnimParamSO paramSO, float value) => _animator.SetFloat(paramSO.HashValue, value);
        public void SetParam(AnimParamSO paramSO) => _animator.SetTrigger(paramSO.HashValue);
    }
}