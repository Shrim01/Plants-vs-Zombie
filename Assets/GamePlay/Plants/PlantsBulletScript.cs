using UnityEngine;

public class PlantsBulletScript : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float liveTime = 5;
    public int speed;
    public int damage;
    public bool through = true;
    public bool boom;
    private float time;


    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        damage = GameObject.FindGameObjectWithTag("Plant").GetComponent<PlantsScript>().bulletDamage;
        speed = GameObject.FindGameObjectWithTag("Player").GetComponent<PeasScript>().speedBullet;
        rb2D.velocity = new Vector2(Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.PI / 180) * speed,
            Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.PI / 180) * speed);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!through && other.gameObject.tag!="Plant")
            Destroy(gameObject);
    }
}
