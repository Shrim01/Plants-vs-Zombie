using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialElement : MonoBehaviour
{
    // Метод, вызываемый при активации элемента
    void Start()
    {
        // Запускаем корутину для исчезновения элемента
        StartCoroutine(HideAfterDelay(5f)); // 5 секунд задержки
    }

    // Корутина для скрытия элемента
    private IEnumerator HideAfterDelay(float delay)
    {
        // Ждем указанное время
        yield return new WaitForSeconds(delay);

        // Скрываем элемент
        gameObject.SetActive(false);
    }
}
