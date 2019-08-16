using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/HealingSkill")]
public class HealingSkill : Action
{

    private int totalHealth;
    private int currentHealth;
    private int expectedHealth;

    public override void Act(StateController controller)
    {
        controller.instance.StartCoroutine(Heal(controller));
    }

    IEnumerator Heal(StateController controller)
    {
        totalHealth = controller.boss.total_health;
        currentHealth = controller.boss.health;
        expectedHealth = totalHealth / 10 * 7;
        while ((controller.currentState.stateIndex == 4 &&  currentHealth < totalHealth)|| (controller.currentState.stateIndex == 2 && currentHealth < totalHealth))
        {
            totalHealth = controller.boss.total_health;
            currentHealth = controller.boss.health;
            if (currentHealth <= expectedHealth)
            {
                currentHealth = currentHealth + 10;
                if (currentHealth > totalHealth)
                {
                    currentHealth = totalHealth;
                }
                controller.boss.health = currentHealth;
                yield return new WaitForSeconds(3);
            }
            Debug.Log("Healing Skill");
        }
 
    }
}
