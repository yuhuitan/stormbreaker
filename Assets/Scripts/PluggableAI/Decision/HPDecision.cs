using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/CheckHP")]
public class HPDecision : Decision
{
    public int HP_percentage;
    private float current_HP_Percentage;

    public override bool Decide(StateController controller)
    {
        return CheckHP(controller);
    }

    private bool CheckHP(StateController controller)
    {
        //Debug.Log("Current Boss Health: " + controller.boss.health);
        current_HP_Percentage = ((float)controller.boss.health / controller.boss.total_health) * 100;
        //current_HP_Percentage = (controller.healthObject.total_health / controller.healthObject.current_health) * 100;
        if (current_HP_Percentage <= HP_percentage)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

