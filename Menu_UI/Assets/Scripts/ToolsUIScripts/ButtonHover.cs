using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private UnityEngine.UI.Image image;
    private Shadow buttonShadow;
    private Color originalColor;
    private UnityEngine.Vector2 originalShadow;
    public Color hoverColor = new Color(0.7f, 0.7f, 0.7f, 1f);
    private UnityEngine.Vector2 hoverShadow = new UnityEngine.Vector2(4f, -4f);

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        buttonShadow = GetComponent<Shadow>();
        if(image != null) 
        {
            originalColor = image.color;  
        }
        
        if(buttonShadow != null)
        {
            originalShadow = buttonShadow.effectDistance;
        }
        originalShadow = buttonShadow.effectDistance;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(image != null)
        {
            image.color = hoverColor;
        }
        if(buttonShadow != null)
        {
            buttonShadow.effectDistance = hoverShadow;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(image != null)
        {
            image.color = originalColor;
        }
        if(buttonShadow != null)
        {
            buttonShadow.effectDistance = originalShadow;
        }
    }
}
