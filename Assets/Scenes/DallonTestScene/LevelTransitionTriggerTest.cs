using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransitionTriggerTest : MonoBehaviour
{
    public string ScenePath;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            LevelTransition.Instance.NextLevel(ScenePath, true);
        }
    }
}