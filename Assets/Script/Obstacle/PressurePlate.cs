using UnityEngine;

public class PressurePlate : MonoBehaviour, ITransmitter
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite onPressSprite;
    [SerializeField] private Sprite defaultSprite;
    public GameObject[] receivers;
    private int objectsOnPlate = 0;
    private bool isPressed = false;

    public void Transmit(bool press = true)
    {
        foreach (GameObject receiver in receivers)
        {
            receiver.GetComponent<IReceiver>()?.Receiver(press);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player") || other.CompareTag("Obstacle")))
        {
            objectsOnPlate++;
            if (objectsOnPlate == 1) // If this is the first object to press the plate
            {
                Debug.Log("press");
                spriteRenderer.sprite = onPressSprite;
                isPressed = true;
                Transmit();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Obstacle"))
        {
            objectsOnPlate--;

            if (objectsOnPlate <= 0)
            {
                objectsOnPlate = 0;
                Debug.Log("release");
                spriteRenderer.sprite = defaultSprite;
                isPressed = false;
                Transmit(false);
            }
        }
    }
}
