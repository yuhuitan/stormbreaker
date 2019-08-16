using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/HitByFusion")]
public class HitByFusionSkillDecision : Decision
{
    private int skillIndex = 1;

    // TODO: Maybe can combine with HitByBerserkBloodMode
    public override bool Decide(StateController controller)
    {
        return HitByWindInBerserkBloodMode(controller);
    }

    private bool HitByWindInBerserkBloodMode(StateController controller)
    {
        if (controller.boss.hit && controller.boss.hitBySkillIndex == skillIndex)
        {
            controller.boss.hit = false;
            return true;
        }
        else
        {
            controller.boss.hit = false;
            return false;
        }

    }
}
