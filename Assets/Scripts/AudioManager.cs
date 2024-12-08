using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource; // ��� ������
    public AudioSource sfxSource;   // ��� �������� ��������

    private void Awake()
    {
        // ���������� Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ���������� ��� �������� ����� �����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float volume)
    {
        musicSource.volume = volume; // ���������� ��������� ������
        sfxSource.volume = volume;    // ���������� ��������� �������� ��������
    }
}
