using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class CoutDownController : MonoBehaviour
{
    [SerializeField]
    private float coutdown = 5f;
    public TextMeshProUGUI coutdownText;
    public GameObject Timer;


    private void Start()
    {
        StartCoroutine(CountDown());
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
        Timer.gameObject.SetActive(true);
    }

}
