using UnityEngine;

public class PressurePlate : MonoBehaviour, ITransmitter
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite onPressSprite;
    [SerializeField] Sprite defaultSprite;
    public GameObject[] receivers;
    public void Transmit(bool press = true)
    {
        foreach (GameObject receiver in receivers)
        {
            receiver.GetComponent<IReceiver>()?.Receiver(press);
        }
    }   
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")|| other.CompareTag("Obstacle"))
        {
            Debug.Log("press");
            spriteRenderer.sprite = onPressSprite;
            Transmit();
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player") || other.CompareTag("Obstacle"))
        {
            Debug.Log("release");
            spriteRenderer.sprite = defaultSprite;
            Transmit(false);
        }
    }
}
