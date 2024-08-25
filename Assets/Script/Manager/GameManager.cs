using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
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
    void Start()
    {
        mainCamera = FindAnyObjectByType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            changeState();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SceneManager.LoadScene("SceneMenu");
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
