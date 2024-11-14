using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixermanager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public static SoundMixermanager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);  
        }
    }


    public void SetMasterVolume(float volume){
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20f);
    }

    public void SetMusicVolume(float volume){
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20f);
    }

    public void SetSFXVolume(float volume){
        audioMixer.SetFloat("FxVolume", Mathf.Log10(volume) * 20f);
    }
}
