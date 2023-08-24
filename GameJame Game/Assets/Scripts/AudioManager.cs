using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-----Audio Source----")]
    [SerializeField]
    private AudioSource MusicSource;
    [SerializeField]
    private AudioSource SFXSource;

    [SerializeField]
    private float waitTime = 10f;


    [Header("-----Audio Clip----")]
    public AudioClip background;
    public AudioClip Death;
    public AudioClip Explosion;
    public AudioClip countdown;
    public AudioClip teleport;
    public AudioClip button;
    public AudioClip coinCollect;

    private void Start()
    {
        MusicSource.clip = background;
        Invoke(nameof(PlayMusic), waitTime);
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    private void PlayMusic()
    {
        MusicSource.Play();
    }
}
