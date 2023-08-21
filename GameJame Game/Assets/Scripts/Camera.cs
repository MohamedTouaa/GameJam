using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private CinemachineVirtualCamera _cam;
    public Transform playerPostion;
    [SerializeField]
    private float size = 5f, waitTime = 10f;
    private void Awake()
    {
        _cam = GetComponent<CinemachineVirtualCamera>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(followPlayer), waitTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void followPlayer()
    {
        _cam.Follow = playerPostion;
        _cam.m_Lens.OrthographicSize = size;
    }
}
