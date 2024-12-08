using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    public Scrollbar scrollbar; // Перетащите сюда ваш Scrollbar в инспекторе

    public void ScrollDown()
    {
        // Уменьшаем значение scrollbar, чтобы прокрутить вниз
        scrollbar.value -= 0.1f; // Измените 0.1f на нужное значение для скорости прокрутки
    }
}
