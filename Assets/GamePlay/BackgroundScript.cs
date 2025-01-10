using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public GameObject player;
    private float positionX = 11.52f;
    private float positionY = 11.52f;
    private Vector2[,] position;
    private const float fault = 0.4f;

    void Start()
    {
        position = new[,]
        {
            { new Vector2(-positionX * 2, positionY * 2), new Vector2(positionX * 2, positionY * 2) },
            { new Vector2(-positionX * 2, -positionY * 2), new Vector2(positionX * 2, -positionY * 2) }
        };
    }

    void Update()
    {
        for (int i = 0; i < 2; i++)
        for (int j = 0; j < 2; j++)
        {
            if (Mathf.Abs(player.transform.position.x - position[i, j].x) < fault &&
                Mathf.Abs(player.transform.position.y - position[i, j].y) < fault)
            {
                transform.position = new Vector3(position[i, j].x, position[i, j].y, 10);
                NewPosition(position, i, j, 1);
            }

            else if (Mathf.Abs(player.transform.position.x - position[i, j].x) < fault)
            {
                transform.position = new Vector3(position[i, j].x, transform.position.y, 10);
                NewPosition(position, -1, j, 2);
            }

            else if (Mathf.Abs(player.transform.position.y - position[i, j].y) < fault)
            {
                transform.position = new Vector3(transform.position.x, position[i, j].y, 10);
                NewPosition(position, i, -1, 2);
            }
        }
    }

    private void NewPosition(Vector2[,] position, int im, int jm, int k)
    {
        var x = 0;
        var y = 0;
        if (im == 0)
            y = 1;
        if (im == 1)
            y = -1;
        if (jm == 0)
            x = -1;
        if (jm == 1)
            x = 1;
        for (int i = 0; i < 2; i++)
        for (int j = 0; j < 2; j++)
            position[i, j] = new Vector2(position[i, j].x + x * positionX * k, position[i, j].y + y * positionY * k);
    }
}
