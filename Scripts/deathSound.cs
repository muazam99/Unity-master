using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathSound : MonoBehaviour
{
    private AudioSource sound;

    public AudioClip[] clips;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        int randomNumber = Random.Range(0, clips.Length);
        sound.clip = clips[randomNumber];
        sound.Play();

    }
}
