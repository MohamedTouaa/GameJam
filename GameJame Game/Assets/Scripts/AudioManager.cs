using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public AudioClip Medieval;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 5)
        {
            MusicSource.clip = Medieval;
            Invoke(nameof(PlayMusic), waitTime);
        }
        else
        {
            MusicSource.clip = background;
            Invoke(nameof(PlayMusic), waitTime);
        }
      
     
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
