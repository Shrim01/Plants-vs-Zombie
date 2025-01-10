using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMusicAndIcon : MonoBehaviour
{
    public GameObject checkmark; // Ссылка на объект галочки
    public GameObject cross;      // Ссылка на объект крестика
    public AudioSource audioSource; // Ссылка на AudioSource

    private bool isMusicPlaying = true; // Переменная для отслеживания состояния музыки

    void Start()
    {
        // Убедитесь, что галочка активна, а крестик - нет
        checkmark.SetActive(true);
        cross.SetActive(false);
    }

    public void Toggle()
    {
        // Переключаем состояние
        isMusicPlaying = !isMusicPlaying;

        // Меняем видимость объектов
        checkmark.SetActive(isMusicPlaying);
        cross.SetActive(!isMusicPlaying);

        // Останавливаем или возобновляем музыку
        if (isMusicPlaying)
        {
            audioSource.Play(); // Воспроизводим музыку
        }
        else
        {
            audioSource.Stop(); // Останавливаем музыку
        }
    }
}
