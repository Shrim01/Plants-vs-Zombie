using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Не забудьте добавить эту библиотеку

public class MenuController : MonoBehaviour
{
    // Публичная переменная для указания имени сцены
    public string sceneToLoad; // Укажите имя сцены в инспекторе

    // Метод для загрузки сцены игры
    public void StartGame()
    {
        // Проверяем, что имя сцены не пустое, и загружаем сцену
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Имя сцены не указано!");
        }
    }
}