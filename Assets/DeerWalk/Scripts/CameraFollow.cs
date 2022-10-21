using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private GameObject followTarget;
    [SerializeField] private Vector3 camOffset;
    private PlayerMovement pMovement;
    private void Start()
    {
        pMovement = followTarget.gameObject.GetComponent<PlayerMovement>();
        cameraTransform = transform;
        camOffset = cameraTransform.position - followTarget.transform.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPos = followTarget.transform.position + camOffset;
        Vector3 targetRot = new Vector3(0f,pMovement.GetPlayerCamMovement().y,pMovement.GetPlayerCamMovement().y);
        cameraTransform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, Time.smoothDeltaTime);

        transform.Rotate(targetRot);
        transform.LookAt(followTarget.transform);
    }
}
