using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MultiDimentionBase
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private bool is2D;
    public CinemachineVirtualCamera camera2D;
    public CinemachineVirtualCamera camera3D;
    private Coroutine transitionCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void To2D()
    {
        base.To2D();

        camera2D.Priority = 20;
        camera3D.Priority = 10;

        if (transitionCoroutine != null)
        {
            StopCoroutine(transitionCoroutine);
        }
        transitionCoroutine = StartCoroutine(Transition(true));
        is2D = true;
    }

    public override void To3D()
    {
        base.To3D();

        camera2D.Priority = 10;
        camera3D.Priority = 20;

        if (transitionCoroutine != null)
        {
            StopCoroutine(transitionCoroutine);
        }
        transitionCoroutine = StartCoroutine(Transition(false));
        is2D = false;
    }

    private IEnumerator Transition(bool is2D)
    {
        yield return new WaitForSeconds(0.4f);
        mainCamera.orthographic = is2D;
    }
}
