using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer masteraudioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider gamemusicSlider;
    [SerializeField] private Slider sfxSlider;
    
    private void Start()
    {
        if (PlayerPrefs.HasKey("MenuMusic"))
        {
            LoadVolume();
        }
        else
        {
            PlayerPrefs.SetFloat("MenuMusic", 0.75f);
            PlayerPrefs.SetFloat("GameMusic", 0.75f);
            PlayerPrefs.SetFloat("SfxVolume", 0.75f);
        }
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        masteraudioMixer.SetFloat("menu_param_audio", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MenuMusic", musicSlider.value);
    }
    public void GameMusicVolume()
    {
        float volume = gamemusicSlider.value;
        masteraudioMixer.SetFloat("game_param_audio", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("GameMusic", gamemusicSlider.value);
    }
    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        masteraudioMixer.SetFloat("sfx_param_audio", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SfxVolume", sfxSlider.value);
    }
    
    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MenuMusic", 0.75f);
        //gamemusicSlider.value = PlayerPrefs.GetFloat("GameMusic", 0.75f);
        sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume", 0.75f);
        
        
    }
    AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
}
