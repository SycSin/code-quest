using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    [Header("----Audio Sources----")]
    [SerializeField] private AudioSource menuMusicSource;
    [SerializeField] private AudioSource GameMusicSource;
    [SerializeField] private AudioSource SFxSource;
    
    [Header("----Audio Clips----")]
    public AudioClip menuMusic;
    public AudioClip buttonClick;
    public AudioClip collisionsFxS;
    public AudioClip gamePlayMusic;
    public AudioClip playerFall;
    public AudioClip playerFinish;
    public AudioClip playerJoinWorld;
    
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            menuMusicSource.clip = menuMusic;
            menuMusicSource.Play();
        }
        else
        {
            GameMusicSource.clip = gamePlayMusic;
            GameMusicSource.Play();
        }
        
    }
    public void PlaySFXSound(AudioClip clip)
    {
        SFxSource.PlayOneShot(clip);
    }
}




