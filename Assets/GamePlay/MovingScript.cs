using UnityEngine;

namespace GamePlay
{
    public class MovingScript : MonoBehaviour
    {
        public Rigidbody2D rb2D;
        public float speed = 10f;
        private readonly float resist = 0.98f;

        void Update()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            if (horizontal != 0)
                rb2D.AddForce(new Vector2(horizontal * speed, 0));
            if (vertical != 0)
                rb2D.AddForce(new Vector2(0, vertical * speed));
            rb2D.velocity *= resist;
        }


        private void Rotate()
        {
            var position = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
            var rotation = Mathf.Atan(position.y / position.x) * 180 / Mathf.PI;
            if (position.x < 0)
                rotation += 180;
            transform.rotation = Quaternion.Euler(0, 0, rotation);
        }
    }
}
