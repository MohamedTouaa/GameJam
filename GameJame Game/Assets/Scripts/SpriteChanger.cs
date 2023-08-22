using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField]
    private float waitTime = 10f;
    public Sprite changer;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();

    }
    private void Start()
    {
        Invoke(nameof(changeSprite), waitTime);
    }

    private void changeSprite()
    {
        sprite.sprite = changer;
    }
}
