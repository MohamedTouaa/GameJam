using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class CoutDownController : MonoBehaviour
{
    [SerializeField]
    private float coutdown = 10f;
    private TextMeshProUGUI coutdownText;
    private GameObject Timer;

    [SerializeField]
    private float waitTime = 20f;
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        coutdownText = GameObject.FindGameObjectWithTag("Text").GetComponent<TextMeshProUGUI>();



    }
    private void Start()
    {
        StartCoroutine(CountDown());
        Invoke(nameof(PlayMusic), waitTime);
    }

    private IEnumerator CountDown()
    {
        while (coutdown > 0)
        {
            coutdownText.text = coutdown.ToString();

            yield return new WaitForSeconds(1f);

            coutdown--;

        }
        coutdownText.text = "GO!";

        yield return new WaitForSeconds(1f);

        coutdownText.gameObject.SetActive(false);

    }

    private void PlayMusic()
    {
        audioManager.PlaySFX(audioManager.countdown);
    }



}
