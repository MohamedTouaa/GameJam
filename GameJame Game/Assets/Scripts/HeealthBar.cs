using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HeealthBar : MonoBehaviour
{
    public Image[] healths;
    private int curentindex = 0;

    public void destroyHealth()
    {
        Destroy(healths[curentindex].gameObject);
        curentindex++;
    }
}
