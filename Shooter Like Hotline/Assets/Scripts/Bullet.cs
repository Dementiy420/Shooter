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

        public void Shoot()
        {
            transform.Translate(speed * Time.deltaTime * Vector2.up);
        }
    }
}