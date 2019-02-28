using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerChild : MonoBehaviour
{
    SpriteRenderer mysprite;
    public float MAX_DISTANCE = 1.1f;
    private GameObject toFollow;
    public Sprite walk1;
    public Sprite walk2;
    public Sprite idle;
    bool animating = false;
    public float animationSpeed = 0.3f;

    void Awake()
    {
        toFollow = GameObject.FindGameObjectsWithTag ("Player") [0];
        mysprite = gameObject.GetComponent <SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 followSpot = toFollow.transform.position;
        float dist = Vector3.Distance (followSpot, transform.position);
        // 0.001f to reduce floating point rounding errors
        if (dist <= MAX_DISTANCE + 0.001f)
        {
            mysprite.sprite = idle;
            return;
        }

        // moving
        if (!animating)
        {
            StartCoroutine("animate", animationSpeed);
            animating = true;
        }

        Vector3 moveDir = (followSpot - transform.position).normalized;
        transform.position += moveDir * (dist - MAX_DISTANCE);
    }

    IEnumerator animate(float waitTime)
    {
        if (mysprite.sprite == walk1)
        {
            mysprite.sprite = walk2;
        }
        else
        {
            mysprite.sprite = walk1;
        }

        yield return new WaitForSeconds(waitTime);
        animating = false;
    }
}
