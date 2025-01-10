using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMusicAndIcon : MonoBehaviour
{
    public GameObject checkmark; // ������ �� ������ �������
    public GameObject cross;      // ������ �� ������ ��������
    public AudioSource audioSource; // ������ �� AudioSource

    private bool isMusicPlaying = true; // ���������� ��� ������������ ��������� ������

    void Start()
    {
        // ���������, ��� ������� �������, � ������� - ���
        checkmark.SetActive(true);
        cross.SetActive(false);
    }

    public void Toggle()
    {
        // ����������� ���������
        isMusicPlaying = !isMusicPlaying;

        // ������ ��������� ��������
        checkmark.SetActive(isMusicPlaying);
        cross.SetActive(!isMusicPlaying);

        // ������������� ��� ������������ ������
        if (isMusicPlaying)
        {
            audioSource.Play(); // ������������� ������
        }
        else
        {
            audioSource.Stop(); // ������������� ������
        }
    }
}
