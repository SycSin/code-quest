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
}
