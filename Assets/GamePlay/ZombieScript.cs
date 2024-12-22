using UnityEngine;

public class ZombieScripts : MonoBehaviour
{
    public GameObject player;
    public readonly int damage = 10;
    private int MaxHealthPoint = 20;
    private int CurrentHealthPoint;
    private readonly int x = 12;
    public LogicScript logic;

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
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            var bullet = other.gameObject;
            var damage = bullet.GetComponent<BulletScript>().damage;
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
}
