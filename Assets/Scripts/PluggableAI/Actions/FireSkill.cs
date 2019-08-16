﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/FireSkill")]
public class FireSkill : Action
{
    public GameObject actionPrefab;
    public GameObject locationsList;

    private Transform[] locations;

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
        for (int i = 0; i < locations.Length; i++)
        {
            if (i == 0)
            {
                continue;
            }
            Destroy(Instantiate(actionPrefab, locations[i].transform.position, locations[i].transform.rotation),5);
            
        }
        Debug.Log("FireSkill");
    }
}
