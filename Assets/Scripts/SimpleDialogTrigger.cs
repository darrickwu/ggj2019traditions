using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDialogTrigger : MonoBehaviour
{
    public DialogMessage[] Messages;
    public AudioSource soundEffect;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShowMessages());
        }
    }

    private IEnumerator ShowMessages()
    {
        if (soundEffect)
        {
            soundEffect.Play();
        }
        foreach (var message in Messages)
        {
            yield return StartCoroutine(DialogSystem.Instance.ShowText(message));
        }
    }
}