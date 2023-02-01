using System;
using UnityEngine;

namespace Project
{
    [RequireComponent(typeof(Collider2D))]
    public class Enemy : Entity
    {
        public float MaxHealth = 10;
        public float Velocity = 1;
        public event Action OnDeath;

        private Vector2 _objective;
        private float _health;

        void Start()
        {
            _health = MaxHealth;
        }

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
    }
}
