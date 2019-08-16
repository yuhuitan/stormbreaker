using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/HitByBerserkBloodMode")]
public class HitByBerserkBloodModeDecision : Decision
{
    private Player player;
    private GameObject playerObject;
    private int playerState;
    private int skillIndex = 0;

    private void OnEnable()
    {
        // need to change to wind
        playerObject = GameObject.Find("Player1(Wind)");
       // Debug.Log(playerObject);
    }
    public override bool Decide(StateController controller)
    {
        return HitByWindInBerserkBloodMode(controller);
    }

    private bool HitByWindInBerserkBloodMode(StateController controller)
    {
        // TODO: Try to find a way to replace GetComponent as it will be resource heavy;
        // If hit by bullet, "basic" attack by Wind
        player = playerObject.GetComponent<Player>();
        playerState = player.state;
        if (controller.boss.hit && playerState == 1 && controller.boss.hitBySkillIndex == skillIndex)
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
