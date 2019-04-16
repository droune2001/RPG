using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class ActionScheduler : MonoBehaviour
    {
        IAction prevAction = null;

        public void StartAction(IAction action)
        {
            if (action == prevAction) return;
            if (prevAction != null)
            {
                Debug.Log("Cancel Action " + prevAction.ToString());
                prevAction.Cancel();
            }
            prevAction = action;
        }
    }
}
