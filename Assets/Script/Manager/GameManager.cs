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
        // Debug.Log("change to 2d");
        player3D.Activate(false);
        foreach (MultiDimentionBase multiDimention in multiDimentionBases)
        {
            multiDimention.To2D();
        }

        // ObstacleKinematic(true);


        yield return null;
        player2D.Activate(true);
        is2D = true;
        // Debug.Log("changed to 2d");
    }
    public IEnumerator To3D(){
        // Debug.Log("change to 3d");
        player2D.Activate(false);
        foreach (MultiDimentionBase multiDimention in multiDimentionBases)
        {
            multiDimention.To3D();
        }

        // ObstacleKinematic(false);

        yield return null;
        player3D.Activate(true);
        is2D = false;
        // Debug.Log("changed to 3d");
    }
    // public void ObstacleKinematic(bool isKinematic){
    //     GameObject[] obstacle = GameObject.FindGameObjectsWithTag("Obstacle");
    //     foreach (GameObject obs in obstacle){
    //         obs.GetComponent<Rigidbody>().isKinematic = isKinematic;
     
    //     }
    // }
}
