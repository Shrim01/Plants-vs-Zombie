using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoroxScript : MonoBehaviour
{
    public Rigidbody2D rb2D;
    private float speed = 10f;
    private float resist = 0.98f;


    void Start()
    {
    }

    void Update()
    {
        Move();
        Rotate();
    }


    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal != 0)
            rb2D.AddForce(new Vector2(horizontal * speed, 0));
        if (vertical != 0)
            rb2D.AddForce(new Vector2(0, vertical * speed));
        rb2D.velocity *= new Vector2(resist, resist);
    }


    private void Rotate()
    {
        var position = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
        var rotation = Mathf.Atan(position.y / position.x) * 180 / Mathf.PI;
        if (position.x < 0)
            rotation += 180;
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}