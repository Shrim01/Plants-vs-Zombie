using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using Unity.Mathematics;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public int speed = 100;
    public float liveTime = 5;
    private float time;

    void Update()
    {
        rb2D.AddForce(new Vector2(Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.PI / 180) * speed,
            Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.PI / 180) * speed));
        if (time > liveTime)
            Destroy(gameObject);
        time += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "GameObject")
            Destroy(gameObject);
    }
}
