using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(SyncCameraGroup))]
public class RaspberriesCameraGroup : MonoBehaviour
{

  public Transform PlayerCharacter;
  public Transform[] Raspberries;
  public Transform Mom;
  public ProgressFlag TalkToMomFlag;
  public ProgressFlag RaspberriesFlag;
  public float DistanceToShowRaspberry = 35;
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
    if (Progress.Instance.GetProgressFlagState(TalkToMomFlag) == 0 ||
      Progress.Instance.GetProgressFlagState(RaspberriesFlag) >= Raspberries.Length)
    {
      list.Add(Mom);
    }
    else
    {
      foreach (var raspberries in Raspberries)
      {
        if (raspberries &&
          (VectorMath.Flatten(raspberries.position) -
            VectorMath.Flatten(PlayerCharacter.position)).sqrMagnitude <
          DistanceToShowRaspberry * DistanceToShowRaspberry)
        {
          list.Add(raspberries);
        }
      }
    }

    syncCameraGroup.Targets = list.ToArray();
  }
}