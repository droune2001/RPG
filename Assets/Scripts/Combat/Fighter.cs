using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RPG.Movement;
using RPG.Core;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] protected float weaponRange = 2.0f;

        [Header("Debug")]
        [SerializeField] Transform target = null;

        private void Update()
        {
            if (target != null)
            {
                if (!GetIsInRange())
                {
                    GetComponent<Mover>().MoveTo(target.position);
                }
                else
                {
                    GetComponent<Mover>().Cancel();
                }
            }
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(target.position, transform.position) < weaponRange;
        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }

        #region IAction overrides
        public void Cancel()
        {
            target = null;
        }

        public string GetName()
        {
            return name;
        }
        #endregion

    }
}
