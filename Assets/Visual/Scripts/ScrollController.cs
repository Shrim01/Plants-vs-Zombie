using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    public Scrollbar scrollbar; // ���������� ���� ��� Scrollbar � ����������

    public void ScrollDown()
    {
        // ��������� �������� scrollbar, ����� ���������� ����
        scrollbar.value -= 0.1f; // �������� 0.1f �� ������ �������� ��� �������� ���������
    }
}
