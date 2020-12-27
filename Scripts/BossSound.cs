using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSound : MonoBehaviour
{

    private AudioSource sound;

    public AudioClip[] clips;

    public float timeBetweenSoundEffect;
    private float nextSoundEffectTime;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        

    }

    private void Update()
    {
        if(Time.time >= nextSoundEffectTime)
        {
            int randomNumber = Random.Range(0, clips.Length);
            sound.clip = clips[randomNumber];
            sound.Play();
            nextSoundEffectTime = Time.time + timeBetweenSoundEffect;
        }
        
    }
}
