using UnityEngine;

public abstract class MultiDimentionBase : MonoBehaviour
{
    protected void Start() {
        LevelManager.instance.AddMultiDimentionObject(this);
    }
    public virtual void To2D(){

    }
    public virtual void To3D(){

    }
}
