using UnityEngine;

namespace Project
{
    [RequireComponent(typeof(TurretMode))]
    [RequireComponent(typeof(TurretScan))]
    public class Turret : Entity
    {
        public float Damage = 1;
        public float Frenquency = 1;
        public bool IsActive = true;

        private TurretScan _scan;
        private TurretMode _turretMode;

        void Start()
        {
            _scan = GetComponent<TurretScan>();
            _turretMode = GetComponent<TurretMode>();
        }

        void Update()
        {
            if (!IsActive) return;

            // Todo: Call Scan() based on the Frequency
            if (_scan?.Scan() is { } target)
            {
                _turretMode?.Activate(target);
            }
        }
    }
}
