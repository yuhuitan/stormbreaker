using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTracker : MonoBehaviour
{
    [HideInInspector] public List<Vector3> playerPositions;
    [HideInInspector] public GameObject[] players;
    [HideInInspector] public Transform[] positions;

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("HAHAHAHAHHA");
        players = GameObject.FindGameObjectsWithTag("Player");
        positions = new Transform[players.Length];
        UpdatePosition();
       // Debug.Log(positions[0].transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        for (int i = 0; i < players.Length; i++)
        {
            positions[i] = players[i].transform;
        }
    }

    public Transform[] GetPositions()
    {
        return positions;
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }


}
