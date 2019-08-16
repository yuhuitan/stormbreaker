using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCloud : MonoBehaviour

{
    private Transform player;
    public GameObject cloud;


    private void Start()
    {
        player = transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {

            Instantiate(cloud, player.position, player.rotation);
        }
    }
}

