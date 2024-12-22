using UnityEngine;
using UnityEngine.Serialization;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float liveTime = 5;
    public int speed;
    public int damage;
    private float time;

    private void Start()
    {
        damage = GameObject.FindGameObjectWithTag("Player").GetComponent<PeasScript>().damageBullet;
        damage = GameObject.FindGameObjectWithTag("Player").GetComponent<PeasScript>().speedBullet;
        rb2D.velocity = new Vector2(Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.PI / 180) * speed,
            Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.PI / 180) * speed);
    }

    void Update()
    {
        if (time > liveTime)
            Destroy(gameObject);
        time += Time.deltaTime;
    }
}