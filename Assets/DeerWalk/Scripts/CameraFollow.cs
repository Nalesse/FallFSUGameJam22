using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    private Vector3 targetPos = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    [SerializeField][Range(0f, 1f)] private float cameraSpeed = 0.5f;
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

        targetPos = transform.position + cameraDistance;

    }

    private void LateUpdate()
    {
        Vector2 mouseDelta = pMovement.GetPlayerCamMovement();
        

        targetPos.x += mouseDelta.x * (cameraSpeed * 0.1f);
        targetPos.y += mouseDelta.y * (cameraSpeed * 0.1f);
        

        cameraTransform.position = Vector3.SmoothDamp(cameraTransform.transform.position, targetPos, ref velocity, Time.smoothDeltaTime);


        targetLook.transform.position = transform.position + cameraOffset;
        cameraTransform.transform.LookAt(targetLook.transform);
    }
}
