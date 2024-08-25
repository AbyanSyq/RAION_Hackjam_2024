using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraScript : MultiDimentionBase
{
    // [SerializeField] private bool is2D;
    // public Camera mainCamera;
    // [SerializeField] private CinemachineVirtualCamera cinemachineCamera;
    // [SerializeField] Vector3 position3D;
    // [SerializeField] Vector3 rotation3D;
    // [SerializeField] Vector3 position2D;
    // [SerializeField] Vector3 rotation2D;
    // [SerializeField] float transitionDuration = 1.0f; // Duration of the transition
    // private Coroutine transitionCoroutine;

    // [SerializeField] Transform player;
    // [SerializeField] private float smoothX = 0.1f;
    // [SerializeField] private float smoothY = 0.1f;
    // private float velocityX = 0f;
    // private float velocityY = 0f;
    // private Vector3 velocity = Vector3.zero;

    // void Start()
    // {
    //     base.Start();
    // }

    // void LateUpdate()
    // {
    //     // CameraMovement();
    // }

    // public void CameraMovement()
    // {
    //     transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    //     // if (is2D)
    //     // {

    //     //     float targetPositionX = player.position.x;
    //     //     float targetPositionY = player.position.y + position2D.y;

    //     //     float newPositionX = Mathf.SmoothDamp(transform.position.x, targetPositionX, ref velocityX, smoothX);
    //     //     float newPositionY = Mathf.SmoothDamp(transform.position.y, targetPositionY, ref velocityY, smoothY);

    //     //     transform.position = new Vector3(newPositionX, newPositionY, position2D.z);

    //     // }
    //     // else
    //     // {
    //     //     Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, position3D.z);
    //     //     Vector3 newPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothX);
    //     //     transform.position = newPosition;
    //     // }
    // }

    // public override void To2D()
    // {
    //     base.To2D();
    //     if (transitionCoroutine != null)
    //     {
    //         StopCoroutine(transitionCoroutine);
    //     }
    //     transitionCoroutine = StartCoroutine(Transition(position2D, rotation2D));
    //     is2D = true;
    // }

    // public override void To3D()
    // {
    //     base.To3D();
    //     if (transitionCoroutine != null)
    //     {
    //         StopCoroutine(transitionCoroutine);
    //     }
    //     transitionCoroutine = StartCoroutine(Transition(position3D, rotation3D));
    //     is2D = false;
    // }

    // private IEnumerator Transition(Vector3 targetPosition, Vector3 targetRotation)
    // {
    //     Vector3 startPosition = transform.position;
    //     Quaternion startRotation = transform.rotation;
    //     Quaternion targetQuaternion = Quaternion.Euler(targetRotation);

    //     float timeElapsed = 0;

    //     while (timeElapsed < transitionDuration)
    //     {
    //         transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / transitionDuration);
    //         transform.rotation = Quaternion.Slerp(startRotation, targetQuaternion, timeElapsed / transitionDuration);

    //         timeElapsed += Time.deltaTime;
    //         yield return null;
    //     }

    //     // Ensure the camera reaches the target position and rotation
    //     transform.position = targetPosition;
    //     transform.rotation = targetQuaternion;

    //     if (is2D)
    //     {
    //         mainCamera.orthographic = true;
    //         player = GameManager.instance.player2D.transform;
    //     }
    //     else
    //     {
    //         mainCamera.orthographic = false;
    //         player = GameManager.instance.player3D.transform;
    //     }
    //     cinemachineCamera.Follow =player;
    // }
}
