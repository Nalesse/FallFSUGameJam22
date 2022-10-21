using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Vector3 cameraDistance;
    [SerializeField] private Vector3 cameraOffset;
    private GameObject targetLook;
    private PlayerMovement pMovement;
    private void Start()
    {
        pMovement = gameObject.GetComponent<PlayerMovement>();
        cameraDistance = cameraTransform.position - transform.position;
        targetLook = new GameObject();
        Instantiate(targetLook);
    }

    private void LateUpdate()
    {
        Vector3 targetPos = transform.position + cameraDistance;
        Vector3 targetRot = pMovement.GetPlayerCamMovement();
        cameraTransform.position = Vector3.SmoothDamp(cameraTransform.transform.position, targetPos, ref velocity, Time.smoothDeltaTime);

        cameraTransform.transform.Rotate(targetRot);

        targetLook.transform.position = transform.position + cameraOffset;
        cameraTransform.transform.LookAt(targetLook.transform);
    }
}
