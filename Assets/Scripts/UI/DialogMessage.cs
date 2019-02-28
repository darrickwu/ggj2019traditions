[System.Serializable]
public struct DialogMessage
{
  public string CharacterName;
  public string Text;

  public DialogMessage(string characterName, string text)
  {
    CharacterName = characterName;
    Text = text;
  }
}