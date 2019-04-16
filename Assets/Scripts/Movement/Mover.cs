using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using RPG.Core;

namespace RPG.Movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Mover : MonoBehaviour, IAction
    {
        //[SerializeField] Transform target = null;

        NavMeshAgent nm = null;
        Animator an = null;

        void Start()
        {
            nm = GetComponent<NavMeshAgent>();
            an = GetComponent<Animator>();
        }

        void Update()
        {
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }

        public void MoveTo(Vector3 location)
        {
            nm.destination = location;
            nm.isStopped = false;
        }

        #region IAction overrides
        public void Cancel()
        {
            nm.isStopped = true;
        }

        public string GetName()
        {
            return name;
        }
        #endregion

        private void UpdateAnimator()
        {
            Vector3 velocity = nm.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity); // from world to player frame.
            an.SetFloat("forwardSpeed", localVelocity.z);
        }
    }
}
