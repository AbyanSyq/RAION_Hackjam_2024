using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParallaxBackground : MultiDimentionBase
{
    public ParallaxCamera[] parallaxCameras = new ParallaxCamera[2];
    [SerializeField] private ParallaxCamera parallaxCamera;
    List<ParallaxLayer> parallaxLayers = new List<ParallaxLayer>();

    void Start()
    {
        base.Start();
        SwitchCamera(parallaxCameras[0]);

        SetLayers();
    }

    public override void To2D()
    {
        base.To2D();
        SwitchCamera(parallaxCameras[0]);
    }

    public override void To3D()
    {
        base.To3D();
        SwitchCamera(parallaxCameras[1]);
    }

    void SwitchCamera(ParallaxCamera newCamera)
    {
        if (parallaxCamera != null)
        {
            parallaxCamera.onCameraTranslate -= Move;
        }

        parallaxCamera = newCamera;

        if (parallaxCamera != null)
        {
            parallaxCamera.onCameraTranslate += Move;
        }
    }

    void SetLayers()
    {
        parallaxLayers.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            ParallaxLayer layer = transform.GetChild(i).GetComponent<ParallaxLayer>();

            if (layer != null)
            {
                layer.name = "Layer-" + i;
                parallaxLayers.Add(layer);
            }
        }
    }

    void Move(float delta)
    {
        foreach (ParallaxLayer layer in parallaxLayers)
        {
            layer.Move(delta);
        }
    }
}
