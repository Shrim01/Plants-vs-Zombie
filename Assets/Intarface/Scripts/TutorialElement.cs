using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialElement : MonoBehaviour
{
    // �����, ���������� ��� ��������� ��������
    void Start()
    {
        // ��������� �������� ��� ������������ ��������
        StartCoroutine(HideAfterDelay(5f)); // 5 ������ ��������
    }

    // �������� ��� ������� ��������
    private IEnumerator HideAfterDelay(float delay)
    {
        // ���� ��������� �����
        yield return new WaitForSeconds(delay);

        // �������� �������
        gameObject.SetActive(false);
    }
}
