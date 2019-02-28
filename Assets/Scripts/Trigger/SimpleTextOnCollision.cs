using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleTextOnCollision : MonoBehaviour
{
    public DialogMessage[] Messages;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Invoke());
        }
    }

    private IEnumerator Invoke()
    {
        foreach (var message in Messages)
        {
            yield return DialogSystem.Instance.ShowText(message);
        }
    }
}