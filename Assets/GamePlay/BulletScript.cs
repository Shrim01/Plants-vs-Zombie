using UnityEngine;
using UnityEngine.Serialization;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float liveTime = 5;
    public int speed;
    public int damage;
    public LogicScript logic;
    public bool through;
    private float time;

    private void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        damage = GameObject.FindGameObjectWithTag("Player").GetComponent<PeasScript>().damageBullet;
        speed = GameObject.FindGameObjectWithTag("Player").GetComponent<PeasScript>().speedBullet;
        rb2D.velocity = new Vector2(Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.PI / 180) * speed,
            Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.PI / 180) * speed);
    }

    void Update()
    {
        if (time > liveTime)
            Destroy(gameObject);
        time += Time.deltaTime;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (!through && other.gameObject.tag!="Player")
            Destroy(gameObject);
    }
}