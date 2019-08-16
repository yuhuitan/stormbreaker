using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/SwordSummonSkill")]
public class SwordSummonSkill : Action
{
    public GameObject actionPrefab;
    public GameObject playersPositionTracker;

    private GameObject[] players;
    private Transform[] locations;

    private void OnEnable()
    {
        // Try to see if can restructure this
        players = GameObject.FindGameObjectsWithTag("Player");
        locations = new Transform[players.Length];
        for (int i = 0; i < players.Length; i++)
        {
            locations[i] = players[i].transform;
        }
    }

    public override void Act(StateController controller)
    {
        Attack(controller);
    }

    void Attack(StateController controller)
    {
        //controller.anim.SetTrigger("swordsummon");
        // TODO: Need to change the coordinate to above the players, change the Y coordinate can already
        foreach (Transform location in locations)
        {
            Vector3 newPosition = new Vector3(location.transform.position.x, location.transform.position.y + 10, 0);
            Instantiate(actionPrefab, newPosition, playersPositionTracker.transform.rotation);
        }
        Debug.Log("SwordSummonSkill");
    }

}