using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverEffectUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject objectToShow;

    private void Start()
    {
        objectToShow.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        objectToShow.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        objectToShow.SetActive(false);
    }
}
