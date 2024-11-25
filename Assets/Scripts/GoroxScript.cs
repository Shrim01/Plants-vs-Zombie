using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoroxScript : MonoBehaviour
{
    public Rigidbody2D rb2D;
    private const float speed = 10f;
    private const float resist = 0.98f;

    void Start()
    {

    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal!=0)
            rb2D.AddForce(new Vector2(horizontal * speed,0));
        if (vertical!=0)
            rb2D.AddForce(new Vector2(0, vertical * speed));
        Debug.Log(rb2D.velocity);
        rb2D.velocity*= new Vector2(resist,resist);
    }
}
