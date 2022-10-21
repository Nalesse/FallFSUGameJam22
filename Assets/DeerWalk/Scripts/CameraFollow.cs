using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform followTarget;
    [SerializeField] private Vector3 camOffset;

    private void Start()
    {
        cameraTransform = transform;
        camOffset = cameraTransform.position - followTarget.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPos = followTarget.position + camOffset;

        cameraTransform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, Time.smoothDeltaTime);

        transform.LookAt(followTarget);
    }
}
