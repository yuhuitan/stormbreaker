using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFollow : MonoBehaviour
{
    private GameObject player;
    private Transform playerPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.transform;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = playerPosition.transform.position;
    }
}
