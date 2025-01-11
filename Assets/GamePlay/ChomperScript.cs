using UnityEngine;
using Classes;
using GamePlay;

public class ChomperScript : MonoBehaviour
{
    public float reload;
    public float range;
    public GameObject bullet;
    public int damageBullet;
    public int speedBullet;
    public int countBullet = 1;
    public int speed;
    private float MaxHealthPoint = 100;
    private float CurrentHealthPoint;
    private float timer;
    private bool DoShoot;
    private int DidShoot;
    public ParametersChomper[] NextEvolution;

    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<MovingScript>().speed = speed;
        NextEvolution = CreateParameters();
        CurrentHealthPoint = MaxHealthPoint;
    }

    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        timer += Time.deltaTime;

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
        if (NextEvolution == null || num >= NextEvolution.Length)
        {
            reload *= 0.9f;
            damageBullet *= 2;
            speedBullet *= 2;
            speed *= 2;
        }
        else
        {
            reload = NextEvolution[num].reload;
            range = NextEvolution[num].range;
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
    }

    private ParametersChomper[] CreateParameters()
    {

    }
}