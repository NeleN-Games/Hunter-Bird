using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    [SerializeField] private GameObject Eagle;
    private Vector3 targetposition;
    private Vector3 velocity=Vector3.zero;
    
    private void FixedUpdate()
    {
        targetposition = new Vector3(Eagle.transform.position.x + 8.7f,
            Mathf.Clamp(.75f * Eagle.transform.position.y - 5, 0, .55f), -10);
        transform.position = Vector3.SmoothDamp(transform.position, targetposition, ref velocity,0.15f);
    }
}
