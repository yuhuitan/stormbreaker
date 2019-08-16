using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/CheckPreviousState")]
public class CheckPreviousStateDecision : Decision
{
    public int previousState;

    public override bool Decide(StateController controller)
    {
        return CheckPreviousState(controller);
    }

    private bool CheckPreviousState(StateController controller)
    {
        if (controller.previousState == previousState)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}