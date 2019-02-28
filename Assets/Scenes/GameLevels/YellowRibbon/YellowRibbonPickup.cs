using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowRibbonPickup : MonoBehaviour
{
    public ProgressFlag PickupFlag;
    public GameObject ParentToDisable;
    public AudioSource PickupSound;

    public void HandleTrigger()
    {
        StartCoroutine(_HandleTrigger());
    }

    private IEnumerator _HandleTrigger()
    {
        Progress.Instance.IncrementProgressFlag(PickupFlag);
        ParentToDisable.SetActive(false);
        PickupSound.Play();
        yield return null;
    }
}