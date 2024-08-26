using UnityEngine;
public class SingletonMonoBehaviour<T> : MonoBehaviour where T: SingletonMonoBehaviour<T>
{
    public static T instance { get; protected set; }
 
    protected void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log(this.gameObject.name + " Destroyed");
            Destroy(this.gameObject);
            // throw new System.Exception("An instance of this singleton already exists.");
        }
        else
        {
            Debug.Log(this.gameObject.name + "Instanced");
            instance = (T)this;
        }
    }

}