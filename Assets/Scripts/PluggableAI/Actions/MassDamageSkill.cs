using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/MassDamageSkill")]
public class MassDamageSkill : Action
{
    public GameObject[] actionPrefab;
    public bool randomLocation = true;
    public GameObject leftLocations;
    public GameObject rightLocations;

    private Transform[] leftPositions;
    private Transform[] rightPositions;
    private int locationsLength = 2;
    private int current_index = -1;
    private int chosen;

    private void OnEnable()
    {
        leftPositions = leftLocations.GetComponentsInChildren<Transform>();
        rightPositions = rightLocations.GetComponentsInChildren<Transform>();
    }

    public override void Act(StateController controller)
    {
        Attack(controller);
    }

    void Attack(StateController controller)
    {
        controller.anim.SetTrigger("massdamage");
        Debug.Log("Length Left Position: " + leftPositions.Length);
        Debug.Log("Length Right Position: " + rightPositions.Length);
        current_index = controller.SelectLocationToAttack(randomLocation, locationsLength, current_index);
        if (current_index == 1)
        {
            PlaySkill(leftPositions);
        }
        else
        {
            PlaySkill(rightPositions);
        }
        Debug.Log("MassDamageSkill");
    }

    void PlaySkill(Transform[] positions)
    {
        for (int i = 0; i < positions.Length; i++)
        {
            if (i == 0)
            {
                continue;
            }
            Debug.Log(positions[i].transform.position);
            chosen = Random.Range(0, actionPrefab.Length-1);
            Debug.Log("Chosen: " + chosen);
            Instantiate(actionPrefab[chosen], positions[i].transform.position, positions[i].transform.rotation);
        }

    }
}
