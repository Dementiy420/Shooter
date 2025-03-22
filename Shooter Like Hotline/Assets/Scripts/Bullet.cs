using System;
using UnityEngine;

namespace Player
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 50.0f;

        void Update()
        {
            Shoot();
            Destroy(gameObject, 3.0f);
        }

        private void Shoot()
        {
            transform.Translate(speed * Time.deltaTime * Vector2.up);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Enemy")
                Destroy(col.gameObject);
        }
    }
}