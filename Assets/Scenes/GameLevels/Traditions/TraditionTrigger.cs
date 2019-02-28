using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraditionTrigger : MonoBehaviour
{
    public static readonly int TOTAL_TRADITIONS = 4;

    public ProgressFlag TraditionsFlag;
    public DialogMessage[] Messages;
    public bool Active = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Active)
        {
            StartCoroutine(HandleTrigger());
        }
    }

    private IEnumerator HandleTrigger()
    {
        foreach (var message in Messages)
        {
            yield return StartCoroutine(DialogSystem.Instance.ShowText(message));
        }
        Progress.Instance.IncrementProgressFlag(TraditionsFlag);
        if (Progress.Instance.GetProgressFlagState(TraditionsFlag) >= TOTAL_TRADITIONS)
        {
            yield return StartCoroutine(DialogSystem.Instance.ShowText(new DialogMessage()
            {
                CharacterName = "Alex",
                    Text = "This is where I grew up, Ava, and I’m going to teach you everything that made it a home. All of our traditions."
            }));
            LevelTransition.Instance.NextLevel("Scenes/MainMenu", true);
        }
        else
        {
            Active = false;
        }
    }
}