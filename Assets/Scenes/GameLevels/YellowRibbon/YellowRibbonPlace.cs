using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowRibbonPlace : MonoBehaviour
{
    public SpriteRenderer RibbonSprite;
    public AudioSource PlaceSound;

    public void HandleTrigger()
    {
        StartCoroutine(_HandleTrigger());
    }

    private IEnumerator _HandleTrigger()
    {
        RibbonSprite.enabled = true;
        PlaceSound.Play();
        yield return StartCoroutine(DialogSystem.Instance.ShowText(
            new DialogMessage
            {
                CharacterName = "Alex",
                    Text = "I’m sorry I won’t be here when you get home, Mom. I still make that pie, but it’ll never be as good as yours. Please come back, we miss you."
            }
        ));
        LevelTransition.Instance.NextLevel("Scenes/GameLevels/Traditions");
    }
}