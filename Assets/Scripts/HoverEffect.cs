using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverEffectUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject objectToShow; // Объект, который будет появляться

    private void Start()
    {
        // Скрываем объект в начале
        objectToShow.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Показать объект при наведении курсора
        objectToShow.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Скрыть объект, когда курсор уходит
        objectToShow.SetActive(false);
    }
}
