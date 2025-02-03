using System.IO;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;  // AudioSource ������Ʈ
    public AudioClip audioClip;      // �ҷ��� ����� ���� (MP3 ����)
    public SongLoader songLoader;    // ���� ������ ���� Ŭ����
    public Button loadButton;        // �ε� ��ư
    public ScrollController scrollController;
    public TMP_InputField songNameInputField = null;  // ����ڰ� �ؽ�Ʈ�� �Է��ϴ� InputField
    public string songName = null;                    // �뷡 �̸��� ������ ����

    private float measure_height;

    void Start()
    {
        if (audioSource != null && audioClip != null)
        {
            audioSource.clip = audioClip;  // AudioSource�� AudioClip �Ҵ�
            Debug.Log("AudioClip is set!");
        }
    }

    // �뷡 ��� �Լ�
    public void PlayMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();  // ���� ���
            Debug.Log("Music is playing!");
        }
        else
        {
            Debug.Log("AudioSource is already playing or not set!");
        }
    }

    // �뷡 �Ͻ����� �Լ�
    public void PauseMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();  // ���� �Ͻ�����
            Debug.Log("Music is paused!");
        }
    }

    // �뷡 �簳 �Լ�
    public void ResumeMusic()
    {
        if (audioSource != null)
        {
            
            audioSource.time = 0f;  // �뷡�� ó������ ���ư���
            Debug.Log("Music is resumed from the beginning!");
            if (audioSource.isPlaying)
                PauseMusic();
        }
    }
    public void SetSongName()
    {
        if (songNameInputField != null)
        {
            Debug.Log("songNameInputField.text: " + songNameInputField.text);  // �ؽ�Ʈ �� Ȯ��
            songName = songNameInputField.text;
        }
        else
        {   
            Debug.LogError("songNameInputField is not assigned!");
        }
    }

    // ��ư Ŭ�� �� ȣ��Ǿ� AudioSource.clip�� �ش� �ؽ�Ʈ�� ��ġ�ϴ� �뷡�� ����
    public void SetAudioClip()
    {
        string path = "Songs\\" + songName;  // Resources ���� ���� Songs ������������ ã��
        AudioClip clip = Resources.Load<AudioClip>(path); // Resources ���� ������ ã��

        if (clip != null)
        {
            audioSource.clip = clip;
            Debug.Log("AudioClip set to: " + songName);
        }
        else
        {
            Debug.LogError("Audio file not found for: " + songName);  // ��� �� ���� Ȯ��
        }
    }

    // ���� ����
    public void CreateMeasures() 
    {
        if (songLoader != null)
        {
            songLoader.LoadSong(songName);
        }
        else
        {
            Debug.LogError("songLoader is not assigned!");
        }
    }
}