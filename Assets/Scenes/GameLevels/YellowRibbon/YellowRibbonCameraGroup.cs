using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(SyncCameraGroup))]
public class YellowRibbonCameraGroup : MonoBehaviour
{

    public Transform PlayerCharacter;
    public Transform Dad;
    public Transform RibbonOnTable;
    public Transform Tree;
    public ProgressFlag DadTalkFlag;
    public ProgressFlag GotRibbonFlag;
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
        if (Progress.Instance.GetProgressFlagState(DadTalkFlag) == 0)
        {
            list.Add(Dad);
        }
        else if (Progress.Instance.GetProgressFlagState(GotRibbonFlag) == 0)
        {
            list.Add(RibbonOnTable);
        }
        else
        {
            list.Add(Tree);
        }

        syncCameraGroup.Targets = list.ToArray();
    }
}