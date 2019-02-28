using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour
{

  public TextMeshProUGUI textMesh;
  public TextMeshProUGUI nameText;
  public GameObject nameContainer;
  public Image nextIcon;
  public GameObject CloseSoundPrefab;
  public AudioSource TextSound;
  public float CharacterDelay = 0.05f;

  public IEnumerator ShowText(DialogMessage message)
  {
    bool hasName = !System.String.IsNullOrWhiteSpace(message.CharacterName);
    nameContainer.SetActive(hasName);
    if (hasName)
    {
      nameText.text = message.CharacterName;
    }
    var text = message.Text;
    nextIcon.enabled = false;
    TextSound.Play();
    for (int i = 0; i < text.Length; i++)
    {
      // try to skip formatting tags
      // this isn't particularly robust but it should be good enough for now
      if (text[i] == '<')
      {
        var closingBracket = text.IndexOf('>', i);
        i = closingBracket;
        continue;
      }
      textMesh.text = text.Substring(0, i);
      yield return new WaitForSecondsRealtime(CharacterDelay);
    }
    textMesh.text = text;
    nextIcon.enabled = true;
    TextSound.Stop();
    while (!Input.anyKeyDown)
    {
      // wait for user to close text box
      yield return null;
    }
    GameObject.Instantiate(CloseSoundPrefab, Vector3.zero, Quaternion.identity);
  }
}