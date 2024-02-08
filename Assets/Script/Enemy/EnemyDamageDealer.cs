using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class EnemyDamageDealer : MonoBehaviour
    {
        bool canDealDamage;
        bool hasDealtDamage;

        [SerializeField] float weaponLength;
        [SerializeField] int weaponDamage;
        // Start is called before the first frame update
        void Start()
        {
            canDealDamage = false;
            hasDealtDamage = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (canDealDamage && !hasDealtDamage)
            {
                RaycastHit hit;

                int layerMask = 1 << LayerMask.NameToLayer("Player");
                if (Physics.Raycast(transform.position, -transform.up, out hit, weaponLength, layerMask))
                {
                    if (hit.transform.TryGetComponent(out PlayerStats stats))
                    {
                        stats.TakeDamage(weaponDamage);
                        stats.HitVFX(hit.point);
                        hasDealtDamage = true;
                    }
                }
            }
        }

        public void StartDealDamage()
        {
            canDealDamage = true;
            hasDealtDamage = false;
        }

        public void EndDealDamage()
        {
            canDealDamage = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(transform.position, transform.position - transform.up * weaponLength);
        }
    }
}
