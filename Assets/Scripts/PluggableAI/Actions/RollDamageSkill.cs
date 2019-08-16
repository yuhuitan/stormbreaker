using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/RollDamageSkill")]
public class RollDamageSkill : Action
{
   // public GameObject actionPrefab;
   // public bool randomLocation = false;
 //   public GameObject locationsList;

    //private Transform[] locations;
    private int current_index = -1;

    private void OnEnable()
    {
    //    locations = locationsList.GetComponentsInChildren<Transform>();
    }

    public override void Act(StateController controller)
    {
        Attack(controller);
    }

    void Attack(StateController controller)
    {
        // Default 0 is Left, 1 is Right
        // TODO, make it more flexible
        // Should be calling animation here instead
        controller.anim.SetTrigger("roll");
        current_index = Random.Range(0, 1);
        //current_index = controller.SelectLocationToAttack(randomLocation, locations.Length - 1, current_index);
        if (current_index==0)
        {
            controller.anim.SetTrigger("handsmashleft");
        }
        else
        {
            controller.anim.SetTrigger("handsmashright");
        }

       // Instantiate(actionPrefab, locations[current_index].position, locations[current_index].rotation);
        Debug.Log("RollDamageSkill/HandSmashSkill");

    }
}
