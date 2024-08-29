using UnityEngine;
[ExecuteInEditMode]
public class FollowCam : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] float parrallaxFactor;
    [SerializeField] bool isJustX = true;

    private void LateUpdate()
    {
        if (cameraTransform != null)
        {
            Vector3 newPosition = transform.localPosition;
            newPosition.x = cameraTransform.localPosition.x * parrallaxFactor;
            transform.localPosition = newPosition;
        }
        // if (cameraTransform != null & !isJustX)
        // {
        //     Vector3 newPosition = transform.localPosition;
        //     newPosition.y = cameraTransform.localPosition.y * parrallaxFactor;
        //     newPosition.z = cameraTransform.localPosition.z * parrallaxFactor;
        //     transform.localPosition = newPosition;
        // }
    }
}
