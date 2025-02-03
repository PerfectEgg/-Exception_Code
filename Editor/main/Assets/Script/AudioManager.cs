using System.IO;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;  // AudioSource 컴포넌트
    public AudioClip audioClip;      // 불러올 오디오 파일 (MP3 파일)
    public SongLoader songLoader;    // 마디선 생성을 위한 클래스
    public Button loadButton;        // 로드 버튼
    public ScrollController scrollController;
    public TMP_InputField songNameInputField = null;  // 사용자가 텍스트를 입력하는 InputField
    public string songName = null;                    // 노래 이름을 저장할 변수

    private float measure_height;

    void Start()
    {
        if (audioSource != null && audioClip != null)
        {
            audioSource.clip = audioClip;  // AudioSource에 AudioClip 할당
            Debug.Log("AudioClip is set!");
        }
    }

    // 노래 재생 함수
    public void PlayMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();  // 음악 재생
            Debug.Log("Music is playing!");
        }
        else
        {
            Debug.Log("AudioSource is already playing or not set!");
        }
    }

    // 노래 일시정지 함수
    public void PauseMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();  // 음악 일시정지
            Debug.Log("Music is paused!");
        }
    }

    // 노래 재개 함수
    public void ResumeMusic()
    {
        if (audioSource != null)
        {
            
            audioSource.time = 0f;  // 노래의 처음으로 돌아가기
            Debug.Log("Music is resumed from the beginning!");
            if (audioSource.isPlaying)
                PauseMusic();
        }
    }
    public void SetSongName()
    {
        if (songNameInputField != null)
        {
            Debug.Log("songNameInputField.text: " + songNameInputField.text);  // 텍스트 값 확인
            songName = songNameInputField.text;
        }
        else
        {   
            Debug.LogError("songNameInputField is not assigned!");
        }
    }

    // 버튼 클릭 시 호출되어 AudioSource.clip에 해당 텍스트와 일치하는 노래를 설정
    public void SetAudioClip()
    {
        string path = "Songs\\" + songName;  // Resources 폴더 내의 Songs 서브폴더에서 찾음
        AudioClip clip = Resources.Load<AudioClip>(path); // Resources 폴더 내에서 찾음

        if (clip != null)
        {
            audioSource.clip = clip;
            Debug.Log("AudioClip set to: " + songName);
        }
        else
        {
            Debug.LogError("Audio file not found for: " + songName);  // 경로 및 파일 확인
        }
    }

    // 마디선 생성
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