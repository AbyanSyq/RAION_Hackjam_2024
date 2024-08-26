using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : SingletonMonoBehaviour<LevelManager>
{
    public List<MultiDimentionBase> multiDimentionBases = new List<MultiDimentionBase>();
    public void AddMultiDimentionObject(MultiDimentionBase multiDimentionBase){
        multiDimentionBases.Add(multiDimentionBase);
    }

    public Player3D player3D;
    public Player2D player2D; 
    public Camera mainCamera;
    
    public bool is2D;
    // Start is called before the first frame update
    private void Start() {
        mainCamera = FindAnyObjectByType<Camera>();
        player2D = FindAnyObjectByType<Player2D>();
        player3D = FindAnyObjectByType<Player3D>();

        StartCoroutine(To2D());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            changeState();
        }
    }
    public void changeState(){
        if (is2D)
        {
            StartCoroutine(To3D());
        }else{
            StartCoroutine(To2D());
        }
    }
    public IEnumerator To2D(){
        player3D.Activate(false);
        foreach (MultiDimentionBase multiDimention in multiDimentionBases)
        {
            multiDimention.To2D();
        }
        yield return null;
        player2D.Activate(true);
        is2D = true;
    }
    public IEnumerator To3D(){
        player2D.Activate(false);
        foreach (MultiDimentionBase multiDimention in multiDimentionBases)
        {
            multiDimention.To3D();
        }
        yield return null;
        player3D.Activate(true);
        is2D = false;
    }
}
