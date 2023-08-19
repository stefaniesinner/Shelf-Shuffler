using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager obj;

    public AudioClip jump;
    public AudioClip hit;

    public AudioSource audioSrc;

    private void Awake()
    {
        obj = this;
    }

    private void Update()
    {
        audioSrc = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSrc.PlayOneShot(clip);
    } 

    public void PlayJump()
    {
        PlaySound(jump);
    }

    public void PlayHit()
    {
        PlaySound(hit);
    }

    private void OnDestroy()
    {
        obj = null;
    }
}
