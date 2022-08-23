using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSetup : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private Transform wholeLevelTarget;
    [SerializeField] private float size;

    void Awake()
    {
        cam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    public void wideLevelShot()
    {
        cam.Follow = wholeLevelTarget;
        cam.m_Lens.OrthographicSize = size;
    }
}
