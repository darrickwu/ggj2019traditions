using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(SyncCameraGroup))]
public class PineConeCameraGroup : MonoBehaviour
{

  public Transform PlayerCharacter;
  public Transform[] PineCones;
  public Transform Dad;
  public ProgressFlag PineConesFlag;
  public float DistanceToShowPineCone = 35;
  private SyncCameraGroup syncCameraGroup;

  void Awake()
  {
    syncCameraGroup = GetComponent<SyncCameraGroup>();
  }

  // Update is called once per frame
  void Update()
  {
    var list = new List<Transform>();
    list.Add(PlayerCharacter);
    if (Progress.Instance.GetProgressFlagState(PineConesFlag) >= PineCones.Length)
    {
      list.Add(Dad);
    }
    else
    {
      foreach (var pineCone in PineCones)
      {
        if (pineCone &&
          (VectorMath.Flatten(pineCone.position) -
            VectorMath.Flatten(PlayerCharacter.position)).sqrMagnitude <
          DistanceToShowPineCone * DistanceToShowPineCone)
        {
          list.Add(pineCone);
        }
      }
    }

    syncCameraGroup.Targets = list.ToArray();
  }
}