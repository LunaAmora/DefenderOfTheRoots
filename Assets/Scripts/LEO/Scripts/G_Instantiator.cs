using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{
    public class G_Instantiator : MonoBehaviour
    {
        [SerializeField] GameObject collectorTurret_Prefab;
        [SerializeField] GameObject genericTurret_Prefab;


        public GameObject InstantiateTurret(TurretType _turretType, Vector3 _pos)
        {
            GameObject _goToReturn = null;

            switch (_turretType)
            {
                case TurretType.Collector:
                    _goToReturn = Instantiate(collectorTurret_Prefab, _pos, Quaternion.identity);
                    break;
                case TurretType.Generic:
                    _goToReturn = Instantiate(genericTurret_Prefab, _pos, Quaternion.identity);
                    break;

                default:
                    break;
            }

            return _goToReturn;
        }

    }
}
