using UnityEngine;

public class Entity : MonoBehaviour
{
    public Animator AnimatorCompo;
    protected LayerMask _whatIsEnemy;

    protected virtual void Awake()
    {
        Transform visualTrm = transform.Find("Visual");
        AnimatorCompo = visualTrm.GetComponent<Animator>();
    }
}
