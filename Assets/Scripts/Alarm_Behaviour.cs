using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Alarm_Behaviour : MonoBehaviour
{
    private SpriteRenderer SR;
    private Color tmp;
    
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SR.color=new Color32(255,255,255,(byte)(55 * Mathf.Sin(11f*+Time.time) + 170));
    }
}
