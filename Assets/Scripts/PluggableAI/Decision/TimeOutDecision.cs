using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/TimeOut")]
public class TimeOutDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        return IsTimeOut(controller);
    }

    private bool IsTimeOut(StateController controller)
    {
        return controller.CheckIfCountDownElapsed(controller.currentState.timeout);
    }
}
