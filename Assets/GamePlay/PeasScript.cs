using UnityEngine;
using Classes;
using GamePlay;

public class PeasScript : MonoBehaviour
{
    public float reload;
    public GameObject bullet;
    public int damageBullet;
    public int speedBullet;
    public int countBullet = 1;
    public int speed;
    public bool boom;
    private float MaxHealthPoint = 200;
    private float CurrentHealthPoint;
    private float timer;
    private bool DoShoot;
    private int DidShoot;
    public ParametersPeas[] NextEvolution;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<MovingScript>().speed = speed;
        DidShoot = 0;
        NextEvolution = CreateParameters();
        CurrentHealthPoint = MaxHealthPoint;
    }

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        timer += Time.deltaTime;
        if (!DoShoot)
        {
            if (Input.GetMouseButton(0) && timer > reload)
            {
                Instantiate(bullet, transform.position, transform.rotation);
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
                Instantiate(bullet, transform.position, transform.rotation);
                if (++DidShoot >= countBullet)
                {
                    DidShoot = 0;
                    DoShoot = !DoShoot;
                }
                timer = 0;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Zombie")
            CurrentHealthPoint -= other.gameObject.GetComponent<ZombieScripts>().damage * Time.deltaTime;
        if (CurrentHealthPoint <= 0)
        {
            gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>().GameOver();
        }
    }

    public void NextChoice(int num)
    {
        if (NextEvolution == null || num >= NextEvolution.Length);
        else
        {
            reload = NextEvolution[num].reload;
            if (NextEvolution[num].bullet != null)
                bullet.GetComponent<SpriteRenderer>().sprite = NextEvolution[num].bullet;
            damageBullet = NextEvolution[num].damageBullet;
            speedBullet = NextEvolution[num].speedBullet;
            countBullet = NextEvolution[num].countBullet;
            GameObject.FindGameObjectWithTag("Player").GetComponent<MovingScript>().speed = NextEvolution[num].speed;
            MaxHealthPoint = NextEvolution[num].Health;
            CurrentHealthPoint = NextEvolution[num].Health;
            gameObject.GetComponent<SpriteRenderer>().sprite = NextEvolution[num].evolution;
            if (NextEvolution[num].bullet != null)
                bullet.gameObject.GetComponent<SpriteRenderer>().sprite = NextEvolution[num].bullet;
            if (NextEvolution[num].nextEvolution != null)
                NextEvolution = NextEvolution[num].nextEvolution;
        }
        GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>().choice.SetActive(false);

        foreach (var element in GameObject.FindGameObjectsWithTag("Choisen"))
            Destroy(element);
    }

    private ParametersPeas[] CreateParameters()
    {
        var fin = new ParametersPeas(0.25f,
            GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>().BulletPeas[1],
            120, 80, 45, 400.0f, true,
            GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>().SpritesPeas[3],
            4, null);
        return new[]
        {
            new ParametersPeas(0.4f, null, 45, 80, 45, 250.0f, false,
                GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>().SpritesPeas[0],
                2, new[]
                {
                    new ParametersPeas(0.3f, null, 90, 80, 45, 300.0f, false,
                        GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>().SpritesPeas[1],
                        4, new[] { fin }),
                    new ParametersPeas(0.3f,
                        GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>().BulletPeas[1],
                        60, 80, 45, 250.0f, true,
                        GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>().SpritesPeas[2],
                        1, new[] { fin })
                })
        };
    }
}