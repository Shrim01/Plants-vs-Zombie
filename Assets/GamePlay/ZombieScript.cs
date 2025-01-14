using UnityEngine;

public class ZombieScripts : MonoBehaviour
{
    public GameObject player;
    public readonly int damage = 10;
    public LogicScript logic;
    public Sprite[] sprites;
    private int MaxHealthPoint = 100;
    private int CurrentHealthPoint;
    private readonly int x = 30;
    private int addScore;

    void Start()
    {
        var rnd = Random.Range(0, 10);
        if (rnd <= 4)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
            CurrentHealthPoint = MaxHealthPoint;
            addScore = 10;
        }
        else if (rnd >= 8)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
            CurrentHealthPoint = MaxHealthPoint * 2;
            addScore = 20;
            gameObject.GetComponent<Collider2D>().offset = new Vector2(0, -0.7f);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
            CurrentHealthPoint = MaxHealthPoint / 10 * 15;
            addScore = 15;
            gameObject.GetComponent<Collider2D>().offset = new Vector2(-0.4f, -1);
        }

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
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
            DoDamage(bullet.GetComponent<BulletScript>().damage,true);
        }

        if (other.gameObject.tag == "PlantBullet")
        {
            var bullet = other.gameObject;
            DoDamage(bullet.GetComponent<PlantsBulletScript>().damage,false);
        }
    }

    private void DoDamage(int damage, bool flag)
    {
        if (damage < CurrentHealthPoint)
            CurrentHealthPoint -= damage;
        else
        {
            Destroy(gameObject);
            if (flag)
                logic.AddScore(addScore);
        }
    }
}
