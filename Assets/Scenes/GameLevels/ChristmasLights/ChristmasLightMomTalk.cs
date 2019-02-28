using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristmasLightMomTalk : MonoBehaviour
{

    public ProgressFlag MomTalkFlag;
    public ProgressFlag ChristmasLightFlag;

    public void TriggerEvent()
    {
        StartCoroutine(EventCoroutine());
    }

    public IEnumerator EventCoroutine()
    {
        if (Progress.Instance.GetProgressFlagState(ChristmasLightFlag) < 1)
        {
            yield return StartCoroutine(DialogSystem.Instance.ShowText(
                new DialogMessage
                {
                    CharacterName = "Mom",
                        Text = "This place will feel like home before you know it, Alex. Why don’t you turn on the <color=\"red\">tree</color> lights?"
                }
            ));
            if (Progress.Instance.GetProgressFlagState(MomTalkFlag) == 0)
            {
                Progress.Instance.IncrementProgressFlag(MomTalkFlag);
            }
        }
        else
        {
            yield return StartCoroutine(DialogSystem.Instance.ShowText(
                new DialogMessage
                {
                    CharacterName = "Mom",
                        Text = "There’s that glow I love, it’s a shame we can only have them on for an hour."
                }
            ));
            LevelTransition.Instance.NextLevel("Scenes/GameLevels/PineConesEvent");
        }
    }
}