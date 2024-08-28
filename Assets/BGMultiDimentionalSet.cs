using UnityEngine;

public class BGMultiDimentionalSet : MultiDimentionBase
{
    void Start()
    {
        base.Start();
    }

    public override void To2D()
    {
        base.To2D();
        Vector3 newPosition = transform.position;
        newPosition.x = FindAnyObjectByType<CameraManager>().camera2D.transform.position.x;
        transform.position = newPosition;
    }

    public override void To3D()
    {
        base.To3D();

        // Menyesuaikan posisi X background dengan posisi X player3D
        Vector3 newPosition = transform.position;
        newPosition.x = FindAnyObjectByType<CameraManager>().camera3D.transform.position.x;
        transform.position = newPosition;
    }
}
