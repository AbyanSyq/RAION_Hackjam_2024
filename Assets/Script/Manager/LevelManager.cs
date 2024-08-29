using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : SingletonMonoBehaviour<LevelManager>
{
    public List<MultiDimentionBase> multiDimentionBases = new List<MultiDimentionBase>();
    public void AddMultiDimentionObject(MultiDimentionBase multiDimentionBase){
        multiDimentionBases.Add(multiDimentionBase);
    }
    [Header("Reference")]
    public Player3D player3D;
    public Player2D player2D; 
    public Camera mainCamera;
    public SceneData sceneData;
    public float delayChange = 0.8f;
    [Header("Condition")]
    public bool is2D;
    public bool isTransitioning = false;

    private void Start() {
        UIManager.instance.GetUIGamePlay().StopStopwatch();
        UIManager.instance.GetUIGamePlay().ResetStopwatch();

        mainCamera = FindAnyObjectByType<Camera>();
        player2D = FindAnyObjectByType<Player2D>();
        player3D = FindAnyObjectByType<Player3D>();

        StartCoroutine(To2D());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isTransitioning)
        {   
            changeState();
        }
    }

    public void changeState(){
        isTransitioning = true;
        Invoke("DelayChange", delayChange);
        if (is2D)
        {
            StartCoroutine(To3D());
        }else{
            StartCoroutine(To2D());
        }
    }

    public IEnumerator To2D(){
        player3D.Activate(false);
        yield return null;

        foreach (MultiDimentionBase multiDimention in multiDimentionBases)
        {
            multiDimention.To2D();
        }
        yield return null;

        player2D.Activate(true);
        is2D = true;
    }
    public void DelayChange(){
        isTransitioning = false;
    }

    public IEnumerator To3D(){
        player2D.Activate(false);
        yield return null;

        foreach (MultiDimentionBase multiDimention in multiDimentionBases)
        {
            multiDimention.To3D();
        }
        yield return null;

        player3D.Activate(true);
        is2D = false;
    }
}
