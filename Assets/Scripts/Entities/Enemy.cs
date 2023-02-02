using System;
using UnityEngine;

namespace Project
{
    [RequireComponent(typeof(Collider2D))]
    public class Enemy : Entity
    {
        public float MaxHealth = 2;
        public float Speed = 1;
        public event Action OnDeath;

        private Vector3 _objective = Vector3.zero;
        private Rigidbody2D _body;
        private float _health;

        public void TakeDamage(float damage)
        {
            if (damage > _health)
            {
                OnDeath?.Invoke();
                Destroy(gameObject);
                return;
            }

            _health -= damage;
        }

        private void Start()
        {
            _health = MaxHealth;
            _body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            transform.up = _objective - transform.position;
            _body.MovePosition(transform.position + transform.up * Speed * Time.deltaTime);
        }
    }
}
