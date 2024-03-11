using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_Background : MonoBehaviour
{
    [SerializeField] private GameObject camera;
    private void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).position.x-camera.transform.position.x<-35)
            {
                transform.GetChild(i).localPosition = new Vector3(transform.GetChild(i).localPosition.x + 3 * 26.25f,
                    transform.GetChild(i).localPosition.y, transform.GetChild(i).localPosition.z);
                
            }
        }
    }
}
