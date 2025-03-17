using UnityEngine;
namespace BIS.Animators
{
    [CreateAssetMenu(fileName = "AnimParamSO", menuName = "SO/BIS/Anim/ParamSO")]
    public class AnimParamSO : ScriptableObject
    {
        [SerializeField] private string _paramName; public string ParamName { get { return _paramName; } }
        [SerializeField] private int _hashValue; public int HashValue { get { return _hashValue; } }

        private void OnValidate()
        {
            _hashValue = Animator.StringToHash(_paramName);
        }
    }

}
