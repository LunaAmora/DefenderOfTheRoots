using UnityEngine;

namespace Project
{
    [RequireComponent(typeof(TurretMode))]
    [RequireComponent(typeof(TurretScan))]
    public class Turret : Entity
    {
        public float Damage = 1;
        public float Frenquency = 3;

        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (value && !_isActive)
                {
                    StartScan();
                }

                _isActive = value;
            }
        }

        private bool _isActive = true;
        private TurretScan _scan;
        private TurretMode _turretMode;

        private float _delay => 1 / Frenquency;

        private void Start()
        {
            _scan = GetComponent<TurretScan>();
            _turretMode = GetComponent<TurretMode>();
            ScanShoot();
        }

        private void StartScan() => gameObject.LeanDelayedCall(_delay, ScanShoot);

        private void ScanShoot()
        {
            if (!IsActive) return;

            if (_scan?.Scan() is { } target)
            {
                _turretMode?.Activate(target);
            }

            StartScan();
        }
    }
}
