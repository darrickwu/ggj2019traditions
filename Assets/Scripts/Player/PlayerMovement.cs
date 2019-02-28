using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    public SpriteRenderer SpriteRenderer;
    public Sprite walk1;
    public Sprite walk2;
    public Sprite idle;
    public float Speed;
    bool animating = false;
    public float animationSpeed = 0.3f;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (!SpriteRenderer)
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseState.Instance.CurrentState == PauseState.State.WALKING)
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");

            if (h != 0.0f || v != 0.0f)
            {
                if (!animating)
                {
                    StartCoroutine("animate", animationSpeed);
                    animating = true;
                }
            }
            else
            {
                SpriteRenderer.sprite = idle;
            }

            rigidbody2D.velocity = new Vector2(h, v) * Speed;
            if (rigidbody2D.velocity.x != 0.0f)
            {
                SpriteRenderer.flipX = rigidbody2D.velocity.x > 0;
            }
        }
        else
        {
            rigidbody2D.velocity = Vector2.zero;
        }
    }

    IEnumerator animate(float waitTime)
    {
        if (SpriteRenderer.sprite == walk1)
        {
            SpriteRenderer.sprite = walk2;
        }
        else
        {
            SpriteRenderer.sprite = walk1;
        }

        yield return new WaitForSeconds(waitTime);
        animating = false;
    }
}