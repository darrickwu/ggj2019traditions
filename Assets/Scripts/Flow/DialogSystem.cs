using System.Collections;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
  public static DialogSystem Instance
  {
    get
    {
      return Singleton.GetExistingInstance<DialogSystem>();
    }
  }

  public TextBox TextBox;

  void Start()
  {
    TextBox.gameObject.SetActive(false);
  }

  public IEnumerator ShowText(DialogMessage message)
  {
    var prevState = PauseState.Instance.CurrentState;
    TextBox.gameObject.SetActive(true);
    PauseState.Instance.CurrentState = PauseState.State.DIALOG;
    yield return StartCoroutine(TextBox.ShowText(message));
    TextBox.gameObject.SetActive(false);
    PauseState.Instance.CurrentState = prevState;
  }

  public void StartShowText(DialogMessage message)
  {
    StartCoroutine(ShowText(message));
  }
}