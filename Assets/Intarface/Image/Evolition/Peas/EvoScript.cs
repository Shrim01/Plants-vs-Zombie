using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvoScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var choicen = GameObject.FindGameObjectWithTag("Choice").transform;
        gameObject.tag = "Choisen";
        transform.parent = choicen;
    }
}
