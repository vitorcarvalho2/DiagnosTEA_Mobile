using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
 
public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    [SerializeField] private AudioSource soundFXObject;
    [SerializeField] private AudioSource musicSourceObject;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            AudioSource musicSource = Instantiate(musicSourceObject, Vector3.zero, Quaternion.identity);
            musicSource.Play();
            DontDestroyOnLoad(musicSource.gameObject);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundFXClips(AudioClip[] audioClips, Transform spawnTransform, float volume,int clipIndex)
{
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        
        audioSource.clip = audioClips[clipIndex];
        audioSource.volume = volume;
        audioSource.Play();
        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);
}
}
