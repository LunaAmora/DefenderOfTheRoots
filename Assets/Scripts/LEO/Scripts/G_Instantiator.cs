using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class G_Instantiator : MonoBehaviour
    {
        [SerializeField] GameObject collectorTurret_Prefab;
        [SerializeField] GameObject machinegunTurret_Prefab;
        [SerializeField] GameObject sniperTurret_Prefab;
        [SerializeField] GameObject shotgunTurret_Prefab;


        public void InstantiateTurret(TurretType _turretType, Vector3 _pos)
        {
            switch (_turretType)
            {
                case TurretType.Collector:
                    Instantiate(collectorTurret_Prefab, _pos, Quaternion.identity);
                    break;
                case TurretType.Machinegun:
                    Instantiate(machinegunTurret_Prefab, _pos, Quaternion.identity);
                    break;
                case TurretType.Sniper:
                    Instantiate(sniperTurret_Prefab, _pos, Quaternion.identity);
                    break;
                case TurretType.Shotgun:
                    Instantiate(shotgunTurret_Prefab, _pos, Quaternion.identity);
                    break;

                default:
                    break;
            }
        }

    }
}
