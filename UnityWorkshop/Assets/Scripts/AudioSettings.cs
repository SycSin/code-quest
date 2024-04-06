using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer masteraudioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    
    private void start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("music", 0.75f);
        sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume", 0.75f);
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        masteraudioMixer.SetFloat("menu_param_audio", Mathf.Log10(volume) * 20);
    }
}
