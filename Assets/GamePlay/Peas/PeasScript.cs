using UnityEngine;

public class PeasScript : MonoBehaviour
{

    public int damageBullet = 10;
    public int speedBullet = 100;
    public float reload;
    public GameObject bullet;
    private float MaxHealthPoint = 100;
    private float CurrentHealthPoint;
    private float timer;

    void Start()
    {
        CurrentHealthPoint = MaxHealthPoint;
    }

    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && timer > reload)
        {
            Instantiate(bullet, transform.position, gameObject.GetComponentInParent<Transform>().rotation);
            timer = 0;
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
        Debug.Log(CurrentHealthPoint);
    }

    
}