using System.Collections;
using UnityEngine;

public class CameraScript : MultiDimentionBase
{
    public Camera mainCamera;
    [SerializeField] Vector3 position3D;
    [SerializeField] Vector3 rotation3D;
    [SerializeField] Vector3 position2D;
    [SerializeField] Vector3 rotation2D;
    [SerializeField] float transitionDuration = 1.0f; // Durasi transisi
    private Coroutine transitionCoroutine;

    [SerializeField] Transform player;
    [SerializeField] private float smooth = 0.1f;
    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        base.Start();
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
        Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smooth);
        transform.position = newPosition;
    }


    public override void To2D()
    {
        base.To2D();
        if (transitionCoroutine != null)
        {
            StopCoroutine(transitionCoroutine);
        }
        transitionCoroutine = StartCoroutine(Transition(position2D, rotation2D));
    }

    public override void To3D()
    {
        base.To3D();
        if (transitionCoroutine != null)
        {
            StopCoroutine(transitionCoroutine);
        }
        transitionCoroutine = StartCoroutine(Transition(position3D, rotation3D));
    }

    private IEnumerator Transition(Vector3 targetPosition, Vector3 targetRotation)
    {
        Vector3 startPosition = transform.position;
        Quaternion startRotation = transform.rotation;
        Quaternion targetQuaternion = Quaternion.Euler(targetRotation);

        float timeElapsed = 0;

        while (timeElapsed < transitionDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / transitionDuration);
            transform.rotation = Quaternion.Slerp(startRotation, targetQuaternion, timeElapsed / transitionDuration);

            timeElapsed += Time.deltaTime;
            yield return null;
        }
        if (targetPosition.y < 6)
        {
            mainCamera.orthographic = true;
            player = GameManager.instance.player2D.transform;
        }
        else
        {
            mainCamera.orthographic = false;
             player = GameManager.instance.player3D.transform;
        }
        // Ensure the camera reaches the target position and rotation
        transform.position = targetPosition;
        transform.rotation = targetQuaternion;
    }
}
