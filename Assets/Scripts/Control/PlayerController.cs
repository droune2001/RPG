using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Combat;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        void Update()
        {
            if (InteractWithCombat()) return; // attack or hover a target
            if (InteractWithMovement()) return; // move or hover a moveable location.
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        GetComponent<Fighter>().Attack(target);
                    }
                    return true; // if attacking or even hovering a target, dont move.
                }
            }
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        private bool InteractWithMovement()
        {
            bool hasHit = Physics.Raycast(GetMouseRay(), out RaycastHit hit); // <== inlined declaration of local variable hit.
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Movement.Mover>().StartMoveAction(hit.point);
                }
                return true; // even if just hovering a possible move location.
            }
            return false;
        }
    }
}
