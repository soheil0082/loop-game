using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSetup : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;

    void Awake()
    {
        cam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
