using System.Collections;
using UnityEngine;

public class ChristmasLightSwitchEvent : MonoBehaviour
{
  public ProgressFlag MomTalkFlag;
  public ProgressFlag ChristmasLightFlag;

  public void TriggerEvent()
  {
    StartCoroutine(EventCoroutine());

  }

  public IEnumerator EventCoroutine()
  {
    if (Progress.Instance.GetProgressFlagState(MomTalkFlag) >= 1 &&
      Progress.Instance.GetProgressFlagState(ChristmasLightFlag) < 1)
    {
      GetComponent<AudioSource>().Play();
      Progress.Instance.IncrementProgressFlag(ChristmasLightFlag);
      yield return StartCoroutine(DialogSystem.Instance.ShowText(
        new DialogMessage
        {
            Text = "* You turned on the lights. Mom is going to be so proud!"
        }
      ));
    }

  }
}