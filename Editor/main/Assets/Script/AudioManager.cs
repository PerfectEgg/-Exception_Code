using System.IO;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;  // AudioSource ������Ʈ
    public AudioClip audioClip;      // �ҷ��� ����� ���� (MP3 ����)
    public Button loadButton;        // �ε� ��ư
    public TMP_InputField songNameInputField;  // ����ڰ� �ؽ�Ʈ�� �Է��ϴ� InputField
    public string songName;                    // �뷡 �̸��� ������ ����


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
            // ������ �Ͻ����� ���̸�
            if (!audioSource.isPlaying)
            {
                audioSource.time = 0f;  // �뷡�� ó������ ���ư���
                audioSource.Play();     // �ٽ� ���
                Debug.Log("Music is resumed from the beginning!");
            }
        }
    }
    public void SetSongName(string songName)
    {
        if (songNameInputField != null)
        {
            Debug.Log("songNameInputField.text: " + songNameInputField.text);  // �ؽ�Ʈ �� Ȯ��
            songNameInputField.text = songName;  // songName�� �ؽ�Ʈ �ʵ忡 �Ҵ�
        }
        else
        {
            Debug.LogError("songNameInputField is not assigned!");
        }
    }
    // ��ư Ŭ�� �� ȣ��Ǿ� AudioSource.clip�� �ش� �ؽ�Ʈ�� ��ġ�ϴ� �뷡�� ����
    public void SetAudioClip(string songName)
    {
        string path = "Songs/" + songName;  // Resources ���� ���� Songs ������������ ã��
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

}