using UnityEngine;

public class PlantsScript : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float reload = 0.25f;
    public int score = 100;
    public GameObject bullet;
    public GameObject bulletBoom;
    public int countBullet = 1;
    public int speed = 25;
    public int bulletDamage;
    public bool boom = false;
    public float CurrentHealthPoint;
    private float MaxHealthPoint = 200;
    private float timer;
    private bool DoShoot;
    private int DidShoot;
    public bool Shooting;
    private GameObject nearObject;
    private float range;
    private float rotation;
    private Vector2 position;
    private float moveTime;

    void Start()
    {
        range = 500;
        gameObject.tag = "Plant";
        CurrentHealthPoint = MaxHealthPoint;
        DidShoot = 0;
        nearObject = FindNearEnemy();
    }

    void Update()
    {
        
        position = nearObject.transform.position - transform.position;
        if(position.magnitude>100)
            Destroy(gameObject);
        rotation = Mathf.Atan(position.y / position.x) * 180 / Mathf.PI;
        if (position.x < 0)
            rotation += 180;
        if (GameObject.FindGameObjectWithTag("Player").transform.position.magnitude > 25 || nearObject==null)
            nearObject = FindNearEnemy();
        Move();
        Rotate();
        Shoot();

    }

    private void Shoot()
    {
        timer += Time.deltaTime;
        if (!DoShoot)
        {
            if (Shooting && timer > reload)
            {
                SpawnBullet();
                DidShoot++;
                if (countBullet > 1)
                    DoShoot = !DoShoot;
                timer = 0;
            }
        }
        else
        {
            if (timer > reload / 4)
            {
                SpawnBullet();
                if (++DidShoot >= countBullet)
                {
                    DidShoot = 0;
                    DoShoot = !DoShoot;
                }

                timer = 0;
            }
        }

        if (!Shooting)
            range += (Time.deltaTime * 5);
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation));
        if (position.x * position.x + position.y * position.y < range)
            Shooting = true;
        else
            Shooting = false;
    }

    private void Move()
    {
        moveTime += Time.deltaTime;
        if (moveTime > 0.5)
        {
            float rotate;
            if (position.magnitude < 10)
                rotate = Random.Range(90, 270);
            else
                rotate = Random.Range(-90, 90);
            var rot = (rotation + rotate) / 180 * Mathf.PI;
            rb2D.velocity = new Vector2(Mathf.Cos(rot) * speed,
                Mathf.Sin(rot) * speed);
            moveTime = 0;
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            CurrentHealthPoint -= other.gameObject.GetComponent<ZombieScripts>().damage * Time.deltaTime;
            FindNearEnemy();
        }

        if (other.gameObject.tag == "Bullet")
        {
            FindNearEnemy();
            var damage = other.gameObject.GetComponent<BulletScript>().damage;
            if (damage < CurrentHealthPoint)
                CurrentHealthPoint -= damage;
            else
            {
                Destroy(gameObject);
                GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>().AddScore(score);
            }
        }
        
        if (other.gameObject.tag == "PlantBullet")
        {
            var damage = other.gameObject.GetComponent<PlantsBulletScript>().damage;
            if (damage < CurrentHealthPoint)
                CurrentHealthPoint -= damage;
        }

        if (CurrentHealthPoint <= 0)
        {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>().AddScore(1000);
        }
    }

    private void SpawnBullet()
    {
        if (boom)
            Instantiate(bulletBoom, transform.position, transform.rotation);
        else
            Instantiate(bullet, transform.position, transform.rotation);
    }

    private GameObject FindNearEnemy()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        GameObject nearPlant = null;
        foreach (var plant in GameObject.FindGameObjectsWithTag("Plant"))
        {
            if (nearPlant == null)
                nearPlant = plant;
            else if (nearPlant.transform.position.magnitude > plant.transform.position.magnitude)
                nearPlant = plant;
        }

        GameObject nearZombie = null;
        foreach (var zombie in GameObject.FindGameObjectsWithTag("Zombie"))
        {
            if (nearZombie == null)
                nearZombie = zombie;
            else if (nearZombie.transform.position.magnitude > zombie.transform.position.magnitude)
                nearZombie = zombie;
        }

        if (player.transform.position.magnitude < 18)
            return player;
        if (nearPlant.transform.position.magnitude < 28)
            return nearPlant;
        return nearZombie;
    }
}
