using UnityEngine;

public class EnableOnProgress : MonoBehaviour
{
  public enum ComparisonType
  {
    AT_LEAST,
    NO_MORE_THAN,
    EXACTLY,
  }

  public ProgressFlag ProgressFlag;
  public ComparisonType Comparison;
  public int TargetState;

  public GameObject[] ObjectsToManage;

  void Start()
  {
    CheckProgressFlags();
  }

  void Update()
  {
    CheckProgressFlags();
  }

  private void CheckProgressFlags()
  {
    var progressFlagState = Progress.Instance.GetProgressFlagState(ProgressFlag);
    bool shouldEnable = false;
    switch (Comparison)
    {
      case ComparisonType.AT_LEAST:
        shouldEnable = progressFlagState >= TargetState;
        break;
      case ComparisonType.NO_MORE_THAN:
        shouldEnable = progressFlagState <= TargetState;
        break;
      case ComparisonType.EXACTLY:
        shouldEnable = progressFlagState == TargetState;
        break;
    }
    foreach (var obj in ObjectsToManage)
    {
      obj.SetActive(shouldEnable);
    }
  }
}