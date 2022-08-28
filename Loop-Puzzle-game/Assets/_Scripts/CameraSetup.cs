using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CameraSetup : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private Transform wholeLevelTarget;
    [SerializeField] private float size;

    private Transform player;
    private bool isZoomedOut = false;
    private float originalSize;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cam.Follow = player;
        originalSize = cam.m_Lens.OrthographicSize;
    }
    
    public void wideLevelShot(InputAction.CallbackContext context)
    {
        if (isZoomedOut)
        {
            cam.Follow = player;
            cam.m_Lens.OrthographicSize = originalSize;
            isZoomedOut = false;
        }
        else
        {
            cam.Follow = wholeLevelTarget;
            cam.m_Lens.OrthographicSize = size;
            isZoomedOut = true;
        }
    }
}
