using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Vector3 hoverScale = new Vector3(1.2f, 1.2f, 1.2f);
    private Vector3 originalScale;
    [SerializeField] private Image targetImage; // UI Image component or SpriteRenderer
    [SerializeField] private Sprite newSprite;


    private void Start()
    {
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale;
    }
    public void ChangeSprite()
    {
        if (targetImage != null && newSprite != null)
        {
            targetImage.sprite = newSprite;
        }
    }
}
