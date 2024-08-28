
using UnityEngine;

public abstract class PlayerBase : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] protected Animator animator;
    [Header("Movement")]
    [SerializeField] protected Vector3 direction;
    [SerializeField] protected bool isActive;
    [Header("Facing")]
    [SerializeField] protected bool isFacingRight = true;
    [SerializeField] protected Transform NeedToFlip;
    [SerializeField] protected float flipSpeed = 0.5f;
    private Quaternion targetRotation;
    protected void Update() {
        
    }
    public virtual void Movement(){
        Flip();
    }
    public virtual void Activate(bool isActive){
        direction = Vector3.zero;
        this.isActive = isActive;
    }
    public virtual void Flip(){
        if (direction.x < 0 && isFacingRight)
        {
            targetRotation = Quaternion.Euler(0, 180, 0);
            isFacingRight = false;
        }
        else if (direction.x > 0 && !isFacingRight)
        {
            targetRotation = Quaternion.Euler(0, 0, 0);
            isFacingRight = true;
        }
        NeedToFlip.transform.rotation = Quaternion.Slerp(NeedToFlip.transform.rotation, targetRotation, Time.deltaTime * flipSpeed);
    }
}
