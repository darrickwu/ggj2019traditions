using System.Collections.Generic;
using UnityEngine;

public class Progress : MonoBehaviour, IAutomaticSingleton
{
  public static Progress Instance
  {
    get
    {
      return Singleton.GetInstance<Progress>();
    }
  }

  public Dictionary<string, int> ProgressFlagState;

  void Awake()
  {
    DontDestroyOnLoad(gameObject);
    ProgressFlagState = new Dictionary<string, int>();
  }

  public int GetProgressFlagState(ProgressFlag progressFlag)
  {
    if (ProgressFlagState.ContainsKey(progressFlag.name))
    {
      return ProgressFlagState[progressFlag.name];
    }
    else
    {
      return 0;
    }
  }

  public void IncrementProgressFlag(ProgressFlag progressFlag)
  {
    if (ProgressFlagState.ContainsKey(progressFlag.name))
    {
      ProgressFlagState[progressFlag.name] += 1;
    }
    else
    {
      ProgressFlagState[progressFlag.name] = 1;
    }
  }
}