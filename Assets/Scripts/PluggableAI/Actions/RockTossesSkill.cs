using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/RockTossesSkill")]
public class RockTossesSkill : Action
{
    public GameObject actionPrefab;
    public bool randomLocation = true;
    public GameObject locationsList;

    private Transform[] locations;
    private int current_index = -1;

    private void OnEnable()
    {
        locations = locationsList.GetComponentsInChildren<Transform>();
    }

    public override void Act(StateController controller)
    {
        Attack(controller);
    }

    void Attack(StateController controller)
    {
        current_index = controller.SelectLocationToAttack(randomLocation, locations.Length - 1, current_index);
        controller.anim.SetTrigger("rocktosses");
        Instantiate(actionPrefab, locations[current_index].position, locations[current_index].rotation);
        Debug.Log("RockTossesSkill");
    }
}
