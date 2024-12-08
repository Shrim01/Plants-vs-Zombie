using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GoroxScript : MonoBehaviour
{
    public Rigidbody2D rb2D;
    private readonly float speed = 10f;
    private readonly float resist = 0.98f;
    private int MaxHealthPoint = 100;
    private int CurrentHealthPoint;

    void Start()
    {
        CurrentHealthPoint = MaxHealthPoint;
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

    public void Upgrade(Sprite sprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log(CurrentHealthPoint);
        if (other.gameObject.tag == "Zombie")
            CurrentHealthPoint -= 10;
        if (CurrentHealthPoint < 0)
        {
            gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>().GameOver();
        }
    }
}