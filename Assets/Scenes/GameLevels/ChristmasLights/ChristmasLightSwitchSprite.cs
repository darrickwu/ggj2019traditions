using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChristmasLightSwitchSprite : MonoBehaviour
{
    public ProgressFlag MomTalkProgressFlag;
    public ProgressFlag ChristmasLightProgressFlag;

    public Sprite SwitchOnSprite;
    public Sprite SwitchOffSprite;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        SetSprite();
    }

    void Update()
    {
        SetSprite();
    }

    private void SetSprite()
    {
        bool switchOn = Progress.Instance.GetProgressFlagState(MomTalkProgressFlag) >= 1 &&
            Progress.Instance.GetProgressFlagState(ChristmasLightProgressFlag) == 0;
        spriteRenderer.sprite = switchOn ? SwitchOnSprite : SwitchOffSprite;
    }
}