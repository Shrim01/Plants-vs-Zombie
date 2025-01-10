using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
    public static Camera main;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
    }

}