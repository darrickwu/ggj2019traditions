using System.Collections;
using UnityEngine;

public class PineConeEvent : MonoBehaviour
{
  public ProgressFlag PineConeEventCollectFlag;
  public AudioSource pickupSound;

  public void TriggerEvent()
  {
    StartCoroutine(EventCoroutine());
  }

  public IEnumerator EventCoroutine()
  {
    Progress.Instance.IncrementProgressFlag(PineConeEventCollectFlag);
    if (pickupSound)
      pickupSound.Play();
    if (Progress.Instance.GetProgressFlagState(PineConeEventCollectFlag) > 3)
    {
      yield return StartCoroutine(DialogSystem.Instance.ShowText(
        new DialogMessage
        {
          Text = "* You got all the pinecones"
        }
      ));
    }

    Destroy(this.gameObject);
    yield return null;
  }
}