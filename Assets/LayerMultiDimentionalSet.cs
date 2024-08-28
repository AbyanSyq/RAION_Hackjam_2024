using UnityEngine;

public class LayerMultiDimentionalSet : MultiDimentionBase
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;

    private Vector3 positionDefault;
    private Quaternion rotationDefault;
    private Vector3 scaleDefault;

    public float transitionSpeed = 1.0f; // Kecepatan transisi

    private bool isTransitioning = false;
    private float transitionProgress = 0.0f;

    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private Vector3 targetScale;

    void Start()
    {
        base.Start();

        // Simpan nilai default dari transform saat start
        positionDefault = transform.localPosition;
        rotationDefault = transform.localRotation;
        scaleDefault = transform.localScale;
    }

    void Update()
    {
        if (isTransitioning)
        {
            transitionProgress += Time.deltaTime * transitionSpeed;

            // Lerp position and scale
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, transitionProgress);
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, transitionProgress);

            // Slerp rotation
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, transitionProgress);

            // Stop the transition when complete
            if (transitionProgress >= 1.0f)
            {
                isTransitioning = false;
                transitionProgress = 0.0f;
            }
        }
    }

    public override void To2D()
    {
        base.To2D();
        StartTransition(positionDefault, rotationDefault, scaleDefault);
    }

    public override void To3D()
    {
        base.To3D();
        StartTransition(position, rotation, scale);
    }

    void StartTransition(Vector3 newPosition, Quaternion newRotation, Vector3 newScale)
    {
        targetPosition = newPosition;
        targetRotation = newRotation;
        targetScale = newScale;

        isTransitioning = true;
        transitionProgress = 0.0f;
    }
}
