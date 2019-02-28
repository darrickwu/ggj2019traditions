using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaspberriesMomTalk : MonoBehaviour
{

    public ProgressFlag MomTalkFlag;
    public ProgressFlag ChristmasLightFlag;

    public void TriggerEvent()
    {
        StartCoroutine(EventCoroutine());
    }

    public IEnumerator EventCoroutine()
    {
        //6 of them
        if (Progress.Instance.GetProgressFlagState(ChristmasLightFlag) < 6)
        {
            yield return StartCoroutine(DialogSystem.Instance.ShowText(
                new DialogMessage
                {
                    CharacterName = "Mom",
                        Text = "The markets don’t have any fruits or vegetables anymore. Maybe you can find some <color=\"red\">raspberries</color> in the yard?"
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
                        Text = "It’s just enough to make a pie just like my grandma used to for the Fourth of July. I’m glad we kept the garden alive by pollinating it by hand."
                }
            ));
            LevelTransition.Instance.NextLevel("Scenes/GameLevels/YellowRibbon");
        }
    }
}