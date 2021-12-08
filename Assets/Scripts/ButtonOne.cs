using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonOne : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private Sprite[] sp;

    [SerializeField]
    private Button button;

    //private Sprite buttonSprite;

    private void Start()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
       button.image.sprite = sp[1];
        //Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.image.sprite = sp[0];
        //Debug.Log("Mouse Exit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        button.image.sprite = sp[1];
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        button.image.sprite = sp[0];
    }
}
