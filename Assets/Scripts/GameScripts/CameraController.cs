using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float yMaxBounds, yMinBounds;
    [SerializeField] private CinemachineVirtualCamera virtualCam;
    public Transform player;
     private Camera cam;
    public float height;
    public float width;

    public float GetMinYBounds => yMinBounds;
    public float GetMaxYBounds => yMaxBounds;
    public float GetMinXBounds => transform.position.x + -(width / 2);
    public float GetMaxXBounds => transform.position.x + width / 2;
    
    private void Awake()
    {
        cam = GetComponent<Camera>();
        height = 2 * cam.orthographicSize;
        width = height * cam.aspect;
        FollowTarget(player);
    }

    public void FollowTarget(Transform target)
    {
        virtualCam.Follow = target;
    }
}
