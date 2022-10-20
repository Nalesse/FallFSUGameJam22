using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   [SerializeField] private GameObject followTarget;
   private Vector3 camOffset;

   private void Start()
   {
      camOffset = transform.position;
   }

   private void LateUpdate()
   {
      transform.position = followTarget.transform.position + camOffset;
   }
}
