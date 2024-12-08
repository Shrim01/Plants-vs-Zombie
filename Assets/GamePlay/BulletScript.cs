using UnityEngine;
using UnityEngine.Serialization;

public class BulletScript : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public int speed = 100;
    public float liveTime = 5;
    [FormerlySerializedAs("damege")] public int damage;
    private float time;

    private void Start()
    {
        damage = 10;
        gameObject.tag = "Bullet";
    }

    void Update()
    {
        rb2D.AddForce(new Vector2(Mathf.Cos(transform.rotation.eulerAngles.z * Mathf.PI / 180) * speed,
            Mathf.Sin(transform.rotation.eulerAngles.z * Mathf.PI / 180) * speed));
        if (time > liveTime)
            Destroy(gameObject);
        time += Time.deltaTime;
    }
}