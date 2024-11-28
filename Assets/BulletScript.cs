using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public int speed = 100;

    void Start()
    {

    }

    void Update()
    {
        rb2D.AddForce(new Vector2(Mathf.Sin(transform.rotation.z)*speed,Mathf.Cos(transform.rotation.z)*speed));
    }
}
