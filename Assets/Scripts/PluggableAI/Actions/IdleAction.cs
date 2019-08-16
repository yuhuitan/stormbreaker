using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/IdleAction")]
public class IdleAction : Action
{


    public override void Act(StateController controller)
    {
        Idle(controller);
    }

    void Idle(StateController controller)
    {
        controller.anim.SetTrigger("idle");
      //  Debug.Log("set trigger");
       // Debug.Log("Idle");
    }
}