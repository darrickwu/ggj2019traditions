using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slapdashNPCMovement : MonoBehaviour
{

    public GameObject wayPoint;
    private Vector3 wayPointPos;
    public float speed = 6.0f;
    public float distance = 5f;


    void Update()
    {
        if (Vector3.Distance(wayPoint.transform.position, transform.position) > distance)
        {


            wayPointPos = new Vector3(wayPoint.transform.position.x, wayPoint.transform.position.y, wayPoint.transform.position.z);

            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);

        }
    }
}
