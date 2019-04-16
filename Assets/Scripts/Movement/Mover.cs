using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Mover : MonoBehaviour
{
    [SerializeField] Transform target = null;

    NavMeshAgent nm = null;
    Animator an = null;

    void Start()
    {
        nm = GetComponent<NavMeshAgent>();
        an = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            MoveToCursor();
        }

        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = nm.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity); // from world to player frame.
        an.SetFloat("forwardSpeed", localVelocity.z);
    }

    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hasHit = Physics.Raycast(ray, out RaycastHit hit); // <== inlined declaration of local variable hit.
        //Debug.DrawRay(ray.origin, ray.direction * 30.0f, Color.red, 1.0f);
        if (hasHit) //if (hit.collider)
        {
            nm.destination = hit.point;
        }
    }
}
