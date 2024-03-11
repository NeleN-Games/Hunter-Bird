using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_2_Behaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 First_Position;
    [SerializeField] private float a;
    [SerializeField] private float force;
    public bool addedscore;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        First_Position = transform.position;
        addedscore = false;
    }

    private void FixedUpdate()
    {
        Vector2 newposition=new Vector2(First_Position.x-a*Mathf.Cos(force*Time.time),Mathf.Clamp(First_Position.y+a*Mathf.Sin(force*Time.time),-4,5.6f));
        rb.MovePosition(newposition); 
    }
}
