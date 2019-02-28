using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetProgress : MonoBehaviour
{
    void Start()
    {
        GameObject.Destroy(Progress.Instance.gameObject);
    }

}