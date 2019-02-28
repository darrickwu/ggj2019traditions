using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(SyncCameraGroup))]
public class TraditionsCameraGroup : MonoBehaviour
{

  public Transform PlayerCharacter;
  public Transform[] TraditionTriggers;
  public float DistanceToShow = 35;
  private SyncCameraGroup syncCameraGroup;

  void Awake()
  {
    syncCameraGroup = GetComponent<SyncCameraGroup>();
  }

  void Update()
  {
    var list = new List<Transform>();
    list.Add(PlayerCharacter);

    foreach (var target in TraditionTriggers)
    {
      if (target &&
        (VectorMath.Flatten(target.position) -
          VectorMath.Flatten(PlayerCharacter.position)).sqrMagnitude <
        DistanceToShow * DistanceToShow)
      {
        list.Add(target);
      }
    }

    syncCameraGroup.Targets = list.ToArray();
  }
}