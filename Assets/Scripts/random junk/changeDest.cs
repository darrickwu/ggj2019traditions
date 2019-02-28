using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeDest : MonoBehaviour
{
    public GameObject playerPt;
    public GameObject newDest;
    public float distance = 5f;
    public slapdashNPCMovement npcMove;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(playerPt.transform.position, transform.position) <= distance)
        {
            npcMove.wayPoint = newDest;
        }
    }
}
