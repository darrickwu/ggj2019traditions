using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineConeEventTalk : MonoBehaviour
{

    public ProgressFlag PineConeEventCollectFlag;

    public void TriggerEvent()
    {
        StartCoroutine(EventCoroutine());
    }

    public IEnumerator EventCoroutine()
    {
        if (Progress.Instance.GetProgressFlagState(PineConeEventCollectFlag) < 4)
        {
            yield return StartCoroutine(DialogSystem.Instance.ShowText(
                new DialogMessage
                {
                    CharacterName = "Dad",
                        Text = "I have a little project for us to do. Why don’t you go out and find some <color=\"red\">pine cones</color>? Look all over for them, they’re getting harder to find now."
                }
            ));
        }
        else
        {
            yield return StartCoroutine(DialogSystem.Instance.ShowText(
                new DialogMessage
                {
                    CharacterName = "Dad",
                        Text = "Wow, this is more than I expected, this will be great for the birds after we dip them in suet and roll them in bird seed. Hopefully we’ll see a few this year, I haven’t seen any birds since before you were born, Alex."
                }
            ));

            LevelTransition.Instance.NextLevel("Scenes/GameLevels/raspberries");
        }
    }
}