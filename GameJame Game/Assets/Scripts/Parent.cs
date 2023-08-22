using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent : MonoBehaviour
{
    public GameObject child;
    [SerializeField]
    private float time=10f;

    private void Start()
    {
        Invoke(nameof(enableChild), time);
    }

    private void enableChild()
    {
        child.SetActive(true);
    }
}
