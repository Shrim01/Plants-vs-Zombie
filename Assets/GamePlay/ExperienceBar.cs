using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public Image experienceBar; // ������ �� Image, �������������� ����� �����
    public LogicScript logicScript; // ������ �� ��� LogicScript

    void Update()
    {
        if (logicScript != null)
        {
            // ��������� ������� �����
            float experiencePercentage = (float)logicScript.scorePlayer / logicScript.scoreNextlevel;
            experienceBar.fillAmount = experiencePercentage; // ��������� ���������� �����
        }
    }
}
