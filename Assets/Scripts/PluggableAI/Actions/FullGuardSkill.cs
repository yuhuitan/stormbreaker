using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/FullGuardSkill")]
public class FullGuardSkill : Action
{
    //public GameObject actionPrefab;

    public override void Act(StateController controller)
    {
        Guard(controller);
    }

    void Guard(StateController controller)
    {
        // The condition for only receiving damage at head is in Boss.cs
        // here reset the boxTrigger back to false
        // controller.boss.boxTrigger = false;
        // Always played until the boss quit this state
        if (controller.currentState.stateIndex == 2)
        {
            controller.anim.SetTrigger("fullguardnormal");
        }
        else if (controller.currentState.stateIndex == 4)
        {
            controller.anim.SetTrigger("fullguardfrenzy");
        }
        //controller.anim.SetTrigger("fullguard");
        Debug.Log("Trigger: " + controller.boss.boxTrigger);
        Debug.Log("FullGuardSkill");
    }
}
