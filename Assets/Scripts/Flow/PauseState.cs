using UnityEngine;

public class PauseState : MonoBehaviour, IAutomaticSingleton
{
  public static PauseState Instance
  {
    get
    {
      return Singleton.GetInstance<PauseState>();
    }
  }

  public enum State
  {
    WALKING,
    PAUSED,
    TRANSITION,
    DIALOG
  }

  public State CurrentState;
}