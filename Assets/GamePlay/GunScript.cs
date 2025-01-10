using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bullet;
    public float Reload;
    private float timer;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && timer > Reload)
        {
            Instantiate(bullet, transform.position, gameObject.GetComponentInParent<Transform>().rotation);
            timer = 0;
        }
    }
}
