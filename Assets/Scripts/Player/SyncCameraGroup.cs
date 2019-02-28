using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;

public class SyncCameraGroup : MonoBehaviour
{
  public CinemachineTargetGroup TargetGroup;
  public float WeightFadeRate = 1.5f;
  public Transform PlayerCharacter;
  public float MaxDistance = 45;
  public Transform[] Targets;

  void Awake()
  {
    if (!TargetGroup)
    {
      TargetGroup = GetComponent<CinemachineTargetGroup>();
    }
  }

  void Update()
  {
    // sync the desired list with the current one, fading in new items' weights
    var newTargetList = new List<CinemachineTargetGroup.Target>();
    foreach (var item in Targets)
    {
      if (!item || IsTooFarAway(item))
      {
        continue;
      }
      var currentTarget = TargetGroup.m_Targets.FirstOrDefault(x => x.target == item);
      float currentWeight = 0;
      if (currentTarget.target != null)
      {
        currentWeight = currentTarget.weight;
        if (currentWeight < 1)
        {
          currentWeight = Mathf.Min(1, currentWeight + Time.deltaTime * WeightFadeRate);
        }
      }
      newTargetList.Add(new CinemachineTargetGroup.Target() { target = item, weight = currentWeight });
    }
    // and fade out anything that's missing, and remove anything that's too far away
    foreach (var existingTarget in TargetGroup.m_Targets)
    {
      if (existingTarget.target &&
        !Targets.Contains(existingTarget.target) &&
        !IsTooFarAway(existingTarget.target))
      {
        var newTarget = existingTarget;
        newTarget.weight -= WeightFadeRate * Time.deltaTime;
        if (newTarget.weight > 0)
        {
          newTargetList.Add(newTarget);
        }
      }
    }

    TargetGroup.m_Targets = newTargetList.ToArray();
  }

  private bool IsTooFarAway(Transform target)
  {
    return (
      VectorMath.Flatten(target.position) -
      VectorMath.Flatten(PlayerCharacter.position)
    ).sqrMagnitude > MaxDistance * MaxDistance;
  }
}