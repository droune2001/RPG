using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] protected Transform target = null;

        void LateUpdate() // Late because we want to execute this after the navmesh/click
        {
            if (target)
            {
                transform.position = target.position;
            }
        }
    }
}
