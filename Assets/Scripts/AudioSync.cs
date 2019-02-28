using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSync : MonoBehaviour
{
    public AudioSource parent;
    public AudioSource[] children;
    // Update is called once per frame
    void Update()
    {
        foreach (var child in children)
        {
            child.timeSamples = parent.timeSamples;
        }
    }
}
