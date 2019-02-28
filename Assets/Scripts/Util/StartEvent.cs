using UnityEngine;
using UnityEngine.Events;

public class StartEvent : MonoBehaviour
{
  public UnityEvent OnStart;
  public float WaitSeconds = 1;

  void Start()
  {
    Invoke("Trigger", WaitSeconds);
  }

  private void Trigger()
  {
    OnStart.Invoke();
  }
}