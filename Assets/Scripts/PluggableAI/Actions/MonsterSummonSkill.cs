using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/MonsterSummonSkill")]
public class MonsterSummonSkill : Action
{
    public GameObject actionPrefab;
    public GameObject animPrefab;
    public bool randomLocation = true;
    public GameObject locationsList;
    public int monsterAmount;

    private Transform[] locations;
    private int current_index = -1;

    // TODO: Maybe can combine with rocktossesskill
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
        //controller.anim.SetTrigger("monstersummon");
        Instantiate(animPrefab, animPrefab.transform.position, animPrefab.transform.rotation);
        current_index = controller.SelectLocationToAttack(randomLocation, locations.Length - 1, current_index);
        for (int i = 0; i < monsterAmount; i++)
        {
            Instantiate(actionPrefab, locations[current_index].position, locations[current_index].rotation);
        }
        Debug.Log("MonsterSummonSkill");
    }
}
