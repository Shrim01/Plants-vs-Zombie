using System.Linq;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public void Change()
    {
        var countChild = GameObject.FindGameObjectWithTag("Choice").transform.childCount;
        transform.SetSiblingIndex(countChild+1);
    }
}