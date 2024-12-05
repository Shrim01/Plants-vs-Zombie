using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScripts : MonoBehaviour
{
    public GameObject player;
    private int x = 12;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var position =player.transform.position-transform.position;
        if (Mathf.Sqrt(position.x*position.x+position.y*position.y)>x*3)
        {
            Destroy(gameObject);
        }
    }
}
