using UnityEngine;

public class ZombieScripts : MonoBehaviour
{
    public GameObject player;
    private int MaxHealthPoint = 20;
    private int CurrentHealthPoint;
    private readonly int x = 12;
    private LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        CurrentHealthPoint = MaxHealthPoint;
        gameObject.tag = "Zombie";
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        var position = player.transform.position - transform.position;
        if (Mathf.Sqrt(position.x * position.x + position.y * position.y) > x * 3)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var bullet = other.gameObject;
        var damage = bullet.GetComponent<BulletScript>().damege;
        if (damage < CurrentHealthPoint)
            CurrentHealthPoint -= damage;
        else
        {
            Destroy(gameObject);
            logic.AddScore(10);
        }
        Destroy(bullet);
    }
}
