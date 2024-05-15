using UnityEngine;

public class Entity : MonoBehaviour
{
    public Animator AnimatorCompo;
    public Health HealthCompo;
    public Rigidbody RigodbpdyComp;

    [Header("Collision info")]
    protected Transform _groundChecker;
    protected Transform _wallChecker;
    protected float _groundCheckDistance;
    protected float _wallCheckDistance;
    protected LayerMask _whatIsEnemy;
    protected LayerMask _whatIsGround;
    protected LayerMask _whatIsWall;


    protected virtual void Awake()
    {
        Transform visualTrm = transform.Find("Visual");
        AnimatorCompo = visualTrm.GetComponent<Animator>();
        HealthCompo = gameObject.GetComponent<Health>();
        RigodbpdyComp = gameObject.GetComponent<Rigidbody>();
    }
    public virtual bool IsGroundDetected()
    {
        return Physics.Raycast(_groundChecker.position, Vector2.down, _groundCheckDistance, _whatIsGround);
    }

    public virtual bool IsRightWallDetected()
    {
        return Physics.Raycast(_wallChecker.position, _wallChecker.right, _wallCheckDistance, _whatIsWall);
    }

    public virtual bool IsLeftWallDetected()
    {
        return Physics.Raycast(_wallChecker.position, -_wallChecker.right, _wallCheckDistance, _whatIsWall);
    }

}
