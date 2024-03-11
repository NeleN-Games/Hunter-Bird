using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_1_Behaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private float FirstY_Value;
    [SerializeField] private float a;
    [SerializeField] private float force;
    public bool addedscore;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    private void OnEnable()
    {
        FirstY_Value = transform.position.y;
        addedscore = false;
    }

    private void FixedUpdate()
    {
        Vector2 newposition=new Vector2( transform.position.x,Mathf.Clamp(FirstY_Value+a*Mathf.Cos(force*Time.time),-4,5.6f));
       rb.MovePosition(newposition); 
    }
}
