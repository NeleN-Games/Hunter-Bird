using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 newposition;
    [SerializeField] private float X_Speed;
    private Touch _touch;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
          //  newposition = new Vector2(transform.position.x, transform.position.y + .22f);
         //   rb.MovePosition(newposition);
            
         rb.velocity = new Vector2(X_Speed,7.45f);
        }

        if (Input.touchCount!=0)
        { rb.velocity = new Vector2(X_Speed,7.45f);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(X_Speed,rb.velocity.y);
    }
    
}
