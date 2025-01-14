using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public Image experienceBar; // Ссылка на Image, представляющий шкалу опыта
    public LogicScript logicScript; // Ссылка на ваш LogicScript

    void Update()
    {
        if (logicScript != null)
        {
            // Вычисляем процент опыта
            float experiencePercentage = (float)logicScript.scorePlayer / logicScript.scoreNextlevel;
            experienceBar.fillAmount = experiencePercentage; // Обновляем заполнение шкалы
        }
    }
}
