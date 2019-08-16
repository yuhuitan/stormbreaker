using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/StunAction")]
public class StunAction : Action
{
    public override void Act(StateController controller)
    {
        Stun(controller);
    }

    void Stun(StateController controller)
    {
        controller.anim.SetTrigger("stun");
        Debug.Log("Stun Action");
    }

}
