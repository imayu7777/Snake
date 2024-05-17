using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] sounds;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayEatSound()
    {
        int index = Random.Range(0, sounds.Length-1);
        if (index >= 0 && index < sounds.Length)
        {
            audioSource.clip = sounds[index];
            audioSource.Play();
        }
    }
    public void PlayEndSound()
    {
        audioSource.clip = sounds[sounds.Length-1];
        audioSource.Play();
    }
}
