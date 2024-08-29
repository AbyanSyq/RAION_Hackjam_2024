using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BGChange : MultiDimentionBase
{
    public SpriteRenderer spriteRenderer;
    public bool is2DBG;

    void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void To2D()
    {
        base.To2D();
        if (is2DBG)
        {
            Invoke("Delay",0.5f);
        }
        else
        {
            spriteRenderer.DOFade(0f, 0.1f); // Fade to invisible
        }
    }
    public void Delay(){
        spriteRenderer.DOFade(1f, 1f); // Fade to full visibility
    }


    public override void To3D()
    {
        base.To3D();
        if (is2DBG)
        {
            spriteRenderer.DOFade(0f, 1f); // Fade to invisible
        }
        else
        {
            spriteRenderer.DOFade(1f, 0.5f); // Fade to full visibility
        }
    }
}
