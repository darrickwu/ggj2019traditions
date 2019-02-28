using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowRibbonDadTalk : MonoBehaviour
{
    public ProgressFlag DisableOnFlag;
    public ProgressFlag EnableOnFlag;
    public ProgressFlag IncrementFlag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(HandleTrigger());
        }
    }

    private IEnumerator HandleTrigger()
    {
        bool triggerEnabled = (!DisableOnFlag || Progress.Instance.GetProgressFlagState(DisableOnFlag) == 0) &&
            (!EnableOnFlag || Progress.Instance.GetProgressFlagState(EnableOnFlag) >= 1);

        if (triggerEnabled)
        {
            yield return StartCoroutine(DialogSystem.Instance.ShowText(
                new DialogMessage
                {
                    CharacterName = "Dad",
                        Text = "The <color=\"red\">ribbon</color> is looking a bit worn out, your Mom’s been deployed six times. Why don’t you do the honors this year, Alex?"
                }
            ));
            yield return StartCoroutine(DialogSystem.Instance.ShowText(
                new DialogMessage
                {
                    CharacterName = "Dad",
                        Text = "Tie the ribbon around the <color=\"red\">front tree</color> so she knows we’re here when she gets home."
                }
            ));

            if (IncrementFlag)
            {
                Progress.Instance.IncrementProgressFlag(IncrementFlag);
            }
        }

    }
}